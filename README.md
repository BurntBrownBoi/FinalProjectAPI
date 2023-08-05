# FinalProjectAPI
Final project for contemporary programming course
Develop a ASP.NET WebAPI, using Git as a code repository. Each member of your team should have at least one commit to the project. I would recommend splitting the project into equal parts (the best you can). The WebAPI should conform to the following specifications.


• Use latest version of dotnet (6 or newer)
• Connect to a database using Entity Framework Core - Code First Approach
• The API should consist of four controllers. Each attaching to its own table


At least one of the tables should consist of the following information:
▪ Team member full name
▪ Birthdate (datetime)
▪ College Program
▪ Year in program: Freshman, Sophomore, etc.

3 other tables are your choice. Hobby, favorite breakfast foods, etc. Foreign key relationships not needed. But each table must consist of at least 5 columns, including the primary key column.

Each Controller should consist of all CRUD operations to interact with the underlying table (Create, Read [single or multiple, see below], Update, Delete).


The Read operation for each method should take in a nullable id (int). If null or zero is provided for the id, return the first five results from the table.
• Use NSwag package library as a means to view each controller and its actions
