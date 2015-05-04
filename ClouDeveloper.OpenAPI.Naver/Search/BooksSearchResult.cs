using System;

namespace ClouDeveloper.OpenAPI.Naver.Search
{
    public sealed class BooksSearchResult
    {
        public string Title { get; set; }
        public Uri Link { get; set; }
        public Uri Image { get; set; }
        public string Author {get; set;}
        public decimal? Price {get; set;}
        public float? Discount { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishedDateTime { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
    }
}
