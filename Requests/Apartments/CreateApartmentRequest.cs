namespace WebApplication1.Requests.Apartments
{

    public class CreateApartmentRequest
    {
        public bool Empty { get; set; }
        public int Floor { get; set; }
        public int DoorNumber { get; set; }
        public int OwnerUserId { get; set; }
        public int ApartmentTypeId { get; set; }
    }
}