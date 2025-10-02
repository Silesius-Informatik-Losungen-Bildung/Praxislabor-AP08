using StempelAppCore.Models;
using StempelAppCore.Models.DTOs;
using StempelAppCore.Models.Interfaces.Mappers;
using StempelAppCore.Models.Requests;
using StempelAppCore.Models.Responses;

namespace StempelAppLib.Logic.Mapper.QueryAndResponseMappers
{
    public class UserMapper : IUserMapper
    {
        public BaseQuery ToBaseQuery(BaseRequest request)
        {
            var query = new BaseQuery()
            {
                AuthUserId = request.AuthUserId,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                SearchTerm = request.SearchTerm,
                SortBy = request.SortBy,
                IsAscending = request.IsAscending
            };

            return query;
        }

        public BaseResponse ToBaseResponse(BaseEntity entity)
        {
            var response = new BaseResponse()
            {
                AuthUserId = entity.AuthUserId,
                PageNumber = entity.PageNumber,
                PageSize = entity.PageSize,
                SearchTerm = entity.SearchTerm,
                SortBy = entity.SortBy,
                IsAscending = entity.IsAscending,
            };

            return response;
        }


    }
}