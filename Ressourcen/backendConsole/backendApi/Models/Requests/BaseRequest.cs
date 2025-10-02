namespace StempelAppCore.Models.Requests
{
    public class BaseRequest : BaseRequestId
    {
        /// <summary>
        /// Id of the already-authorised user making the request for query purposes
        /// </summary>
        public int AuthUserId { get; set; }

        /// <summary>
        /// Current page number (starting from 1)
        /// </summary>
        public int PageNumber { get; set; } = 1;

        /// <summary>
        /// Number of items per page
        /// </summary>
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// Optional search or filter term
        /// </summary>
        public string? SearchTerm { get; set; }

        /// <summary>
        /// Optional property for sorting (e.g., "Name" or "CreatedDate")
        /// </summary>
        public string? SortBy { get; set; }

        /// <summary>
        /// Sorting order (true = ascending, false = descending)
        /// </summary>
        public bool IsAscending { get; set; } = true;

        /// <summary>
        /// Calculates the number of items to skip for pagination
        /// </summary>
        public int Skip => (PageNumber - 1) * PageSize;
    }
}