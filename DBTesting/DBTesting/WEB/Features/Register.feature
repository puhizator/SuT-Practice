@web
Feature: Register

Scenario: Successful registration with new user
    Given I navigate to registration page
    When I enter the following data for registration:
    | FirstName | SirName | Email        | Password | Country  | City    |
    | John      | Doe     | RANDOM_EMAIL | pass123  | Bulgaria | Plovdiv |
    And I check agreement
    And I click on register button
    Then I should see Welcome user message
    
Scenario: Unsuccessful registration with existing user
    Given I navigate to registration page
    When I enter the following data for registration:
      | FirstName | SirName | Email                | Password | Country  | City    |
      | John      | Doe     | admin@automation.com | pass123  | Bulgaria | Plovdiv |
    And I check agreement
    And I click on register button
    Then I should see error message for existing user