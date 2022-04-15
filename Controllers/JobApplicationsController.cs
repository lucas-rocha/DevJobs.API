﻿using DevJobs.API.Entities;
using DevJobs.API.Models;
using DevJobs.API.Persistence;
using DevJobs.API.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DevJobs.API.Controllers
{
    [Route("api/job-vacancies/{id}/applications")]
    [ApiController]
    public class JobApplicationsController : ControllerBase
    {
        private readonly IJobVacancyRepository _repository;

        public JobApplicationsController(IJobVacancyRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Create a job application to a job vacancy.
        /// </summary>
        /// <param name="id">Job vacancy ID.</param>
        /// <param name="model"></param>
        /// <returns>No Content</returns>
        [HttpPost]
        public IActionResult Post(int id, AddJobApplicationInputModel model)
        {
            var jobVacancy = _repository.GetById(id);

            if (jobVacancy == null)
                return NotFound();

            var application = new JobApplication(
                model.ApplicantName,
                model.ApplicantEmail,
                id
            );

            _repository.AddApplication(application);

            return NoContent();
        }
    }
}
