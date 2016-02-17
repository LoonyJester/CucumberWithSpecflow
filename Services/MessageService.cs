using System;
using System.Linq;
using Definitions;
using Definitions.Entities.Messaging;
using Definitions.Interfaces.Repositories;
using Definitions.Interfaces.Services;

namespace Services
{
    public class MessageService : BaseService, IMessageService
    {

        private readonly IMessageRepo _repo;
        public MessageService(ILogger logger, IMessageRepo repo) : base(logger)
        {
            _repo = repo;
        }

//        public MessageDTO SaveNewEmail(ReceivedMessage receivedMessage)
//        {
//            throw new NotImplementedException();
//        }

        public MessageDTO CheckFirstReference(ReceivedMessage receivedMessage)
        {
            if (receivedMessage.References != null && receivedMessage.References.Any())
            {
               _repo.CheckByFirstReference(receivedMessage.References.First());
            }
            return null;
        }
    }
}
