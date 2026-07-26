using Coupon_UI.Models;
using Coupon_UI.Service.Interface;
using Microservice.CouponAPI.Models.DTO;

namespace Coupon_UI.Service.Implementation
{
    public class CouponService:ICouponService
    { 
        private readonly IBaseService _baseservice;     
        public CouponService(IBaseService baseservice)
        {
            _baseservice = baseservice;
        }

        public async Task<ResponseDTO?> CreateCouponsAsync(CouponDTO dto)
        {
            return await _baseservice.SendAsync(new RequestDTO)
        }

        public async Task<ResponseDTO?> DeleteCouponsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDTO?> GetAllCouponAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDTO?> GetCouponAsync(string coouponcode)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO?> GetCouponByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDTO?> UpdateCouponsAsync(CouponDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}  