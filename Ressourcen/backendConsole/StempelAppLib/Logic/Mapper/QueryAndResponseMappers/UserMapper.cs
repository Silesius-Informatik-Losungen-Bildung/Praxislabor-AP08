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
    }
}