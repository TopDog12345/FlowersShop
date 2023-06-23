using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Slobodianiuk.University.Example.Models.Database;
using Slobodianiuk.University.Example.Models.Weather;
using Slobodianuik.University.Example.Database.Interfaces;

namespace Slobodianiuk.University.Example.Web.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class FlowersController : ControllerBase
    {
        private readonly IDbEntityService<Flower> _flowerService;
        public FlowersController(IDbEntityService<Flower> flowerService)
        {
            _flowerService = flowerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            List<Flower> cars = await _flowerService.GetAll().ToListAsync();

            return Ok(cars);
        }
    }
}
