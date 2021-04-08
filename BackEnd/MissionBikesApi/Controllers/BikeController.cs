using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


[ApiController]
[Route("[controller]s")]
public class BikeController : ControllerBase
{
  private readonly IRepository<Bike> _bikeRepository;

  public BikeController(IRepository<Bike> bikeRepository)
  {
    _bikeRepository = bikeRepository;
  }

  [HttpGet]
  public async Task<IActionResult> GetAll(string search = "", int limit = 100, int page = 1)
  {
    try
    {
      var bikesResult = await _bikeRepository.Search(search, limit, page);
      return Ok(bikesResult);
    }
    catch (Exception)
    {
      if (limit < 0 || page <= 0)
      {
        return BadRequest($"Sorry, the {(page <= 0 ? "page" : "limit")} entered is not valid.\nTry entering a positive number.");
      }
      return NotFound("Sorry, could not get any bikes from the repository.\nPlease try another request.");
    }
  }


  [HttpGet("{id}")]
  public async Task<IActionResult> Get(long id)
  {
    try
    {
      var returnedBike = await _bikeRepository.Get(id);
      return Ok(returnedBike);
    }
    catch (Exception)
    {
      return NotFound($"Sorry, bike of id {id} cannot be fetched, since it does not exist.\nAre you sure the id is correct?");
    }
  }

  [HttpDelete("{id}")]
  public IActionResult Delete(long id)
  {
    try
    {
      _bikeRepository.Delete(id);
      return Ok();
    }
    catch (Exception)
    {
      return BadRequest($"Sorry, bike of id {id} cannot be deleted, since it does not exit.\nAre you sure the id is correct?");
    }
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Update(long id, [FromBody] Bike bike)
  {
    try
    {
      bike.Id = id;
      var updatedBike = await _bikeRepository.Update(bike);
      return Ok(updatedBike);
    }
    catch (Exception)
    {
      return BadRequest($"Sorry, bike of id {id} cannot be updated, since it does not exist.\nAre you sure the id is correct?");
    }
  }

  [HttpPost]
  public async Task<IActionResult> Insert([FromBody] Bike bike)
  {
    try
    {
      var insertedBike = await _bikeRepository.Insert(bike);
      return Created($"/bikes/{insertedBike.Id}", insertedBike);
    }
    catch (Exception)
    {
      return BadRequest($"Sorry, cannot insert new bike.\nAre you sure the bike is valid?");
    }
  }
}
