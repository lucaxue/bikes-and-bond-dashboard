using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Numerics;


[ApiController]
[Route("missions")]
public class MissionController : ControllerBase
{
    private readonly IRepository<Mission> _missionRepository;

    public MissionController(IRepository<Mission> missionRepository)
    {
        _missionRepository = missionRepository;
    }

    [HttpGet]
    public IEnumerable<Mission> GetAll(string search)
    {
        if (search != null){
                    return _missionRepository.Search(search);
        }

        return _missionRepository.GetAll();
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var mission = await _missionRepository.Get(id);
            return Ok(mission);
        }
        catch (Exception)
        {
            //handle exception
            return NotFound();
        }
    }


    // [HttpPost]
    // public async Task<IActionResult> Insert([FromBody] Mission mission)
    // {
    //     try
    //     {
    //         Console.WriteLine(ModelState.IsValid);
    //         var insertMission = await _missionRepository.Insert(new Mission { Mission = mission.Mission});
    //         return Ok(insertMission);

    //     }
    //     catch (Exception error)
    //     {
    //         Console.WriteLine(error.Message);
    //         Console.WriteLine(error.StackTrace);
    //         //handle exception
    //         return BadRequest();
    //     }
    // }

    //POTENTIAL STRETCH GOAL
    // [HttpPut("{id}")]
    // public async Task<IActionResult> Update(long id, [FromBody] Mission mission)
    // {
    //     try
    //     {
    //         var editMission = await _missionRepository.Update(new Mission { Id = id, Title = Mission.Title, Artist = Mission.Artist, MissionLengthCode = Mission.MissionLengthCode, Link = Mission.Link, SuggestedBy = Mission.SuggestedBy });
    //         return Ok(editMission);
    //     }
    //     catch (Exception error)
    //     {
    //         Console.WriteLine(error.Message);
    //         Console.WriteLine(error.StackTrace);
    //         //handle exception
    //         return NotFound("no mission updated");
    //     }
    // }
}