<p align="center">
  <img src="https://github.com/Karrotts/notespace.io/blob/main/doc/wireframe/notespace%20logo.JPG?raw=true">
</p>
<p align="center">Markdown note taking application</p>

## Table Of Contents
1. [Concept](#concept)
2. [Database Diagram](#database-diagram)
3. [Draft Wireframe](#draft-wireframe)
4. [Requirements](#requirements)
	1. [User Stories](#user-stories)
	2. [Use-Cases](#use-cases)
	3. [Use-Case Diagram](#use-case-diagram)
	4. [Individual Requirements](#individual-requirements)
5. [Requirements And Test Methods](#requirements-and-test-methods)
6. [Tests](#tests)
7. [Prototype](https://github.com/Karrotts/notespace.io/tree/main/doc/prototype)
8. [Task List](#task-list)

## Concept
[Back To Top](https://github.com/Karrotts/notespace.io#table-of-contents)

Note taking is an important aspect of learning any kind of material, it allows you to look back at important topics or sections in which you may struggle with. Taking notes allows you to write material into your own words which helps with retaining the information you have learned. A major problem with most note taking applications is formatting the information in a clear concise manner. This application attempts to solve that by allowing users to quickly transform notes into a well formatted documents using Markdown.

## Database Diagram
[Back To Top](https://github.com/Karrotts/notespace.io#table-of-contents)

![Database Diagram](/doc/database/ERD.png)

# Draft wireframe
[Back To Top](https://github.com/Karrotts/notespace.io#table-of-contents)

#### Login Page
![Login Page](/doc/wireframe/login.png)
#### Home Page
![Home Page](/doc/wireframe/home.png)
#### Notebook Edit Page
![Notebook Edit](/doc/wireframe/edit.png)
#### Notebook View Page
![Notebook View](/doc/wireframe/view.png)
#### Discover Page
![Discover Page](/doc/wireframe/discover.png)

## Requirements
## User stories
[Back To Top](https://github.com/Karrotts/notespace.io#table-of-contents)

* As a student, I need website where I can view, store, and edit my markdown formatted notes, so that I can convienently access them from anywhere.
* As a developer, I need to write documentation for a code project and be able to link my documentation together, so that other developers can view the documentation in a clear consise format.
* As a life-long learner, I want a website where I can view other peoples notes, so that I can learn from other peoples experiences.


## Use Cases
[Back To Top](https://github.com/Karrotts/notespace.io#table-of-contents)

* Given a new user, when logging into the site, then ask the user to register for a new account.
* Given a registered user and on the home page, when selecting new notebook, then display the new notebook window.
* Given a registered user and on the home page, when selecting new note, then display the new note window.
* Given a registered user and a notebook, when viewing the notebook and click on edit, then display the edit screen to the user.
* Given a registered user and on the edit notebook screen, when clicking the save button, save plaintext file to server.
* Given a registered user and a note, when viewing the note and click on edit, then display the edit screen to the user.
* Given a registered user and on the edit note screen, when clicking the save button, save plaintext file to server.
* Given a admin user, when logging into the site, they are brought to the manage users screen.

## Use-Case Diagram
[Back To Top](https://github.com/Karrotts/notespace.io#table-of-contents)

![UML](/doc/requirements/uml.png)

## Individual Requirements
[Back To Top](https://github.com/Karrotts/notespace.io#table-of-contents)

1. The system shall provide a way to log into the site.
	1. The system shall display a login screen to the user
		1. The system shall verify the user has entered a username
		2. The system shall verify the user has entered the correct password for that user.
		3. The system shall update the user database entry of last logon with current time.
2. The system shall provide a way for a new user to register for the site.
	1. The system shall display a register user screen.
		1. The system shall verify the user has entered a unique username
		2. The system shall verify if the user has entered a secure password
		3. The system shall verify that a valid email was provided.
		4. The system shall create a new user in database if all information is valid
3. The system shall allow the user to create a new notebook.
	1. The system shall present a window to create a new notebook.
		1. The system shall show a text box to input the notebook name.
		2. The system shall show a selection of notebook colors.
		3. The system shall allow the user to mark the notebook as public or private.
		4. The system shall verify the information is correct.
		5. The system shall insert a new notebook into the database.
4. The system shall allow the user to create a new note.
	1. The system shall present a window to create a new note.
		1. The system shall show a text box to input the note name.
		2. The system shall verify the information is correct.
		3. The system shall insert a new note into the database.
5. The system shall allow the user to edit created notebooks.
	1. The system shall show a pencil icon for edit.
	2. The system shall show an edit screen when the icon is clicked on.
		1. The system shall allow the user to change the notebook name.
		2. The system shall allow the user to change the accessibility of the notebook.
		3. The system shall allow the user to change the color of the notebook.
		4. The system shall allow the user to save changes to the database.

## Requirements and Test Methods
[Back To Top](https://github.com/Karrotts/notespace.io#table-of-contents)

|ReqID|Requirement|test method|TestID|
|---|---|--|---|
|1. |The system shall provide a way to log into the site.|inspection| |
|1.1 |The system shall display a login screen to the user.|inspection| |
|1.1.1|The system shall verify the user has entered a username|test|1|
|1.1.2|The system shall verify the user has entered the correct password for that user.|test|2|
|1.1.3|The system shall update the user database entry of last logon with current time.|test|3|
|2. |The system shall provide a way for a new user to register for the site.|inspection| |
|2.1 |The system shall display a register user screen.|demonstration| |
|2.1.1|The system shall verify the user has entered a unique username|test|4|
|2.1.2|The system shall verify if the user has entered a secure password|test|5|
|2.1.3|The system shall verify that a valid email was provided.|test|6|
|2.1.4|The system shall create a new user in database if all information is valid|test|7|
|3. |The system shall allow the user to create a new notebook.|inspection| |
|3.1 |The system shall present a window to create a new notebook.|demonstration| |
|3.1.1|The system shall show a text box to input the notebook name.|test|8|
|3.1.2|The system shall verify the information is correct.|test|9|
|3.1.3|The system shall insert a new notebook into the database|test|10|
|4. |The system shall allow the user to create a new note.|inspection| |
|4.1 |The system shall present a window to create a new note.|demonstration| |
|4.1.1|The system shall show a text box to input the note name.|test|11|
|4.1.2|The system shall verify the information is correct.|test|12|
|4.1.3|The system shall insert a new note into the database.|test|13|
|5. |The system shall allow the user to edit created notebooks.|inspection| |
|5.1 |The system shall show an edit screen when the icon is clicked on.|demonstration| |
|5.1.1|The system shall allow the user to change the notebook name.|test|14|
|5.1.2|The system shall allow the user to change the accessibility of the notebook.|test|15|
|5.1.3|The system shall allow the user to save changes to the database.|test|16|

## Tests
[Back To Top](https://github.com/Karrotts/notespace.io#table-of-contents)

|testID|Req|Test proc|current|time|
|---|---|---|---|---|
|1|1.1.1|From the textbox, on submit, result should not be empty and contain only alphanumeric characters|not tested| |
|2|1.1.2|From the textbox, on submit, result should match hashed password in database to the appropriate user|not tested| |
|3|1.1.3|On form submit, user's last login date will be updated to current date/time|not tested| |
|4|2.1.1|From the textbox, on submit,result check if the user already exists in the database, render error information if they already exist.|not tested| |
|5|2.1.2|From the textbox, on submit, result check if the user has entered a password containing at least 8 characters, with at least 1 upper and 1 lowercase character|not tested| |
|6|2.1.3|From the textbox, on submit, check if the provided email address is in the correct format|not tested| |
|7|2.1.4|On submit, if information is valid in form, result should be a new user in the database. |not tested| |
|8|3.1.1|On form load, if user is logged in, display notebook name space or send to login page|not tested| |
|9|3.1.2|On form submit, result should validate provided data and correct any errors. |not tested| |
|10|3.1.3|On form submit, result should insert new notebook into database.|not tested| |
|11|4.1.1|On form load, if user is logged in, display note name space or send to login page|not tested| |
|12|4.1.2|On form submit, result should validate provided data and correct any errors.|not tested| |
|13|4.1.3|On form submit, result should insert new note into database.|not tested| |
|14|5.1.1|On form load, it should populate texbox with current notebook name, on submit result new name updated in database.|not tested| |
|15|5.1.2|On form load, it should populate on/off switch for public/private, on submit result, accessibility should be modified.|not tested| |
|16|5.1.3|On form submit result, if changes were made to data, update data in database.|not tested| |

