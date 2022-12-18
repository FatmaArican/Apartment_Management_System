namespace WebApplication1.Requests.Messages
{

    public class SendMessageToManagerRequest
    {
        public int FromId { get; set; }
        public string Message { get; set; }
    }
}