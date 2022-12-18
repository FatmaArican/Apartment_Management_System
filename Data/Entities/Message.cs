using System;

namespace WebApplication1.Data.Entities
{

    public class Message
    {
        public int Id { get; set; }
        public int FromApartmentId { get; set; }
        public string FromOwnerName { get; set; }
        public int ToApartmentId { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreateDate { get; set; }
    }
}