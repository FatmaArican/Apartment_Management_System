using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Configuration;
using WebApplication1.Data.Entities;
using WebApplication1.Requests.Apartments;

namespace WebApplication1.Data.Repositories
{

    public interface IApartmentRepository
    {
        List<ApartmentType> ListOfTypes();
        ApartmentType GetApartmentTypeById(int id);
        List<Apartment> ListOfApartments();
        void Create(CreateApartmentRequest request);
        void Update(UpdateApartmentRequest request);
        void Delete(int id);
        Apartment GetApartmentByOwnerUserId(int userId);
    }

    public class ApartmentRepository : IApartmentRepository
    {
        private readonly IConfiguration _configuration;

        public ApartmentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<ApartmentType> ListOfTypes()
        {
            using var connection = new SqlConnection(_configuration.GetValue<string>("SqlConnection"));
            var result = connection.Query<ApartmentType>(
                "select Id as id,number_of_rooms as NumberOfRooms,dues_paid as DuesPaid, area as Area,type as Type from apartments_type");
            return result.ToList();
        }

        public ApartmentType GetApartmentTypeById(int id)
        {
            using var connection = new SqlConnection(_configuration.GetValue<string>("SqlConnection"));
            var result = connection.QueryFirstOrDefault<ApartmentType>(
                "select Id as id,number_of_rooms as NumberOfRooms,dues_paid as DuesPaid, area as Area,type as Type from apartments_type where id=@id ",
                new { id = id });
            return result;
        }

        public List<Apartment> ListOfApartments()
        {
            using var connection = new SqlConnection(_configuration.GetValue<string>("SqlConnection"));
            var result = connection.Query<Apartment>(
                @"select a.id as Id,a.empty as Empty,a.floor as Floor,a.door_number as DoorNumber,a.owner_user_id as OwnerUserId,u.full_name as OwnerFullName,ap.id as ApartmentTypeId ,ap.number_of_rooms as NumberOfRooms
from apartments a inner join users u on a.owner_user_id=u.id inner join apartments_type ap on ap.id=a.apartment_type_id where a.deleted='false'");

            return result.ToList();
        }

        private bool CheckUser(int userId)
        {
            using var connection = new SqlConnection(_configuration.GetValue<string>("SqlConnection"));
            var result = connection.ExecuteScalar(
                @"select COUNT(*) from users where id=@id", new { id = userId });

            return Convert.ToInt32(result) > 0;
        }


        public void Create(CreateApartmentRequest request)
        {
            //CheckUser Id in DB.

            if (!CheckUser(request.OwnerUserId))
                throw new ClientError($"this user({request.OwnerUserId}) not found");

            using var connection = new SqlConnection(_configuration.GetValue<string>("SqlConnection"));
            connection.Execute(
                @"insert into apartments Values(@empty,@floor,@doorNumber,@ownerId,@apartTypeId,'false')",
                new
                {
                    empty = request.Empty,
                    floor = request.Floor,
                    doorNumber = request.DoorNumber,
                    ownerId = request.OwnerUserId,
                    apartTypeId = request.ApartmentTypeId,
                });
        }

        public void Update(UpdateApartmentRequest request)
        {
            using var connection = new SqlConnection(_configuration.GetValue<string>("SqlConnection"));
            connection.Execute(
                @"update apartments set empty=@empty,floor=@floor,door_number=@doorNumber,owner_user_id=@ownerId where id=@id",
                new
                {
                    id = request.Id,
                    floor = request.Floor,
                    doorNumber = request.DoorNumber,
                    ownerId = request.OwnerUserId,
                });
        }

        public void Delete(int id)
        {
            using var connection = new SqlConnection(_configuration.GetValue<string>("SqlConnection"));
            connection.Execute(
                @"update apartments set deleted='true' where id=@id",
                new
                {
                    id = id,
                });
        }

        public Apartment GetApartmentByOwnerUserId(int userId)
        {
            using var connection = new SqlConnection(_configuration.GetValue<string>("SqlConnection"));
            var result = connection.QueryFirstOrDefault<Apartment>(
                @"select a.id as Id,a.empty as Empty,a.floor as Floor,a.door_number as DoorNumber,a.owner_user_id as OwnerUserId,u.full_name as OwnerFullName,ap.id as ApartmentTypeId ,ap.number_of_rooms as NumberOfRooms
from apartments a inner join users u on a.owner_user_id=u.id inner join apartments_type ap on ap.id=a.apartment_type_id where a.owner_user_id=@userId",
                new { userId = userId });

            return result;
        }
    }
}