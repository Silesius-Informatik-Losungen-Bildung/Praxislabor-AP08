namespace StempelAppCore.Models.Requests.User
{
    public class UserUpdateRequest : BaseRequest
    {
        public string? UpdatedUsername { get; set; }
        public string? UpdatedEmail { get; set; }
        public string? UpdatedPasswordHash { get; set; }
        public string? UpdatedFirstName { get; set; }
        public string? UpdatedLastName { get; set; }
        public string? UpdatedPhoneNumber { get; set; }
        public int? UpdatedProjectId { get; set; }
        public int? UpdatedAssignmentId { get; set; }
    }
}