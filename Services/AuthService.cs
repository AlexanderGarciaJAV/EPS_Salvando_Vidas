using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fase3JavierGarcia.Services
{
    public class AuthService
    {
        public bool Authenticate(string password)
        {
            return password == "jav";
        }
    }
}
