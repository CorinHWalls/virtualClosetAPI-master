using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace virtualClosetApi.Models
{
    public class CreateAccountModel
    {
        public int Id {get;set;}
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? LastName{ get; set; }
        public string? FirstName{ get; set; }
        public CreateAccountModel(){}
    }
}