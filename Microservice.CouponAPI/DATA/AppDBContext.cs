using Microservice.CouponAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservice.CouponAPI.DATA
{
    public class AppDBContext:DbContext
    {

        public AppDBContext(DbContextOptions<AppDBContext> options):base(options)
        {
            
        }

        public DbSet<Coupon> CouponDS { get; set; }

    }
}
