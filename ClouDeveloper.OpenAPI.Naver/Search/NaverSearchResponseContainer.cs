using System;
using System.Collections.Generic;

namespace ClouDeveloper.OpenAPI.Naver.Search
{
    /// <summary>
    /// NaverSearchResponseContainer
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class NaverSearchResponseContainer<T> : List<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NaverSearchResponseContainer{T}" /> class.
        /// </summary>
        public NaverSearchResponseContainer()
            : base()
        {
        }

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
        /// Gets or sets the last build date.
        /// </summary>
        /// <value>
        /// The last build date.
        /// </value>
        public DateTime LastBuildDate { get; set; }
        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>
        /// The total.
        /// </value>
        public int Total { get; set; }
        /// <summary>
        /// Gets or sets the start.
        /// </summary>
        /// <value>
        /// The start.
        /// </value>
        public int Start { get; set; }
        /// <summary>
        /// Gets or sets the display.
        /// </summary>
        /// <value>
        /// The display.
        /// </value>
        public int Display { get; set; }

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public IEnumerable<T> Items { get { return this; } }
    }
}
