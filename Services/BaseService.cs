using Definitions;
using Definitions.Interfaces.Base;

namespace Services
{
    public abstract class BaseService : IService
    {
        protected readonly ILogger Logger;

        protected BaseService(ILogger logger)
        {
            Logger = logger;
        }
    }
}