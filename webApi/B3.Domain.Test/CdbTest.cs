using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B3.Domain.Commands.Inputs;
using B3.Domain.Commands.Results;
using B3.Domain.Services.Implementation;
using B3.Domain.Services.Interfaces;

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
            Assert.Equal(result.ToString(), new CalcularCdbCommandResult().ToString());
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
            Assert.Equal(result.Data.Any(x => x.Message.Equals("")), true);

        }
    }
}
