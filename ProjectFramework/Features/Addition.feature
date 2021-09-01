Feature: Addition
   Simple Addition of two numbers using calculator App


@mytag
Scenario: Verify user is able to add two numbers
	Given I launch the application
	When I add '2' and '4'
	Then I should see result '6'
	

