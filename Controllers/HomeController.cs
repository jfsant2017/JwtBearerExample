using System.Threading.Tasks;
using JwtBearerExample.Data;
using JwtBearerExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JwtBearerExample.Controllers
{
    public class HomeController: Controller
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<dynamic>> Get([FromServices] DataContext context)
        {
            var roleManager = new Role { ID = 1, Name = "Manager" };
            var roleEmployee = new Role { ID = 2, Name = "Employee" };

            var userManager = new User { ID = 1, Name = "Manager User", Login = "manager_1", Password = "123456", Role = roleManager };
            var userEmployee = new User { ID = 2, Name = "Employee User 1", Login = "user_1", Password = "654321", Role = roleEmployee };

            dynamic existData = await context.Roles.FirstOrDefaultAsync(x => x.ID == roleManager.ID);
            if (existData == null)
                context.Roles.Add(roleManager);

            existData = await context.Roles.FirstOrDefaultAsync(x => x.ID == roleEmployee.ID);
            if (existData == null)
                context.Roles.Add(roleEmployee);

            existData = await context.Users.FirstOrDefaultAsync(x => x.ID == userManager.ID);
            if (existData == null)
                context.Users.Add(userManager);

            existData = await context.Users.FirstOrDefaultAsync(x => x.ID == userEmployee.ID);
            if (existData == null)
                context.Users.Add(userEmployee);

            await context.SaveChangesAsync();

            return Ok( new { message = "Initial data configured." });
        }
    }
}