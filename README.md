# MovieCharactersAPI
This repository contains a implementation of a Web API using ASP.NET Core and Entity Framework Code First for managing movie characters data. It was developed as part of the Experis Academy program and was implemented using C# programming language with Visual Studio as the Integrated Development Environment (IDE).

## Overview
In  Web API for managing data about movie characters. The API provides endpoints to create, read, update and delete movies, characters, and franchises. The project uses Entity Framework Code First to create the database and the ASP.NET Core framework to build the Web API.

### Entity Framework Code First
The project uses Entity Framework Code First to create the database. The following models and DbContext are implemented:

- Movie
- Character
- Franchise
- MovieCharactersDbContext


### Web API
The project includes a Web API implemented using ASP.NET Core. The following controllers and DTOs are implemented:

- MovieController
- CharacterController
- FranchiseController
- MovieDto
- CharacterDto
- FranchiseDto

Each domain entity (Movie, Character, and Franchise) is encapsulated in a service that interacts with the DbContext. Swagger/Open API documentation is available using annotations. Each method is documented using summary tags that explain what the method does, any exceptions it can throw, and what data it returns (if applicable).

## Getting Started
To get started with this project, follow the steps below:

1. Clone this repository.
2. Open the solution file (MovieCharactersApi.sln) in Visual Studio.
3. Open the Package Manager Console and run the following command: ```Update-Database``` to create the database
4. Build and run the project.

### Made by: Filip Lindell and Tintin Petersson
