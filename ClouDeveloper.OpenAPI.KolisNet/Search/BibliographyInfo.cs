using System;

namespace ClouDeveloper.OpenAPI.KolisNet.Search
{
    /// <summary>
    /// BibliographyInfo
    /// </summary>
    public class BibliographyInfo
    {
        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        public int Number { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        /// <value>
        /// The author.
        /// </value>
        public string Author { get; set; }
        /// <summary>
        /// Gets or sets the publisher.
        /// </summary>
        /// <value>
        /// The publisher.
        /// </value>
        public string Publisher { get; set; }
        /// <summary>
        /// Gets or sets the published year.
        /// </summary>
        /// <value>
        /// The published year.
        /// </value>
        public string PublishedYear { get; set; }
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public string Type { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance has contents.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance has contents; otherwise, <c>false</c>.
        /// </value>
        public bool HasContents { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance has cover.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has cover; otherwise, <c>false</c>.
        /// </value>
        public bool HasCover { get; set; }
        /// <summary>
        /// Gets or sets the cover image.
        /// </summary>
        /// <value>
        /// The cover image.
        /// </value>
        public Uri CoverImage { get; set; }
        /// <summary>
        /// Gets or sets the name of the library.
        /// </summary>
        /// <value>
        /// The name of the library.
        /// </value>
        public string LibraryName { get; set; }
        /// <summary>
        /// Gets or sets the library code.
        /// </summary>
        /// <value>
        /// The library code.
        /// </value>
        public string LibraryCode { get; set; }
        /// <summary>
        /// Gets or sets the bibliography key.
        /// </summary>
        /// <value>
        /// The bibliography key.
        /// </value>
        public string BibliographyKey { get; set; }
    }
}
