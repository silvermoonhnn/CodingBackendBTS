using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BTS.Test.DataContext;
using MediatR;

namespace BTS.Test.Features.CreateNewShopping
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
            var check = _context.Shoppings.FirstOrDefault(x => x.Name == request.Shopping.Name);
            if (check != null)
                throw new Exception("Shopping with the same name already exist");

            var data = new Shopping
            {
                Id = Guid.NewGuid(),
                Name = request.Shopping.Name,
                CreatedDate = request.Shopping.CretedDate
            };

            await _context.Shoppings.AddAsync(data, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            var response = new Response
            {
                Data = new DataResponse
                {
                    CretedDate = data.CreatedDate,
                    Id = data.Id,
                    Name = data.Name
                }
            };

            return response;
        }
    }
}
