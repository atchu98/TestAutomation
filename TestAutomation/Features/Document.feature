Feature: Document

A short summary of the feature

@Smoke
Scenario: Upload a single Document
	Given I have successfully logged in
	When I go to the Document Manager
	And I upload a document
	Then the document should be available in the Document Manager
	And Delete the test document

@Manual
Scenario: Upload a Single Data File
	Given I have successfully logged in
	When I go to the Data File Manager
	And I upload a single data file
	Then the file should be available in the Data File Manager

@ignore
Scenario: Upload Multiple Data Files
	Given I have successfully logged in
	When I go to the Data File Manager	
	And I upload a multiple data files
		| FileName |
		| txt      |
		| png      |
		| etc      |
	Then the file should be available in the Data File Manager