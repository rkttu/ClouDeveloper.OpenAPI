using System;

namespace ClouDeveloper.OpenAPI.Naver.Search
{
    /// <summary>
    /// BlogSearchResult
    /// </summary>
    public sealed class BlogSearchResult
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
        /// Gets or sets the name of the blogger.
        /// </summary>
        /// <value>
        /// The name of the blogger.
        /// </value>
        public string BloggerName { get; set; }
        /// <summary>
        /// Gets or sets the blogger link.
        /// </summary>
        /// <value>
        /// The blogger link.
        /// </value>
        public Uri BloggerLink { get; set; }
    }
}
