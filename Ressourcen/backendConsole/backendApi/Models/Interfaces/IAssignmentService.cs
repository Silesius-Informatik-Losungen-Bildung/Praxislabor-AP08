using StempelAppCore.Models.Domain;

namespace StempelAppCore.Models.Interfaces
{
    public interface IAssignmentService
    {
        Task<UserAssignment> CreateNewAssignmentAsync();
        Task<UserAssignment> GetAssignmentAsync();
        Task<IEnumerable<UserAssignment>> GetAssignmentsAsync();
        Task<UserAssignment> UpdateAssignmentAsync();
        Task<UserAssignment> DeleteAssignmentAsync();
    }
}