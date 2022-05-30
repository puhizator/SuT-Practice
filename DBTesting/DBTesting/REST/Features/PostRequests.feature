Feature: PostRequests


@deleteSingleUser
Scenario: Create single test user
	When I execute POST request with new test user
	Then I should see succesfully created user

@deleteSingleUser
	Scenario: Create single user from data table
	When I execute POST request with the following user
	| title | isAdmin | firstName | sirName | email             | password | country  | city  |
	| Mr.   | 0       | Test      | Test    | qa@automation.com | pass123  | Bulgaria | Sofia |
	Then I should see succesfully created user

