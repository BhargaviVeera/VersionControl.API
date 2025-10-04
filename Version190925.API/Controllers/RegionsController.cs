using Microsoft.AspNetCore.Mvc;
using Version190925.API.Models.Domain;
using Version190925.API.Repositories.Interfaces;

namespace Version190925.API.Controllers
{
    [ApiController]
    [Route("api/v190925/[controller]")]
    public class RegionsController : ControllerBase
    {
        private readonly IExtendedRegionRepository _regionRepository;

        public RegionsController(IExtendedRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_regionRepository.GetAllRegions());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var region = _regionRepository.GetRegionById(id);
            if (region == null) return NotFound();
            return Ok(region);
        }

        [HttpGet("code/{code}")]
        public IActionResult GetByCode(string code)
        {
            var region = _regionRepository.GetRegionByCode(code);
            if (region == null) return NotFound();
            return Ok(region);
        }
    }
}
