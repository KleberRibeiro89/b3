﻿using System;
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
        private const decimal Tb = (108 / 100);
        private const decimal Cdi = (0.9M / 100);
        public CalcularCdbCommandResult Calcular(CalcularCdbCommand command)
        {
            command.Validar();

            if (!command.IsValid)
            {
                return new CalcularCdbCommandResult(command.IsValid, "Objeto inválido", command.Notifications);
            }

            decimal valorBruto = decimal.Zero;
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
                Bruto = Math.Round(valorBruto,2),
                Liquido = CalcularIr(new CalcularIrCommand 
                { 
                    Bruto = valorBruto,
                    Prazo = command.Prazo, 
                    ValorAplicado = command.ValorAplicado
                })
            };

        }

        public decimal CalcularIr(CalcularIrCommand command)
        {
            var lucro = command.Bruto - command.ValorAplicado;
            decimal imposto = decimal.Zero;
            if (command.Prazo <= 6)
            {
                imposto = lucro * (22.5M / 100);
            }

            if (command.Prazo > 6 && command.Prazo <= 12)
            {
                imposto = lucro * (20M / 100);
            }

            if (command.Prazo > 12 && command.Prazo <= 24)
            {
                imposto = lucro * (17.5M / 100);
            }

            if (command.Prazo > 24)
            {
                imposto = lucro * (15M / 100);
            }

            return Math.Round(command.Bruto - imposto, 2);
        }
    }
}
