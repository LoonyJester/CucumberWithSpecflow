using Definitions.Entities.Messaging;
using Moq;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Tests.Services.Messages
{
    [Binding]
    public class MessageScenariosSteps
    {
        private MessageScenariosContext _context;

        [Given(@"We have a received email")]
        public void GivenWeHaveAReceivedEmail()
        {
            _context = new MessageScenariosContext();
        }

        [Given(@"The first reference is exist")]
        public void ThenTheFirstReferenceIsExist()
        {
            _context.InitReceivedMessage.References = _context.References;
        }

        [Given(@"A the first reference is null or empty")]
        public void ThenATheFirstReferenceIsNullOrEmpty()
        {
            _context.InitReceivedMessage.References = null;
        }

        [Then(@"We start to found a message")]
        public void ThenWeStartToFoundAMessage()
        {
            _context.Result = _context.MessageServise.CheckFirstReference(_context.InitReceivedMessage);
        }

        [When(@"It shouldn't check first reference")]
        public void WhenItShouldnTCheckFirstReference()
        {
            _context.MessageRepoMock.Verify(x => x.CheckByFirstReference(It.IsAny<string>()), Times.Never);
        }

        [When(@"It should check by the first reference")]
        public void WhenItShouldCheckByTheFirstReference()
        {
            _context.MessageRepoMock.Verify(x => x.CheckByFirstReference(It.IsAny<string>()), Times.Once);
        }

        [When(@"It should return a message")]
        public void WhenItShouldReturnAMessage()
        {
            Assert.IsNotNull(_context.Result as MessageDTO);
        }

        [When(@"It should check by the message Id")]
        public void WhenItShouldCheckByTheMessageId()
        {
            _context.MessageRepoMock.Verify(x => x.CheckByMessageId(It.IsAny<string>()), Times.Once);
        }

        [When(@"It should return null")]
        public void WhenItShouldReturnNull()
        {
            Assert.IsNull(_context.Result);
        }

        [When(@"It should set Message-ID as a unique message identifier from Email Header")]
        public void WhenItShouldSetMessage_IDAsAUniqueMessageIdentifierFromEmailHeader()
        {
            Assert.IsTrue(((MessageDTO)_context.Result).Id.Equals(_context.InitReceivedMessage.MessageId));
        }

        [When(@"It should set Email message content from the reseived message")]
        public void WhenItShouldSetEmailMessageContentFromTheReseivedMessage()
        {
            Assert.IsTrue(((MessageDTO)_context.Result).Content.Equals(_context.InitReceivedMessage.Content));
        }

        [When(@"It should set timestamp from the reseived message")]
        public void WhenItShouldSetTimestampFromTheReseivedMessage()
        {
            Assert.IsTrue(((MessageDTO)_context.Result).Timestamp.Equals(_context.InitReceivedMessage.Timestamp));
        }

        [When(@"It should update the message")]
        public void WhenItShouldUpdateTheMessage()
        {
            _context.MessageRepoMock.Verify(x => x.Save(It.IsAny<MessageDTO>()));
        }

        [When(@"It should return the massage")]
        public void WhenItShouldReturnTheMassage()
        {
            Assert.IsNotNull(_context.Result as MessageDTO);
        }

        [When(@"It should save the message")]
        public void WhenItShouldSaveTheMessage()
        {
            _context.MessageRepoMock.Verify(x => x.Save(It.IsAny<MessageDTO>()));
        }

        [Then(@"A message has been found by the first the first reference and the ticket Id is greater that zero")]
        public void ThenAMessageHasBeenFoundByTheFirstTheFirstReferenceAndTheTicketIdIsGreaterThat()
        {
            _context.MessageRepoMock.Setup(x => x.CheckByFirstReference(_context.InitReceivedMessage.References[0]))
                .Returns(new MessageDTO { CWTiketId = 456 });
        }

        [Then(@"A message hasn't been found by the first reference")]
        public void ThenAMessageHasnTBeenFoundByTheFirstReference()
        {
            _context.MessageRepoMock.Setup(x => x.CheckByFirstReference(_context.InitReceivedMessage.References[0]))
                .Returns((MessageDTO)null);
        }

        [Then(@"A message has been found by the message Id and the ticket id greater zero")]
        public void ThenAMessageHasBeenFoundByTheMessageId()
        {
            _context.MessageRepoMock.Setup(x => x.CheckByMessageId(_context.InitReceivedMessage.MessageId))
                .Returns(new MessageDTO { CWTiketId = 456 });
        }


        [Then(@"A message hasn't been found by the message Id")]
        public void ThenAMessageHasnTBeenFoundByTheMessageId()
        {
            _context.MessageRepoMock.Setup(x => x.CheckByMessageId(_context.InitReceivedMessage.MessageId))
                .Returns((MessageDTO)null);
        }

        [Then(@"A message with the specific message Id exists")]
        public void ThenAMessageWithTheSpecificMessageIdExists()
        {
            _context.MessageRepoMock.Setup(x => x.Get(_context.InitReceivedMessage.MessageId))
                .Returns(new MessageDTO { Id = _context.InitReceivedMessage.MessageId });
        }

        [Then(@"A message with the specific message Id doesn't exist")]
        public void ThenAMessageWithTheSpecificMessageIdDoesnTExist()
        {
            _context.MessageRepoMock.Setup(x => x.Get(_context.InitReceivedMessage.MessageId))
                .Returns((MessageDTO)null);
        }

        [Then(@"A message has been found by the first reference and the ticket Id is equal zero")]
        public void ThenAMessageHasBeenFoundByTheFirstReferenceAndTicketIdEqualZero()
        {
            _context.MessageRepoMock.Setup(x => x.CheckByFirstReference(_context.InitReceivedMessage.References[0]))
                .Returns(new MessageDTO());
        }

        [Then(@"A message has been found by the message Id and the ticket Id is equal zero")]
        public void ThenAMessageHasBeenFoundByTheMessageIdAndTheTicketIdEqualZero()
        {
            _context.MessageRepoMock.Setup(x => x.CheckByMessageId(_context.InitReceivedMessage.MessageId))
                .Returns(new MessageDTO());
        }



        [Then(@"We start to save a message")]
        public void ThenWeStartToSaveAMessage()
        {
            _context.MessageRepoMock.Setup(x => x.Save(It.IsAny<MessageDTO>())).Returns<MessageDTO>(x => x);
            _context.Result = _context.MessageServise.SaveNewEmail(_context.InitReceivedMessage);
        }

        [When(
            @"It should set Primary-ID \(message-id\) as a unique message identifier from Email Header\(The first reference\)"
            )]
        public void WhenItShouldSetPrimary_IDMessage_IdAsAUniqueMessageIdentifierFromEmailHeaderTheFirstReference()
        {
            Assert.IsTrue(((MessageDTO)_context.Result).PrimaryId.Equals(_context.InitReceivedMessage.References[0]));
        }

        [When(@"It should set Primary-ID \(message-id\) as a unique message identifier from Email Header\(Message-ID\)")
        ]
        public void WhenItShouldSetPrimary_IDMessage_IdAsAUniqueMessageIdentifierFromEmailHeaderMessage_ID()
        {
            Assert.IsTrue(((MessageDTO)_context.Result).PrimaryId.Equals(_context.InitReceivedMessage.MessageId));
        }
    }
}
