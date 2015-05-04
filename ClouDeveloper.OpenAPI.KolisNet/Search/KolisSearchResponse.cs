using System.Collections.Generic;

namespace ClouDeveloper.OpenAPI.KolisNet.Search
{
    public class KolisSearchResponse : List<BibliographyInfo>
    {
        public int Total { get; set; }
    }
}
