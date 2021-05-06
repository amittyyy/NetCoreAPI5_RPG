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

6. Install Entity Framework 
    #dotnet add package Microsoft.EntityFrameWorkCore.SqlServer
    #dotnet add package microsoft.EntityFrameworkCore.Design
    - Install Entity Framework Tool
        #dotnet toll install --global dotnet-ef
        #dotnet tool uninstall --global dotnet-ef
7. Code First Approach dotnet Migration
        #dotnet ef migrations add initialCreate
            - Now you can see Migrations folder.
            - Add the table and database in Sql Server. In my case Azure/SqlServer Database
            #dotnet ef database update
        <b>Possible Errors</b>
        -   <font color="red">Error Number:40615,State:1,Class:14
            Cannot open server 'amity-dbserver' requested by the login. Client with IP address '72.80.238.99' is not allowed to access the server.  To enable access, use the           Windows Azure Managemen  t Portal or run sp_set_firewall_rule on the master database to create a firewall rule for this IP address or address range.  It may take up          to five minutes for this change to take effect. </font>

        - Solution:-  <font color="red"> Go to Azure Data and setup IP address by clicking 4th tab on top bar.</font>