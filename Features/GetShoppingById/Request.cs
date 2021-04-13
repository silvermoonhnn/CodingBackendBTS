using System;
using MediatR;

namespace BTS.Test.Features.GetShoppingById
{
    public class Request : IRequest<Response>
    {
        public Guid Id { get; set; }
    }
}
