using System;

namespace WebApplication1.Requests.Users
{

    public class PayMineDueRequest
    {
        public DateTime RelatedDueDate { get; set; }
        public string Reason { get; set; }
        public int UserId { get; set; }
    }
}