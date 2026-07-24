using AutoMapper;
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
        private readonly IMapper _mapper;
        public CouponAPIController(AppDBContext context ,IMapper mapper)
        {
            _context = context;
            _response = new ResponseDTO();
            _mapper = mapper;
                
        }

        [HttpGet]
        public ResponseDTO get()
        {
            try
            {

                IEnumerable<Coupon> objlist = _context.CouponDS.ToList();
                // _response.Result = objlist;
                _response.Result = _mapper.Map<IEnumerable<CouponDTO>>(objlist);


            }catch(Exception ex)
            {
                _response.isSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;

        }

        [HttpGet("getbycode/{code}")]
        public ResponseDTO getbycode(string code)
        {
            try
            {
                Coupon obj = _context.CouponDS.First(u => u.CouponCode.ToLower() == code.ToLower());
                _response.Result = _mapper.Map<CouponDTO>(obj);
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
                // _response.Result = objlist;

                _response.Result = _mapper.Map<CouponDTO>(objlist);

            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.Message = ex.Message;

            }

            return _response;
        }


        [HttpPost]
        public ResponseDTO Createcoupon([FromBody] CouponDTO dto)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(dto);
                _context.Add(obj);
                _context.SaveChanges();

                _response.Result = _mapper.Map<CouponDTO>(obj);
               // return Ok(_response);

            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.Message = ex.InnerException?.Message ?? ex.Message;
                // return BadRequest(_response);
            }
            return _response;

        }




        [HttpPut]
        public ResponseDTO UpdateCoupon([FromBody] CouponDTO dto)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(dto);
                _context.Update(obj);
                _context.SaveChanges();

                _response.Result = _mapper.Map<CouponDTO>(obj);
                // return Ok(_response);

            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.Message = ex.InnerException?.Message ?? ex.Message;
                // return BadRequest(_response);
            }
            return _response;

        }

        [HttpDelete("{id}")]
        public ResponseDTO DeleteCoupon(int id)
        {
            try
            {
                Coupon obj = _context.CouponDS.First(u => u.CouponID == id);
                _context.CouponDS.Remove(obj);
                _context.SaveChanges();
                
            }catch(Exception ex)
            {
                _response.isSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;


        }

    }
}
