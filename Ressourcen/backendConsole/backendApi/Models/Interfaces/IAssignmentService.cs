using StempelAppCore.Models.Domain;
using StempelAppCore.Models.Requests.Assignment;
using StempelAppCore.Models.Responses.Assignment;

namespace StempelAppCore.Models.Interfaces
{
    public interface IAssignmentService
    {
        Task<AssignmentCreateResponse> CreateNewAssignmentAsync(AssignmentCreateRequest request);
        Task<AssignmentGetResponse> GetAssignmentAsync(AssignmentGetRequest request);
        Task<AssignmentListResponse> GetAssignmentsAsync(AssignmentListRequest request);
        Task<AssignmentUpdateResponse> UpdateAssignmentAsync(AssignmentUpdateRequest request);
        Task<AssignmentDeleteResponse> DeleteAssignmentAsync(AssignmentDeleteRequest request);
    }
}