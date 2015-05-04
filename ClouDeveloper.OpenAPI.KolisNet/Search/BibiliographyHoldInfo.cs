
namespace ClouDeveloper.OpenAPI.KolisNet.Search
{
    public sealed class BibiliographyHoldInfo
    {
        public int Number { get; set; }
        public LibraryLocalAreaCode LibraryLocalArea { get; set; }
        public string LibraryCode { get; set; }
        public string LibraryName { get; set; }
        public string CallNumber { get; set; }
        public string StartVolume { get; set; }
        public bool HasOriginal { get; set; }
    }
}
