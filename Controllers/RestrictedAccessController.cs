using System.Linq;
using System.Security.Claims;
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
            string loginName = HttpContext.User.Claims.FirstOrDefault(a => a.Type == ClaimTypes.Name)?.Value;
            return Ok(new { message = string.Format("{0}, you got public content.", loginName) });
        }
        // Manager Only
        [HttpGet]
        [Route("manager")]
        [Authorize(Roles="Manager")]
        public async Task<ActionResult<dynamic>> ManagerContent()
        {
            string loginName = HttpContext.User.Claims.FirstOrDefault(a => a.Type == ClaimTypes.Name)?.Value;
            return Ok(new { message = string.Format("{0}, you got manager content.", loginName) });
        }

        // Employee only
        [HttpGet]
        [Route("employee")]
        [Authorize(Roles="Employee")]
        public async Task<ActionResult<dynamic>> EmployeeContent()
        {
            string loginName = HttpContext.User.Claims.FirstOrDefault(a => a.Type == ClaimTypes.Name)?.Value;
            return Ok(new { message = string.Format("{0}, you got employee content.", loginName) });
        }

        // Authenticated access
        [HttpGet]
        [Route("authenticated")]
        [Authorize(Roles="Manager,Employee")]
        public async Task<ActionResult<dynamic>> AuthenticatedContent()
        {
            string loginName = HttpContext.User.Claims.FirstOrDefault(a => a.Type == ClaimTypes.Name)?.Value;
            return Ok(new { message = string.Format("{0}, you got authenticated content.", loginName) });
        }
    }
}