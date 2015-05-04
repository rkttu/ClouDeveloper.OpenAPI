using System;

namespace ClouDeveloper.OpenAPI.TED.Search
{
    public sealed class TEDConversation : ITEDItem
    {
        public int? Id { get; set; }
        public int? UserId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Type { get; set; }
        public int? TedCred { get; set; }
        public int? CommentedCount { get; set; }
        public string Description { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
