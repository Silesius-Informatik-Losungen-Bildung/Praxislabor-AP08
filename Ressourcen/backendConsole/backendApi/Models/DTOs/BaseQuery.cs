namespace StempelAppCore.Models.DTOs
{
    public class BaseQuery
    {
        /// <summary>
        /// Id of the already-authorised user making the request for data-query purposes
        /// </summary>
        public int AuthUserId { get; set; }
    }
}