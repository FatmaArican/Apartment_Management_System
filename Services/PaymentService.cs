using AutoMapper;
using System;
using WebApplication1.Data.Repositories;

namespace WebApplication1.Services
{
    public class PaymentMapping : Profile
    {
        public PaymentMapping()
        {
        }
    }

    public interface IPaymentService
    {
        void PayMineDue(int apartmentId, decimal due, int paymentTypeId, DateTime relatedDueDate);
    }

    public class PaymentService : IPaymentService
    {
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IMapper mapper, IPaymentRepository paymentRepository)
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository;
        }

        public void PayMineDue(int apartmentId, decimal due, int paymentTypeId, DateTime relatedDueDate)
        {
            _paymentRepository.PayMineDue(apartmentId, due, paymentTypeId, relatedDueDate);
        }
    }
}