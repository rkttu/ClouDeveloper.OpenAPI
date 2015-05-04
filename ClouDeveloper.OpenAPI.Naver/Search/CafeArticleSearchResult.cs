using System;

namespace ClouDeveloper.OpenAPI.Naver.Search
{
    public sealed class CafeArticleSearchResult
    {
        public string Title { get; set; }
        public Uri Link { get; set; }
        public string Description { get; set; }
        public string CafeName { get; set; }
        public Uri CafeUrl { get; set; }
    }
}
