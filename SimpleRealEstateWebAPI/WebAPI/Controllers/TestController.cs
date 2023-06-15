using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
    }
}
