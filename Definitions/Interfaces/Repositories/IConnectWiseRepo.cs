using Definitions.Entities.ConnectWise;
using Definitions.Interfaces.Base;

namespace Definitions.Interfaces.Repositories
{
    public interface IConnectWiseRepo: IRepo
    {
        CwTicket CreateTicket(int contactId, int companyId, string summary, int? boardId, string initialDescription);
        CWContact GetClient(string clientEmail);
        int? GetBoardIdByName(string name);
    }
}