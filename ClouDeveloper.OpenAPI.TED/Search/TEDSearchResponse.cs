using System.Collections.Generic;

namespace ClouDeveloper.OpenAPI.TED.Search
{
    /// <summary>
    /// TEDSearchResponse
    /// </summary>
    public sealed class TEDSearchResponse
    {
        /// <summary>
        /// Gets or sets the query.
        /// </summary>
        /// <value>
        /// The query.
        /// </value>
        public string Query { get; set; }
        /// <summary>
        /// Gets or sets the intended categories.
        /// </summary>
        /// <value>
        /// The intended categories.
        /// </value>
        public string IntendedCategories { get; set; }
        /// <summary>
        /// Gets or sets the results.
        /// </summary>
        /// <value>
        /// The results.
        /// </value>
        public List<ITEDItem> Results { get; set; }
    }
}
