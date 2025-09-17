namespace backendConsoleDemo.Models
{
    public class BaseUser
    {
        public Guid UserGuid { get; set; }
        public int UserTypeId { get; set; }
        public UserType UserType
        {
            get => (UserType)UserTypeId;
            set => UserTypeId = (int)value;
        }
    }
}