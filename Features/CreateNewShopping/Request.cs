using System;
using MediatR;

namespace BTS.Test.Features.CreateNewShopping
{
    public class Request : IRequest<Response>
    {
        public AddShopping Shopping { get; set; }
    }

    public class AddShopping
    {
        public DateTime CretedDate { get; set; }
        public string Name { get; set; }
    }
}
