using System;

namespace ClouDeveloper.OpenAPI.Naver.Search
{
    public sealed class ProductSearchResult
    {
        public string Title { get; set; }
        public Uri Link { get; set; }
        public Uri Image { get; set; }
        public decimal LowestPrice { get; set; }
        public decimal HighestPrice { get; set; }
        public string MallName { get; set; }
        public string ProductId { get; set; }
        public ProductType ProductType { get; set; }
    }
}
