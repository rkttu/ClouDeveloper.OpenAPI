using System;
using System.Collections.Generic;

namespace ClouDeveloper.OpenAPI.KolisNet.Search
{
    public sealed class BibliographyDetailInfoResponse
    {
        public string BibliographyKey { get; set; }
        public string TitleInfo { get; set; }
        public string EditionInfo { get; set; }
        public string CartographicInfo { get; set; }
        public string PublishInfo { get; set; }
        public string FormInfo { get; set; }
        public string SeriesInfo { get; set; }
        public string NoteInfo { get; set; }
        public string StandardInfo { get; set; }
        public string ClassificationInfo { get; set; }
        public string SubjectName { get; set; }
        public bool HasContents { get; set; }
        public bool HasAbstracts { get; set; }
        public bool HasCover { get; set; }
        public Uri CoverImage { get; set; }
        public string UBControlNumber { get; set; }
        public bool HasOriginal { get; set; }
        public bool HasCopyright { get; set; }
        public string LocalControlNumber { get; set; }
        public string ISBN { get; set; }
        public string PriceInfo { get; set; }

        public List<BibiliographyHoldInfo> HoldLibraries { get; set; }
    }
}
