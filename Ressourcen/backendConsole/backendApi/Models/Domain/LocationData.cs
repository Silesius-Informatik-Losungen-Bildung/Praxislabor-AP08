namespace StempelAppCore.Models.Domain
{
    public class LocationData : BaseEntity
    {
        public string LocationName { get; set; }
        public double GPSLongitude { get; set; }
        public double GPSLatitude { get; set; }
    }
}