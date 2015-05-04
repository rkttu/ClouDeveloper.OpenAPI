using System;

namespace ClouDeveloper.OpenAPI.Naver.Search
{
    public sealed class BlogSearchResult
    {
        public string Title { get; set; }
        public Uri Link { get; set; }
        public string Description { get; set; }
        public string BloggerName { get; set; }
        public Uri BloggerLink { get; set; }
    }
}
