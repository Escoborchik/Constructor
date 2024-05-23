using Constructor.DTO;
using Constructor.Models;
using Constructor.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Constructor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutentificationController : Controller
    {
        [HttpPost]
        public IActionResult Autentificate([FromBody] Userdata dataUser, [FromServices] MasterRepository masterrepos)
        {
            var answer = new AnswerAutentic();
            var allmasters = masterrepos.GetAll().ToList();
            foreach (var master in allmasters)
            {
                if (master.Email.Equals(dataUser.Email) && master.Password.Equals(dataUser.Password))
                {
                    answer.Client_id = master.Id;
                    answer.Username = master.Username;                   
                    break;
                }
                else if (master.Email.Equals(dataUser.Email))
                {
                    answer.Client_id = -2;
                }
                else
                {
                    answer.Client_id = -1;
                }
            }

            if (answer.Client_id == -1)
            {
                return new StatusCodeResult(404);
            }
            else if (answer.Client_id == -2)
            {
                return new StatusCodeResult(401);
            }
            else
            {
                return Ok(answer);
            }

        }
    }
}
