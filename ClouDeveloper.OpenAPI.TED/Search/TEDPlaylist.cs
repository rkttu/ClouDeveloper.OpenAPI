using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClouDeveloper.OpenAPI.TED.Search
{
    public sealed class TEDPlaylist : ITEDItem
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
