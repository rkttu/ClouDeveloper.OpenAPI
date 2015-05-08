using System;

namespace ClouDeveloper.OpenAPI.TED.Search
{
    /// <summary>
    /// TEDFellowsProfile
    /// </summary>
    public sealed class TEDFellowsProfile : ITEDItem
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int? Id { get; set; }
        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        public int? CreatedBy { get; set; }
        /// <summary>
        /// Gets or sets the old fellow identifier.
        /// </summary>
        /// <value>
        /// The old fellow identifier.
        /// </value>
        public int? OldFellowId { get; set; }
        /// <summary>
        /// Gets or sets the profile identifier.
        /// </summary>
        /// <value>
        /// The profile identifier.
        /// </value>
        public int? ProfileId { get; set; }
        /// <summary>
        /// Gets or sets the event identifier.
        /// </summary>
        /// <value>
        /// The event identifier.
        /// </value>
        public int? EventId { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the middle initial.
        /// </summary>
        /// <value>
        /// The middle initial.
        /// </value>
        public string MiddleInitial { get; set; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the biography.
        /// </summary>
        /// <value>
        /// The biography.
        /// </value>
        public string Biography { get; set; }
        /// <summary>
        /// Gets or sets the questions and answers.
        /// </summary>
        /// <value>
        /// The questions and answers.
        /// </value>
        public string QuestionsAndAnswers { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is senior.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is senior; otherwise, <c>false</c>.
        /// </value>
        public bool IsSenior { get; set; }
        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// Gets or sets the date publish.
        /// </summary>
        /// <value>
        /// The date publish.
        /// </value>
        public DateTime? DatePublish { get; set; }
        /// <summary>
        /// Gets or sets the date expire.
        /// </summary>
        /// <value>
        /// The date expire.
        /// </value>
        public DateTime? DateExpire { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="TEDFellowsProfile"/> is visible.
        /// </summary>
        /// <value>
        ///   <c>true</c> if visible; otherwise, <c>false</c>.
        /// </value>
        public bool Visible { get; set; }
        /// <summary>
        /// Gets or sets the entity status.
        /// </summary>
        /// <value>
        /// The entity status.
        /// </value>
        public string EntityStatus { get; set; }
        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>
        /// The created at.
        /// </value>
        public DateTime? CreatedAt { get; set; }
        /// <summary>
        /// Gets or sets the updated at.
        /// </summary>
        /// <value>
        /// The updated at.
        /// </value>
        public DateTime? UpdatedAt { get; set; }
        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>
        /// The gender.
        /// </value>
        public string Gender { get; set; }
        /// <summary>
        /// Gets or sets the organizations.
        /// </summary>
        /// <value>
        /// The organizations.
        /// </value>
        public string Organizations { get; set; }
        /// <summary>
        /// Gets or sets the favorite meal.
        /// </summary>
        /// <value>
        /// The favorite meal.
        /// </value>
        public string FavoriteMeal { get; set; }
        /// <summary>
        /// Gets or sets something funny.
        /// </summary>
        /// <value>
        /// Something funny.
        /// </value>
        public string SomethingFunny { get; set; }
        /// <summary>
        /// Gets or sets the orientation.
        /// </summary>
        /// <value>
        /// The orientation.
        /// </value>
        public string Orientation { get; set; }
        /// <summary>
        /// Gets or sets the relationship status.
        /// </summary>
        /// <value>
        /// The relationship status.
        /// </value>
        public string RelationshipStatus { get; set; }
        /// <summary>
        /// Gets or sets the children.
        /// </summary>
        /// <value>
        /// The children.
        /// </value>
        public string Children { get; set; }
        /// <summary>
        /// Gets or sets the looking for help with.
        /// </summary>
        /// <value>
        /// The looking for help with.
        /// </value>
        public string LookingForHelpWith { get; set; }
        /// <summary>
        /// Gets or sets the can help with.
        /// </summary>
        /// <value>
        /// The can help with.
        /// </value>
        public string CanHelpWith { get; set; }
        /// <summary>
        /// Gets or sets the name of the twitter user.
        /// </summary>
        /// <value>
        /// The name of the twitter user.
        /// </value>
        public string TwitterUserName { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [show last tweet].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show last tweet]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowLastTweet { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [show recent tweets].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show recent tweets]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowRecentTweets { get; set; }
        /// <summary>
        /// Gets or sets the name of the facebook user.
        /// </summary>
        /// <value>
        /// The name of the facebook user.
        /// </value>
        public string FacebookUserName { get; set; }
        /// <summary>
        /// Gets or sets the name of the skype user.
        /// </summary>
        /// <value>
        /// The name of the skype user.
        /// </value>
        public string SkypeUserName { get; set; }
        /// <summary>
        /// Gets or sets the blog URL.
        /// </summary>
        /// <value>
        /// The blog URL.
        /// </value>
        public Uri BlogUrl { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [show recent blogs].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show recent blogs]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowRecentBlogs { get; set; }
        /// <summary>
        /// Gets or sets the name of the headshot file.
        /// </summary>
        /// <value>
        /// The name of the headshot file.
        /// </value>
        public string HeadshotFileName { get; set; }
        /// <summary>
        /// Gets or sets the type of the headshot content.
        /// </summary>
        /// <value>
        /// The type of the headshot content.
        /// </value>
        public string HeadshotContentType { get; set; }
        /// <summary>
        /// Gets or sets the size of the headshot file.
        /// </summary>
        /// <value>
        /// The size of the headshot file.
        /// </value>
        public long? HeadshotFileSize { get; set; }
        /// <summary>
        /// Gets or sets the headshot updated at.
        /// </summary>
        /// <value>
        /// The headshot updated at.
        /// </value>
        public DateTime? HeadshotUpdatedAt { get; set; }
        /// <summary>
        /// Gets or sets the name of the flickr user.
        /// </summary>
        /// <value>
        /// The name of the flickr user.
        /// </value>
        public string FlickrUserName { get; set; }
        /// <summary>
        /// Gets or sets the flickr user identifier.
        /// </summary>
        /// <value>
        /// The flickr user identifier.
        /// </value>
        public string FlickrUserId { get; set; }
        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        public string FullName { get; set; }
        /// <summary>
        /// Gets or sets the blog feed URL.
        /// </summary>
        /// <value>
        /// The blog feed URL.
        /// </value>
        public Uri BlogFeedUrl { get; set; }
        /// <summary>
        /// Gets or sets the slug.
        /// </summary>
        /// <value>
        /// The slug.
        /// </value>
        public string Slug { get; set; }
    }
}
