using System;

namespace ClouDeveloper.OpenAPI.Naver.Search
{
    public sealed class NewsSearchResult
    {
        public string Title { get; set; }
        public Uri OriginalLink { get; set; }
        public Uri Link { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDateTime { get; set; }
    }
}
