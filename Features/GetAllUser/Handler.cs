using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BTS.Test.DataContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BTS.Test.Features.GetAllUser
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
            var data = await _context.Users.Select(x => new UserList
            {
                Id = x.Id,
                Username = x.UserName,
                Email = x.Email
            }).ToListAsync(cancellationToken);

            var response = new Response
            {
                Users = data
            };

            return response;
        }
    }
}
