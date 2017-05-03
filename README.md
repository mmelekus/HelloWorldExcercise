# HelloWorldExcercise
Hello World excercise

## Summary
This project is based on the following brief requirements:

Write a ‘Hello World’ program. 
a.	The program has 1 current business requirement – write “Hello World” to the console/screen. 
b.	The program should have an API that is separated from the program logic to eventually support mobile applications, web applications, or console applications, or windows services. 
c.	The program should support future enhancements for writing to a database, console application, etc. 
    1.	Use common design patterns (inheritance, e.g.) to account for these future concerns. 
    2.	Use configuration files or another industry-standard mechanism for determining where to write the information to. 

Write unit tests to support the API.

## Technologies Used
* .NET Core
* ASP.NET Core
* Visual Studio 2017 Community Edition

## Solution Description
* Web API provides messages to display
* Console app displays messages retrieved from Web API

## Solution Architecture
Used repository pattern with a repository interface to allow replacing the data access component with a different data access source.
The data access source is loaded using IoC during the API startup configuration, with source settings being loaded from a JSON configuration file.
A service locator can be used in the future using configuration information to determine the correct DAL component, and load it using reflection and a builder pattern.
A file access DAL has been included for demonstration purposes.
