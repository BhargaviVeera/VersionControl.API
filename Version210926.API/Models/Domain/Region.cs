namespace Version210926.API.Models.Domain
{
    public class Region
    {
        public Guid Id { get; set; }
        public string Code { get; set; }  // e.g., "NTL"
        public string Name { get; set; }
        public double Area { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Population { get; set; }
    }
}
