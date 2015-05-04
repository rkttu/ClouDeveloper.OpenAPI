using System;

namespace ClouDeveloper.OpenAPI.Naver.Search
{
    public sealed class LocalSearchResult
    {
        public string Title { get; set; }
        public Uri Link { get; set; }
        public string[] Category { get; set; }
        public string Description { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public string RoadAddress { get; set; }
        public double MapX { get; set; }
        public double MapY { get; set; }
    }
}
