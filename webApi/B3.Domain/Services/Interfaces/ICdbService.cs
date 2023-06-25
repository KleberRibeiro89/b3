using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B3.Domain.Commands.Inputs;
using B3.Domain.Commands.Results;

namespace B3.Domain.Services.Interfaces
{
    public interface ICdbService 
    {
        CalcularCdbCommandResult Calcular(CalcularCdbCommand command);

        decimal CalcularIr(CalcularIrCommand command);
    }
}
