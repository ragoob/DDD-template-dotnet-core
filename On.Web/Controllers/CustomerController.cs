using MediatR;
using Microsoft.AspNetCore.Mvc;
using On.Application.Commands.Customers;
using System;
using System.Threading.Tasks;

namespace On.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromServices] IMediator _mediator, AddCustomerCommand customer)
        {
           await _mediator.Send(customer);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromServices] IMediator _mediator,  UpdateCustomerCommand customer)
        {
            await _mediator.Send(customer);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchAsync([FromServices] IMediator _mediator, Guid id)
        {
            await _mediator.Send(new ActivateCustomerCommand(id));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromServices] IMediator _mediator,Guid id)
        {
            await _mediator.Send(new DeleteCustomerCommand(id));
            return NoContent();
        }
    }
}

