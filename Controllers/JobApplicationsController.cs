using DevJobs.API.Models;
using DevJobs.API.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DevJobs.API.Controllers
{
    [Route("api/job-vacancies/{id}/applications")]
    [ApiController]
    public class JobApplicationsController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(int id, AddJobApplicationInputModel model)
        {
            return NoContent();
        }
    }
}
