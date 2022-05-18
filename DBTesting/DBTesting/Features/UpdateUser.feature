@DB
Feature: UpdateUser

Create and update user

@deleteEntity
Scenario: Update user first name
	Given I have already created user
	When I update his first name to "David"
	Then I should see his first name changed
