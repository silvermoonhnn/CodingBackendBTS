using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BTS.Test.DataContext;
using MediatR;

namespace BTS.Test.Features.SignUp
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly ShoppingContext _context;

        public Handler(ShoppingContext context)
        {
            _context = context;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var check = _context.Users.FirstOrDefault(x => x.Name == request.User.Name);
            if (check != null)
                throw new Exception("User with the same name already exist");

            var data = new User
            {
                Id = Guid.NewGuid(),
                UserName = request.User.UserName,
                Password = request.User.Password,
                Email = request.User.Email,
                Phone = request.User.Phone,
                Country = request.User.Country,
                City = request.User.City,
                PostCode = request.User.PostCode,
                Address = request.User.Address,
                Name = request.User.Name,

            };

            await _context.Users.AddAsync(data, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            var response = new Response
            {
                UserName = data.UserName,
                Email = data.Email,
                Token = request.Token
            };

            return response;
        }
    }
}
