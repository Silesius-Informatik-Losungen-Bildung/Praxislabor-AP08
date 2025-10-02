using StempelAppCore.Models.Responses;

namespace StempelAppCore.Models.Interfaces.Mappers
{
    public interface IBaseMapper
    {
        BaseResponse ToBaseResponse(BaseEntity entity);
    }
}