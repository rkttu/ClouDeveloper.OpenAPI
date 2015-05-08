using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClouDeveloper.OpenAPI.TED.Search
{
    /// <summary>
    /// TEDLocalEvent
    /// </summary>
    public sealed class TEDLocalEvent : ITEDItem
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int? Id { get; set; }
        /// <summary>
        /// Gets or sets the tedx group identifier.
        /// </summary>
        /// <value>
        /// The tedx group identifier.
        /// </value>
        public int? TEDXGroupId { get; set; }
        /// <summary>
        /// Gets or sets the tedx venue identifier.
        /// </summary>
        /// <value>
        /// The tedx venue identifier.
        /// </value>
        public int? TEDXVenueId { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the starts at.
        /// </summary>
        /// <value>
        /// The starts at.
        /// </value>
        public DateTime? StartsAt { get; set; }
        /// <summary>
        /// Gets or sets the ends at.
        /// </summary>
        /// <value>
        /// The ends at.
        /// </value>
        public DateTime? EndsAt { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is full.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is full; otherwise, <c>false</c>.
        /// </value>
        public bool IsFull { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is private.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is private; otherwise, <c>false</c>.
        /// </value>
        public bool IsPrivate { get; set; }
        /// <summary>
        /// Gets or sets the size of the event.
        /// </summary>
        /// <value>
        /// The size of the event.
        /// </value>
        public int? EventSize { get; set; }
        /// <summary>
        /// Gets or sets the attendee count.
        /// </summary>
        /// <value>
        /// The attendee count.
        /// </value>
        public int? AttendeeCount { get; set; }
        /// <summary>
        /// Gets or sets the RSVP URL.
        /// </summary>
        /// <value>
        /// The RSVP URL.
        /// </value>
        public Uri RSVPUrl { get; set; }
        /// <summary>
        /// Gets or sets the rsvpe mail.
        /// </summary>
        /// <value>
        /// The rsvpe mail.
        /// </value>
        public string RSVPEMail { get; set; }
        /// <summary>
        /// Gets or sets the acknowledgements.
        /// </summary>
        /// <value>
        /// The acknowledgements.
        /// </value>
        public string Acknowledgements { get; set; }
        /// <summary>
        /// Gets or sets the web stream URL.
        /// </summary>
        /// <value>
        /// The web stream URL.
        /// </value>
        public Uri WebStreamUrl { get; set; }
        /// <summary>
        /// Gets or sets the twitter codes.
        /// </summary>
        /// <value>
        /// The twitter codes.
        /// </value>
        public string TwitterCodes { get; set; }
        /// <summary>
        /// Gets or sets the flickr tags.
        /// </summary>
        /// <value>
        /// The flickr tags.
        /// </value>
        public string FlickrTags { get; set; }
        /// <summary>
        /// Gets or sets you tube playlist.
        /// </summary>
        /// <value>
        /// You tube playlist.
        /// </value>
        public string YouTubePlaylist { get; set; }
        /// <summary>
        /// Gets or sets the ticket price.
        /// </summary>
        /// <value>
        /// The ticket price.
        /// </value>
        public string TicketPrice { get; set; }
        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        /// <value>
        /// The currency.
        /// </value>
        public string Currency { get; set; }
    }
}
