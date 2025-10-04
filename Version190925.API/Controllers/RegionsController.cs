using Microsoft.AspNetCore.Mvc;
using System;
using Versions.API.Models.Domain;             // ✅ use shared model
using Versions.API.Repositories.Interfaces;

namespace Version190925.API.Controllers
{
    [ApiController]
    [Route("api/v190925/[controller]")]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository _repository;

        public RegionsController(IRegionRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_repository.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id) => Ok(_repository.GetById(id));

        [HttpPost]
        public IActionResult Create([FromBody] Region region)
        {
            _repository.Create(region);
            return CreatedAtAction(nameof(GetById), new { id = region.Id }, region);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] Region region)
        {
            _repository.Update(id, region);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _repository.Delete(id);
            return NoContent();
        }
    }
}
