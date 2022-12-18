using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Data.Entities;
using WebApplication1.Data.Repositories;
using WebApplication1.Requests.Users;

namespace WebApplication1.Services
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserType, UserTypeModel>();
        }
    }

    public interface IUserService
    {
        List<UserModel> ListOfUser();
        List<UserTypeModel> ListOfUserTypes();
        void Create(CreateUserRequest request);
        void Update(UpdateUserRequest request);
        void Delete(int id);
        void PayMineDue(PayMineDueRequest request);
    }

    public class UserService : IUserService
    {
        private readonly IPaymentService _paymentService;
        private readonly IUserRepository _userRepository;
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IApartmentRepository apartmentRepository,
            IPaymentService paymentService, IMapper mapper)
        {
            _paymentService = paymentService;
            _userRepository = userRepository;
            _apartmentRepository = apartmentRepository;
            _mapper = mapper;
        }

        public List<UserModel> ListOfUser()
        {
            var entities = _userRepository.ListOfUser();

            return entities.Select(x => _mapper.Map<UserModel>(x)).ToList();
        }

        public List<UserTypeModel> ListOfUserTypes()
        {
            var entities = _userRepository.ListOfUserTypes();

            return entities.Select(x => _mapper.Map<UserTypeModel>(x)).ToList();
        }

        public void Create(CreateUserRequest request)
        {
            _userRepository.Create(request);
        }

        public void Update(UpdateUserRequest request)
        {
            _userRepository.Update(request);
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }

        public void PayMineDue(PayMineDueRequest request)
        {
            var user = _userRepository.Get(request.UserId);
            if (user == null)
                throw new ClientError($"user ({request.UserId}) not found");


            var apartment = _apartmentRepository.GetApartmentByOwnerUserId(user.Id);
            if (apartment == null)
                throw new ClientError($"this user ({request.UserId}) does not have a apartment");


            var apartmentType = _apartmentRepository.GetApartmentTypeById(apartment.ApartmentTypeId);

            var due = apartmentType.DuesPaid;

            _paymentService.PayMineDue(apartment.Id, due, 3, request.RelatedDueDate);
        }
    }
}