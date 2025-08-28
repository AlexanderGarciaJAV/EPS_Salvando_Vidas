using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fase3JavierGarcia.Factories
{
    public static class AboutMessageFactory
    {
        public static string CreateMessage(string companyInfo, string phoneNumber, string author)
        {
            return $"{companyInfo}\nNúmero: {phoneNumber}\nElaborado por: {author}";
        }
    }
}