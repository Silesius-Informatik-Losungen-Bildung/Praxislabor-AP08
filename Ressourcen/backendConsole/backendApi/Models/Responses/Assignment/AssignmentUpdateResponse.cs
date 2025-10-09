namespace StempelAppCore.Models.Responses.Assignment
{
    public class AssignmentUpdateResponse : BaseResponse
    {
        public string? UpdatedLocation { get; set; }
        public string? UpdatedLocationName { get; set; }
        public string? UpdatedComment { get; set; }
        public byte[]? UpdatedPicture { get; set; }
        public DateTime? UpdatedTimeStamp { get; set; }
        public DateTime? UpdatedStartTime { get; set; }
        public DateTime? UpdatedEndTime { get; set; }
        public TimeSpan? UpdatedWorkTime => UpdatedEndTime - UpdatedStartTime;
    }
}