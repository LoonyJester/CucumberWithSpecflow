using Definitions.Entities.Messaging;
using Definitions.Interfaces.Base;

namespace Definitions.Interfaces.Repositories
{
    public interface IMessageRepo: IEntityRepo<string, MessageDTO>
    {
        MessageDTO CheckByFirstReference(string firstReference);
        MessageDTO CheckByMessageId(string messageId);
    }
}