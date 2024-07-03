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
                IsArchive = false,
                IsProblem = false,
                Reason = "",
                ReasonComment = ""
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

        [HttpGet("Status")]
        public IActionResult GetDealWithStatus([FromQuery] int Project_id, [FromQuery] string status, [FromServices] DealRepository dealrepos)
        {
            var answer = dealrepos.GetAll(Project_id).Where(d => d.Status == status);
            return Ok(answer);
        }

        [HttpPatch("Status")]
        public IActionResult EditStatusDeal([FromBody] StatusDTO statusDTO, [FromServices] DealRepository dealrepos)
        {
            var res = dealrepos.Get(statusDTO.DealId);
            res.Status = statusDTO.Status;
            dealrepos.Update(res);
            return Ok();
        }

        [HttpPatch("Archive")]
        public IActionResult EditArchiveDeal([FromBody] ArchiveDTO archiveDTO, [FromServices] DealRepository dealrepos)
        {
            var res = dealrepos.Get(archiveDTO.DealId);
            res.IsArchive = true;
            res.IsProblem = archiveDTO.IsProblem; 
            res.Reason = archiveDTO.Reason;
            res.ReasonComment = archiveDTO.ReasonComment;
            dealrepos.Update(res);
            return Ok();
        }
    }
}
