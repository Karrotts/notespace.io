# Notespace.io (Active Project)
Markdown Note Taking Application

## Table Of Contents
1. [Concept](https://github.com/Karrotts/notespace.io#concept)
2. [Database Diagram](https://github.com/Karrotts/notespace.io#database-diagram)
3. [Draft Wireframe](https://github.com/Karrotts/notespace.io#draft-wireframe)
4. [Requirements](https://github.com/Karrotts/notespace.io#requirements)
	1. [User Stories]()
	2. [Use-Cases]()
	3. [Use-Case Diagram]()
	4. [Individual Requirements]()
5. [Test Planning & RTM]()  

## Concept
Note taking is an important aspect of learning any kind of material, it allows you to look back at important topics or sections in which you may struggle with. Taking notes allows you to write material into your own words which helps with retaining the information you have learned. A major problem with most note taking applications is formatting the information in a clear concise manner. This application attempts to solve that by allowing users to quickly transform notes into a well formatted documents using Markdown.

[Back To Top](https://github.com/Karrotts/notespace.io#table-of-contents)

## Database Diagram
![Database Diagram](/database/ERD.png)

# Draft wireframe
#### Login Page
![Login Page](/wireframe/login.png)
#### Home Page
![Home Page](/wireframe/home.png)
#### Notebook Edit Page
![Notebook Edit](/wireframe/edit.png)
#### Notebook View Page
![Notebook View](/wireframe/view.png)
#### Discover Page
![Discover Page](/wireframe/discover.png)

## Requirements
## User stories
* As a student, I need website where I can view, store, and edit my markdown formatted notes, so that I can convienently access them from anywhere.
* As a developer, I need to write documentation for a code project and be able to link my documentation together, so that other developers can view the documentation in a clear consise format.
* As a life-long learner, I want a website where I can view other peoples notes, so that I can learn from other peoples experiences.

## Use Cases
* Given a new user, when logging into the site, then ask the user to register for a new account.
* Given a registered user and on the home page, when selecting new notebook, then display the new notebook window.
* Given a registered user and on the home page, when selecting new note, then display the new note window.
* Given a registered user and a notebook, when viewing the notebook and click on edit, then display the edit screen to the user.
* Given a registered user and on the edit notebook screen, when clicking the save button, save plaintext file to server.
* Given a registered user and a note, when viewing the note and click on edit, then display the edit screen to the user.
* Given a registered user and on the edit note screen, when clicking the save button, save plaintext file to server.
* Given a admin user, when logging into the site, they are brought to the manage users screen.

## Use-Case Diagram (UML)
![UML](/requirements/uml.png)

## Individual Requirements
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
6. The system shall allow the user to edit created notes.
	1. The system shall show a pencil icon for edit.
	2. The system shall show an edit screen when the icon is clicked on.
		1. The system shall allow the user to change the notebook name.
		2. The system shall allow the user to save changes to the database.
7. The system shall allow the user to delete created notebooks.
	1. The system shall show a trash can icon for delete.
	2. The system shall show a delete screen when the icon is clicked on.
		2. The system shall delete entry from database.
8. The system shall allow the user to delete created notes.
	1. The system shall show a trash can icon for delete.
	2. The system shall show a delete screen when the icon is clicked on.
		2. The system shall delete entry from database.
9. The system should provide a way to view public notes.
	1. The system shall show a screen which shows all publically viewable notebooks.
		1. The system shall sort notebooks by the most recently modified notebooks.
10. The system should provide a way to search for public notes.
	1. The system shall display a search bar.
		1. The system shall allow the user to search by username.
		2. The system shall allow the user to search by notebook name.
 
