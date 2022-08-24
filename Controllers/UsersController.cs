using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleAPIs.Entities;
using SampleAPIs.Interfaces.Bussiness;
using System.Net;

namespace SampleAPIs.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize]

    public class UsersController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
        }       

        [HttpGet]
        public IQueryable Get()
        {
            return _userManager.GetUs();
        }

        [HttpGet("{name}")]
        public List<Users> SearchUserByName(string name)
        {
            return _userManager.GetUserByN(name);            
        }

        [HttpGet("{email}")]
        public List<Users> SearchUserByEmail(string email)
        {
            return _userManager.GetUserByE(email);
        }

        [HttpGet("{pno}")]
        public List<Users> SearchUserByPhoneNumber(string pno)
        {
            return _userManager.GetUserByP(pno);
        }

        [HttpPost]
        public Users Add(Users user)
        {
            bool isSaved = _userManager.Add(user);
            if (isSaved)
            {
                return user;
            }
            return null;
        }

        [HttpPut("{Id:int}")]
        public IActionResult Update(int Id, [FromBody] Users user)
        {
            if (user == null || Id != user.Id)
                return BadRequest(ModelState);

            if (!_userManager.UpdateU(user))
            {
                ModelState.AddModelError("", $"Something went wrong while updating");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{Id:int}")]
        public IActionResult Delete(int Id)
        {
            var depobj = _userManager.GetU(Id);

            if (!_userManager.DeleteU(depobj))
            {
                ModelState.AddModelError("", $"Something went wrong while deleting");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
