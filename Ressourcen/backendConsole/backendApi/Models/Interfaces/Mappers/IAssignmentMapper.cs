using StempelAppCore.Models.Domain;
using StempelAppCore.Models.Requests.Assignment;
using StempelAppCore.Models.Responses.Assignment;

namespace StempelAppCore.Models.Interfaces.Mappers
{
    public interface IAssignmentMapper
    {
        AssignmentCreateResponse ToCreateResponse(UserAssignment assignment);
        AssignmentGetResponse ToGetResponse(UserAssignment? assignment);
        AssignmentListResponse ToListResponse(IEnumerable<UserAssignment?> assignments, AssignmentListRequest request);
        AssignmentUpdateResponse ToUpdateResponse(UserAssignment assignment);
    }
}