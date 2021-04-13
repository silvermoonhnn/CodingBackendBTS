using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BTS.Test.DataContext;
using MediatR;

namespace BTS.Test.Features.DeleteShopping
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
            var data = _context.Shoppings.FirstOrDefault(x => x.Id == request.Id);
            if (data == null)
                throw new Exception("Shopping not found");

            _context.Shoppings.Remove(data);
            await _context.SaveChangesAsync(cancellationToken);

            var response = new Response
            {
                ErrorCode = 0,
                Description = "Success"
            };

            return response;
        }
    }
}
