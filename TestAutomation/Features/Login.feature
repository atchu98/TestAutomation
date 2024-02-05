Feature: Login

A short summary of the feature

@Sanity @1
Scenario: (Non SSO) Check Login Fields
	Given I launch my browser and go to the login page
	When I click login with the Mestec Account
	Then I move to the page to login using Mestec account

@Smoke
Scenario: Successful login using Mestec Account (Non SSO)
	Given I launch my browser and go to the login page
	When I login with the Mestec Account
	Then I go to the home screen



@Sanity @1
Scenario: Try Logging in with Incorrect Username & Password
        Given I launch my browser and go to the login page
        When I try to login  to Mestec with wrong details
            | Username   | Password    |
            | iPhone     | Electronics |
            | Laptop     | Electronics |
            | Headphones | Electronics |
        Then I should see error message

@ignore
Scenario: Login and change Shift
        Given I launch my browser and go to the login page
	    When I login with the Mestec Account
        And I change my shift
	    Then the shift changes

@Sanity
Scenario: Login and Logout
        Given I launch my browser and go to the login page
	    When I login with the Mestec Account
        And I Logout
	    Then I am on the Login Page

@Sanity @2
Scenario: Login and Logout then login again to check Shift has not changed
        Given I launch my browser and go to the login page
	    When I login with the Mestec Account
        And I Logout
	    Then I am on the Login Page

