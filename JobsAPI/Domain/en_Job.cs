namespace JobsAPI.Domain
{
    public class en_Job
    {
        public en_Job()
        {
            Create_Date = DateTime.Now;
        }

        public int ID_Job { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public decimal Salary { get; set; }
        public DateTime Create_Date { get; set; }

        public void UpdateJob(string title, string description, string location, decimal salary)
        {
            Title = title;
            Description = description;
            Location = location;
            Salary = salary;
        }
    }
}
