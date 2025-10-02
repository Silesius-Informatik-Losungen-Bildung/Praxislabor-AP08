using StempelAppCore.Models.Requests;
using StempelAppCore.Models.Responses;

namespace StempelAppCore.Models.Interfaces.Mappers
{
    public interface IAssignmentMapper : IBaseMapper
    {
        AssignmentCreateResponse ToCreateResponse(Assignment assignment);
        AssignmentGetResponse ToGetResponse(Assignment assignment);
        AssignmentListResponse ToListResponse(IEnumerable<Assignment> assignment, AssignmentListRequest request);
        AssignmentUpdateResponse ToUpdateResponse(Assignment assignment);
    }
}