using Version190925.API.Models.Domain;
using System.Collections.Generic;

namespace Version190925.API.Repositories.Interfaces
{
    public interface IRegionRepository
    {
        IEnumerable<Region> GetAllRegions();
        Region GetRegionById(int id);
    }

    public interface IExtendedRegionRepository : IRegionRepository
    {
        Region GetRegionByCode(string code);
    }
}
