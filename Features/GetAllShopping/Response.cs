using System;
using System.Collections.Generic;

namespace BTS.Test.Features.GetAllShopping
{
    public class Response
    {
        public IEnumerable<ShoppingList> ShoppingLists { get; set; }
    }

    public class ShoppingList
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
