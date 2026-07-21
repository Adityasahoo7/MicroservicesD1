using Coupon_UI.Models;
using Coupon_UI.Service.Interface;
using Microservice.CouponAPI.Models.DTO;

namespace Coupon_UI.Service.Implementation
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BaseService(IHttpClientFactory factory)
        {
            _httpClientFactory = factory;
        }
        public async Task<ResponseDTO?> SendAsync(RequestDTO dto)
        {
            
        }
    }
}
