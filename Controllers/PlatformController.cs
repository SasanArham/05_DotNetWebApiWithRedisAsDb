using Microsoft.AspNetCore.Mvc;
using RediAPI.Data;
using RediAPI.Models;

namespace RediAPI.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformRepo _repo;

        public PlatformController(IPlatformRepo repo)
        {
            _repo = repo;
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> Post(Platform plat)
        {
            var created = await _repo.createPlatform(plat);
            if (plat == null)
            {
                return BadRequest();
            }
            return Ok(created);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetById(string Id)
        {
            var plat = await _repo.GetById(Id) ;
            return Ok(plat) ;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var plats = await _repo.GetAll() ;
            return Ok(plats) ;
        }

    }
}