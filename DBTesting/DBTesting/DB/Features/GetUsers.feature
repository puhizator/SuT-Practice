@DB
Feature: GetUsers


Scenario: Get all users
	When Get all users
	Then I should be able to see list of all users


Scenario: Get single user by ID
	When Get single user by ID <id>
	Then I should see user with ID <id>
Examples:
	| id |
	| 3  |


Scenario: Get first user
	When Get first user
	Then I should see first user


Scenario: Get user by particular email
	When I Get user by email '<email>'
	Then I should see user with the same '<email>'
Examples:
	| email                |
	| admin@automation.com |


Scenario: Get user by email containing phrase
	When Get users by email containing '<phrase>'
	Then I should see all users that contain this '<phrase>' in their emails
Examples:
	| phrase     |
	| automation |