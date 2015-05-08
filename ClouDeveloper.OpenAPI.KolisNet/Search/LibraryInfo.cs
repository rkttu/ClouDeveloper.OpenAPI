using System;

namespace ClouDeveloper.OpenAPI.KolisNet.Search
{
    /// <summary>
    /// LibraryInfo
    /// </summary>
    public sealed class LibraryInfo
    {
        /// <summary>
        /// Gets or sets the library code.
        /// </summary>
        /// <value>
        /// The library code.
        /// </value>
        public string LibraryCode { get; set; }
        /// <summary>
        /// Gets or sets the name of the library.
        /// </summary>
        /// <value>
        /// The name of the library.
        /// </value>
        public string LibraryName { get; set; }
        /// <summary>
        /// Gets or sets the division.
        /// </summary>
        /// <value>
        /// The division.
        /// </value>
        public string Division { get; set; }
        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        /// <value>
        /// The zip code.
        /// </value>
        public string ZipCode { get; set; }
        /// <summary>
        /// Gets or sets the telephone.
        /// </summary>
        /// <value>
        /// The telephone.
        /// </value>
        public string Telephone { get; set; }
        /// <summary>
        /// Gets or sets the fax.
        /// </summary>
        /// <value>
        /// The fax.
        /// </value>
        public string Fax { get; set; }
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string Address { get; set; }
        /// <summary>
        /// Gets or sets the e mail.
        /// </summary>
        /// <value>
        /// The e mail.
        /// </value>
        public Uri EMail { get; set; }
        /// <summary>
        /// Gets or sets the web site.
        /// </summary>
        /// <value>
        /// The web site.
        /// </value>
        public Uri WebSite { get; set; }
    }
}
