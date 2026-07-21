namespace Coupon_UI.Models
{
    public class ResponseDTO
    {
        public object? Result { get; set; }
        public bool isSuccess { get; set; } = true;
        public string Message { get; set; } = "";


    }
}
