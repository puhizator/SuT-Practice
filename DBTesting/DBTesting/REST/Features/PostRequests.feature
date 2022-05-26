Feature: PostRequests

A short summary of the feature

@Rest
Scenario: Create single user
	When I execute POST request with default user
	Then I should see succesfully created user
