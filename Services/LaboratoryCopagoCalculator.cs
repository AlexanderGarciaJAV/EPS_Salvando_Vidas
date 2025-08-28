using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fase3JavierGarcia.Services
{
    public class LaboratoryCopagoCalculator : ICopagoCalculator
    {
        public decimal CalculateCopago(int estrato)
        {
            switch (estrato)
            {
                case 1:
                case 2:
                case 3:
                    return 0;
                case 4:
                    return 5000;
                case 5:
                    return 10000;
                case 6:
                    return 20000;
                default:
                    return 0;
            }
        }
    }
}