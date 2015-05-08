using System;

namespace ClouDeveloper.OpenAPI.Naver.Search
{
    /// <summary>
    /// EncyclopediaSearchResult
    /// </summary>
    public sealed class EncyclopediaSearchResult
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
        /// Gets or sets the thumbnail.
        /// </summary>
        /// <value>
        /// The thumbnail.
        /// </value>
        public Uri Thumbnail { get; set; }
    }
}
