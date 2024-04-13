using Constructor.Models;
using Constructor.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Constructor.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class MasterRegController : Controller
    {
        [HttpPost]
        public IActionResult Post([FromBody] Master master, [FromServices] MasterRepository repos)
        {
            var allmasters = repos.GetAll().ToList();
            foreach (var item in allmasters)
            {
                if (item.Email.Equals(master.Email))
                {
                    return new StatusCodeResult(404);
                }
            }
            repos.Add(master);
            return Ok();
        }

    }

}
