using System;
using MediatR;

namespace BTS.Test.Features.DeleteShopping
{
    public class Request : IRequest<Response>
    {
        public Guid Id { get; set; }
    }
}
