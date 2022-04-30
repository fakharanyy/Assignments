using System.Threading.Tasks;
using ITS_Technical_Test.Core.Data.AggregateServices.Interfaces;
using ITS_Technical_Test.Presentation.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITS_Technical_Test.Presentation.APis.Controllers
{
    [ApiController]
    [Route("api/customer")]
    public class CustomerWriteController:ControllerBase
    {
        private readonly ICustomerWriteAggregateService CustomerWriteServices;

        public CustomerWriteController(ICustomerWriteAggregateService writeServices)
        {
            CustomerWriteServices = writeServices;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerModel model)
        {

            var response = await CustomerWriteServices.CreateCustomer(model);
            return Ok(response);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomerModel model)
        {

            var response = await CustomerWriteServices.UpdateCustomer(model);
            return Ok(response);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] long id)
        {

            var response = await CustomerWriteServices.DeleteCustomer(id);
            return Ok(response);

        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteCustomer([FromBody] CustomerModel model)
        {

            var response = await CustomerWriteServices.DeleteCustomer(model);
            return Ok(response);

        }
    }
}
