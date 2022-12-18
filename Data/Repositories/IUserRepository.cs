using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Configuration;
using WebApplication1.Data.Entities;
using WebApplication1.Requests.Users;

namespace WebApplication1.Data.Repositories
{

    public interface IUserRepository
    {
        List<User> ListOfUser();
        User Get(int id);
        List<UserType> ListOfUserTypes();
        void Create(CreateUserRequest request);
        void Update(UpdateUserRequest request);
        void Delete(int id);
    }

    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<User> ListOfUser()
        {
            using var connection = new SqlConnection(_configuration.GetValue<string>("SqlConnection"));
            var result = connection.Query<User>(
                "select u.id as Id , u.full_name as FullName,u.identity_number as IdentityNumber,u.email as Email,u.phone as Phone,u.plate as Plate,u.deleted as Deleted,u.user_type_id as UserTypeId,ut.name as UserTypeName " +
                "from users  u inner join users_type ut on u.user_type_id=ut.id where u.deleted='false'");
            return result.ToList();
        }

        public User Get(int id)
        {
            using var connection = new SqlConnection(_configuration.GetValue<string>("SqlConnection"));
            var result = connection.QueryFirstOrDefault<User>(
                "select u.id as Id , u.full_name as FullName,u.identity_number as IdentityNumber,u.email as Email,u.phone as Phone,u.plate as Plate,u.deleted as Deleted,u.user_type_id as UserTypeId,ut.name as UserTypeName " +
                "from users  u inner join users_type ut on u.user_type_id=ut.id where u.id=@id", new { id = id });
            return result;
        }

        public List<UserType> ListOfUserTypes()
        {
            using var connection = new SqlConnection(_configuration.GetValue<string>("SqlConnection"));
            var result = connection.Query<UserType>("select id as Id,name as Name from users_type");
            return result.ToList();
        }

        public void Create(CreateUserRequest request)
        {
            using var connection = new SqlConnection(_configuration.GetValue<string>("SqlConnection"));
            connection.Execute(
                "insert into users values(@fullName,@identityNumber,@email,@phone,@plate,@deleted,@userTypeId)", new
                {
                    fullName = request.FullName,
                    identityNumber = request.IdentityNumber,
                    email = request.Email,
                    phone = request.Phone,
                    plate = request.Plate,
                    deleted = false,
                    userTypeId = request.UserTypeId
                });
        }

        public void Update(UpdateUserRequest request)
        {
            using var connection = new SqlConnection(_configuration.GetValue<string>("SqlConnection"));
            connection.Execute(
                "update users set full_name=@fullname,identity_number=@identityNumber,email=@email,phone=@phone,plate=@plate where id=@id",
                new
                {
                    id = request.Id,
                    fullName = request.FullName,
                    identityNumber = request.IdentityNumber,
                    email = request.Email,
                    phone = request.Phone,
                    plate = request.Plate,
                });
        }

        public void Delete(int id)
        {
            using var connection = new SqlConnection(_configuration.GetValue<string>("SqlConnection"));
            connection.Execute(
                "update users set deleted='true' where id=@id",
                new
                {
                    id = id,
                });
        }
    }
}