using System.Threading.Tasks;
using ITS_Technical_Test.Core.Data.AggregateServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ITS_Technical_Test.Presentation.APis.Controllers
{
    [ApiController]
    [Route("api/customer")]
    public class CustomerReadController:ControllerBase
    {
        private readonly ICustomerReadAggregateService CustomerReadService;
        public CustomerReadController(ICustomerReadAggregateService customerReadService)
        {
            CustomerReadService = customerReadService;
        }
        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetCustomers()
        {

            var response = await CustomerReadService.GetCustomers();
            return Ok(response);
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetCustomers(long id)
        {

            var response = await CustomerReadService.GetCustomer(id);
            return Ok(response);
        }

    }
}
