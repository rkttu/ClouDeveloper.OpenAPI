using System;

namespace ClouDeveloper.OpenAPI.Naver.Search
{
    /// <summary>
    /// NewsSearchResult
    /// </summary>
    public sealed class NewsSearchResult
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the original link.
        /// </summary>
        /// <value>
        /// The original link.
        /// </value>
        public Uri OriginalLink { get; set; }
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
        /// Gets or sets the published date time.
        /// </summary>
        /// <value>
        /// The published date time.
        /// </value>
        public DateTime PublishedDateTime { get; set; }
    }
}
