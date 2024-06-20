using BlazorWebApp.Server.Models.SalesSimpleDBContext;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesSimpleController : Controller
    {
        private readonly SalesSimpleContext _dbContext;

        public SalesSimpleController(SalesSimpleContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet("GetCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetClientUser()
        {
            var customers = _dbContext.Customers.Take(10).ToList();

            return Ok(customers);

        }


    }
}
