﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B3.Domain.Commands.Inputs;
using B3.Domain.Commands.Results;
using B3.Domain.Services.Implementation;
using B3.Domain.Services.Interfaces;
using Flunt.Notifications;

namespace B3.Domain.Test
{

    public class CdbTest
    {
        [Fact(DisplayName = "Solicitar Calculo de Cdb Com valor Positivo")]
        public void SoliciarCalculoValorPositivo()
        {
            //Arange
            var cmd = new CalcularCdbCommand();
            cmd.Prazo = 2;
            cmd.ValorAplicado = 1;


            //Act
            ICdbService cdbService = new CdbService();
            var result = cdbService.Calcular(cmd);


            //Assert
            Assert.True(result.Liquido > 0);
        }

        [Fact(DisplayName = "Solicitar Calculo de Cdb Com valor Negativo")]
        public void SoliciarCalculoValorNegativo()
        {
            //Arange
            var cmd = new CalcularCdbCommand();
            cmd.Prazo = 2;
            cmd.ValorAplicado = -1;


            //Act
            ICdbService cdbService = new CdbService();
            var result = cdbService.Calcular(cmd);



            //Assert
            Assert.Equal("Objeto inválido", result.Message);

        }

        [Fact(DisplayName = "Solicitar Calculo de Cdb Com Mes igual á 1")]
        public void SoliciarCalculoComMesIgual1()
        {
            //Arange
            var cmd = new CalcularCdbCommand();
            cmd.Prazo = 1;
            cmd.ValorAplicado = 100;


            //Act
            ICdbService cdbService = new CdbService();
            var result = cdbService.Calcular(cmd);



            //Assert
            Assert.Equal(expected: "Objeto inválido", result.Message);

        }

        [Theory(DisplayName = "Testar Cálculo, resultado Líquido")]
        [InlineData(100, 6, 105.02)]
        [InlineData(100, 12, 109.88)]
        [InlineData(100, 24, 120.71)]
        [InlineData(100, 25, 122.3)]
        [InlineData(100, 50, 149.24)]
        public void SolicicarCalculoResultadosLiquido(decimal valorAplicado, int prazo, Decimal liquido)
        {
            var cmd = new CalcularCdbCommand();
            cmd.Prazo = prazo;
            cmd.ValorAplicado = valorAplicado;


            //Act
            ICdbService cdbService = new CdbService();
            var result = cdbService.Calcular(cmd);


            //Assert
            Assert.Equal(result.Liquido, liquido);
        }



        [Theory(DisplayName = "Testar Cálculo, resultado Bruto")]
        [InlineData(100, 6, 106.47)]
        [InlineData(100, 12, 112.35)]
        [InlineData(100, 24, 125.11)]
        [InlineData(100, 25, 126.23)]
        [InlineData(100, 50, 157.92)]
        public void SolicicarCalculoResultadosBruto(decimal valorAplicado, int prazo, Decimal bruto)
        {
            var cmd = new CalcularCdbCommand();
            cmd.Prazo = prazo;
            cmd.ValorAplicado = valorAplicado;


            //Act
            ICdbService cdbService = new CdbService();
            var result = cdbService.Calcular(cmd);


            //Assert
            Assert.Equal(result.Bruto, bruto);
        }


        [Fact]
        public void ValidarCalcularCdbCommand()
        {
            //Arange
            var cmd = new CalcularCdbCommand();
            cmd.Prazo = 2;
            cmd.ValorAplicado = 100;

            //Act
            cmd.Validar();

            //Assert
            Assert.True(cmd.IsValid);
        }
    }
}