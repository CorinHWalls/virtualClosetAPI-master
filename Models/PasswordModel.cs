using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace virtualClosetApi.Models
{
    public class PasswordModel
    {
        public string? Salt { get; set; }
        public string? Hash { get; set; }
    }
}