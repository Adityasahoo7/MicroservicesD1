using Coupon_UI.Models;
using Coupon_UI.Service.Interface;
using Coupon_UI.Utility;
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
            return await _baseservice.SendAsync(new RequestDTO()
            {

                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = SD.CouponApiBase+"/api/coupon"

            });
        }

        public async Task<ResponseDTO?> DeleteCouponsAsync(int id)
        {
            return await _baseservice.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.CouponApiBase + "/api/coupon/" + id
            });
        }

        public async Task<ResponseDTO?> GetAllCouponAsync()
        {
            return await _baseservice.SendAsync(new RequestDTO()
            {

                ApiType = SD.ApiType.GET,
                Url = SD.CouponApiBase + "/api/coupon"
            });
        }

        public async Task<ResponseDTO?> GetCouponAsync(string coouponcode)
        {
            return await _baseservice.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponApiBase + "/api/coupon/getbycode/"+coouponcode
            });
        }

        public async Task<ResponseDTO?> GetCouponByIdAsync(int id)
        {
            return await _baseservice.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponApiBase + "/api/coupon/" + id
            });
        }
        
        public async Task<ResponseDTO?> UpdateCouponsAsync(CouponDTO dto)
        {
            return await _baseservice.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = SD.CouponApiBase + "/api/coupon"
            });
        }
    }
}   