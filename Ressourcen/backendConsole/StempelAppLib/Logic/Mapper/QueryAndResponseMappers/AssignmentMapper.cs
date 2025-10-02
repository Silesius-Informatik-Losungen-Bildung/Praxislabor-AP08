using StempelAppCore.Models;
using StempelAppCore.Models.Interfaces.Mappers;
using StempelAppCore.Models.Requests;
using StempelAppCore.Models.Responses;

namespace StempelAppLib.Logic.Mapper.QueryAndResponseMappers
{
    public class AssignmentMapper : IAssignmentMapper
    {

        public BaseResponse ToBaseResponse(BaseEntity entity)
        {
            var response = new BaseResponse()
            {
                PageNumber = entity.PageNumber,
                PageSize = entity.PageSize,
                SearchTerm = entity.SearchTerm,
                SortBy = entity.SortBy,
                IsAscending = entity.IsAscending,
            };

            return response;
        }

        public AssignmentCreateResponse ToCreateResponse(Assignment assignment)
        {
            var response = new AssignmentCreateResponse();

            response.PageNumber = assignment.PageNumber;
            response.PageSize = assignment.PageSize;
            response.SearchTerm = assignment.SearchTerm;
            response.SortBy = assignment.SortBy;
            response.IsAscending = assignment.IsAscending;
            response.UserId = assignment.UserId;
            response.Location = assignment.Location;

            if (assignment.Comment != null) response.Comment = assignment.Comment;
            if (assignment.Picture != null) response.Picture = assignment.Picture;
            if (assignment.AssignmentTimeStamp != null) response.TimeStamp = assignment.AssignmentTimeStamp;
            if (assignment.StartTime != null) response.StartTime = assignment.StartTime;
            if (assignment.EndTime != null) response.EndTime = assignment.EndTime;

            return response;
        }

        public AssignmentGetResponse ToGetResponse(Assignment assignment)
        {
            var response = new AssignmentGetResponse();

            response.PageNumber = assignment.PageNumber;
            response.PageSize = assignment.PageSize;
            response.SearchTerm = assignment.SearchTerm;
            response.SortBy = assignment.SortBy;
            response.IsAscending = assignment.IsAscending;
            response.UserId = assignment.UserId;
            response.Location = assignment.Location;

            if (assignment.Comment != null) response.Comment = assignment.Comment;
            if (assignment.Picture != null) response.Picture = assignment.Picture;
            if (assignment.AssignmentTimeStamp != null) response.TimeStamp = assignment.AssignmentTimeStamp;
            if (assignment.StartTime != null) response.StartTime = assignment.StartTime;
            if (assignment.EndTime != null) response.EndTime = assignment.EndTime;

            return response;
        }

        public AssignmentListResponse ToListResponse(IEnumerable<Assignment> assignments, AssignmentListRequest request)
        {
            return new AssignmentListResponse()
            {
                Assignments = assignments.ToList(),
                IsAscending = request.IsAscending,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                SearchTerm = request.SearchTerm,
                SortBy = request.SortBy,
            };

        }

        public AssignmentUpdateResponse ToUpdateResponse(Assignment assignment)
        {
            var response = new AssignmentUpdateResponse();

            response.PageSize = assignment.PageSize;
            response.SearchTerm = assignment.SearchTerm;
            response.SortBy = assignment.SortBy;
            response.IsAscending = assignment.IsAscending;
            response.PageNumber = assignment.PageNumber;

            if (assignment.Comment != null) response.UpdatedComment = assignment.Comment;
            if (assignment.Picture != null) response.UpdatedPicture = assignment.Picture;
            if (assignment.AssignmentTimeStamp != null) response.UpdatedTimeStamp = assignment.AssignmentTimeStamp;
            if (assignment.StartTime != null) response.UpdatedStartTime = assignment.StartTime;
            if (assignment.EndTime != null) response.UpdatedEndTime = assignment.EndTime;

            return response;
        }
    }
}