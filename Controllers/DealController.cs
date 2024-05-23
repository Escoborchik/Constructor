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
            var date = new DateOnly();
            var client = clientrepos.GetAll().FirstOrDefault(c => c.Email == dealdto.ClientEmail);
            if (client == null)
            {
                client = new Client() { Name = dealdto.ClientName, Email = dealdto.ClientEmail };
                clientrepos.Add(client);
            }
            
            var project = projectrepos.GetProject(dealdto.Project_Id);
            var newDeal = new Deal() { 
                Amount = dealdto.Amount,
                Client = client,
                ProductsName = dealdto.ProductName,
                Project = project,
                Comment = dealdto.Comment,
                Phone = dealdto.Phone,
                Status = "Создан",
                Adress = dealdto.Adress,
                Created = DateTime.Now,
            };                       
            dealrepository.Add(newDeal);

            return Ok();


        }

        [HttpGet]
        public IActionResult GetDeal([FromQuery] int Project_id, [FromServices] DealRepository dealrepos)
        {
            var answer = dealrepos.GetAll(Project_id);
            return Ok(answer);
        }
    }
}
