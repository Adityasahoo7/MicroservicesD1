using Coupon_UI.Models;
using Coupon_UI.Service.Interface;
using Microservice.CouponAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Coupon_UI.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponservice;
        public CouponController(ICouponService service)
        {
            _couponservice = service;
        }
        public async Task<IActionResult> CouponIndex()
        {
            List<CouponDTO>? couponlist = new();
            ResponseDTO response = await _couponservice.GetAllCouponAsync();
            if(response != null && response.isSuccess)
            {
                couponlist = JsonConvert.DeserializeObject<List<CouponDTO>>(Convert.ToString(response.Result));
            }

            return View(couponlist);
        }
    }
}
