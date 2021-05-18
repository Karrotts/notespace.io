<p align="center">
  <img src="https://github.com/Karrotts/notespace.io/blob/main/doc/wireframe/notespace%20logo.JPG?raw=true">
</p>
<h1 align="center"><strong>Final Project Review</strong><br></h1>
<p align="center"><a align="center" href="https://notespace.io">Check out the site!</a></p>

## What is Notespace?
Notespace is a note taking web application that uses Markdown to create strongly formatted notes, and notebooks. The application was inspired by my love and curiosity of Markdown and my strive to learn more on how to parse data. I built a custom Markdown-to-HTML class library in C# called ConvertMarkdown (you can find it [here](https://github.com/Karrotts/ConvertMarkdown)) which was the most challenging part of building this application.
## Notespace Throughout the SDLC
### Planning & Analysis
During the planning and analysis phase of the SDLC, I gathered my requirements for my application. As the product owner it was my job to decide on what features I wanted for this application. I knew I needed a login system since everyone needs to keep track of their own notes and notebooks, so no one modifies their documents. I also knew that I had to create my own Markdown-to-HTML converter for my application to work. I gathered all the must have requirements and formed a requirements list. You can find my requirements for this application [here](https://github.com/Karrotts/notespace.io#requirements).
### Design
The design of the application was also one of the most difficult parts of this project. I have had prior experience in web development and web design, and I really wanted to challenge myself to create the best-looking site I could. I followed as many standards as I could when designing the site like maintaining consistent spacing and using relative values to make sure my application fits any size screen.

![phases](https://github.com/Karrotts/notespace.io/blob/main/doc/prototype/images/phases.JPG?raw=true)

As illustrated above, the design for my project went through many different changes, from color scheme to elements on a page. I changed plans from my initial wireframe after doing several iterations of design reviews with family and friends. They pointed out many UI and UX issues which I changed and modified in the final project.

[Link to Wireframes](https://github.com/Karrotts/notespace.io#draft-wireframe)

[Link to Prototype](https://github.com/Karrotts/notespace.io/tree/main/doc/prototype)

### Implementation
The first part I developed for the project before touching any of the web development is creating the Markdown-to-HTML converter. I created the converter which supports the basic implementation of Markdown. Once it met my basic requirements for it, I moved on to developing the website using ASP.NET MVC. I utilized the code-first approach with Entity Framework which allowed me to create class models in C# which are then migrated into a SQL Server database. I then implemented identity and scaffolded out my database tables. I modified those pages to meet the requirements of my application.

### Testing
During the testing phase I tested my application on the initial tests I created for my application to meet its minimal viable product state. The individual tests and completion dates can be found [here](https://github.com/Karrotts/notespace.io/tree/main/doc/prototype).

### Maintenance
After doing all of my testing I moved to my maintenance phase. During this phase I discovered many errors my application had. Some of these errors are simple, like UI scaling on mobile devices or more critical like a certain Markdown tag not working as intended.

## Lessons Learned
### What did I do right?
Overall I accomplished what I originally set out to accomplish, which was a site that uses Markdown to create structured notes and notebooks. Since I maintained site consistency I think I created one of my best looking sites I have ever created.

### What did I do wrong?
I really wish I spent more time on my Markdown-to-HTML converter. For the most part it does it's job but there is definitely room for improvement since there are still bugs in it and it is missing many of the extended features which would be really nice to have.

### Where was I lucky?
Since there wasn’t too much I needed to change (code-wise) from the scaffolded pages, I didn’t need to spend as much time doing any backend development.

### What would I change?
As previously mentioned, I would add some features to my Markdown-to-HTML converter. Additionally, there is not really any account management pages so if a user forgets their password, there is no way currently of recovering that or changing their password. I would have also liked to create user pages where you could see information about certain users like seeing what public notes/notebooks that user has posted.


