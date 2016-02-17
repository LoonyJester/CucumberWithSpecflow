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

        public MessageDTO SaveNewEmail(ReceivedMessage receivedMessage)
        {
            if (receivedMessage == null) throw new ArgumentNullException(nameof(receivedMessage));

            var message = _repo.Get(receivedMessage.MessageId) ?? new MessageDTO();
            message.Id = receivedMessage.MessageId;
            message.PrimaryId = receivedMessage.References != null ? receivedMessage.References.FirstOrDefault() ?? receivedMessage.MessageId : receivedMessage.MessageId;
            message.Content = receivedMessage.Content;
            message.Timestamp = receivedMessage.Timestamp;
            return _repo.Save(message);
        }

        public MessageDTO CheckFirstReference(ReceivedMessage receivedMessage)
        {
            MessageDTO message;
            if (receivedMessage.References != null && receivedMessage.References.Any())
            {
                message = _repo.CheckByFirstReference(receivedMessage.References.First());
                if (message != null && message.CWTiketId > 0)
                    return message;
            }
            message = _repo.CheckByMessageId(receivedMessage.MessageId);
            if (message != null && message.CWTiketId > 0)
                return message;
            return null;
        }
    }
}
