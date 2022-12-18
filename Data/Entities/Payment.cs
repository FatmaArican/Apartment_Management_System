using System;

namespace WebApplication1.Data.Entities
{

    public class Payment
    {
        public int Id { get; set; }
        public int ApartmentId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public int PaymentTypeId { get; set; }
        public string Reason { get; set; }
        public string State { get; set; }
        public DateTime DueDate { get; set; }
    }
}