1. Project Requirements
    #DotNet 5.0
    #swagger 5.0
2. Create new web api project 
    #dotnet new webapi
3. Create Git Ignore
    #dotnet new gitignore

Note:- Dependency Injection 
    #Transient objects are always different; a new instance is provided to every controller and every service.
    #Scoped objects are the same within a request, but different across different requests.
    #Singleton objects are the same for every object and every request.

4. <b>Install AtutoMapper</b>
    AutoMapper is a simple library that helps us to transform one object type to another. It is a convention-based object-to-object mapper that requires very little configuration. 

    The object-to-object mapping works by transforming an input object of one type into an output object of a different type.

    #dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection

5. <b>How to Add Logger</b>
    #dotnet add package Microsoft.Extensions.Logging