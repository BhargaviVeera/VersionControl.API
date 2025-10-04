using Version190925.API.Models.Domain;
using Version190925.API.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Version190925.API.Repositories.Version190925
{
    public class RegionRepository : IExtendedRegionRepository
    {
        private readonly List<Region> _regions = new()
        {
            new Region { Id = 1, Name = "Auckland", Code = "AKL", Area = 5000, Lat = -36.8485, Long = 174.7633, Population = 1657000 },
            new Region { Id = 2, Name = "Wellington", Code = "WLG", Area = 2900, Lat = -41.2865, Long = 174.7762, Population = 215100 }
        };

        public IEnumerable<Region> GetAllRegions() => _regions;

        public Region GetRegionById(int id) => _regions.FirstOrDefault(r => r.Id == id);

        public Region GetRegionByCode(string code) => _regions.FirstOrDefault(r => r.Code == code);
    }
}
