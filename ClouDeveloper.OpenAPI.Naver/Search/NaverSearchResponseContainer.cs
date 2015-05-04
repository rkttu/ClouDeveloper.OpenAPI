using System;
using System.Collections.Generic;

namespace ClouDeveloper.OpenAPI.Naver.Search
{
    public sealed class NaverSearchResponseContainer<T> : List<T>
    {
        public NaverSearchResponseContainer()
            : base()
        {
        }

        public string Title { get; set; }
        public Uri Link { get; set; }
        public string Description { get; set; }
        public DateTime LastBuildDate { get; set; }
        public int Total { get; set; }
        public int Start { get; set; }
        public int Display { get; set; }

        public IEnumerable<T> Items { get { return this; } }
    }
}
