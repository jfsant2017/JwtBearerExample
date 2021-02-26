# Jwt Bearer Example

This project demonstrates the use of Jwt Bearer with RestAPI.

After register two users and two roles (manager and employee) calling the `HomeController.cs` they are registered inside the SQL Server In Memory database for further requests.

It is possible to validate the profiles access through Restricted Access request (`/content`).

Both users are registered and available for testing.

* [/content/public][3] available for all authenticated or not;
* [/content/manager][3] available only for a manager role;
* [/content/employee][3] available only for a employee role;
* [/content/authenticated][3] available for both manager and employee roles;
* [/user/login][2] (Post Method) with user and password, if correct will return a token that can be used for restricted contents;

The tests using xUnit for those requests are available in [JwtBearerExample.Tests][1]


[1]: https://github.com/jfsant2017/JwtBearerExample.Tests
[2]: https://github.com/jfsant2017/JwtBearerExample/blob/main/Controllers/UserController.cs
[3]: https://github.com/jfsant2017/JwtBearerExample/blob/main/Controllers/RestrictedAccessController.cs
