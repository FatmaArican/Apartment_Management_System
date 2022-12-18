namespace WebApplication1.Requests.Apartments
{

    public class UpdateApartmentRequest
    {
        public int Id { get; set; }
        public int Floor { get; set; }
        public int DoorNumber { get; set; }
        public int OwnerUserId { get; set; }
    }
}