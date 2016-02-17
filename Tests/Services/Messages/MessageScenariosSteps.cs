using Moq;
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

        [Given(@"The first reference is exist")]
        public void GivenTheFirstReferenceIsExist()
        {
            _context.InitReceivedMessage.References = _context.References;
        }

        [When(@"It should check by the first reference")]
        public void WhenItShouldCheckByTheFirstReference()
        {
            _context.MessageRepoMock.Verify(x => x.CheckByFirstReference(It.IsAny<string>()), Times.Once);
        }

    }
}
