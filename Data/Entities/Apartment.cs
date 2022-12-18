namespace WebApplication1.Data.Entities
{
    public class Apartment
    {
        public int Id { get; set; }
        public bool Empty { get; set; }
        public int Floor { get; set; }
        public int DoorNumber { get; set; }
        public int OwnerUserId { get; set; }
        public string OwnerFullName { get; set; }
        public string NumberOfRooms { get; set; }
        public int ApartmentTypeId { get; set; }
        public bool Deleted { get; set; }
    }
}