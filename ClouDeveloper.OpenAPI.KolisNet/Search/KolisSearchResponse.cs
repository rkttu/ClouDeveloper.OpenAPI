using System.Collections.Generic;

namespace ClouDeveloper.OpenAPI.KolisNet.Search
{
    /// <summary>
    /// KolisSearchResponse
    /// </summary>
    public class KolisSearchResponse : List<BibliographyInfo>
    {
        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>
        /// The total.
        /// </value>
        public int Total { get; set; }
    }
}
