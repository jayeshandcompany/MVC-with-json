namespace WebApplication4.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }
        public string name { get; set; }


        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}