﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace B3.Domain.Commands.Results
{
    public class CalcularCdbCommandResult : CommandResult
    {
        public CalcularCdbCommandResult()
        {
                
        }

        public CalcularCdbCommandResult(bool success, string message, IReadOnlyCollection<Flunt.Notifications.Notification> data)
        {
            this.Success = success;
            this.Message = message;
            this.Data = data;
        }

        public double Bruto { get; set; }

        
        public double Liquido { get; set; }


    }
}
