Feature: Label Print

A short summary of the feature
@ignore
Scenario: Create Label Type
	Given the user is on the Label Design Page
	When the user clicks on label Types
	And the user clicks on New and Fills out the mandatory fields 
	Then the user should see the new label type populate in the Popup list

@ignore
Scenario: Edit Label Type
	Given the user is on the Label Design Page
	And a Label Type exists
	When the user clicks on label Types
	And the user selects an existng Label Type
	And the user clicks on edit to edit the existing Label Type
	Then the user should see the existing label type updated with the edited information

@ignore
Scenario: Delete Label Type
	Given the user is on the Label Design Page
	And a Label Type exists
	When the user clicks on label Types
	And the user selects an existng Label Type
	And the user clicks on Delete
	Then the user should see the existing label type removed from the Popup list



@ignore
Scenario: Create New Label Design
	Given the user is on the Label Design Page
	And a Label Type exists
	When the user creates a New Label Design by clicking the New Button and completing the fields
	Then the user should see the New Label Design populate in the Label Design Table

@ignore
Scenario: Edit Label Design
	Given the user is on the Label Design Page
	And a Label Design exists
	When the user edits an existing Label Design by clicking the Edit Button and changing the fields
	Then the user should see the existing Label Design updated with the new information

@ignore
Scenario: Upload a Template to a Label Design
	Given the user is on the Label Design Page
	And a Label Design exists
	When the user selects an Existing Label Design and Uploads a Label Template
	Then the table should update with the Label File Name

@ignore
Scenario: Create a New Version of Exisitng Label Design via Copy
	Given the user is on the Label Design Page
	And a Label Design exists
	When the user selects an Existing Label Design and click on New Version Copy
	Then FIND OUT INFO

@ignore
Scenario: Create a New Version of Exisitng Label Design via Blank
	Given the user is on the Label Design Page
	And a Label Design exists
	When the user selects an Existing Label Design and click on New Version Copy
	Then FIND OUT INFO

@ignore
Scenario: Delete Label Design with 1 Version
	Given the user is on the Label Design Page
	And a Label Design exists with 1 Version
	When the user deletes an existing Label Design by clicking the delete Button 
	Then the user should see the existing Label Design removed from the list

@ignore
Scenario: Delete Label Design with Multiple Versions view Show Latest
	Given the user is on the Label Design Page
	And a Label Design exists with Multiple Versions
	And User is on Show Only Latest Version
	When the user deletes an existing Label Design by clicking the delete Button 
	Then the user should see the latest version deleted Regressing the Version to the previous version

@ignore
Scenario: Delete Label Design with Multiple Versions view Show All
	Given the user is on the Label Design Page
	And a Label Design exists with Multiple Versions
	And User is on Show All
	When the user deletes an existing Label Design by clicking the delete Button 
	Then the user should see that version deleted if it is the latest then label design regresses to the previous version


@ignore
Scenario: Print Through Stock Items
	Given the user is on the Stock Items
	When the user searches for a Stock Item
	And the user selects an Item and click Print
	Then the user should see that Item is added to the Label Print Queue

@ignore
Scenario: Print Through Item Status
	Given the user is on the Item Status
	When the user searches for a Item Status
	And the user select an Item and click Print
	Then the user should see that Item is added to the Label Print Queue

@ignore
Scenario: Reprint in Label Print Queue
	Given the user is on the Label Print Queue Page
	When the user searches for a Item in the Queue
	And the user select an Item and click Reprint
	Then the user should see that Item is added to the Label Print Queue


#	@Manual
#Scenario: Create, Edit and Delete Label Type
#	Given the user is on the Label Design Page
#	When the user clicks on label Types
#	And the user clicks on New and Fills out the mandatory fields
#	And completing the Popup the new Label Type should be in the List
#	And the user clicks on edit to edit the existing Label Type
#	And edited the user sees the updated Label Type in the list and clicks Delete
#	Then the user should see the existing label type removed from the Popup list