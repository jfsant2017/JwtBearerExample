using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtBearerExample.Controllers
{
    [Route("content")]
    public class RestrictedAccessController: ControllerBase
    {
        // Public access
        [HttpGet]
        [Route("public")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> PublicContent()
        {
            return Ok(new { message = "You got public content." });
        }
        // Manager Only
        [HttpGet]
        [Route("manager")]
        [Authorize(Roles="Manager")]
        public async Task<ActionResult<dynamic>> ManagerContent()
        {
            return Ok(new { message = "You got manager content." });
        }

        // Employee only
        [HttpGet]
        [Route("employee")]
        [Authorize(Roles="Employee")]
        public async Task<ActionResult<dynamic>> EmployeeContent()
        {
            return Ok(new { message = "You got employee content." });
        }

        // Authenticated access
        [HttpGet]
        [Route("authenticated")]
        [Authorize(Roles="Manager,Employee")]
        public async Task<ActionResult<dynamic>> AuthenticatedContent()
        {
            return Ok(new { message = "You got authenticated data." });
        }
    }
}