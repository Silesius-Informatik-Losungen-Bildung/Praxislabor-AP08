namespace StempelAppCore.Models.Requests
{
    public class BaseEntityRequest
    {
        /// <summary>
        /// Id of the already-authorised user making the request for query purposes
        /// </summary>
        public int AuthUserId { get; set; }
    }
}