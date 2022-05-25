@DB
Feature: AddEntities

Add entity to DB

@deleteSingleEntity
Scenario: AddSingleEntity
	When I add single Entity
	Then I should be able to see that user in DB

@deleteMultipleEntities
Scenario: AddMultipleEntities
	When I add multiple entities
	Then I should be able to see all of the users in DB

