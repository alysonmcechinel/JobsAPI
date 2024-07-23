using JobsAPI.Domain;
using JobsAPI.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace JobsAPI.Controllers
{
    [ApiController]
    [Route("api/jobs")]
    public class JobController : ControllerBase
    {
        private readonly JobsContext _context;

        public JobController(JobsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var jobs = _context.Jobs.ToList();

            return Ok(jobs);
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            var job = _context.Jobs.SingleOrDefault(x => x.ID_Job == id);

            if(job == null)
                return NotFound();

            return Ok(job);
        }

        [HttpPost]
        public IActionResult CreateJob(en_Job job)
        {
            _context.Jobs.Add(job);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetSingle), new { id = job.ID_Job }, job);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateJob(int id, en_Job job)
        {
            var jobToUpdate = _context.Jobs.Find(id);
            if (jobToUpdate == null)
                return NotFound();

            jobToUpdate.UpdateJob(job.Title, job.Description, job.Location, job.Salary);

            _context.Jobs.Update(jobToUpdate);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteJob(int id)
        {
            var job = _context.Jobs.Find(id);

            if(job == null)
                return NotFound();

            _context.Jobs.Remove(job); // ou apenas desativa
            _context.SaveChanges();

            return Ok();
        }
    }
}
