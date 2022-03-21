using DevJobs.API.Entities;
using System.Collections.Generic;

namespace DevJobs.API.Persistence
{
    public class DevJobsContext
    {
        public DevJobsContext()
        {
            JobVacancies = new List<JobVacancy>();
        }

        public List<JobVacancy> JobVacancies { get; set; }
    }
}
