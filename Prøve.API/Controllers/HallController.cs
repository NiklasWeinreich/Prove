using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prøve.Repository.Interfaces;
using Prøve.Repository.Models;

namespace Prøve.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HallController : ControllerBase
    {

        public IHallRepository _iHallrepository { get; set; }

        public HallController(IHallRepository iHallrepository)
        {
            _iHallrepository = iHallrepository;
        }


        [HttpGet("All")] 
        public async Task<Hall> readSeatsInHall(int hallId)
        {
            return await _iHallrepository.readSeatsInHall(hallId);
        }

        [HttpPost("create")]
        public async Task create(int rowCount, int colCount)
        {
             await _iHallrepository.create(rowCount, colCount);
            
        }

        [HttpDelete("id")]
        public async Task delete(bool choice)
        {
            await _iHallrepository.delete(choice);

        }

        [HttpGet("reservedAll")]
        public async Task<List<Reserved>> readReservedSeats()
        {
          return await _iHallrepository.readReservedSeats();
        }

    }
}
