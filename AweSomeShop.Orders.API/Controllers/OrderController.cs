using AweSomeShop.Orders.Application.Commands;
using AweSomeShop.Orders.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AweSomeShop.Orders.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        
        [HttpGet]
        public async Task<ActionResult> Orders(Guid id){
            
            var query = new GetOrderDetailByIdQueries(id);
            
            var result = await this.mediator.Send(query);

            if (result == null){
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddOrderCommand command){
            
            var id = await this.mediator.Send(command);

            return CreatedAtAction(nameof(Orders),new {id = id}, command);

        }

    }
}