using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Configuration;
using WebApplication1.Data.Entities;
using WebApplication1.Requests.Messages;

namespace WebApplication1.Data.Repositories
{

    public interface IMessageRepository
    {
        List<Message> ListOfMessage(int toApartmentId, bool isRead);
        void SendMessageToManager(SendMessageToManagerRequest request);
    }

    public class MessageRepository : IMessageRepository
    {
        private readonly IConfiguration _configuration;

        public MessageRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Message> ListOfMessage(int toApartmentId, bool isRead)
        {
            using var connection = new SqlConnection(_configuration.GetValue<string>("SqlConnection"));
            var result = connection.Query<Message>(
                @"select m.id as Id,m.from_apartment_id as FromApartmentId,u.full_name as FromOwnerName ,m.to_apartment_id as ToApartmentId,m.summary as Content,m.[read] as IsRead,m.create_date as CreateDate
        from messages m inner join apartments a on m.from_apartment_id=a.id inner join users u on u.id=a.owner_user_id
        Where to_apartment_id=@toApartId and [read]=@isRead Order by m.create_date desc", new { toApartId = toApartmentId, isRead = isRead });
            return result.ToList();
        }

        public void SendMessageToManager(SendMessageToManagerRequest request)
        {
            using var connection = new SqlConnection(_configuration.GetValue<string>("SqlConnection"));
            connection.Execute(
                @"Insert Into messages Values(@fromId,(select top 1 a.id from apartments a inner join apartments_type at on a.apartment_type_id=at.id
where type='office')
,@message,'false',getdate())", new { fromId = request.FromId, message = request.Message });
        }
    }
}