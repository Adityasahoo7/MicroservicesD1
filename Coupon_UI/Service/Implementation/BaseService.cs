using Coupon_UI.Models;
using Coupon_UI.Service.Interface;
using Microservice.CouponAPI.Models.DTO;
using Newtonsoft.Json;
using System.Text;
using System.Net;
using System.Text.Json.Serialization;

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
            try
            {


                HttpClient client = _httpClientFactory.CreateClient("CouponApi");
                HttpRequestMessage message = new();
                message.Headers.Add("Accept", "application/json");

                message.RequestUri = new Uri(dto.Url);

                if (dto.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(dto.Data), Encoding.UTF8, "application/json");
                }

                HttpResponseMessage? apiresponse = null;
                switch (dto.ApiType)
                {
                    case Utility.SD.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case Utility.SD.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case Utility.SD.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                apiresponse = await client.SendAsync(message);

                switch (apiresponse.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new() { isSuccess = false, Message = "Not Found" };

                    case HttpStatusCode.Forbidden:
                        return new() { isSuccess = false, Message = "Accesss Denied" };

                    case HttpStatusCode.Unauthorized:
                        return new() { isSuccess = false, Message = "Unauthorize" };

                    case HttpStatusCode.InternalServerError:
                        return new() { isSuccess = false, Message = "Internal server error " };

                    default:
                        var apicontent = await apiresponse.Content.ReadAsStringAsync();
                        var apiresponsedto = JsonConvert.DeserializeObject<ResponseDTO>(apicontent);
                        return apiresponsedto;
                }
            }catch(Exception ex)
            {
                var errdto = new ResponseDTO
                {
                    Message = ex.Message.ToString(),
                    isSuccess = false

                };
                return errdto;
            }
        }
    }
}
