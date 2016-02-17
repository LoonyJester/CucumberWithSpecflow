Feature: MessageScenarios

@MessageScenarios @CheckFirstReference
Scenario: The first reference don't exist
	Given We have a received email
	And A the first reference is null or empty 
	Then We start to found a message
	When It shouldn't check first reference
