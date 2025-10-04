using Version210926.API.Models.Domain;

namespace Version210926.API.Repositories.Interfaces
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllAsync();
        Task<Region> GetAsync(Guid id);
        Task<Region> AddAsync(Region region);
        Task<Region> UpdateAsync(Guid id, Region region);
        Task DeleteAsync(Guid id);
    }
}
