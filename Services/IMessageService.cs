using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Data.Entities;
using WebApplication1.Data.Repositories;
using WebApplication1.Requests.Messages;
using WebApplication1.Services.Models;

namespace WebApplication1.Services
{

    public class MessageMapping : Profile
    {
        public MessageMapping()
        {
            CreateMap<Message, MessageModel>();
        }
    }

    public interface IMessageService
    {
        List<MessageModel> ListOfMessage(int toApartmentId, bool isRead);
        void SendMessageToManager(SendMessageToManagerRequest request);
    }

    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public MessageService(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public List<MessageModel> ListOfMessage(int toApartmentId, bool isRead)
        {
            var entities = _messageRepository.ListOfMessage(toApartmentId, isRead);

            return entities.Select(x => _mapper.Map<MessageModel>(x)).ToList();
        }

        public void SendMessageToManager(SendMessageToManagerRequest request)
        {
            _messageRepository.SendMessageToManager(request);
        }
    }
}