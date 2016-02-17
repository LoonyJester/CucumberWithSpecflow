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
            _context.InitReceivedMessagen.References = null;
        }

        [Then(@"We start to found a message")]
        public void ThenWeStartToFoundAMessage()
        {
            _context.Result = _context.MessageServise.CheckFirstReference(_context.InitReceivedMessagen);
        }

        [When(@"It shouldn't check first reference")]
        public void WhenItShouldnTCheckFirstReference()
        {
            _context.MessageRepoMock.Verify(x => x.CheckByFirstReference(It.IsAny<string>()), Times.Never);
        }
    }
}
