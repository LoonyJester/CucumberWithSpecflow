using System;
using Definitions;
using Definitions.Entities.Messaging;
using Definitions.Interfaces.Repositories;
using Definitions.Interfaces.Services;
using Moq;
using Services;

namespace Tests.Services.Messages
{
    internal class MessageScenariosContext: BaseContext
    {
        internal readonly IMessageService MessageServise;
        internal readonly Mock<IMessageRepo> MessageRepoMock;
        internal readonly Mock<ILogger> LoogerMock;

        public MessageScenariosContext()
        {
            LoogerMock = new Mock<ILogger>();
            MessageRepoMock = new Mock<IMessageRepo>();
            MessageServise = new MessageService(LoogerMock.Object, MessageRepoMock.Object);
        }

        internal readonly string[] References =
        {
            "fa744daa-ad50-4b17-a63d-e122609a2cff@zfort.com",
            "CAMb8S-oJ5DKNWt987RAGgRX1E8g6J7Bd1-cm7V5RREJ1BVj=2A@mail.gmail.com"
        };

        internal ReceivedMessage InitReceivedMessage = new ReceivedMessage
            {
                MessageId = "9889fa57-6995-4de1-ba9c-55adf4c0d238@zfort.com",
                Content = "Test Start Content",
                Timestamp = DateTime.Now,
                From = new[] { "mykhaylichenko@zfort.com" },
                To = new[] { "aleksey.mykhaylichenko@webteks.com" }

            };
}
}