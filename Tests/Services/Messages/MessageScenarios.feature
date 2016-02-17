Feature: MessageScenarios

@MessageScenarios @CheckFirstReference
Scenario: The first reference don't exist
	Given We have a received email
	And A the first reference is null or empty 
	Then We start to found a message
	When It shouldn't check first reference

@MessageScenarios @CheckFirstReference
Scenario: The  first reference exists
	Given We have a received email
	And The first reference is exist
	Then We start to found a message
	When It should check by the first reference

@MessageScenarios @CheckFirstReference
Scenario: The first reference exists and a message has been found in db by the first reference and the ticket Id is greater that zero
	Given We have a received email
	And The first reference is exist
	Then A message has been found by the first the first reference and the ticket Id is greater that zero
	And We start to found a message
	When It should return a message

@MessageScenarios @CheckFirstReference
Scenario: A message hasn't been found by the first reference and it should check by the message Id
	Given We have a received email
	And The first reference is exist
	Then A message hasn't been found by the first reference
	And We start to found a message
	When It should check by the message Id

@MessageScenarios @CheckFirstReference
Scenario: A message has been found by the first reference but ticket Id is equal zero and it should check by the message Id
	Given We have a received email
	And The first reference is exist
	Then A message has been found by the first reference and the ticket Id is equal zero
	And We start to found a message
	When It should check by the message Id

@MessageScenarios @CheckFirstReference
Scenario: A message hasn't been found by the first reference but has been found by the message Id and ticket id greater zero
	Given We have a received email
	And The first reference is exist
	Then A message hasn't been found by the first reference
	And A message has been found by the message Id and the ticket id greater zero
	And We start to found a message
	When It should return a message

@MessageScenarios @CheckFirstReference
Scenario: A message hasn't been found by the first reference but has been found by the message Id and ticket Id is equal zero
	Given We have a received email
	And The first reference is exist
	Then A message hasn't been found by the first reference
	And A message has been found by the message Id and the ticket Id is equal zero
	And We start to found a message
	When It should return null

@MessageScenarios @CheckFirstReference
Scenario:  A message has been found neither by the first reference nor by a message Id
	Given We have a received email
	And The first reference is exist
	Then A message hasn't been found by the first reference
	And A message hasn't been found by the message Id
	And We start to found a message
	When It should return null

@MessageScenarios @SaveReceivedEmail
Scenario: Message exists, received email has references and we return it
	Given We have a received email
	And The first reference is exist 
	Then A message with the specific message Id exists
	And We start to save a message
	When It should set Primary-ID (message-id) as a unique message identifier from Email Header(The first reference)
	And It should set Message-ID as a unique message identifier from Email Header
	And It should set Email message content from the reseived message
	And It should set timestamp from the reseived message
	And It should update the message
	And It should return the massage


@MessageScenarios @SaveReceivedEmail
Scenario: Message don't exist, received email has references  and we return it
	Given We have a received email 
	And The first reference is exist
	Then A message with the specific message Id doesn't exist
	And We start to save a message
	When It should set Primary-ID (message-id) as a unique message identifier from Email Header(The first reference)
	And It should set Message-ID as a unique message identifier from Email Header
	And It should set Email message content from the reseived message
	And It should set timestamp from the reseived message
	And It should save the message
	And    It should return the massage 

	@MessageScenarios @SaveReceivedEmail
Scenario: Message exists, received email hasn't references and we return it
	Given We have a received email 
	Then A message with the specific message Id exists
	And We start to save a message
	When It should set Primary-ID (message-id) as a unique message identifier from Email Header(Message-ID)
	And It should set Message-ID as a unique message identifier from Email Header
	And It should set Email message content from the reseived message
	And It should set timestamp from the reseived message
	And It should update the message
	And It should return the massage


@MessageScenarios @SaveReceivedEmail
Scenario: Message don't exist, received email hasn't references and we return it
	Given We have a received email 
	Then A message with the specific message Id doesn't exist
	And We start to save a message
	When It should set Primary-ID (message-id) as a unique message identifier from Email Header(Message-ID)
	And It should set Message-ID as a unique message identifier from Email Header
	And It should set Email message content from the reseived message
	And It should set timestamp from the reseived message
	And It should save the message
	And    It should return the massage 