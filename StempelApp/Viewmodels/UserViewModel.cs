namespace StempelApp.Viewmodels
{
    public class UserViewModel
    {
        public string UserEmail { get; set; } = null!;
        public List<ProjectInfo> Projects { get; set; } = new();
    }

    public class ProjectInfo
    {
        public string CustomerName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public DateTime StartTime { get; set; }

        public List<string> Activities { get; set; } = new();
    }
}
