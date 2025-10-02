namespace StempelAppCore.Models.Responses
{
    public class BaseEntityResponse
    {
        /// <summary>
        /// Id of the already-authorised user receiving the response
        /// </summary>
        public int AuthUserId { get; set; }
    }
}