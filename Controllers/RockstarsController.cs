using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleAPIs.Entities;
using SampleAPIs.Interfaces.Bussiness;

namespace SampleAPIs.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize(Roles = "admin")]

    public class RockstarsController : ControllerBase
    {
        private readonly IRockstarManager _rockstarManager;

        public RockstarsController(IRockstarManager rockstarManager)
        {
            _rockstarManager = rockstarManager;
        }

        [HttpGet]
        public IQueryable Get()
        {
            return _rockstarManager.GetRocks();
        }

        [HttpGet("{id:int}")]
        public List<Rockstar> SearchRockstarById(int id)
        {
            return _rockstarManager.GetRockstarByI(id);
        }

        [HttpPost]
        public Rockstar Add(Rockstar rockstar)
        {
            bool isSaved = _rockstarManager.Add(rockstar);
            if (isSaved)
            {
                return rockstar;
            }
            return null;
        }

        [HttpPut("{Id:int}")]
        public IActionResult Update(int Id, [FromBody] Rockstar rockstar)
        {
            if (rockstar == null || Id != rockstar.RockId)
                return BadRequest(ModelState);

            if (!_rockstarManager.UpdateRock(rockstar))
            {
                ModelState.AddModelError("", $"Something went wrong while updating");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{Id:int}")]
        public IActionResult Delete(int Id)
        {
            var depobj = _rockstarManager.GetRock(Id);

            if (!_rockstarManager.DeleteRock(depobj))
            {
                ModelState.AddModelError("", $"Something went wrong while deleting");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
