using System;

namespace ClouDeveloper.OpenAPI.TED.Search
{
    public sealed class TEDWordPressPost : ITEDItem
    {
        public int? Id { get; set; }
        public string WordPressSubDomain { get; set; }
        public string PostId { get; set; }
        public int? CommentCount { get; set; }
        public string CommentStatus { get; set; }
        public string Guid { get; set; }
        public int? MenuOrder { get; set; }
        public string PingStatus { get; set; }
        public string Pinged { get; set; }
        public string PostAuthor { get; set; }
        public string PostContent { get; set; }
        public string PostContentFiltered { get; set; }
        public DateTime? PostDate { get; set; }
        public DateTime? PostDateGmt { get; set; }
        public string PostExcerpt { get; set; }
        public string PostMimeType { get; set; }
        public DateTime? PostModified { get; set; }
        public DateTime? PostModifiedGmt { get; set; }
        public string PostName { get; set; }
        public string PostParent { get; set; }
        public string PostPassword { get; set; }
        public string PostStatus { get; set; }
        public string PostTitle { get; set; }
        public string PostType { get; set; }
        public string ToPing { get; set; }
        public string PostCategories { get; set; }
    }
}
