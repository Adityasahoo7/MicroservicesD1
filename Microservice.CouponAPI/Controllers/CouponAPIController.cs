using Microservice.CouponAPI.DATA;
using Microservice.CouponAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDBContext _context;
        public CouponAPIController(AppDBContext context)
        {
            _context = context;
                
        }

        [HttpGet]
        public object get()
        {
            try
            {

                IEnumerable<Coupon> objlist = _context.CouponDS.ToList();
                return objlist;

            }catch(Exception ex)
            {
                return ex.Message;
            }

            return null;

        }

        [HttpGet("{id}")]
        public object getbyid(int id)
        {
            try
            {
                Coupon objlist = _context.CouponDS.First(u => u.CouponID == id);
                return objlist;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return null;
        }


    }
}
