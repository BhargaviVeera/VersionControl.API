// Versions/Repositories/Interfaces/IRegionRepository.cs
using System;
using System.Collections.Generic;
using Versions.API.Models.Domain;

namespace Versions.API.Repositories.Interfaces
{
    public interface IRegionRepository
    {
        IEnumerable<Region> GetAll();
        Region? GetById(Guid id);
        void Create(Region region);
        void Update(Guid id, Region region);
        void Delete(Guid id);
    }
}
