using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B3.Domain.Commands
{
    public abstract class CommandResult
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public IReadOnlyCollection<Flunt.Notifications.Notification> Data { get; set; } = new List<Flunt.Notifications.Notification>();
    }
}
