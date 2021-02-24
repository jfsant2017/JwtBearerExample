using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtBearerExample.Data;
using JwtBearerExample.Models;
using JwtBearerExample.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JwtBearerExample.Controllers
{
    [Route("user")]
    public class UserController: ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<User>>> Get (
            [FromServices] DataContext context
        )
        {
            var users = await context
                    .Users
                    .Include(x => x.Role)
                    .AsNoTracking().ToListAsync();
            return Ok(users);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate(
            [FromServices] DataContext context,
            [FromBody] User model)
        {
            var user = await context.Users
                .AsNoTracking()
                .Include(x => x.Role)
                .Where(x => x.Login == model.Login && x.Password == model.Password)
                .FirstOrDefaultAsync();
            
            if (user == null)
                return NotFound(new { message = "User/password invalid" });
            
            var token = TokenService.GenerateToken(user);

            user.Password = "";
            return new {
                user = user,
                token = token
            };
        }
    }
}