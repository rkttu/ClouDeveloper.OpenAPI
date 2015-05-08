
namespace ClouDeveloper.OpenAPI.TED.Search
{
    /// <summary>
    /// TEDTheme
    /// </summary>
    public sealed class TEDTheme : ITEDItem
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int? Id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the short summary.
        /// </summary>
        /// <value>
        /// The short summary.
        /// </value>
        public string ShortSummary { get; set; }
        /// <summary>
        /// Gets or sets the talks description.
        /// </summary>
        /// <value>
        /// The talks description.
        /// </value>
        public string TalksDescription { get; set; }
        /// <summary>
        /// Gets or sets the speakers description.
        /// </summary>
        /// <value>
        /// The speakers description.
        /// </value>
        public string SpeakersDescription { get; set; }
        /// <summary>
        /// Gets or sets the slug.
        /// </summary>
        /// <value>
        /// The slug.
        /// </value>
        public string Slug { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is featured.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is featured; otherwise, <c>false</c>.
        /// </value>
        public bool IsFeatured { get; set; }
    }
}
