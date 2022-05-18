@DB
Feature: AddEntities

Add entity to DB

@deleteEntity
Scenario: AddSingleEntity
	When I add single Entity
	Then I should be able to see that user in DB
