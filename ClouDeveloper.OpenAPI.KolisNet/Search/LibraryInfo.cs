using System;

namespace ClouDeveloper.OpenAPI.KolisNet.Search
{
    public sealed class LibraryInfo
    {
        public string LibraryCode { get; set; }
        public string LibraryName { get; set; }
        public string Division { get; set; }
        public string ZipCode { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Address { get; set; }
        public Uri EMail { get; set; }
        public Uri WebSite { get; set; }
    }
}
