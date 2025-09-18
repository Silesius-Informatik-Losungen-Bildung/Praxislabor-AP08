using backendConsoleDemo.Models;

namespace StempelAppCore.Models
{
    public class Project : BaseEntity
    {
        public string CompanyName { get; set; } // CompanyClass?
        public string CustomerName { get; set; } // CustomerClass?
        public string Address { get; set; } // AddressClass?
        public ICollection<string> Activities { get; set; } = new List<string>();
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public TimeSpan? PlannedTime { get; set; }
    }
}