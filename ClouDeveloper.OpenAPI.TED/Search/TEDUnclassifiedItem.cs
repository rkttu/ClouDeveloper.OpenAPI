
namespace ClouDeveloper.OpenAPI.TED.Search
{
    /// <summary>
    /// TEDUnclassifiedItem
    /// </summary>
    public sealed class TEDUnclassifiedItem : ITEDItem
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int? Id { get; set; }
        /// <summary>
        /// Gets or sets the raw XML.
        /// </summary>
        /// <value>
        /// The raw XML.
        /// </value>
        public string RawXml { get; set; }
    }
}
