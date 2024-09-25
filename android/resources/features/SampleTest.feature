@sample-test
Feature: BStack Sample
	Scenario Outline: Can search wikipedia
		Given I open the App
		Then I click on search wikipedia
		Then I enter 'BrowserStack'
		When I check if products are opened
		Then I should see same product in cart
