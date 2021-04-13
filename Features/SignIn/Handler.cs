using System;
using System.Threading;
using System.Threading.Tasks;
using BTS.Test.DataContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BTS.Test.Features.SignIn
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
            var check = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email && x.Password == request.Password, cancellationToken);
            if (check != null)
                throw new Exception("Can't login, wrong input");

            var response = new Response
            {
                UserName = check.UserName,
                Email = check.Email,
                Token = request.Token
            };

            return response;
        }
    }
}
