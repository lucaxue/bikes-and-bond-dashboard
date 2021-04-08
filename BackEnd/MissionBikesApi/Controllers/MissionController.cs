using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


[ApiController]
[Route("[controller]s")]
public class MissionController : ControllerBase
{
  private readonly IRepository<Mission> _missionRepository;

  public MissionController(IRepository<Mission> missionRepository)
  {
    _missionRepository = missionRepository;
  }

  [HttpGet]
  public async Task<IActionResult> GetAll(string search = "", int limit = 100, int page = 1)
  {
    try
    {
      var missionsResult = await _missionRepository.Search(search, limit, page);
      return Ok(missionsResult);
    }
    catch (Exception)
    {
      if (limit < 0 || page <= 0)
      {
        return BadRequest($"Sorry, the {(page <= 0 ? "page" : "limit")} entered is not valid.\nTry entering a positive number.");
      }
      return NotFound("Sorry, could not get any missions from the repository.\nPlease try another request.");
    }
  }


  [HttpGet("{id}")]
  public async Task<IActionResult> Get(long id)
  {
    try
    {
      var returnedMission = await _missionRepository.Get(id);
      return Ok(returnedMission);
    }
    catch (Exception)
    {
      return NotFound($"Sorry, mission of id {id} cannot be fetched, since it does not exist.\nAre you sure the id is correct?");
    }
  }

  [HttpDelete("{id}")]
  public IActionResult Delete(long id)
  {
    try
    {
      _missionRepository.Delete(id);
      return Ok();
    }
    catch (Exception)
    {
      return BadRequest($"Sorry, mission of id {id} cannot be deleted, since it does not exit.\nAre you sure the id is correct?");
    }
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Update(long id, [FromBody] Mission mission)
  {
    try
    {
      mission.Id = id;
      var updatedMission = await _missionRepository.Update(mission);
      return Ok(updatedMission);
    }
    catch (Exception)
    {
      return BadRequest($"Sorry, mission of id {id} cannot be updated, since it does not exist.\nAre you sure the id is correct?");
    }
  }

  [HttpPost]
  public async Task<IActionResult> Insert([FromBody] Mission mission)
  {
    try
    {
      var insertedMission = await _missionRepository.Insert(mission);
      return Created($"/missions/{insertedMission.Id}", insertedMission);
    }
    catch (Exception)
    {
      return BadRequest($"Sorry, cannot insert new mission.\nAre you sure the mission is valid?");
    }
  }
}
