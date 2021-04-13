using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BTS.Test.Controllers
{
    [Route("users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] Features.SignUp.Request request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIp([FromBody] Features.SignIn.Request request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("/")]
        public async Task<IActionResult> GetUserList()
        {
            var result = await _mediator.Send(new Features.GetAllUser.Request());
            return Ok(result);
        }
    }
}
