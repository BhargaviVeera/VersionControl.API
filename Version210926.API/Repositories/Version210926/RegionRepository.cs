using Version210926.API.Models.Domain;
using Version210926.API.Repositories.Interfaces;

namespace Version210926.API.Repositories.Version210926
{
    public class RegionRepository : IRegionRepository
    {
        private readonly List<Region> regions = new();

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await Task.FromResult(regions);
        }

        public async Task<Region> GetAsync(Guid id)
        {
            var region = regions.FirstOrDefault(r => r.Id == id);
            return await Task.FromResult(region);
        }

        public async Task<Region> AddAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            regions.Add(region);
            return await Task.FromResult(region);
        }

        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
            var existing = regions.FirstOrDefault(r => r.Id == id);
            if (existing != null)
            {
                existing.Name = region.Name;
                existing.Code = region.Code;
                existing.Area = region.Area;
                existing.Latitude = region.Latitude;
                existing.Longitude = region.Longitude;
                existing.Population = region.Population;
            }
            return await Task.FromResult(existing);
        }

        public async Task DeleteAsync(Guid id)
        {
            var region = regions.FirstOrDefault(r => r.Id == id);
            if (region != null) regions.Remove(region);
            await Task.CompletedTask;
        }
    }
}
