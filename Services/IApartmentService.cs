using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Data.Entities;
using WebApplication1.Data.Repositories;
using WebApplication1.Requests.Apartments;
using WebApplication1.Services.Models;

namespace WebApplication1.Services
{

    public class ApartmentMapping : Profile
    {
        public ApartmentMapping()
        {
            CreateMap<ApartmentType, ApartmentTypeModel>();
            CreateMap<Apartment, ApartmentModel>();
        }
    }

    public interface IApartmentService
    {
        List<ApartmentTypeModel> ListOfApartmentTypes();
        List<ApartmentModel> ListOfApartments();
        void Create(CreateApartmentRequest request);
        void Update(UpdateApartmentRequest request);
        void Delete(int id);
    }

    public class ApartmentService : IApartmentService
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IMapper _mapper;

        public ApartmentService(IApartmentRepository apartmentRepository, IMapper mapper)
        {
            _apartmentRepository = apartmentRepository;
            _mapper = mapper;
        }

        public List<ApartmentTypeModel> ListOfApartmentTypes()
        {
            var entities = _apartmentRepository.ListOfTypes();

            return entities.Select(x => _mapper.Map<ApartmentTypeModel>(x)).ToList();
        }

        public List<ApartmentModel> ListOfApartments()
        {
            var entities = _apartmentRepository.ListOfApartments();

            return entities.Select(x => _mapper.Map<ApartmentModel>(x)).ToList();
        }

        public void Create(CreateApartmentRequest request)
        {
            if (request.OwnerUserId == 0)
                throw new ClientError("owner_user_id can not be null or empty");

            if (request.ApartmentTypeId == 0)
                throw new ClientError("apartment_type_id can not be null or empty");

            if (request.DoorNumber == 0)
                throw new ClientError("door_number can not be null or empty");


            _apartmentRepository.Create(request);
        }

        public void Update(UpdateApartmentRequest request)
        {
            _apartmentRepository.Update(request);
        }

        public void Delete(int id)
        {
            _apartmentRepository.Delete(id);
        }
    }
}