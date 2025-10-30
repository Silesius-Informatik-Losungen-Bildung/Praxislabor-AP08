using Microsoft.Extensions.Logging;
using StempelAppCore.Models.Domain;
using StempelAppCore.Models.Interfaces;
using StempelAppCore.Models.Interfaces.Mappers;
using StempelAppCore.Models.Requests.Assignment;
using StempelAppCore.Models.Responses.Assignment;
using StempelAppLib.Exceptions.MapperExceptions;

namespace StempelAppLib.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentMapper _mapper;
        private readonly ILogger<AssignmentService> _logger;
        private readonly IRepository<UserAssignment> _repository;

        public AssignmentService(IAssignmentMapper mapper,
            ILogger<AssignmentService> logger,
            IRepository<UserAssignment> repository)
        {
            _mapper = mapper;
            _logger = logger;
            _repository = repository;
        }

        public async Task<AssignmentCreateResponse> CreateNewAssignmentAsync(AssignmentCreateRequest request)
        {
            var response = new AssignmentCreateResponse();
            try
            {
                var assignment = _mapper.MapFromCreateToAssignment(request);
                await _repository.AddAsync(assignment);
                await _repository.SaveChangesAsync();

                response.CreatedAssignmentId = assignment.Id;

                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.Message = ex switch
                {
                    AssignmentMapperException => $"",
                    _ => $"Unexpected error."
                };
                response.IsSuccess = false;
            }

            return response;
        }


        public Task<AssignmentGetResponse> GetAssignmentAsync(AssignmentGetRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<AssignmentListResponse> GetAssignmentsAsync(AssignmentListRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<AssignmentUpdateResponse> UpdateAssignmentAsync(AssignmentUpdateRequest request)
        {
            throw new NotImplementedException();
        }
        public Task<AssignmentDeleteResponse> DeleteAssignmentAsync(AssignmentDeleteRequest request)
        {
            throw new NotImplementedException();
        }
    }
}