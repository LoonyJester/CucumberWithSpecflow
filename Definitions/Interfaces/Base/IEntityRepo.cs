using Definitions.Interfaces.Entities;

namespace Definitions.Interfaces.Base
{
    public interface IEntityRepo<in TID, TInfoEntity> : IRepo
//        where TID : new()
        where TInfoEntity : IEntity<TID>, new()

    {
        TInfoEntity Get(TID id);
        TInfoEntity Save(TInfoEntity item);
        void Remove(TID id);
    }
}