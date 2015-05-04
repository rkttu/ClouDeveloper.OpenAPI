using System;

namespace ClouDeveloper.OpenAPI.TED.Search
{
    public sealed class TEDFellowsProfile : ITEDItem
    {
        public int? Id { get; set; }
        public int? CreatedBy { get; set; }
        public int? OldFellowId { get; set; }
        public int? ProfileId { get; set; }
        public int? EventId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string Biography { get; set; }
        public string QuestionsAndAnswers { get; set; }
        public bool IsSenior { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? DatePublish { get; set; }
        public DateTime? DateExpire { get; set; }
        public bool Visible { get; set; }
        public string EntityStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Gender { get; set; }
        public string Organizations { get; set; }
        public string FavoriteMeal { get; set; }
        public string SomethingFunny { get; set; }
        public string Orientation { get; set; }
        public string RelationshipStatus { get; set; }
        public string Children { get; set; }
        public string LookingForHelpWith { get; set; }
        public string CanHelpWith { get; set; }
        public string TwitterUserName { get; set; }
        public bool ShowLastTweet { get; set; }
        public bool ShowRecentTweets { get; set; }
        public string FacebookUserName { get; set; }
        public string SkypeUserName { get; set; }
        public Uri BlogUrl { get; set; }
        public bool ShowRecentBlogs { get; set; }
        public string HeadshotFileName { get; set; }
        public string HeadshotContentType { get; set; }
        public long? HeadshotFileSize { get; set; }
        public DateTime? HeadshotUpdatedAt { get; set; }
        public string FlickrUserName { get; set; }
        public string FlickrUserId { get; set; }
        public string FullName { get; set; }
        public Uri BlogFeedUrl { get; set; }
        public string Slug { get; set; }
    }
}
