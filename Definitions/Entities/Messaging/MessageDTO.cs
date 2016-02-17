using System;
using Definitions.Enums;
using Definitions.Interfaces.Entities;

namespace Definitions.Entities.Messaging
{
    public class MessageDTO: IMessage
    {
        public string Id { get; set; }
        public string PrimaryId { get; set; }
        public int CWTiketId { get; set; }
        public MessageStatus Status { get; set; }
        public DateTime Timestamp { get; set; }
        public string Content { get; set; }
    }
}