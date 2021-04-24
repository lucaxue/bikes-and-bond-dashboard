using System;
using Xunit;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;

namespace BikeApi.UnitTests
{
  public class BikeControllerTest
  {
    //fields
    readonly BikeController _controller;
    readonly List<Bike> _bikes;
    readonly Bike _bikeUpdate;
    readonly Bike _bikeToInsert;
    readonly Bike _bikeInserted;

    //constructor
    public BikeControllerTest()
    {
      //arrange
      _bikes = new List<Bike> {
        new Bike
        {
          Id = 1,
          Genre = "Unicycle",
          Author = "Mr Trek",
          Color = "Red",
          Title = "Red-Roller"
        },
        new Bike
        {
          Id = 2,
          Genre = "Penny Farthing",
          Author = "Ms Raleigh",
          Color = "Black",
          Title = "Tally Ho"
        },
        new Bike
        {
          Id = 3,
          Genre = "BMX",
          Author = "Miss Bianchi",
          Color = "Purple",
          Title = "Cool Goose"
        },
      };

      _bikeUpdate = new Bike
      {
        Id = 3,
        Genre = "BMX",
        Author = "Miss Bianchi",
        Color = "Blue",
        Title = "Cool Goose"
      };

      _bikeToInsert = new Bike
      {
        Genre = "Electric",
        Author = "Mr VanMoof",
        Color = "Yellow with racing stripes",
        Title = "The Green Alternative"
      };

      _bikeInserted = new Bike
      {
        Id = 4,
        Genre = "Electric",
        Author = "Mr VanMoof",
        Color = "Yellow with racing stripes",
        Title = "The Green Alternative"
      };

      var bikeRepository = new Mock<IRepository<Bike>>();

      bikeRepository.Setup(r => r.GetAll().Result).Returns(_bikes);
      bikeRepository.Setup(r => r.Get(2).Result).Returns(_bikes[1]);
      bikeRepository.Setup(r => r.Search("", 100, 1).Result).Returns(_bikes);
      bikeRepository.Setup(r => r.Search("", 2, 1).Result).Returns(new List<Bike>() { _bikes[0], _bikes[1] });
      bikeRepository.Setup(r => r.Search("", 2, 2).Result).Returns(new List<Bike>() { _bikes[2] });
      bikeRepository.Setup(r => r.Search("Penny", 100, 1).Result).Returns(new List<Bike>() { _bikes[1] });
      bikeRepository.Setup(r => r.Update(_bikeUpdate).Result).Returns(_bikeUpdate);
      bikeRepository.Setup(r => r.Insert(_bikeToInsert).Result).Returns(_bikeInserted);

      _controller = new BikeController(bikeRepository.Object);
    }

    [Fact]
    public async Task GetAll_WhenCalledWithNothingPassedIn_ReturnStatusCode200()
    {
      //act
      var result = await _controller.GetAll();
      var statusCode = ((OkObjectResult)result).StatusCode;
      //assert
      statusCode.Should().Be(200);
    }

    [Fact]
    public async Task GetAll_WhenCalledWithNothingPassedIn_ReturnsAllBikes()
    {
      //act
      var result = await _controller.GetAll();
      var bikes = ((OkObjectResult)result).Value as List<Bike>;
      //assert
      bikes.Should().BeEquivalentTo(_bikes);
    }

    [Fact]
    public async Task GetAll_WhenCalledWithSearchQueryPassedIn_ReturnStatusCode200()
    {
      //act
      var result = await _controller.GetAll("Penny");
      var statusCode = ((OkObjectResult)result).StatusCode;
      //assert
      statusCode.Should().Be(200);
    }

    [Fact]
    public async Task GetAll_WhenCalledWithSearchQueryPassedIn_ReturnsCorrectBikes()
    {
      //act
      var result = await _controller.GetAll("Penny");
      var bikes = ((OkObjectResult)result).Value as List<Bike>;
      //assert
      bikes.Should().BeEquivalentTo(new List<Bike>() { _bikes[1] });
    }

    [Fact]
    public async Task GetAll_WhenCalledWithLimitPassedIn_ReturnsStatusCode200()
    {
      //act
      var result = await _controller.GetAll("", 2);
      var statusCode = ((OkObjectResult)result).StatusCode;
      //assert
      statusCode.Should().Be(200);
    }

    [Fact]
    public async Task GetAll_WhenCalledWithLimitPassedIn_ReturnsCorrectLimitedBikes()
    {
      //act
      var result = await _controller.GetAll("", 2);
      var bikes = ((OkObjectResult)result).Value as List<Bike>;
      //assert
      bikes.Should().BeEquivalentTo(new List<Bike>() { _bikes[0], _bikes[1] });
    }

    [Fact]
    public async Task GetAll_WhenCalledWithLimitAndPagePassedIn_ReturnsStatusCode200()
    {
      //act
      var result = await _controller.GetAll("", 2, 2);
      var statusCode = ((OkObjectResult)result).StatusCode;
      //assert
      statusCode.Should().Be(200);
    }

    [Fact]
    public async Task GetAll_WhenCalledWithLimitAndPagePassedIn_ReturnsCorrectPageOfLimitedBikes()
    {
      //act
      var result = await _controller.GetAll("", 2, 2);
      var bikes = ((OkObjectResult)result).Value as List<Bike>;
      //assert
      bikes.Should().BeEquivalentTo(new List<Bike>() { _bikes[2] });
    }

    [Fact]
    public async Task Get_WhenCalledWithIdPassedIn_ReturnsStatusCode200()
    {
      //act
      var result = await _controller.Get(2);
      var statusCode = ((OkObjectResult)result).StatusCode;
      //assert
      statusCode.Should().Be(200);
    }

    [Fact]
    public async Task Get_WhenCalledWithIdPassedIn_ReturnsCorrectBike()
    {
      //act
      var result = await _controller.Get(2);
      var bike = ((OkObjectResult)result).Value as Bike;
      //assert
      bike.Should().BeEquivalentTo(_bikes[1]);
    }

    [Fact]
    public void Delete_WhenCalledWithId_ReturnStatusCode200()
    {
      //act
      var statusCode = ((OkResult)_controller.Delete(2)).StatusCode;
      //assert
      statusCode.Should().Be(200);
    }

    [Fact]
    public async Task Update_WhenCalledWithIdAndBikeToUpdate_ReturnStatusCode200()
    {
      //act
      var result = await _controller.Update(3, _bikeUpdate);
      var statusCode = ((OkObjectResult)result).StatusCode;
      //assert
      statusCode.Should().Be(200);
    }

    [Fact]
    public async Task Update_WhenCalledWithIdAndBikeToUpdate_ReturnsUpdatedBike()
    {
      //act
      var result = await _controller.Update(3, _bikeUpdate);
      var updatedBike = ((OkObjectResult)result).Value as Bike;
      //assert
      updatedBike.Should().BeEquivalentTo(_bikeUpdate);
    }

    [Fact]
    public async Task Insert_WhenCalledWithBikeToInsert_ReturnStatusCode201()
    {
      //act
      var result = await _controller.Insert(_bikeToInsert);
      var statusCode = ((ObjectResult)result).StatusCode;
      //assert
      statusCode.Should().Be(201);
    }

    [Fact]
    public async Task Insert_WhenCalledWithBikeToInsert_ReturnsBikeInserted()
    {
      //act
      var result = await _controller.Insert(_bikeToInsert);
      var insertedBike = ((ObjectResult)result).Value as Bike;
      //assert
      insertedBike.Should().BeEquivalentTo(_bikeInserted);
    }
  }
}
