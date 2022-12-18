namespace WebApplication1.Requests.Users
{

    public class CreateUserRequest
    {
        public string FullName { get; set; }
        public string IdentityNumber { get; set; }
        public string Email { get; set; }
        public string Plate { get; set; }
        public string Phone { get; set; }
        public int UserTypeId { get; set; }
    }
}