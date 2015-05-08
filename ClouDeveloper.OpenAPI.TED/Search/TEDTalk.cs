using System;

namespace ClouDeveloper.OpenAPI.TED.Search
{
    /// <summary>
    /// TEDTalk
    /// </summary>
    public sealed class TEDTalk : ITEDItem
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int? Id { get; set; }
        /// <summary>
        /// Gets or sets the event identifier.
        /// </summary>
        /// <value>
        /// The event identifier.
        /// </value>
        public int? EventId { get; set; }
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
        /// Gets or sets the slug.
        /// </summary>
        /// <value>
        /// The slug.
        /// </value>
        public string Slug { get; set; }
        /// <summary>
        /// Gets or sets the native language code.
        /// </summary>
        /// <value>
        /// The native language code.
        /// </value>
        public string NativeLanguageCode { get; set; }
        /// <summary>
        /// Gets or sets the published at.
        /// </summary>
        /// <value>
        /// The published at.
        /// </value>
        public DateTime? PublishedAt { get; set; }
        /// <summary>
        /// Gets or sets the recorded at.
        /// </summary>
        /// <value>
        /// The recorded at.
        /// </value>
        public DateTime? RecordedAt { get; set; }
        /// <summary>
        /// Gets or sets the updated at.
        /// </summary>
        /// <value>
        /// The updated at.
        /// </value>
        public DateTime? UpdatedAt { get; set; }
        /// <summary>
        /// Gets or sets the released at.
        /// </summary>
        /// <value>
        /// The released at.
        /// </value>
        public DateTime? ReleasedAt { get; set; }
    }
}
