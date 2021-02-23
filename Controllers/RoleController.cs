using System.Collections.Generic;
using System.Threading.Tasks;
using JwtBearerExample.Data;
using JwtBearerExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JwtBearerExample.Controllers
{
    [Route("role")]
    public class RoleController: ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Role>>> GetTask(
            [FromServices] DataContext context
        )
        {
            var roles = await context.Roles.AsNoTracking().ToListAsync();
            return Ok(roles);
        }
    }
}