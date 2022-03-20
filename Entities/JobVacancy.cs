namespace DevJobs.API.Entities
{
    public class JobVacancy
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Company { get; private set; }
        public bool IsRemote { get; private set; }
        public string SalaryRange { get; private set; }
    }
}
