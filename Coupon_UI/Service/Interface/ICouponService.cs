using Coupon_UI.Models;
using Microservice.CouponAPI.Models.DTO;

namespace Coupon_UI.Service.Interface
{
    public interface ICouponService
    {
        Task<ResponseDTO?> GetCouponAsync(string coouponcode);
        Task<ResponseDTO?> GetAllCouponAsync();
        Task<ResponseDTO?> GetCouponByIdAsync(int id);
        Task<ResponseDTO?> CreateCouponsAsync(CouponDTO dto);
        Task<ResponseDTO?> UpdateCouponsAsync(CouponDTO dto);
        Task<ResponseDTO?> DeleteCouponsAsync(int id);

    }
}
