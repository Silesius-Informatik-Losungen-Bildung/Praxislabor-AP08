using StempelAppCore.Models.Domain;

namespace StempelAppCore.Models.Responses.Assignment
{
    public class AssignmentListResponse : BaseResponse
    {
        public List<UserAssignment?> Assignments { get; set; }
    }
}