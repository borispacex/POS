using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Dtos.User.Request
{
    public  class TokenRequestDto
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
