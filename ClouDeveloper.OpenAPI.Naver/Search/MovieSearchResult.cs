using System;

namespace ClouDeveloper.OpenAPI.Naver.Search
{
    public sealed class MovieSearchResult
    {
        public string Title { get; set; }
        public Uri Link { get; set; }
        public Uri Image { get; set; }
        public string Subtitle { get; set; }
        public DateTime PublishedDateTime { get; set; }
        public string[] Directors { get; set; }
        public string[] Actors { get; set; }
        public float UserRating { get; set; }
    }
}
