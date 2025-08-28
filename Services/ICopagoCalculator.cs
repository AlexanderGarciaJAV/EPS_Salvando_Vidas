using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fase3JavierGarcia.Services
{
    public interface ICopagoCalculator
    {
        decimal CalculateCopago(int estrato);
    }
}