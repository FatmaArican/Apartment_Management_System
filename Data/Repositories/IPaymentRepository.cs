using System;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace WebApplication1.Data.Repositories
{

    public interface IPaymentRepository
    {
        void PayMineDue(int apartmentId, decimal due, int paymentTypeId, DateTime relatedDueDate);
    }

    public class PaymentRepository : IPaymentRepository
    {
        private readonly IConfiguration _configuration;

        public PaymentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void PayMineDue(int apartmentId, decimal due, int paymentTypeId, DateTime relatedDueDate)
        {
            using var connection = new SqlConnection(_configuration.GetValue<string>("SqlConnection"));
            connection.Execute(
                "insert  into payments values(@apartmentId,GETDATE(),@dueAmount,@paymentTypeId,'aidat','success',@date)", new
                {
                    apartmentId = apartmentId,
                    dueAmount = due,
                    paymentTypeId = paymentTypeId,
                    date = relatedDueDate
                });
        }
    }
}