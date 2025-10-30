using StempelAppCore.Models.Domain;
using StempelAppCore.Models.Interfaces.Mappers;
using StempelAppCore.Models.Requests.Assignment;
using StempelAppCore.Models.Responses.Assignment;
using StempelAppLib.Exceptions.MapperExceptions;

namespace StempelAppLib.Logic.Mapper.QueryAndResponseMappers
{
    public class AssignmentMapper : IAssignmentMapper
    {
        public UserAssignment MapFromCreateToAssignment(AssignmentCreateRequest request)
        {
            var assignment = new UserAssignment()
            {
                AssignmentTimeStamp = request.TimeStamp,
                Comment = request.Comment,
                EndTime = request.EndTime,
                PictureRequired = request.PictureRequired,
                StartTime = request.StartTime,
                LocationId = request.LocationId,
                UserId = request.UserId,
            };
            return assignment;
        }

        public UserAssignment MapFromDeleteToAssignment(AssignmentDeleteRequest request)
        {
            var assignment = new UserAssignment()
            {
                Id = request.AssignmentId,
            };
            return assignment;
        }

        public UserAssignment MapFromUpdateToAssignment(AssignmentUpdateRequest request)
        {

            var assignment = new UserAssignment();
            if (request.NewUserId != null) assignment.UserId = (int)request.NewUserId;
            if (request.NewComment != null) assignment.Comment = request.NewComment;
            if (request.NewLocationId != null) assignment.LocationId = (int)request.NewLocationId;
            if (request.NewTimeStamp != null) assignment.AssignmentTimeStamp = request.NewTimeStamp;
            if (request.NewStartTime != null) assignment.StartTime = request.NewStartTime;
            if (request.NewEndTime != null) assignment.EndTime = request.NewEndTime;
            if (request.PictureId != null) assignment.PictureId = request.PictureId;

            return assignment;
        }

        public AssignmentCreateResponse ToCreateResponse(UserAssignment assignment)
        {
            if (assignment == null) throw new AssignmentMapperException($"Mapping failed. Assignment null.");
            var response = new AssignmentCreateResponse();

            if (assignment.Comment != null) response.Comment = assignment.Comment;
            if (assignment.AssignmentTimeStamp != null) response.TimeStamp = assignment.AssignmentTimeStamp;
            if (assignment.StartTime != null) response.StartTime = assignment.StartTime;
            if (assignment.EndTime != null) response.EndTime = assignment.EndTime;

            return response;
        }

        public AssignmentGetResponse ToGetResponse(UserAssignment? assignment)
        {
            if (assignment == null) throw new AssignmentMapperException($"Mapping failed. Assignment null.");
            var response = new AssignmentGetResponse();

            if (assignment.Comment != null) response.Comment = assignment.Comment;
            if (assignment.Picture != null) response.Picture = assignment.Picture;
            if (assignment.AssignmentTimeStamp != null) response.TimeStamp = assignment.AssignmentTimeStamp;
            if (assignment.StartTime != null) response.StartTime = assignment.StartTime;
            if (assignment.EndTime != null) response.EndTime = assignment.EndTime;


            return response;
        }

        public AssignmentListResponse ToListResponse(IEnumerable<UserAssignment?> assignments, AssignmentListRequest request)
        {
            if (assignments == null) throw new AssignmentMapperException($"Mapping failed. Assignments list null.");
            if (assignments.Any(u => u == null)) throw new AssignmentMapperException($"Mapping failed. An assignment in the list is null.");
            var response = new AssignmentListResponse();
            if (assignments != null)
            {
                response.Assignments = assignments.ToList();
                response.IsAscending = request.IsAscending;
                response.PageNumber = request.PageNumber;
                response.PageSize = request.PageSize;
                response.SearchTerm = request.SearchTerm;
                response.SortBy = request.SortBy;
            }
            return response;
        }

        public AssignmentUpdateResponse ToUpdateResponse(UserAssignment assignment)
        {
            if (assignment == null) throw new AssignmentMapperException($"Mapping failed. Assignment null.");
            var response = new AssignmentUpdateResponse();

            if (assignment.Comment != null) response.UpdatedComment = assignment.Comment;
            if (assignment.Picture != null) response.UpdatedPicture = assignment.Picture;
            if (assignment.AssignmentTimeStamp != null) response.UpdatedTimeStamp = assignment.AssignmentTimeStamp;
            if (assignment.StartTime != null) response.UpdatedStartTime = assignment.StartTime;
            if (assignment.EndTime != null) response.UpdatedEndTime = assignment.EndTime;

            return response;
        }
    }
}