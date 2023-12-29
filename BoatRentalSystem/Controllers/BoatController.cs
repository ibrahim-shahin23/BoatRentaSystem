using BoatRentalSystem.Services.BoatServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoatRentalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoatController : ControllerBase
    {
        private readonly IBoatService _boatService;
        public BoatController(IBoatService boatService)
        {
          _boatService = boatService ;   
        }
        [HttpGet]
        public async Task<ActionResult<List<Boat>>> GetAllBoats() 
        {
            return await _boatService.GetAllBoats();
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Boat>> GetSingleBoat(int id)
        {
            var result = await _boatService.GetSingleBoat(id);
            if (result == null)
                return NotFound($"boat with id {id} doesn't exist");
            return Ok(result);
            
        }
        [HttpPost]
        public async Task<ActionResult<List<Boat>>> AddBoat(Boat boat)
        {
            var result = await _boatService.AddBoat(boat);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Boat>>> UpdateBoat(int id, Boat request)
        {
            var result = await _boatService.UpdateBoat(id, request);
            if (result == null)
                return NotFound($"boat with id {id} doesn't exist");
            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Boat>>> DeleteBoat(int id)
        {   
            var result = await _boatService.DeleteBoat(id);
            if (result == null)
                return NotFound($"boat with id {id} doesn't exist");
            return Ok(result);
        }


    }

}
