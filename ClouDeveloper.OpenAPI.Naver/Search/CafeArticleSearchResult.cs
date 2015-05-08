using System;

namespace ClouDeveloper.OpenAPI.Naver.Search
{
    /// <summary>
    /// CafeArticleSearchResult
    /// </summary>
    public sealed class CafeArticleSearchResult
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the link.
        /// </summary>
        /// <value>
        /// The link.
        /// </value>
        public Uri Link { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the name of the cafe.
        /// </summary>
        /// <value>
        /// The name of the cafe.
        /// </value>
        public string CafeName { get; set; }
        /// <summary>
        /// Gets or sets the cafe URL.
        /// </summary>
        /// <value>
        /// The cafe URL.
        /// </value>
        public Uri CafeUrl { get; set; }
    }
}
