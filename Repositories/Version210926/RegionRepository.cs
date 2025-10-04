using System;
using System.Collections.Generic;
using System.Linq;
using Versions.API.Models.Domain;
using Versions.API.Repositories.Interfaces;

namespace Versions.API.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly List<Region> _regions = new();

        public IEnumerable<Region> GetAll() => _regions;

        public Region? GetById(Guid id) => _regions.FirstOrDefault(r => r.Id == id);

        public void Create(Region region) => _regions.Add(region);

        public void Update(Guid id, Region region)
        {
            var existing = GetById(id);
            if (existing != null)
            {
                existing.Code = region.Code;
                existing.Name = region.Name;
            }
        }

        public void Delete(Guid id)
        {
            var region = GetById(id);
            if (region != null) _regions.Remove(region);
        }
    }
}
