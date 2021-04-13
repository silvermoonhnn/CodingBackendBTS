using MediatR;

namespace BTS.Test.Features.SignUp
{
    public class Request : IRequest<Response>
    {
        public UserSignUp User { get; set; }
        public string Token { get; set; }
    }

    public class UserSignUp
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
