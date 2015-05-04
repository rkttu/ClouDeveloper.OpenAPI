
namespace ClouDeveloper.OpenAPI.Naver.Search
{
    public enum ProductType : int
    {
        Undefined = 0,

        NormalPriceComparison = 1,
        NormalPriceComparisonUnmatched = 2,
        NormalPriceComparisonMatched = 3,

        SecondHandPriceComparison = 4,
        SecondHandPriceComparisonUnmatched = 5,
        SecondHandPriceComparisonMatched = 6,

        DiscontinuedPriceComparison = 7,
        DiscontinuedPriceComparisonUnmatched = 8,
        DiscontinuedPriceComparisonMatched = 9,

        PlannedPriceComparison = 10,
        PlannedPriceComparisonUnmatched = 11,
        PlannedPriceComparisonMatched = 12,
    }
}
