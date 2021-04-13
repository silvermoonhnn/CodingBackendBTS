using System;

namespace BTS.Test.Features.CreateNewShopping
{
    public class Response
    {
        public DataResponse Data { get; set; }
    }

    public class DataResponse
    {
        public DateTime CretedDate { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
