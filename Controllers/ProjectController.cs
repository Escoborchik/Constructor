using Constructor.DTO;
using Constructor.Models;
using Constructor.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Constructor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
    
    public class ProjectController : Controller
    {
        [HttpPost]
        public IActionResult MakeProject([FromBody] ProjectDTO projectdto, [FromServices] ProjectRepository projectrepos,
            [FromServices] MasterRepository masterrepos)
        {            
            var master = masterrepos.GetAll().FirstOrDefault(mas => mas.Id == projectdto.Master_Id);
            Project project = new Project()
            {
                Name = projectdto.Name,
                Description = projectdto.Description,
                Master = master,
                Content = projectdto.Content,

            };
            projectrepos.Add(project);

            return Ok();
             

        }

        [HttpGet]
        public IActionResult GetProject([FromQuery] int Master_id, [FromServices] ProjectRepository projectrepos)
        {
            var answer = projectrepos.Get(Master_id);
            return Ok(answer);             
        }


        [HttpPost("Edit")]
        public IActionResult EditProject([FromBody] ProjectDTO projectdto, [FromServices] ProjectRepository projectrepos)
        {

            var project = projectrepos.Get(projectdto.Master_Id);
            project.Name = projectdto.Name;
            project.Description = projectdto.Description;
            project.Content = projectdto.Content;
            projectrepos.Edit(project);
            return Ok();
        }
    }
}
