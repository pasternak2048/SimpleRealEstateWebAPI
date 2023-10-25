using Application.Common.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace WebAPI.Controllers
{
    public class TestController : BaseApiController
    {
        [Authorize]
        [HttpGet("TestAuthorize")]
        public async Task<ActionResult> TestAuthorize()
        {
            return Ok();
        }

        [Authorize(Roles = "Superuser, Administrator")]
        [HttpGet("TestAuthorizeRole")]
        public async Task<ActionResult> TestAuthorizeRole()
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("TestNotFound")]
        public async Task<ActionResult> TestNotFound()
        {
            throw new NotFoundException("Not found test");
        }

    }
}
