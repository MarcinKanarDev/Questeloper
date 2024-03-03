# Questeloper

Welcome to Questeloper Web Application repository, I'm glad you visited. This repository was created as part of the **100 commits** initiative, if you want to see the projects of others, see link  -https://100commitow.pl/repozytoria

<p align="center">
  <a >
    <img src="./assets/logo.png"
         alt="Screenshot">
  </a>
</p>

# About project

Questeloper is an application that aims to facilitate the preparation for an interview (mainly technical) for IT professionals. As a user, you will be faced with questions that will involve defeating a virtual opponent which will be specific programming and technical areas. Authorization, architecture, data structures are the opponents you will have to face. Create your own hero, gain experience and acquire new skills to help you overcome challenges. In the first release of the application, you will have the opportunity: 
- Create an account and a hero from a given frontend/backend/tester class
- Preview of the categories, areas, and opponents you will fight
-  Fight your opponent by answering his questions a given area (in the form of questions and answers from technical talks)
	 > **Note:** For example, we choose the area of object-oriented programming where we hit the opponent "Inheritance" (Sick!). We enter a virtual clash with him where to defeat him we have to answer his set of questions in this topic 
- Gain experience for overcoming a challenge, advance a character, check combat stats
- Compare yourself with other users at a similar level, or check the global ranking

# 100 commits - Delivery plan 
Below you can see the planned scope of delivery of parts of the application and the assumptions to be realized within ~ 3 months of work
> **Note** Depending on time, possible contributors and progress, the scope may expand or change a little bit. 

**First month delivery - backend part**
The first stage involves the delivery of the server part of the application
- Basic structure of the project on the backend side
- Providing communication with the database
- Provide communication with the API and perform basic operations on resources
- Enable account creation and user authentication in the application 
- Depending on the remaining time - refactoring, unit and integration tests

**Second month delivery - frontend part**
The second stage involves providing the client part of the application
- Create basic views and application components on the client side of the API
- Develop a system for logging, storing and managing authorization tokens
- Connecting communication with the server
- Hadle reqeuests and responses to server and enabling client-side operations
- Time dependent - Refinement of views, architecture review, refactoring
> **Note** Probably the most challenging part due to low experience inTypeScript and Angular

**Third month delivery - technical details and buffer**
The third stage in the first instance assumes a time buffer for the delivery of requirements before the official end of the initiative. If the core business assumptions can be delivered on time, the remaining time will be used for technical details and implementation of additional technologies
- Containerization of applications using docker
- Advanced application log management with Elasticsearch and kibana deployment
- Trying and learning how to deploy an application to a cloud system
- Preparing a plan and learning how to implement CI/CD (Github Actions)


# Technology stack

**Backend side**
- C# and .NET 8
- Clean Architecture
- Entity Framework Core with PostgreSQL database
- CQRS with MediatR
- FluentValidation
- Minimal API
- Serilog
- XUnit, NSubstitute, Shouldly, TestContainers
- Swagger for API documentation

**Frontend side**
- TypeScript
- HTML and CSS
- Angular 17
- NodeJS

**Others**
- Docker

# Application Overwiev
//todo

# Build and run project
//todo

# Information for contributors
//todo