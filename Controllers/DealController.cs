using Constructor.DTO;
using Constructor.Models;
using Constructor.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Constructor.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DealController : Controller
    {
        [HttpPost]
        public IActionResult MakeDeal([FromBody] DealDTO dealdto, [FromServices] ProjectRepository projectrepos,
             [FromServices] ClientRepository clientrepos, [FromServices] DealRepository dealrepository)
        {
            var client = clientrepos.GetAll().FirstOrDefault(c => c.Email == dealdto.ClientEmail);
            if (client == null)
            {
                client = new Client() { Name = dealdto.ClientName, Email = dealdto.ClientEmail };
                clientrepos.Add(client);
            }
            
            var project = projectrepos.GetProject(dealdto.Project_Id);
            var newDeal = new Deal() { Amount = dealdto.Amount, Client = client, ProductName = dealdto.ProductName, Project = project };                       
            dealrepository.Add(newDeal);

            return Ok();


        }

        [HttpGet]
        public IActionResult GetDeal([FromQuery] int Project_id, [FromServices] ProjectRepository projectrepos)
        {
            var answer = projectrepos.GetProject(Project_id);
            return Ok(answer.Deals);
        }
    }
}
