using System;

namespace Definitions.Entities.Messaging
{
    public class ReceivedMessage
    {
        public string MessageId { get; set; }
        public string[] References { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public string[] From { get; set; }
        public string[] To { get; set; }
    }
}