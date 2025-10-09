namespace StempelAppCore.Models.Requests.User
{
    public class UserListRequest : BaseRequest
    {
        public List<int?> UserIds { get; set; }
        public List<string?> Emails { get; set; }
        public List<string?> Usernames { get; set; }
        public List<string?> FirstNames { get; set; }
        public List<string?> LastNames { get; set; }
        public List<DateTime?> CreationDates { get; set; }
        public List<DateTime?> LastLoginDates { get; set; }
        public List<DateTime?> LastActivityDates { get; set; }
        public List<int?> ProjectIds { get; set; }
        public List<int?> AssignmentIds { get; set; }
        public List<int?> LocationIds { get; set; }
        public List<string?> LocationNames { get; set; }
        public List<string?> Cities { get; set; }
    }
}