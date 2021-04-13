using MediatR;

namespace BTS.Test.Features.SignIn
{
    public class Request : IRequest<Response>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
