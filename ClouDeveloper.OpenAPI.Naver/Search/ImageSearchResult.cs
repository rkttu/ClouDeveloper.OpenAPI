using System;

namespace ClouDeveloper.OpenAPI.Naver.Search
{
    public sealed class ImageSearchResult
    {
        public string Title { get; set; }
        public Uri Link { get; set; }
        public Uri Thumbnail { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
    }
}
