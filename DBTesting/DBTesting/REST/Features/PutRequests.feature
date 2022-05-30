Feature: PutRequests


@deleteSingleUser
	Scenario: Update single user from data table
	Given I have existing user
	| title | isAdmin | firstName | sirName | email             | password | country  | city  |
	| Mr.   | 0       | Test      | Test    | qa@automation.com | pass123  | Bulgaria | Sofia |
	When I execute PUT request with the following user
	| title | firstName | sirName | email        | country  | city   |
	| Mr.   | Updated   | User    | new@test.com | Bulgaria | Burgas |
	Then I should see succesfully updated user