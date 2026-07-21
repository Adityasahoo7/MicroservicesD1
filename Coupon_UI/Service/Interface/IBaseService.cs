using Coupon_UI.Models;
using Microservice.CouponAPI.Models.DTO;

namespace Coupon_UI.Service.Interface
{
    public interface IBaseService
    {
        Task<ResponseDTO?> SendAsync(RequestDTO dto);
    }
}
