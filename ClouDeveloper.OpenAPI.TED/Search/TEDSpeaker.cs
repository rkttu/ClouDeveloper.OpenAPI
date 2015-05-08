using System;

namespace ClouDeveloper.OpenAPI.TED.Search
{
    /// <summary>
    /// TEDSpeaker
    /// </summary>
    public sealed class TEDSpeaker : ITEDItem
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int? Id { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the middle initial.
        /// </summary>
        /// <value>
        /// The middle initial.
        /// </value>
        public string MiddleInitial { get; set; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the who they are.
        /// </summary>
        /// <value>
        /// The who they are.
        /// </value>
        public string WhoTheyAre { get; set; }
        /// <summary>
        /// Gets or sets the why listen.
        /// </summary>
        /// <value>
        /// The why listen.
        /// </value>
        public string WhyListen { get; set; }
        /// <summary>
        /// Gets or sets the slug.
        /// </summary>
        /// <value>
        /// The slug.
        /// </value>
        public string Slug { get; set; }
        /// <summary>
        /// Gets or sets the published at.
        /// </summary>
        /// <value>
        /// The published at.
        /// </value>
        public DateTime? PublishedAt { get; set; }
        /// <summary>
        /// Gets or sets the updated at.
        /// </summary>
        /// <value>
        /// The updated at.
        /// </value>
        public DateTime? UpdatedAt { get; set; }
    }
}
