using System;

namespace ClouDeveloper.OpenAPI.Naver.Search
{
    /// <summary>
    /// MovieSearchResult
    /// </summary>
    public sealed class MovieSearchResult
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
        /// Gets or sets the image.
        /// </summary>
        /// <value>
        /// The image.
        /// </value>
        public Uri Image { get; set; }
        /// <summary>
        /// Gets or sets the subtitle.
        /// </summary>
        /// <value>
        /// The subtitle.
        /// </value>
        public string Subtitle { get; set; }
        /// <summary>
        /// Gets or sets the published date time.
        /// </summary>
        /// <value>
        /// The published date time.
        /// </value>
        public DateTime PublishedDateTime { get; set; }
        /// <summary>
        /// Gets or sets the directors.
        /// </summary>
        /// <value>
        /// The directors.
        /// </value>
        public string[] Directors { get; set; }
        /// <summary>
        /// Gets or sets the actors.
        /// </summary>
        /// <value>
        /// The actors.
        /// </value>
        public string[] Actors { get; set; }
        /// <summary>
        /// Gets or sets the user rating.
        /// </summary>
        /// <value>
        /// The user rating.
        /// </value>
        public float UserRating { get; set; }
    }
}
