namespace StempelAppCore.Models.Requests.User
{
    public class UserGetRequest : BaseRequest
    {
        public int? UserId { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? LastActivityDate { get; set; }
        public int? ProjectId { get; set; }
        public int? AssignmentId { get; set; }
        public int? LocationId { get; set; }
        public string? LocationName { get; set; }
        public string? City { get; set; }
    }
}