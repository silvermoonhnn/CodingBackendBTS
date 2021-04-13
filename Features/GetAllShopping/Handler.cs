using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BTS.Test.DataContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BTS.Test.Features.GetAllShopping
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
            var data = await _context.Shoppings.Select(x => new ShoppingList
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync(cancellationToken);

            var response = new Response
            {
                ShoppingLists = data
            };

            return response;
        }
    }
}
