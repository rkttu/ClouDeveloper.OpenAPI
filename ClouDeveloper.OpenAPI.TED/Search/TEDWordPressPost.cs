using System;

namespace ClouDeveloper.OpenAPI.TED.Search
{
    /// <summary>
    /// TEDWordPressPost
    /// </summary>
    public sealed class TEDWordPressPost : ITEDItem
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int? Id { get; set; }
        /// <summary>
        /// Gets or sets the word press sub domain.
        /// </summary>
        /// <value>
        /// The word press sub domain.
        /// </value>
        public string WordPressSubDomain { get; set; }
        /// <summary>
        /// Gets or sets the post identifier.
        /// </summary>
        /// <value>
        /// The post identifier.
        /// </value>
        public string PostId { get; set; }
        /// <summary>
        /// Gets or sets the comment count.
        /// </summary>
        /// <value>
        /// The comment count.
        /// </value>
        public int? CommentCount { get; set; }
        /// <summary>
        /// Gets or sets the comment status.
        /// </summary>
        /// <value>
        /// The comment status.
        /// </value>
        public string CommentStatus { get; set; }
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        /// <value>
        /// The unique identifier.
        /// </value>
        public string Guid { get; set; }
        /// <summary>
        /// Gets or sets the menu order.
        /// </summary>
        /// <value>
        /// The menu order.
        /// </value>
        public int? MenuOrder { get; set; }
        /// <summary>
        /// Gets or sets the ping status.
        /// </summary>
        /// <value>
        /// The ping status.
        /// </value>
        public string PingStatus { get; set; }
        /// <summary>
        /// Gets or sets the pinged.
        /// </summary>
        /// <value>
        /// The pinged.
        /// </value>
        public string Pinged { get; set; }
        /// <summary>
        /// Gets or sets the post author.
        /// </summary>
        /// <value>
        /// The post author.
        /// </value>
        public string PostAuthor { get; set; }
        /// <summary>
        /// Gets or sets the content of the post.
        /// </summary>
        /// <value>
        /// The content of the post.
        /// </value>
        public string PostContent { get; set; }
        /// <summary>
        /// Gets or sets the post content filtered.
        /// </summary>
        /// <value>
        /// The post content filtered.
        /// </value>
        public string PostContentFiltered { get; set; }
        /// <summary>
        /// Gets or sets the post date.
        /// </summary>
        /// <value>
        /// The post date.
        /// </value>
        public DateTime? PostDate { get; set; }
        /// <summary>
        /// Gets or sets the post date GMT.
        /// </summary>
        /// <value>
        /// The post date GMT.
        /// </value>
        public DateTime? PostDateGmt { get; set; }
        /// <summary>
        /// Gets or sets the post excerpt.
        /// </summary>
        /// <value>
        /// The post excerpt.
        /// </value>
        public string PostExcerpt { get; set; }
        /// <summary>
        /// Gets or sets the type of the post MIME.
        /// </summary>
        /// <value>
        /// The type of the post MIME.
        /// </value>
        public string PostMimeType { get; set; }
        /// <summary>
        /// Gets or sets the post modified.
        /// </summary>
        /// <value>
        /// The post modified.
        /// </value>
        public DateTime? PostModified { get; set; }
        /// <summary>
        /// Gets or sets the post modified GMT.
        /// </summary>
        /// <value>
        /// The post modified GMT.
        /// </value>
        public DateTime? PostModifiedGmt { get; set; }
        /// <summary>
        /// Gets or sets the name of the post.
        /// </summary>
        /// <value>
        /// The name of the post.
        /// </value>
        public string PostName { get; set; }
        /// <summary>
        /// Gets or sets the post parent.
        /// </summary>
        /// <value>
        /// The post parent.
        /// </value>
        public string PostParent { get; set; }
        /// <summary>
        /// Gets or sets the post password.
        /// </summary>
        /// <value>
        /// The post password.
        /// </value>
        public string PostPassword { get; set; }
        /// <summary>
        /// Gets or sets the post status.
        /// </summary>
        /// <value>
        /// The post status.
        /// </value>
        public string PostStatus { get; set; }
        /// <summary>
        /// Gets or sets the post title.
        /// </summary>
        /// <value>
        /// The post title.
        /// </value>
        public string PostTitle { get; set; }
        /// <summary>
        /// Gets or sets the type of the post.
        /// </summary>
        /// <value>
        /// The type of the post.
        /// </value>
        public string PostType { get; set; }
        /// <summary>
        /// Gets or sets to ping.
        /// </summary>
        /// <value>
        /// To ping.
        /// </value>
        public string ToPing { get; set; }
        /// <summary>
        /// Gets or sets the post categories.
        /// </summary>
        /// <value>
        /// The post categories.
        /// </value>
        public string PostCategories { get; set; }
    }
}
