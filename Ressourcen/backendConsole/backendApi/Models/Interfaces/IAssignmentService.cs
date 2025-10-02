namespace StempelAppCore.Models.Interfaces
{
    public interface IAssignmentService
    {
        Task<Assignment> CreateNewAssignmentAsync();
        Task<Assignment> GetAssignmentAsync();
        Task<IEnumerable<Assignment>> GetAssignmentsAsync();
        Task<Assignment> UpdateAssignmentAsync();
        Task<Assignment> DeleteAssignmentAsync();
    }
}