namespace StempelAppCore.Models
{
    public partial class Address : BaseEntity
    {
        public string StreetHouseNr { get; set; } = null!;
        public string City { get; set; } = null!;
        public Country Country { get; set; } = null!;
    }
}