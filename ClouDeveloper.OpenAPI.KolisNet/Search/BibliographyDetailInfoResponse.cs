using System;
using System.Collections.Generic;

namespace ClouDeveloper.OpenAPI.KolisNet.Search
{
    /// <summary>
    /// BibliographyDetailInfoResponse
    /// </summary>
    public sealed class BibliographyDetailInfoResponse
    {
        /// <summary>
        /// Gets or sets the bibliography key.
        /// </summary>
        /// <value>
        /// The bibliography key.
        /// </value>
        public string BibliographyKey { get; set; }
        /// <summary>
        /// Gets or sets the title information.
        /// </summary>
        /// <value>
        /// The title information.
        /// </value>
        public string TitleInfo { get; set; }
        /// <summary>
        /// Gets or sets the edition information.
        /// </summary>
        /// <value>
        /// The edition information.
        /// </value>
        public string EditionInfo { get; set; }
        /// <summary>
        /// Gets or sets the cartographic information.
        /// </summary>
        /// <value>
        /// The cartographic information.
        /// </value>
        public string CartographicInfo { get; set; }
        /// <summary>
        /// Gets or sets the publish information.
        /// </summary>
        /// <value>
        /// The publish information.
        /// </value>
        public string PublishInfo { get; set; }
        /// <summary>
        /// Gets or sets the form information.
        /// </summary>
        /// <value>
        /// The form information.
        /// </value>
        public string FormInfo { get; set; }
        /// <summary>
        /// Gets or sets the series information.
        /// </summary>
        /// <value>
        /// The series information.
        /// </value>
        public string SeriesInfo { get; set; }
        /// <summary>
        /// Gets or sets the note information.
        /// </summary>
        /// <value>
        /// The note information.
        /// </value>
        public string NoteInfo { get; set; }
        /// <summary>
        /// Gets or sets the standard information.
        /// </summary>
        /// <value>
        /// The standard information.
        /// </value>
        public string StandardInfo { get; set; }
        /// <summary>
        /// Gets or sets the classification information.
        /// </summary>
        /// <value>
        /// The classification information.
        /// </value>
        public string ClassificationInfo { get; set; }
        /// <summary>
        /// Gets or sets the name of the subject.
        /// </summary>
        /// <value>
        /// The name of the subject.
        /// </value>
        public string SubjectName { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance has contents.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance has contents; otherwise, <c>false</c>.
        /// </value>
        public bool HasContents { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance has abstracts.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance has abstracts; otherwise, <c>false</c>.
        /// </value>
        public bool HasAbstracts { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance has cover.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has cover; otherwise, <c>false</c>.
        /// </value>
        public bool HasCover { get; set; }
        /// <summary>
        /// Gets or sets the cover image.
        /// </summary>
        /// <value>
        /// The cover image.
        /// </value>
        public Uri CoverImage { get; set; }
        /// <summary>
        /// Gets or sets the ub control number.
        /// </summary>
        /// <value>
        /// The ub control number.
        /// </value>
        public string UBControlNumber { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance has original.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance has original; otherwise, <c>false</c>.
        /// </value>
        public bool HasOriginal { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance has copyright.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance has copyright; otherwise, <c>false</c>.
        /// </value>
        public bool HasCopyright { get; set; }
        /// <summary>
        /// Gets or sets the local control number.
        /// </summary>
        /// <value>
        /// The local control number.
        /// </value>
        public string LocalControlNumber { get; set; }
        /// <summary>
        /// Gets or sets the isbn.
        /// </summary>
        /// <value>
        /// The isbn.
        /// </value>
        public string ISBN { get; set; }
        /// <summary>
        /// Gets or sets the price information.
        /// </summary>
        /// <value>
        /// The price information.
        /// </value>
        public string PriceInfo { get; set; }

        /// <summary>
        /// Gets or sets the hold libraries.
        /// </summary>
        /// <value>
        /// The hold libraries.
        /// </value>
        public List<BibiliographyHoldInfo> HoldLibraries { get; set; }
    }
}
