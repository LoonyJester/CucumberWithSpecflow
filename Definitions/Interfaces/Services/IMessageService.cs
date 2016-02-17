using Definitions.Entities.Messaging;

namespace Definitions.Interfaces.Services
{
    public interface IMessageService
    {
        MessageDTO SaveNewEmail(ReceivedMessage receivedMessage);
        MessageDTO CheckFirstReference(ReceivedMessage receivedMessage);
    }
}