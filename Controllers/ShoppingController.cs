using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BTS.Test.Controllers
{
    [Route("shopping")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShoppingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create-shopping")]
        public async Task<IActionResult> SignUp([FromBody] Features.CreateNewShopping.Request request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("/")]
        public async Task<IActionResult> GetShoppingList()
        {
            var result = await _mediator.Send(new Features.GetAllShopping.Request());
            return Ok(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetShopingById([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new Features.GetShoppingById.Request
            {
                Id = id
            });
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateShopping([FromRoute] Guid id, [FromBody] Features.UpdateShopping.Request request)
        {
            request.Id = id;
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new Features.DeleteShopping.Request
            {
                Id = id
            });
            return Ok(result);
        }
    }
}
