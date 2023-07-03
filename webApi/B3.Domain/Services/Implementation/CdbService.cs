using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B3.Domain.Commands;
using B3.Domain.Commands.Inputs;
using B3.Domain.Commands.Results;
using B3.Domain.Services.Interfaces;

namespace B3.Domain.Services.Implementation
{
    public class CdbService : ICdbService
    {
        private const double Tb = (108 / 100);
        private const double Cdi = (0.9 / 100);
        public CalcularCdbCommandResult Calcular(CalcularCdbCommand command)
        {
            command.Validar();

            if (!command.IsValid)
            {
                return new CalcularCdbCommandResult(command.IsValid, "Objeto inválido", command.Notifications);
            }

            double valorBruto = 0;
            for (int i = 0; i < command.Prazo; i++)
            {
                if (i == 0)
                {
                    valorBruto = command.ValorAplicado * (1 + (Cdi * Tb));
                }

                valorBruto *= (1 + (Cdi * Tb));
            }


            return new CalcularCdbCommandResult
            {
                Success = true,
                Bruto = Math.Round(valorBruto, 2),
                Liquido = Math.Round(CalcularIr(new CalcularIrCommand
                {
                    Bruto = valorBruto,
                    Prazo = command.Prazo,
                    ValorAplicado = command.ValorAplicado
                }), 2)
            };

        }

        public double CalcularIr(CalcularIrCommand command)
        {
            var lucro = command.Bruto - command.ValorAplicado;
            double imposto = 0;
            if (command.Prazo <= 6)
            {
                imposto = lucro * (22.5 / 100);
            }

            if (command.Prazo > 6 && command.Prazo <= 12)
            {
                imposto = lucro * (20.0 / 100);
            }

            if (command.Prazo > 12 && command.Prazo <= 24)
            {
                imposto = lucro * (17.5 / 100);
            }

            if (command.Prazo > 24)
            {
                imposto = lucro * (15.0 / 100);
            }

            return (command.Bruto - imposto);
        }
    }
}
