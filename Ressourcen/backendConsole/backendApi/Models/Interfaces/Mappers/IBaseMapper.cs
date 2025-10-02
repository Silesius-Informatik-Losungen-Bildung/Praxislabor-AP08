using StempelAppCore.Models.DTOs;
using StempelAppCore.Models.Requests;
using StempelAppCore.Models.Responses;

namespace StempelAppCore.Models.Interfaces.Mappers
{
    public interface IBaseMapper
    {
        BaseQuery ToBaseQuery(BaseRequest request);
        BaseResponse ToBaseResponse(BaseResponse response);
    }
}