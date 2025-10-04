using Microsoft.AspNetCore.Mvc;
using Version210926.API.Models.Domain;
using Version210926.API.Repositories.Version210926; // make sure namespace matches
using Version210926.API.Repositories.Interfaces;

namespace Version210926.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;

        public RegionsController()
        {
            _regionRepository = new RegionRepository();
        }

        [HttpGet]
        public async Task<IEnumerable<Region>> Get()
        {
            return await _regionRepository.GetAllAsync();
        }
    }
}
