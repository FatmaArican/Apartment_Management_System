namespace WebApplication1.Data.Entities
{

    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string IdentityNumber { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Plate { get; set; }
        public bool Deleted { get; set; }
        public int UserTypeId { get; set; }
        public string UserTypeName { get; set; }
    }
}