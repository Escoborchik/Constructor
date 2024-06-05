using Constructor.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Constructor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchiveController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetArchiveDeal([FromQuery] int Project_id, [FromServices] DealRepository dealrepos)
        {
            var answer = dealrepos.GetAllArchive(Project_id);
            return Ok(answer);
        }

        [HttpGet("withProblem")]
        public IActionResult GetArchiveDealWithProblem([FromQuery] int Project_id, [FromServices] DealRepository dealrepos)
        {
            var answer = dealrepos.GetAllArchive(Project_id).Where(d => d.IsProblem == true);
            return Ok(answer);
        }
    }
}
