
namespace ClouDeveloper.OpenAPI.TED.Search
{
    public sealed class TEDTheme : ITEDItem
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortSummary { get; set; }
        public string TalksDescription { get; set; }
        public string SpeakersDescription { get; set; }
        public string Slug { get; set; }
        public bool IsFeatured { get; set; }
    }
}
