using System;

namespace ClouDeveloper.OpenAPI.Naver.Search
{
    /// <summary>
    /// LocalSearchResult
    /// </summary>
    public sealed class LocalSearchResult
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the link.
        /// </summary>
        /// <value>
        /// The link.
        /// </value>
        public Uri Link { get; set; }
        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public string[] Category { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the telephone.
        /// </summary>
        /// <value>
        /// The telephone.
        /// </value>
        public string Telephone { get; set; }
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string Address { get; set; }
        /// <summary>
        /// Gets or sets the road address.
        /// </summary>
        /// <value>
        /// The road address.
        /// </value>
        public string RoadAddress { get; set; }
        /// <summary>
        /// Gets or sets the map x.
        /// </summary>
        /// <value>
        /// The map x.
        /// </value>
        public double MapX { get; set; }
        /// <summary>
        /// Gets or sets the map y.
        /// </summary>
        /// <value>
        /// The map y.
        /// </value>
        public double MapY { get; set; }
    }
}
