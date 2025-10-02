namespace StempelAppCore.Models
{
    public partial class Address : BaseEntity
    {
        public string StreetHouseNr { get; set; }
        public string City { get; set; }
        public Country Country { get; set; }
    }
}