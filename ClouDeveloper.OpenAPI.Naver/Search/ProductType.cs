
namespace ClouDeveloper.OpenAPI.Naver.Search
{
    /// <summary>
    /// ProductType
    /// </summary>
    public enum ProductType : int
    {
        /// <summary>
        /// The undefined
        /// </summary>
        Undefined = 0,

        /// <summary>
        /// The normal price comparison
        /// </summary>
        NormalPriceComparison = 1,
        /// <summary>
        /// The normal price comparison unmatched
        /// </summary>
        NormalPriceComparisonUnmatched = 2,
        /// <summary>
        /// The normal price comparison matched
        /// </summary>
        NormalPriceComparisonMatched = 3,

        /// <summary>
        /// The second hand price comparison
        /// </summary>
        SecondHandPriceComparison = 4,
        /// <summary>
        /// The second hand price comparison unmatched
        /// </summary>
        SecondHandPriceComparisonUnmatched = 5,
        /// <summary>
        /// The second hand price comparison matched
        /// </summary>
        SecondHandPriceComparisonMatched = 6,

        /// <summary>
        /// The discontinued price comparison
        /// </summary>
        DiscontinuedPriceComparison = 7,
        /// <summary>
        /// The discontinued price comparison unmatched
        /// </summary>
        DiscontinuedPriceComparisonUnmatched = 8,
        /// <summary>
        /// The discontinued price comparison matched
        /// </summary>
        DiscontinuedPriceComparisonMatched = 9,

        /// <summary>
        /// The planned price comparison
        /// </summary>
        PlannedPriceComparison = 10,
        /// <summary>
        /// The planned price comparison unmatched
        /// </summary>
        PlannedPriceComparisonUnmatched = 11,
        /// <summary>
        /// The planned price comparison matched
        /// </summary>
        PlannedPriceComparisonMatched = 12,
    }
}
