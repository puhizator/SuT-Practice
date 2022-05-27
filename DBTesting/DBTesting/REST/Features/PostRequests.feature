Feature: PostRequests

A short summary of the feature

@deleteSingleUser
Scenario: Create single test user
	When I execute POST request with new test user
	Then I should see succesfully created user

@deleteSingleUser
	Scenario: Create single user from data table
	When I execute POST request with new user
	Then I should see succesfully created user
	Examples: 
	|  |  |  |  |  |  |  |  |  |
	|  |  |  |  |  |  |  |  |  |
