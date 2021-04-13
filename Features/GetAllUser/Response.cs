using System;
using System.Collections.Generic;

namespace BTS.Test.Features.GetAllUser
{
    public class Response
    {
        public IEnumerable<UserList> Users { get; set; }
    }

    public class UserList
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
