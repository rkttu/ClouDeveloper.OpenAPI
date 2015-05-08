
namespace ClouDeveloper.OpenAPI.KolisNet.Search
{
    /// <summary>
    /// BibiliographyHoldInfo
    /// </summary>
    public sealed class BibiliographyHoldInfo
    {
        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        public int Number { get; set; }
        /// <summary>
        /// Gets or sets the library local area.
        /// </summary>
        /// <value>
        /// The library local area.
        /// </value>
        public LibraryLocalAreaCode LibraryLocalArea { get; set; }
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
        /// Gets or sets the call number.
        /// </summary>
        /// <value>
        /// The call number.
        /// </value>
        public string CallNumber { get; set; }
        /// <summary>
        /// Gets or sets the start volume.
        /// </summary>
        /// <value>
        /// The start volume.
        /// </value>
        public string StartVolume { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance has original.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance has original; otherwise, <c>false</c>.
        /// </value>
        public bool HasOriginal { get; set; }
    }
}
