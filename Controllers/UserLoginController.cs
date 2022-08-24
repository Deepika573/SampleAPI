using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleAPIs.Interfaces.Bussiness;
using SampleAPIs.Models;

namespace SampleAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private IUserLoginManager _userLoginManager;

        public UserLoginController(IUserLoginManager userLoginManager)
        {
            _userLoginManager = userLoginManager;
        }

        // POST api/user/login
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] LoginJwt user)
        {
            var token = _userLoginManager.Login(user.UserName, user.Password);

            if (token == null || token == String.Empty)
                return BadRequest(new { message = "User name or password is incorrect" });

            return Ok(token);
        }
    }
}
