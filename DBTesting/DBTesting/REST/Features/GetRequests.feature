Feature: GetRequests


@rest
Scenario: Get all users

	When I perform get request to all users
	Then I should receive response code 200 with message 'OK'


Scenario: Get single user

	When I perform get request to user with id <id>
	Then I should receive response code 200 with message 'OK'
	And I should see user email '<email>'
Examples:
	| id | email                   |
	| 3  | yivanova@automation.com |