using System;
using Xunit;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;

namespace MissionApi.UnitTests
{
  public class MissionControllerTest
  {
    //fields
    readonly MissionController _controller;
    readonly List<Mission> _missions;
    readonly Mission _missionUpdate;
    readonly Mission _missionToInsert;
    readonly Mission _missionInserted;

    //constructor
    public MissionControllerTest()
    {
      //arrange
      _missions = new List<Mission> {
        new Mission
        {
          Id = 1,
          Name = "Panic in Paris",
          Location = "Paris",
          Difficulty = 3,
          Task = "Some task description",
          Villain = "Mr VanMoof"
        },
        new Mission
        {
          Id = 2,
          Name = "Brawl in Brussels",
          Location = "Brawl",
          Difficulty = 1,
          Task = "Some task description",
          Villain = "Master Kermit"
        },
        new Mission
        {
          Id = 3,
          Name = "Hijacking in Honolulu",
          Location = "Honolulu",
          Difficulty = 4,
          Task = "Some task description",
          Villain = "Dr Cervelo"
        },
      };

      _missionUpdate = new Mission
      {
        Id = 3,
        Name = "Hijacking in Honolulu",
        Location = "Honolulu",
        Difficulty = 4,
        Task = "Some updated task description",
        Villain = "Dr Cervelo"
      };

      _missionToInsert = new Mission
      {
        Name = "Problems in the Pacific",
        Location = "Northern Pacific",
        Difficulty = 5,
        Task = "Some task description",
        Villain = "unknown"
      };

      _missionInserted = new Mission
      {
        Id = 4,
        Name = "Problems in the Pacific",
        Location = "Northern Pacific",
        Difficulty = 5,
        Task = "Some task description",
        Villain = "unknown"
      };

      var missionRepository = new Mock<IRepository<Mission>>();

      missionRepository.Setup(r => r.GetAll().Result).Returns(_missions);
      missionRepository.Setup(r => r.Get(2).Result).Returns(_missions[1]);
      missionRepository.Setup(r => r.Search("", 100, 1).Result).Returns(_missions);
      missionRepository.Setup(r => r.Search("", 2, 1).Result).Returns(new List<Mission>() { _missions[0], _missions[1] });
      missionRepository.Setup(r => r.Search("", 2, 2).Result).Returns(new List<Mission>() { _missions[2] });
      missionRepository.Setup(r => r.Search("Brawl", 100, 1).Result).Returns(new List<Mission>() { _missions[1] });
      missionRepository.Setup(r => r.Update(_missionUpdate).Result).Returns(_missionUpdate);
      missionRepository.Setup(r => r.Insert(_missionToInsert).Result).Returns(_missionInserted);

      _controller = new MissionController(missionRepository.Object);
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
    public async Task GetAll_WhenCalledWithNothingPassedIn_ReturnsAllMissions()
    {
      //act
      var result = await _controller.GetAll();
      var missions = ((OkObjectResult)result).Value as List<Mission>;
      //assert
      missions.Should().BeEquivalentTo(_missions);
    }

    [Fact]
    public async Task GetAll_WhenCalledWithSearchQueryPassedIn_ReturnStatusCode200()
    {
      //act
      var result = await _controller.GetAll("Brawl");
      var statusCode = ((OkObjectResult)result).StatusCode;
      //assert
      statusCode.Should().Be(200);
    }

    [Fact]
    public async Task GetAll_WhenCalledWithSearchQueryPassedIn_ReturnsCorrectMissions()
    {
      //act
      var result = await _controller.GetAll("Brawl");
      var missions = ((OkObjectResult)result).Value as List<Mission>;
      //assert
      missions.Should().BeEquivalentTo(new List<Mission>() { _missions[1] });
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
    public async Task GetAll_WhenCalledWithLimitPassedIn_ReturnsCorrectLimitedMissions()
    {
      //act
      var result = await _controller.GetAll("", 2);
      var missions = ((OkObjectResult)result).Value as List<Mission>;
      //assert
      missions.Should().BeEquivalentTo(new List<Mission>() { _missions[0], _missions[1] });
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
    public async Task GetAll_WhenCalledWithLimitAndPagePassedIn_ReturnsCorrectPageOfLimitedMissions()
    {
      //act
      var result = await _controller.GetAll("", 2, 2);
      var missions = ((OkObjectResult)result).Value as List<Mission>;
      //assert
      missions.Should().BeEquivalentTo(new List<Mission>() { _missions[2] });
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
    public async Task Get_WhenCalledWithIdPassedIn_ReturnsCorrectMission()
    {
      //act
      var result = await _controller.Get(2);
      var mission = ((OkObjectResult)result).Value as Mission;
      //assert
      mission.Should().BeEquivalentTo(_missions[1]);
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
    public async Task Update_WhenCalledWithIdAndMissionToUpdate_ReturnStatusCode200()
    {
      //act
      var result = await _controller.Update(3, _missionUpdate);
      var statusCode = ((OkObjectResult)result).StatusCode;
      //assert
      statusCode.Should().Be(200);
    }

    [Fact]
    public async Task Update_WhenCalledWithIdAndMissionToUpdate_ReturnsUpdatedMission()
    {
      //act
      var result = await _controller.Update(3, _missionUpdate);
      var updatedMission = ((OkObjectResult)result).Value as Mission;
      //assert
      updatedMission.Should().BeEquivalentTo(_missionUpdate);
    }

    [Fact]
    public async Task Insert_WhenCalledWithMissionToInsert_ReturnStatusCode201()
    {
      //act
      var result = await _controller.Insert(_missionToInsert);
      var statusCode = ((ObjectResult)result).StatusCode;
      //assert
      statusCode.Should().Be(201);
    }

    [Fact]
    public async Task Insert_WhenCalledWithMissionToInsert_ReturnsMissionInserted()
    {
      //act
      var result = await _controller.Insert(_missionToInsert);
      var insertedMission = ((ObjectResult)result).Value as Mission;
      //assert
      insertedMission.Should().BeEquivalentTo(_missionInserted);
    }
  }
}
