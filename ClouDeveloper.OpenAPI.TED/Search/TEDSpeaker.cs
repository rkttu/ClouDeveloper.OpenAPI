using System;

namespace ClouDeveloper.OpenAPI.TED.Search
{
    public sealed class TEDSpeaker : ITEDItem
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string WhoTheyAre { get; set; }
        public string WhyListen { get; set; }
        public string Slug { get; set; }
        public DateTime? PublishedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
