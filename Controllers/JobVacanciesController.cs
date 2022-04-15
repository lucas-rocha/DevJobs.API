using DevJobs.API.Entities;
using DevJobs.API.Models;
using DevJobs.API.Persistence;
using DevJobs.API.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DevJobs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobVacanciesController : ControllerBase
    {
        private readonly IJobVacancyRepository _repository;
        public JobVacanciesController(IJobVacancyRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get all job vacancies
        /// </summary>
        /// <returns>A list of all job vancancies</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            var jobVacancies = _repository.GetAll();
            return Ok(jobVacancies);
        }

        /// <summary>
        /// Get a job vacancy by id.
        /// </summary>
        /// <param name="id">Job vacancy id.</param>
        /// <returns>The specified object of job vacancy</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var jobVacancy = _repository.GetById(id);

            if (jobVacancy == null)
                return NotFound();

            return Ok(jobVacancy);
        }

        /// <summary>
        /// Register job vacancy.
        /// </summary>
        /// <remarks>
        /// {
        ///     "title": "string",
        ///     "description": "string",
        ///     "company": "string",
        ///     "isRemote": true,
        ///     "salaryRange": "string"
        ///  }
        /// </remarks>
        /// <param name="model">Vacancy data.</param>
        /// <returns>Created object.</returns>
        /// <response code="201"></response>
        [HttpPost]
        public IActionResult Post(AddJobVacancyInputModel model)
        {
            var jobVacancy = new JobVacancy(
                model.Title,
                model.Description,
                model.Company,
                model.IsRemote,
                model.SalaryRange
            );

            _repository.Add(jobVacancy);

            return CreatedAtAction("GetById", new { id = jobVacancy.Id }, jobVacancy );
        }

        /// <summary>
        /// Update job vacancy.
        /// </summary>
        /// <param name="id">Job vacancy id.</param>
        /// <param name="model"></param>
        /// <returns>No content.</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateJobVacancyInputModel model)
        {
            var jobVacancy = _repository.GetById(id);

            if (jobVacancy == null)
                return NotFound();

            jobVacancy.Update(model.Title, model.Description);

            _repository.Update(jobVacancy);

            return NoContent();
        }
    }
}
