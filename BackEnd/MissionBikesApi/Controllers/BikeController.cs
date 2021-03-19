using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Numerics;


[ApiController]
[Route("bikes")]
public class BikeController : ControllerBase
{
    private readonly IRepository<Bike> _bikeRepository;

    public BikeController(IRepository<Bike> bikeRepository)
    {
        _bikeRepository = bikeRepository;
    }

    [HttpGet] 
    public IEnumerable<Bike> GetAll()
    {
        return _bikeRepository.GetAll();
    }

    [HttpGet("{rand}")] //reccomeneded 
    public async Task<IActionResult> Get(int rand) //bike id   - can we randomise in SQL 
    {
        try
        {
            var bike = await _bikeRepository.Get(rand);
            return Ok(bike);
        }
        catch (Exception)
        {
            //handle exception
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<IActionResult> Insert([FromBody] Bike bike)
    {
        try
        {
            Console.WriteLine(ModelState.IsValid);
            var insertBike = await _bikeRepository.Insert(new Bike { Bike = bike.Bike });
            return Ok(insertBike);

        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message);
            Console.WriteLine(error.StackTrace);
            //handle exception
            return BadRequest();
        }
    }

    //POTENTIAL STRETCH GOAL//
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] Bike bike)
    {
        try
        {
            var editBike = await _bikeRepository.Update(new Bike { Bike = bike.Bike });
            return Ok(editBike);
        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message);
            Console.WriteLine(error.StackTrace);
            //handle exception
            return NotFound("no bike updated");
        }
    }
}