using DevJobs.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevJobs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobVacanciesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(AddJobVacancyInputModel model)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(UpdateJobVacancyInputModel model)
        {
            return NoContent();
        }
    }
}
