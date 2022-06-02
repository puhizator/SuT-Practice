@web
Feature: Login 

Scenario: Successful login with existing user
	Given I navigate to login page
	When I enter username '<email>' and password '<password>'
	And I click on login button
	Then I should see Welcome user message
Examples:
	| email                | password |
	| admin@automation.com | pass123  |	
	
Scenario: Unsuccessful login with unexisting user
	Given I navigate to login page
	When I enter username '<email>' and password '<password>'
	And I click on login button
	Then I should see error message
Examples:
  	|email           | password |
  	|nonono@mail.com | pass999  |
