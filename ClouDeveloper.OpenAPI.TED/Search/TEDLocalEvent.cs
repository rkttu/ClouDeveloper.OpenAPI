using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClouDeveloper.OpenAPI.TED.Search
{
    public sealed class TEDLocalEvent : ITEDItem
    {
        public int? Id { get; set; }
        public int? TEDXGroupId { get; set; }
        public int? TEDXVenueId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? StartsAt { get; set; }
        public DateTime? EndsAt { get; set; }
        public bool IsFull { get; set; }
        public bool IsPrivate { get; set; }
        public int? EventSize { get; set; }
        public int? AttendeeCount { get; set; }
        public Uri RSVPUrl { get; set; }
        public string RSVPEMail { get; set; }
        public string Acknowledgements { get; set; }
        public Uri WebStreamUrl { get; set; }
        public string TwitterCodes { get; set; }
        public string FlickrTags { get; set; }
        public string YouTubePlaylist { get; set; }
        public string TicketPrice { get; set; }
        public string Currency { get; set; }
    }
}
