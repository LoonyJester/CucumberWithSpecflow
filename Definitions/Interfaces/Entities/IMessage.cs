using System;
using Definitions.Enums;

namespace Definitions.Interfaces.Entities
{
    public interface IMessage: IEntity<string>
    {
        string PrimaryId { get; set; }
        int CWTiketId { get; set; }
        MessageStatus Status { get; set; }
        DateTime Timestamp { get; set; }
        string Content { get; set; }
    }
}