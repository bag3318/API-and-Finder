[comment]: # (Start markdown README.md script)

APIforFinder
============

About this API
--------------

> This API is an ASP.net RESTful Web API. This API will be the middleman between the database and the webpage.

### Methods

<span>The 4 methods of HTTP are:</span>
[//]: # (Start markdown table)
<!--
| GET                  | POST                 | PUT                  | REMOVE               |
|----------------------|----------------------|----------------------|----------------------|
| Sends a GET request  | Sends a POST request | Sends a PUT request  | Sends a REMOVE       | 
| to the database to   | to add data to the   | to change or update  | request to delete    |
| retrieve all data    | database             | data in the database | data from the        |
| from the database    |                      |                      | database             |
-->
| GET | POST | PUT | REMOVE |
|-------------|-------------|-------------|-------------|
| Sends a GET request to the database to retrieve all data from the database | Sends a POST request to add data to the database | Sends a PUT request to change or update data in the database | Sends a REMOVE request to delete data from the database |           
[//]: # (End markdown table)
> I use these methods to add, remove, push, or retrieve data in my web API.


### SQL

> I used MySQL Database, with Maria DB in the MySqlWorkbench application on windows. Additionaly, I used stored procedures for the POST, PUT, & REMOVE requests.

### Visual Studio

> I also used Visual Studio Express for Web on windows to create this ASP.net web API.

[comment]: # (End markdown README.md script)