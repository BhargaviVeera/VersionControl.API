namespace Version190925.API.Models.Domain
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public double Area { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public int Population { get; set; }
    }
}
