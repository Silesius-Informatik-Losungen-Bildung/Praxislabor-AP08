namespace StempelApp.Viewmodels
{
    public class UserHomepageViewModel
    {
        public List<ProjectInfo> Projects { get; set; } = new();
    }

    public class ProjectInfo
    {
        public string CustomerName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public DateTime StartTime { get; set; }
    }
}
