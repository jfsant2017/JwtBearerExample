using System.Collections.Generic;
using System.Threading.Tasks;
using JwtBearerExample.Data;
using JwtBearerExample.Models;
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
        
    }
}