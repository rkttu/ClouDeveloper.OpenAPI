using System;

namespace ClouDeveloper.OpenAPI.KolisNet.Search
{
    public class BibliographyInfo
    {
        public int Number { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string PublishedYear { get; set; }
        public string Type { get; set; }
        public bool HasContents { get; set; }
        public bool HasCover { get; set; }
        public Uri CoverImage { get; set; }
        public string LibraryName { get; set; }
        public string LibraryCode { get; set; }
        public string BibliographyKey { get; set; }
    }
}
