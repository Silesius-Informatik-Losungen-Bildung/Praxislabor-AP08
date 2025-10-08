namespace StempelAppCore.Models.Domain
{
    public partial class Country : BaseEntity
    {
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
    }
}