using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Business.Abstract;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class JobsController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet]
        [Route("OneDayTodo")]
        public IActionResult OneDayTodo()
        {
            var jobs = _jobService.OneDayTodo();
            if(jobs == null)
            {
                return BadRequest();
            }
            return Ok(jobs);
        }

        [HttpGet]
        [Route("OneWeekTodo")]
        public IActionResult OneWeekTodo()
        {
            var jobs = _jobService.OneWeekTodo();
            if (jobs == null)
            {
                return BadRequest();
            }
            return Ok(jobs);
        }

        [HttpGet]
        [Route("ThirtyDaysTodo")]
        public IActionResult ThirtyDaysTodo()
        {
            var jobs = _jobService.ThirtyDaysTodo();
            if (jobs == null)
            {
                return BadRequest();
            }
            return Ok(jobs);
        }
    }
}
