using System;
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
        [InlineData(1000, 2, 1015.14)]
        [InlineData(1000, 3, 1022.82)]
        [InlineData(1000, 4, 1030.57)]
        [InlineData(1000, 5, 1038.40)]
        [InlineData(1000, 6, 1046.31)]
        [InlineData(1000, 7, 1056.05)]
        [InlineData(1000, 8, 1064.37)]
        [InlineData(1000, 9, 1072.77)]
        [InlineData(1000, 10, 1081.25)]
        [InlineData(1000, 11, 1089.82)]
        [InlineData(1000, 12, 1098.47)]
        [InlineData(1000, 13, 1110.55)]
        [InlineData(1000, 14, 1119.64)]
        [InlineData(1000, 15, 1128.82)]
        [InlineData(1000, 16, 1138.10)]
        [InlineData(1000, 17, 1147.46)]
        [InlineData(1000, 18, 1156.91)]
        [InlineData(1000, 19, 1166.45)]
        [InlineData(1000, 20, 1176.09)]
        [InlineData(1000, 21, 1185.82)]
        [InlineData(1000, 22, 1195.65)]
        [InlineData(1000, 23, 1205.57)]
        [InlineData(1000, 24, 1215.58)]
        [InlineData(1000, 25, 1232.54)]
        [InlineData(1000, 26, 1243.06)]
        [InlineData(1000, 27, 1253.68)]
        [InlineData(1000, 28, 1264.41)]
        [InlineData(1000, 29, 1275.24)]
        [InlineData(1000, 30, 1286.18)]
        [InlineData(1000, 31, 1297.23)]
        [InlineData(1000, 32, 1308.38)]
        [InlineData(1000, 33, 1319.64)]
        public void SolicicarCalculoResultadosLiquido(double valorAplicado, int prazo, double liquido)
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
        [InlineData(1000, 2, 1019.53)]
        [InlineData(1000, 3, 1029.44)]
        [InlineData(1000, 4, 1039.45)]
        [InlineData(1000, 5, 1049.55)]
        [InlineData(1000, 6, 1059.76)]
        [InlineData(1000, 7, 1070.06)]
        [InlineData(1000, 8, 1080.46)]
        [InlineData(1000, 9, 1090.96)]
        [InlineData(1000, 10, 1101.56)]
        [InlineData(1000, 11, 1112.27)]
        [InlineData(1000, 12, 1123.08)]
        [InlineData(1000, 13, 1134)]
        [InlineData(1000, 14, 1145.02)]
        [InlineData(1000, 15, 1156.15)]
        [InlineData(1000, 16, 1167.39)]
        [InlineData(1000, 17, 1178.74)]
        [InlineData(1000, 18, 1190.19)]
        [InlineData(1000, 19, 1201.76)]
        [InlineData(1000, 20, 1213.44)]
        [InlineData(1000, 21, 1225.24)]
        [InlineData(1000, 22, 1237.15)]
        [InlineData(1000, 23, 1249.17)]
        [InlineData(1000, 24, 1261.31)]
        [InlineData(1000, 25, 1273.57)]
        public void SolicicarCalculoResultadosBruto(double valorAplicado, int prazo, double bruto)
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

        [Fact]
        public void ValidarCalcularCdbCommandComPrazoIgual1()
        {
            //Arange
            var cmd = new CalcularCdbCommand();
            cmd.Prazo = 1;
            cmd.ValorAplicado = 100;

            //Act
            cmd.Validar();

            //Assert
            Assert.False(cmd.IsValid);
        }

        [Fact]
        public void ValidarCalcularCdbCommandComPrazoMenorQue1()
        {
            //Arange
            var cmd = new CalcularCdbCommand();
            cmd.Prazo = 0;
            cmd.ValorAplicado = 100;

            //Act
            cmd.Validar();

            //Assert
            Assert.False(cmd.IsValid);
        }

        [Fact]
        public void ValidarCalcularCdbCommandComValorIgual0()
        {
            //Arange
            var cmd = new CalcularCdbCommand();
            cmd.Prazo = 12;
            cmd.ValorAplicado = 0;

            //Act
            cmd.Validar();

            //Assert
            Assert.False(cmd.IsValid);
        }


        [Theory]
        [InlineData(2, 1000, 1019.53, 1015.14)]
        [InlineData(12, 100, 112.31, 109.85)]
        [InlineData(24, 100, 126.13, 121.56)]
        [InlineData(50, 100, 162.2, 152.87)]
        public void CalcularIr(int prazo, double valorAplicado, double bruto, double valorLiquido)
        {
            //Arange
            var cmd = new CalcularIrCommand();
            cmd.Prazo = prazo;
            cmd.ValorAplicado = valorAplicado;
            cmd.Bruto = bruto;

            //Act
            ICdbService cdbService = new CdbService();
            var result = cdbService.CalcularIr(cmd);

            //Assert
            Assert.Equal(Math.Round(result, 2), valorLiquido);
        }
    }
}