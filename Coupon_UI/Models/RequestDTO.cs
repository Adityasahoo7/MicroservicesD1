using Coupon_UI.Utility;
using Microsoft.AspNetCore.Mvc;
using static Coupon_UI.Utility.SD;

namespace Coupon_UI.Models
{
    public class RequestDTO
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }

    }
}
