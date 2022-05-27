Feature: PostRequests

A short summary of the feature

@deleteSingleUser
Scenario: Create single test user
	When I execute POST request with new test user
	Then I should see succesfully created user

@deleteSingleUser
	Scenario: Create single user from data table
	When I execute POST request with new user
	| title   | isAdmin   | firstName   | sirName   | email   | password   | country   | city   |
	| <title> | <isAdmin> | <firstName> | <sirName> | <email> | <password> | <country> | <city> |
	Then I should see succesfully created user
	
	
	Examples: 
	| title | isAdmin | firstName | sirName | email             | password | country  | city  |
	| Mr.   | 0       | Test      | Test    | qa@automation.com | pass123  | Bulgaria | Sofia |
