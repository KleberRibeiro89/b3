using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flunt.Notifications;
using Flunt.Validations;

namespace B3.Domain.Commands.Inputs
{
    public class CalcularCdbCommand : Notifiable<Notification>
    {
        public decimal ValorAplicado { get; set; }

        public int Prazo { get; set; }

        
     
        public void Validar()
        {
            AddNotifications(new Contract<Notification>()
                .IsGreaterThan(ValorAplicado, decimal.Zero, "Informar um Valor Monetário Positivo")
                .IsGreaterThan(Prazo, 1, "Informar um prazo em meses maior que 1"));
        }
    }
}
