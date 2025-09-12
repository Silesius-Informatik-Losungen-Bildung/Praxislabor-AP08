namespace backendConsoleDemo.Models.Interfaces
{
    public interface IEntry
    {
        int EntryId { get; set; }
        int EmployeeId { get; set; }
        double GPSLongitude { get; set; }
        double GPSLatitude { get; set; }
        string? Comment { get; set; }
        byte[]? Picture { get; set; }
    }
}