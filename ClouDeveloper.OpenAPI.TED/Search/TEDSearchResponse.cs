using System.Collections.Generic;

namespace ClouDeveloper.OpenAPI.TED.Search
{
    public sealed class TEDSearchResponse
    {
        public string Query { get; set; }
        public string IntendedCategories { get; set; }
        public List<ITEDItem> Results { get; set; }
    }
}
