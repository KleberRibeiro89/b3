using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B3.Domain.Commands.Inputs
{
    public class CalcularIrCommand
    {
        public int Prazo { get; set; }

        public double ValorAplicado { get; set; }

        public double Bruto { get; set; }
    }
}
