using System;

namespace ClouDeveloper.OpenAPI.Naver.Search
{
    /// <summary>
    /// BooksSearchResult
    /// </summary>
    public sealed class BooksSearchResult
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
        /// Gets or sets the author.
        /// </summary>
        /// <value>
        /// The author.
        /// </value>
        public string Author {get; set;}
        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public decimal? Price {get; set;}
        /// <summary>
        /// Gets or sets the discount.
        /// </summary>
        /// <value>
        /// The discount.
        /// </value>
        public float? Discount { get; set; }
        /// <summary>
        /// Gets or sets the publisher.
        /// </summary>
        /// <value>
        /// The publisher.
        /// </value>
        public string Publisher { get; set; }
        /// <summary>
        /// Gets or sets the published date time.
        /// </summary>
        /// <value>
        /// The published date time.
        /// </value>
        public DateTime PublishedDateTime { get; set; }
        /// <summary>
        /// Gets or sets the isbn.
        /// </summary>
        /// <value>
        /// The isbn.
        /// </value>
        public string ISBN { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
    }
}
