using System;
using System.Threading;
using System.Threading.Tasks;
using BTS.Test.DataContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BTS.Test.Features.GetShoppingById
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
            var data = await _context.Shoppings.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (data == null) throw new Exception("Id not found");

            var response = new Response
            {
                Shopping = new CreateNewShopping.DataResponse
                {
                    Id = data.Id,
                    Name = data.Name,
                    CretedDate = data.CreatedDate
                }
            };

            return response;
        }
    }
}
