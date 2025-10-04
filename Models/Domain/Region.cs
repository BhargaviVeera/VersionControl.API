// Versions/Models/Domain/Region.cs
using System;

namespace Versions.API.Models.Domain
{
    public class Region
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Code { get; set; }
        public required string Name { get; set; }
    }
}
