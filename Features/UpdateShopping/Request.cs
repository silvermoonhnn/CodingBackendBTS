using System;
using BTS.Test.Features.CreateNewShopping;
using MediatR;

namespace BTS.Test.Features.UpdateShopping
{
    public class Request : IRequest<Response>
    {
        public Guid Id { get; set; }
        public AddShopping Shopping { get; set; }
    }
}
