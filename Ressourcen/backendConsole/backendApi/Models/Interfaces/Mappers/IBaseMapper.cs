using StempelAppCore.Models.DTOs;
using StempelAppCore.Models.Requests;
using StempelAppCore.Models.Responses;

namespace StempelAppCore.Models.Interfaces.Mappers
{
    public interface IBaseMapper
    {
        BaseQuery ToQuery(BaseEntityRequest request);
        BasePaginationResponse ToResponse(BasePaginationRequest request);
    }
}