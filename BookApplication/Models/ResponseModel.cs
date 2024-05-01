namespace BookApplication.WebApi.Models
{
    public class ResponseModel
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
