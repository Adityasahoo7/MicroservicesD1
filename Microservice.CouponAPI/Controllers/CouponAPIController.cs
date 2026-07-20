using Microservice.CouponAPI.DATA;
using Microservice.CouponAPI.Models;
using Microservice.CouponAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDBContext _context;
        private readonly ResponseDTO _response;
        public CouponAPIController(AppDBContext context , ResponseDTO dto)
        {
            _context = context;
            _response = dto;
                
        }

        [HttpGet]
        public ResponseDTO get()
        {
            try
            {

                IEnumerable<Coupon> objlist = _context.CouponDS.ToList();
                _response.Result = objlist;

            }catch(Exception ex)
            {
                _response.isSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;

        }

        [HttpGet("{id}")]
        public ResponseDTO getbyid(int id)
        {
            try
            {
                Coupon objlist = _context.CouponDS.First(u => u.CouponID == id);
                _response.Result = objlist;

            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.Message = ex.Message;

            }

            return _response;
        }


    }
}
