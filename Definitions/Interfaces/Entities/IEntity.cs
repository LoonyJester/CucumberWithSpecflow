namespace Definitions.Interfaces.Entities
{
    public interface IEntity<TID>
    {
        TID Id { get; set; }
    }
}