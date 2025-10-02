using StempelAppCore.Models.DTOs;
using StempelAppCore.Models.Interfaces.Mappers;
using StempelAppCore.Models.Requests;
using StempelAppCore.Models.Responses;

namespace StempelAppLib.Logic.Mapper.QueryAndResponseMappers
{
    public class UserMapper : IUserMapper
    {
        public BaseQuery ToQuery(BaseEntityRequest request)
        {
            var query = new BaseQuery()
            {
                AuthUserId = request.AuthUserId,
            };

            return query;
        }
    }
}