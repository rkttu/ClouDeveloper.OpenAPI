using System;

namespace ClouDeveloper.OpenAPI.TED.Search
{
    public sealed class TEDTalk : ITEDItem
    {
        public int? Id { get; set; }
        public int? EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public string NativeLanguageCode { get; set; }
        public DateTime? PublishedAt { get; set; }
        public DateTime? RecordedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? ReleasedAt { get; set; }
    }
}
