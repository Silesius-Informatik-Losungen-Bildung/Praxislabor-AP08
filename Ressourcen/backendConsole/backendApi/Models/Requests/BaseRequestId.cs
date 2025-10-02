namespace StempelAppCore.Models.Requests
{
    public class BaseRequestId
    {
        /// <summary>
        /// Id of the already-authorised user receiving the response
        /// </summary>
        public int AuthUserId { get; set; }
    }
}