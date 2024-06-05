using Constructor.DTO;
using Constructor.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Constructor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStatistics([FromQuery] int Project_id, [FromServices] DealRepository dealrepos)
        {
            var answer = new StaticsDTO();
            var deals = dealrepos.GetAll(Project_id);
            answer.TotalCount = deals.Count();
            answer.ProblemCount = dealrepos.GetAllArchive(Project_id).Where(d=> d.IsProblem == true).Count();
            foreach (var deal in deals)
            {
                var products = deal.ProductsName.Split(' ');
                foreach(var product in products)
                {
                    if (answer.GoodSales.ContainsKey(product))
                    {
                        answer.GoodSales[product]++;
                    }
                    else
                    {
                        answer.GoodSales[product] = 1;
                    }
                }
                
            }            
            return Ok(answer);
        }
        
    }
}
