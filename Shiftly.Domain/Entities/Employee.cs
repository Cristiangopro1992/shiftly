
namespace Shiftly.Domain.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string CodEtt { get; set; } = default!; // código de trabajador (único)
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public bool IsActive { get; set; } = true;

        public ICollection<TimeEntry> TimeEntries { get; set; } = new List<TimeEntry>();
    }
}
