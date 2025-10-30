namespace StempelAppCore.Models.Domain
{
    public class AssignmentPicture : BaseEntity
    {
        public byte[]? PictureBytes { get; set; }
        public string? PictureBase64 { get; set; }
        public string? PictureURL { get; set; }
    }
}