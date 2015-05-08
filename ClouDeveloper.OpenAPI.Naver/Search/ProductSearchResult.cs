using System;

namespace ClouDeveloper.OpenAPI.Naver.Search
{
    /// <summary>
    /// ProductSearchResult
    /// </summary>
    public sealed class ProductSearchResult
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
        /// Gets or sets the image.
        /// </summary>
        /// <value>
        /// The image.
        /// </value>
        public Uri Image { get; set; }
        /// <summary>
        /// Gets or sets the lowest price.
        /// </summary>
        /// <value>
        /// The lowest price.
        /// </value>
        public decimal LowestPrice { get; set; }
        /// <summary>
        /// Gets or sets the highest price.
        /// </summary>
        /// <value>
        /// The highest price.
        /// </value>
        public decimal HighestPrice { get; set; }
        /// <summary>
        /// Gets or sets the name of the mall.
        /// </summary>
        /// <value>
        /// The name of the mall.
        /// </value>
        public string MallName { get; set; }
        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        public string ProductId { get; set; }
        /// <summary>
        /// Gets or sets the type of the product.
        /// </summary>
        /// <value>
        /// The type of the product.
        /// </value>
        public ProductType ProductType { get; set; }
    }
}
