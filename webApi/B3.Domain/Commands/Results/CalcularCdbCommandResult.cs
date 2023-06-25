using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B3.Domain.Commands.Results
{
    public class CalcularCdbCommandResult : ICommandResult
    {
        public CalcularCdbCommandResult()
        {
                
        }

        public decimal Bruto { get; set; }

        public decimal Liquido { get; set; }

        public CalcularCdbCommandResult(bool success, string message, IReadOnlyCollection<Flunt.Notifications.Notification> data)
        {
            this.Success = success;
            this.Message = message;
            this.Data = data;
        }
    }
}
