using AutoMapper;
using Microservice.CouponAPI.Models;
using Microservice.CouponAPI.Models.DTO;

namespace Microservice.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMap()
        {
            var mapconfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDTO, Coupon>();
                config.CreateMap<Coupon, CouponDTO>();
            });

            return mapconfig;
        }
    }
}
