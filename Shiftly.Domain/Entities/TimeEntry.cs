using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shiftly.Domain.Entities 
{ 

    public class TimeEntry
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTimeOffset StartUtc { get; set; }
        public DateTimeOffset? EndUtc { get; set; }
        public string Type { get; set; } = "WORK"; // WORK|BREAK|PAUSE|SICK|VACATION
        public string? Notes { get; set; }

        public Employee Employee { get; set; } = default!;
    }
}
