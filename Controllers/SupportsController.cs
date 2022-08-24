using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleAPIs.Entities;
using SampleAPIs.Interfaces.Bussiness;
using SampleAPIs.Models;

namespace SampleAPIs.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize(Roles = "admin")]

    public class SupportsController : ControllerBase
    {
        private readonly ISupportManager _supportManager;

        public SupportsController(ISupportManager supportManager)
        {
            _supportManager = supportManager;
        }

        [HttpGet]
        public IQueryable Get()
        {
            return _supportManager.GetSups();
        }

        [HttpGet("{id:int}")]
        public List<Support> SearchSupportById(int id)
        {
            return _supportManager.GetSupportByI(id); 
        }

        [HttpGet("{id:int}")]

        public List<FullSupport> GetAssignedPersonDetailsByTicketId(int id)
        {
            return _supportManager.GetFullSup(id);
        }

        [HttpGet]
        public List<Support> SortSupportByCreatedDate()
        {
            return _supportManager.SortSupportByCreatedD();
        }

        [HttpGet]
        public List<Support> SortSupportByClosedDate()
        {
            return _supportManager.SortSupportByClosedD();
        }


        [HttpPost]
        public Support Add(Support support)
        {
            bool isSaved = _supportManager.Add(support);
            if (isSaved)
            {
                return support;
            }
            return null;
        }

        [HttpPut("{Id:int}")]
        public IActionResult Update(int Id, [FromBody] Support support)
        {
            if (support == null || Id != support.TicketId)
                return BadRequest(ModelState);

            if (!_supportManager.UpdateSup(support))
            {
                ModelState.AddModelError("", $"Something went wrong while updating");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{Id:int}")]
        public IActionResult Delete(int Id)
        {
            var depobj = _supportManager.GetSup(Id);

            if (!_supportManager.DeleteSup(depobj))
            {
                ModelState.AddModelError("", $"Something went wrong while deleting");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
