using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Xml;

namespace ClouDeveloper.OpenAPI.TED.Search
{
    /// <summary>
    /// TEDSearchClient
    /// </summary>
    public sealed class TEDSearchClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TEDSearchClient"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        public TEDSearchClient(string key)
            : base()
        {
            this.Key = key;
        }

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        public string Key { get; set; }

        /// <summary>
        /// Asserts the response.
        /// </summary>
        /// <param name="doc">The document.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">
        /// doc
        /// or
        /// doc
        /// </exception>
        /// <exception cref="TEDSearchException"></exception>
        private static XmlDocument AssertResponse(XmlDocument doc)
        {
            if (doc == null)
                throw new ArgumentNullException("doc");
            if (doc.DocumentElement == null)
                throw new ArgumentNullException("doc");
            if (!String.Equals(doc.DocumentElement.Name, "response", StringComparison.OrdinalIgnoreCase))
                throw new TEDSearchException(doc);
            return doc;
        }

        /// <summary>
        /// Builds the request URI.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns></returns>
        private static Uri BuildRequestUri(params KeyValuePair<string, string>[] items)
        {
            UriBuilder requestUriBuilder = new UriBuilder(new Uri("https://api.ted.com/v1/search.xml", UriKind.Absolute));

            var buffer = new StringBuilder();
            var itemEnumerator = items.GetEnumerator();

            if (itemEnumerator.MoveNext())
            {
                var eachItem = (KeyValuePair<string, string>)itemEnumerator.Current;
                buffer.Append(Uri.EscapeUriString(eachItem.Key));
                buffer.Append('=');
                buffer.Append(Uri.EscapeUriString(eachItem.Value));
            }

            while (itemEnumerator.MoveNext())
            {
                buffer.Append('&');
                var eachItem = (KeyValuePair<string, string>)itemEnumerator.Current;
                buffer.Append(Uri.EscapeUriString(eachItem.Key));
                buffer.Append('=');
                buffer.Append(Uri.EscapeUriString(eachItem.Value));
            }

            requestUriBuilder.Query = buffer.ToString();
            return requestUriBuilder.Uri;
        }

        /// <summary>
        /// Searches all raw.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="category">The category.</param>
        /// <param name="targetCulture">The target culture.</param>
        /// <returns></returns>
        public XmlDocument SearchAllRaw(
            string query,
            string category = default(string),
            CultureInfo targetCulture = default(CultureInfo))
        {
            XmlDocument doc = new XmlDocument();
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>(new KeyValuePair<string, string>[] {
                new KeyValuePair<string, string>("api-key", this.Key),
                new KeyValuePair<string, string>("q", query)
            });

            if (category != default(string))
                parameters.Add(new KeyValuePair<string,string>("categories", category));

            if (targetCulture != default(CultureInfo))
                parameters.Add(new KeyValuePair<string, string>("language", targetCulture.TwoLetterISOLanguageName));

            doc.Load(BuildRequestUri(parameters.ToArray()).AbsoluteUri);
            return AssertResponse(doc);
        }

        /// <summary>
        /// Searches all.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="category">The category.</param>
        /// <param name="targetCulture">The target culture.</param>
        /// <returns></returns>
        public IEnumerable<ITEDItem> SearchAll(
            string query,
            string category = default(string),
            CultureInfo targetCulture = default(CultureInfo))
        {
            XmlDocument doc = this.SearchAllRaw(query, category, targetCulture);
            List<ITEDItem> items = new List<ITEDItem>();

            foreach (XmlNode eachNode in doc.SelectNodes("/response/results/*"))
            {
                ITEDItem eachItem = default(ITEDItem);

                switch (eachNode.Name.ToUpperInvariant())
                {
                    case "TALK":
                        eachItem = this.ParseTalk(eachNode);
                        break;
                    case "PLAYLIST":
                        eachItem = this.ParsePlaylist(eachNode);
                        break;
                    case "WORDPRESS_POST":
                        eachItem = this.ParseWordPressPost(eachNode);
                        break;
                    case "CONVERSATION":
                        eachItem = this.ParseConversation(eachNode);
                        break;
                    case "TEDX_EVENT":
                        eachItem = this.ParseTEDLocalEvent(eachNode);
                        break;
                    case "SPEAKER":
                        eachItem = this.ParseTEDLocalEvent(eachNode);
                        break;
                    case "FELLOWS_PROFILE":
                        eachItem = this.ParseFellowsProfile(eachNode);
                        break;
                    case "THEME":
                        eachItem = this.ParseTheme(eachNode);
                        break;
                    default:
                        eachItem = this.ParseUnclassifiedItem(eachNode);
                        break;
                }

                items.Add(eachItem);
            }

            return items.AsReadOnly();
        }

        /// <summary>
        /// Searches the talks raw.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="targetCulture">The target culture.</param>
        /// <returns></returns>
        public XmlDocument SearchTalksRaw(string query, CultureInfo targetCulture = default(CultureInfo))
        { return this.SearchAllRaw(query, "talks", targetCulture); }

        /// <summary>
        /// Searches the talks.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="targetCulture">The target culture.</param>
        /// <returns></returns>
        public IEnumerable<TEDTalk> SearchTalks(string query, CultureInfo targetCulture = default(CultureInfo))
        { return this.SearchAll(query, "talks", targetCulture).Cast<TEDTalk>(); }

        /// <summary>
        /// Searches the playlists raw.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="targetCulture">The target culture.</param>
        /// <returns></returns>
        public XmlDocument SearchPlaylistsRaw(string query, CultureInfo targetCulture = default(CultureInfo))
        { return this.SearchAllRaw(query, "playlists", targetCulture); }

        /// <summary>
        /// Searches the playlists.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="targetCulture">The target culture.</param>
        /// <returns></returns>
        public IEnumerable<TEDPlaylist> SearchPlaylists(string query, CultureInfo targetCulture = default(CultureInfo))
        { return this.SearchAll(query, "playlists", targetCulture).Cast<TEDPlaylist>(); }

        /// <summary>
        /// Searches the blog posts raw.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="targetCulture">The target culture.</param>
        /// <returns></returns>
        public XmlDocument SearchBlogPostsRaw(string query, CultureInfo targetCulture = default(CultureInfo))
        { return this.SearchAllRaw(query, "blog_posts", targetCulture); }

        /// <summary>
        /// Searches the blog posts.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="targetCulture">The target culture.</param>
        /// <returns></returns>
        public IEnumerable<TEDWordPressPost> SearchBlogPosts(string query, CultureInfo targetCulture = default(CultureInfo))
        { return this.SearchAll(query, "blog_posts", targetCulture).Cast<TEDWordPressPost>(); }

        /// <summary>
        /// Searches the conversations raw.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="targetCulture">The target culture.</param>
        /// <returns></returns>
        public XmlDocument SearchConversationsRaw(string query, CultureInfo targetCulture = default(CultureInfo))
        { return this.SearchAllRaw(query, "converstations", targetCulture); }

        /// <summary>
        /// Searches the conversations.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="targetCulture">The target culture.</param>
        /// <returns></returns>
        public IEnumerable<TEDConversation> SearchConversations(string query, CultureInfo targetCulture = default(CultureInfo))
        { return this.SearchAll(query, "converstations", targetCulture).Cast<TEDConversation>(); }

        /// <summary>
        /// Searches the ted local events raw.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="targetCulture">The target culture.</param>
        /// <returns></returns>
        public XmlDocument SearchTEDLocalEventsRaw(string query, CultureInfo targetCulture = default(CultureInfo))
        { return this.SearchAllRaw(query, "tedx_events", targetCulture); }

        /// <summary>
        /// Searches the ted local events.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="targetCulture">The target culture.</param>
        /// <returns></returns>
        public IEnumerable<TEDLocalEvent> SearchTEDLocalEvents(string query, CultureInfo targetCulture = default(CultureInfo))
        { return this.SearchAll(query, "tedx_events", targetCulture).Cast<TEDLocalEvent>(); }

        /// <summary>
        /// Searches the speakers raw.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="targetCulture">The target culture.</param>
        /// <returns></returns>
        public XmlDocument SearchSpeakersRaw(string query, CultureInfo targetCulture = default(CultureInfo))
        { return this.SearchAllRaw(query, "speakers", targetCulture); }

        /// <summary>
        /// Searches the speakers.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="targetCulture">The target culture.</param>
        /// <returns></returns>
        public IEnumerable<TEDSpeaker> SearchSpeakers(string query, CultureInfo targetCulture = default(CultureInfo))
        { return this.SearchAll(query, "speakers", targetCulture).Cast<TEDSpeaker>(); }

        /// <summary>
        /// Searches the fellows raw.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="targetCulture">The target culture.</param>
        /// <returns></returns>
        public XmlDocument SearchFellowsRaw(string query, CultureInfo targetCulture = default(CultureInfo))
        { return this.SearchAllRaw(query, "fellows", targetCulture); }

        /// <summary>
        /// Searches the fellows.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="targetCulture">The target culture.</param>
        /// <returns></returns>
        public IEnumerable<TEDFellowsProfile> SearchFellows(string query, CultureInfo targetCulture = default(CultureInfo))
        { return this.SearchAll(query, "fellows", targetCulture).Cast<TEDFellowsProfile>(); }

        /// <summary>
        /// Searches the themes raw.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="targetCulture">The target culture.</param>
        /// <returns></returns>
        public XmlDocument SearchThemesRaw(string query, CultureInfo targetCulture = default(CultureInfo))
        { return this.SearchAllRaw(query, "themes", targetCulture); }

        /// <summary>
        /// Searches the themes.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="targetCulture">The target culture.</param>
        /// <returns></returns>
        public IEnumerable<TEDTheme> SearchThemes(string query, CultureInfo targetCulture = default(CultureInfo))
        { return this.SearchAll(query, "themes", targetCulture).Cast<TEDTheme>(); }

        /// <summary>
        /// Parses the ted item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="node">The node.</param>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">item</exception>
        private T ParseTEDItem<T>(XmlNode node, T item)
            where T : ITEDItem
        {
            if (item == null)
                throw new ArgumentNullException("item");

            XmlNode temp = null;

            if ((temp = node.SelectSingleNode("id")) != null)
            {
                int t;
                if (Int32.TryParse(temp.InnerText, out t))
                    item.Id = t;
            }

            return item;
        }

        /// <summary>
        /// Parses the talk.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns></returns>
        private TEDTalk ParseTalk(XmlNode node)
        {
            var item = ParseTEDItem(node, new TEDTalk());
            XmlNode temp = null;

            if ((temp = node.SelectSingleNode("event_id")) != null)
            {
                int t;
                if (Int32.TryParse(temp.InnerText, out t))
                    item.EventId = t;
            }

            if ((temp = node.SelectSingleNode("name")) != null)
                item.Name = temp.InnerText;

            if ((temp = node.SelectSingleNode("description")) != null)
                item.Description = temp.InnerText;

            if ((temp = node.SelectSingleNode("slug")) != null)
                item.Slug = temp.InnerText;

            if ((temp = node.SelectSingleNode("native_language_code")) != null)
                item.NativeLanguageCode = temp.InnerText;

            if ((temp = node.SelectSingleNode("published_at")) != null)
            {
                DateTime t;
                if (DateTime.TryParse(temp.InnerText, out t))
                    item.PublishedAt = t;
            }

            if ((temp = node.SelectSingleNode("recorded_at")) != null)
            {
                DateTime t;
                if (DateTime.TryParse(temp.InnerText, out t))
                    item.RecordedAt = t;
            }

            if ((temp = node.SelectSingleNode("updated_at")) != null)
            {
                DateTime t;
                if (DateTime.TryParse(temp.InnerText, out t))
                    item.UpdatedAt = t;
            }

            if ((temp = node.SelectSingleNode("released_at")) != null)
            {
                DateTime t;
                if (DateTime.TryParse(temp.InnerText, out t))
                    item.ReleasedAt = t;
            }

            return item;
        }

        /// <summary>
        /// Parses the playlist.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns></returns>
        private TEDPlaylist ParsePlaylist(XmlNode node)
        {
            var item = ParseTEDItem(node, new TEDPlaylist());
            XmlNode temp = null;

            if ((temp = node.SelectSingleNode("title")) != null)
                item.Title = temp.InnerText;

            if ((temp = node.SelectSingleNode("description")) != null)
                item.Description = temp.InnerText;

            if ((temp = node.SelectSingleNode("slug")) != null)
                item.Slug = temp.InnerText;

            if ((temp = node.SelectSingleNode("created_at")) != null)
            {
                DateTime t;
                if (DateTime.TryParse(temp.InnerText, out t))
                    item.CreatedAt = t;
            }

            if ((temp = node.SelectSingleNode("updated_at")) != null)
            {
                DateTime t;
                if (DateTime.TryParse(temp.InnerText, out t))
                    item.UpdatedAt = t;
            }

            return item;
        }

        /// <summary>
        /// Parses the word press post.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns></returns>
        private TEDWordPressPost ParseWordPressPost(XmlNode node)
        {
            var item = ParseTEDItem(node, new TEDWordPressPost());
            XmlNode temp = null;

            if ((temp = node.SelectSingleNode("wp_subdomain")) != null)
                item.WordPressSubDomain = temp.InnerText;

            if ((temp = node.SelectSingleNode("post_id")) != null)
                item.PostId = temp.InnerText;

            if ((temp = node.SelectSingleNode("comment_count")) != null)
            {
                int t;
                if (Int32.TryParse(temp.InnerText, out t))
                    item.CommentCount = t;
            }

            if ((temp = node.SelectSingleNode("comment_status")) != null)
                item.CommentStatus = temp.InnerText;

            if ((temp = node.SelectSingleNode("guid")) != null)
                item.Guid = temp.InnerText;

            if ((temp = node.SelectSingleNode("menu_order")) != null)
            {
                int t;
                if (Int32.TryParse(temp.InnerText, out t))
                    item.MenuOrder = t;
            }

            if ((temp = node.SelectSingleNode("ping_status")) != null)
                item.PingStatus = temp.InnerText;

            if ((temp = node.SelectSingleNode("pinged")) != null)
                item.Pinged = temp.InnerText;

            if ((temp = node.SelectSingleNode("post_author")) != null)
                item.PostAuthor = temp.InnerText;

            if ((temp = node.SelectSingleNode("post_content")) != null)
                item.PostContent = temp.InnerText;

            if ((temp = node.SelectSingleNode("post_content_filtered")) != null)
                item.PostContentFiltered = temp.InnerText;

            if ((temp = node.SelectSingleNode("post_date")) != null)
            {
                DateTime t;
                if (DateTime.TryParse(temp.InnerText, out t))
                    item.PostDate = t;
            }

            if ((temp = node.SelectSingleNode("post_date_gmt")) != null)
            {
                DateTime t;
                if (DateTime.TryParse(temp.InnerText, out t))
                    item.PostDateGmt = t;
            }

            if ((temp = node.SelectSingleNode("post_excerpt")) != null)
                item.PostExcerpt = temp.InnerText;

            if ((temp = node.SelectSingleNode("post_mime_type")) != null)
                item.PostMimeType = temp.InnerText;

            if ((temp = node.SelectSingleNode("post_modified")) != null)
            {
                DateTime t;
                if (DateTime.TryParse(temp.InnerText, out t))
                    item.PostModified = t;
            }

            if ((temp = node.SelectSingleNode("post_modified_gmt")) != null)
            {
                DateTime t;
                if (DateTime.TryParse(temp.InnerText, out t))
                    item.PostModifiedGmt = t;
            }

            if ((temp = node.SelectSingleNode("post_name")) != null)
                item.PostName = temp.InnerText;

            if ((temp = node.SelectSingleNode("post_parent")) != null)
                item.PostParent = temp.InnerText;

            if ((temp = node.SelectSingleNode("post_password")) != null)
                item.PostPassword = temp.InnerText;

            if ((temp = node.SelectSingleNode("post_status")) != null)
                item.PostStatus = temp.InnerText;

            if ((temp = node.SelectSingleNode("post_title")) != null)
                item.PostTitle = temp.InnerText;

            if ((temp = node.SelectSingleNode("post_type")) != null)
                item.PostType = temp.InnerText;

            if ((temp = node.SelectSingleNode("to_ping")) != null)
                item.ToPing = temp.InnerText;

            if ((temp = node.SelectSingleNode("post_categories")) != null)
                item.PostCategories = temp.InnerText;

            return item;
        }

        /// <summary>
        /// Parses the conversation.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns></returns>
        private TEDConversation ParseConversation(XmlNode node)
        {
            var item = ParseTEDItem(node, new TEDConversation());
            XmlNode temp = null;

            if ((temp = node.SelectSingleNode("user_id")) != null)
            {
                int t;
                if (Int32.TryParse(temp.InnerText, out t))
                    item.UserId = t;
            }

            if ((temp = node.SelectSingleNode("title")) != null)
                item.Title = temp.InnerText;

            if ((temp = node.SelectSingleNode("slug")) != null)
                item.Slug = temp.InnerText;

            if ((temp = node.SelectSingleNode("type")) != null)
                item.Type = temp.InnerText;

            if ((temp = node.SelectSingleNode("tedcred")) != null)
            {
                int t;
                if (Int32.TryParse(temp.InnerText, out t))
                    item.TedCred = t;
            }

            if ((temp = node.SelectSingleNode("commented_count")) != null)
            {
                int t;
                if (Int32.TryParse(temp.InnerText, out t))
                    item.CommentedCount = t;
            }

            if ((temp = node.SelectSingleNode("description")) != null)
                item.Description = temp.InnerText;

            if ((temp = node.SelectSingleNode("expires_at")) != null)
            {
                DateTime t;
                if (DateTime.TryParse(temp.InnerText, out t))
                    item.ExpiresAt = t;
            }

            if ((temp = node.SelectSingleNode("created_at")) != null)
            {
                DateTime t;
                if (DateTime.TryParse(temp.InnerText, out t))
                    item.CreatedAt = t;
            }

            if ((temp = node.SelectSingleNode("updated_at")) != null)
            {
                DateTime t;
                if (DateTime.TryParse(temp.InnerText, out t))
                    item.UpdatedAt = t;
            }

            return item;
        }

        /// <summary>
        /// Parses the ted local event.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns></returns>
        private TEDLocalEvent ParseTEDLocalEvent(XmlNode node)
        {
            var item = ParseTEDItem(node, new TEDLocalEvent());
            XmlNode temp = null;

            if ((temp = node.SelectSingleNode("tedx_group_id")) != null)
            {
                int t;
                if (Int32.TryParse(temp.InnerText, out t))
                    item.TEDXGroupId = t;
            }

            if ((temp = node.SelectSingleNode("tedx_venue_id")) != null)
            {
                int t;
                if (Int32.TryParse(temp.InnerText, out t))
                    item.TEDXVenueId = t;
            }

            if ((temp = node.SelectSingleNode("title")) != null)
                item.Title = temp.InnerText;

            if ((temp = node.SelectSingleNode("description")) != null)
                item.Description = temp.InnerText;

            if ((temp = node.SelectSingleNode("starts_at")) != null)
            {
                DateTime t;
                if (DateTime.TryParse(temp.InnerText, out t))
                    item.StartsAt = t;
            }

            if ((temp = node.SelectSingleNode("ends_at")) != null)
            {
                DateTime t;
                if (DateTime.TryParse(temp.InnerText, out t))
                    item.EndsAt = t;
            }

            if ((temp = node.SelectSingleNode("is_full")) != null)
                item.IsFull = String.Equals(temp.InnerText, Boolean.TrueString, StringComparison.OrdinalIgnoreCase);

            if ((temp = node.SelectSingleNode("is_private")) != null)
                item.IsPrivate = String.Equals(temp.InnerText, Boolean.TrueString, StringComparison.OrdinalIgnoreCase);

            if ((temp = node.SelectSingleNode("event_size")) != null)
            {
                int t;
                if (Int32.TryParse(temp.InnerText, out t))
                    item.EventSize = t;
            }

            if ((temp = node.SelectSingleNode("attendee_count")) != null)
            {
                int t;
                if (Int32.TryParse(temp.InnerText, out t))
                    item.AttendeeCount = t;
            }

            if ((temp = node.SelectSingleNode("rsvp_url")) != null)
            {
                Uri t;
                if (Uri.TryCreate(temp.InnerText, UriKind.Absolute, out t))
                    item.RSVPUrl = t;
            }

            if ((temp = node.SelectSingleNode("rsvp_email")) != null)
                item.RSVPEMail = temp.InnerText;

            if ((temp = node.SelectSingleNode("acknowledgements")) != null)
                item.Acknowledgements = temp.InnerText;

            if ((temp = node.SelectSingleNode("webstream_url")) != null)
            {
                Uri t;
                if (Uri.TryCreate(temp.InnerText, UriKind.Absolute, out t))
                    item.WebStreamUrl = t;
            }

            if ((temp = node.SelectSingleNode("twitter_codes")) != null)
                item.TwitterCodes = temp.InnerText;

            if ((temp = node.SelectSingleNode("flickr_tags")) != null)
                item.FlickrTags = temp.InnerText;

            if ((temp = node.SelectSingleNode("you_tube_playlists")) != null)
                item.YouTubePlaylist = temp.InnerText;

            if ((temp = node.SelectSingleNode("ticket_price")) != null)
                item.TicketPrice = temp.InnerText;

            if ((temp = node.SelectSingleNode("currency")) != null)
                item.Currency = temp.InnerText;

            return item;
        }

        /// <summary>
        /// Parses the fellows profile.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns></returns>
        private TEDFellowsProfile ParseFellowsProfile(XmlNode node)
        {
            var item = ParseTEDItem(node, new TEDFellowsProfile());
            XmlNode temp = null;

            if ((temp = node.SelectSingleNode("createdby")) != null)
            {
                int t;
                if (Int32.TryParse(temp.InnerText, out t))
                    item.CreatedBy = t;
            }

            if ((temp = node.SelectSingleNode("old_fellow_id")) != null)
            {
                int t;
                if (Int32.TryParse(temp.InnerText, out t))
                    item.OldFellowId = t;
            }

            if ((temp = node.SelectSingleNode("profile_id")) != null)
            {
                int t;
                if (Int32.TryParse(temp.InnerText, out t))
                    item.ProfileId = t;
            }

            if ((temp = node.SelectSingleNode("event_id")) != null)
            {
                int t;
                if (Int32.TryParse(temp.InnerText, out t))
                    item.EventId = t;
            }

            if ((temp = node.SelectSingleNode("title")) != null)
                item.Title = temp.InnerText;

            if ((temp = node.SelectSingleNode("firstname")) != null)
                item.FirstName = temp.InnerText;

            if ((temp = node.SelectSingleNode("middleinitial")) != null)
                item.MiddleInitial = temp.InnerText;

            if ((temp = node.SelectSingleNode("lastname")) != null)
                item.LastName = temp.InnerText;

            if ((temp = node.SelectSingleNode("description")) != null)
                item.Description = temp.InnerText;

            if ((temp = node.SelectSingleNode("bio")) != null)
                item.Biography = temp.InnerText;

            if ((temp = node.SelectSingleNode("q_a")) != null)
                item.QuestionsAndAnswers = temp.InnerText;

            if ((temp = node.SelectSingleNode("is_senior")) != null)
                item.IsSenior = String.Equals(temp.InnerText, Boolean.TrueString, StringComparison.OrdinalIgnoreCase);

            if ((temp = node.SelectSingleNode("start_date")) != null)
            {
                DateTime t;
                if (DateTime.TryParse(temp.InnerText, out t))
                    item.StartDate = t;
            }

            if ((temp = node.SelectSingleNode("end_date")) != null)
            {
                DateTime t;
                if (DateTime.TryParse(temp.InnerText, out t))
                    item.EndDate = t;
            }

            if ((temp = node.SelectSingleNode("datepublish")) != null)
            {
                DateTime t;
                if (DateTime.TryParse(temp.InnerText, out t))
                    item.DatePublish = t;
            }

            if ((temp = node.SelectSingleNode("dateexpire")) != null)
            {
                DateTime t;
                if (DateTime.TryParse(temp.InnerText, out t))
                    item.DateExpire = t;
            }

            if ((temp = node.SelectSingleNode("visible")) != null)
                item.Visible = String.Equals(temp.InnerText, Boolean.TrueString, StringComparison.OrdinalIgnoreCase);

            if ((temp = node.SelectSingleNode("entitystatus")) != null)
                item.EntityStatus = temp.InnerText;

            if ((temp = node.SelectSingleNode("created_at")) != null)
            {
                DateTime t;
                if (DateTime.TryParse(temp.InnerText, out t))
                    item.CreatedAt = t;
            }

            if ((temp = node.SelectSingleNode("updated_at")) != null)
            {
                DateTime t;
                if (DateTime.TryParse(temp.InnerText, out t))
                    item.UpdatedAt = t;
            }

            if ((temp = node.SelectSingleNode("gender")) != null)
                item.Gender = temp.InnerText;

            if ((temp = node.SelectSingleNode("organizations")) != null)
                item.Organizations = temp.InnerText;

            if ((temp = node.SelectSingleNode("favorite_meal")) != null)
                item.FavoriteMeal = temp.InnerText;

            if ((temp = node.SelectSingleNode("something_funny")) != null)
                item.SomethingFunny = temp.InnerText;

            if ((temp = node.SelectSingleNode("orientation")) != null)
                item.Orientation = temp.InnerText;

            if ((temp = node.SelectSingleNode("relationship_status")) != null)
                item.RelationshipStatus = temp.InnerText;

            if ((temp = node.SelectSingleNode("children")) != null)
                item.Children = temp.InnerText;

            if ((temp = node.SelectSingleNode("looking_for_help_with")) != null)
                item.LookingForHelpWith = temp.InnerText;

            if ((temp = node.SelectSingleNode("can_help_with")) != null)
                item.CanHelpWith = temp.InnerText;

            if ((temp = node.SelectSingleNode("twitter_username")) != null)
                item.TwitterUserName = temp.InnerText;

            if ((temp = node.SelectSingleNode("show_last_tweet")) != null)
                item.ShowLastTweet = String.Equals(temp.InnerText, Boolean.TrueString, StringComparison.OrdinalIgnoreCase);

            if ((temp = node.SelectSingleNode("show_recent_tweets")) != null)
                item.ShowRecentTweets = String.Equals(temp.InnerText, Boolean.TrueString, StringComparison.OrdinalIgnoreCase);

            if ((temp = node.SelectSingleNode("facebook_username")) != null)
                item.FacebookUserName = temp.InnerText;

            if ((temp = node.SelectSingleNode("skype_username")) != null)
                item.SkypeUserName = temp.InnerText;

            if ((temp = node.SelectSingleNode("blog_url")) != null)
            {
                Uri t;
                if (Uri.TryCreate(temp.InnerText, UriKind.Absolute, out t))
                    item.BlogUrl = t;
            }

            if ((temp = node.SelectSingleNode("show_recent_blogs")) != null)
                item.ShowRecentBlogs = String.Equals(temp.InnerText, Boolean.TrueString, StringComparison.OrdinalIgnoreCase);

            if ((temp = node.SelectSingleNode("headshot_file_name")) != null)
                item.HeadshotFileName = temp.InnerText;

            if ((temp = node.SelectSingleNode("headshot_content_type")) != null)
                item.HeadshotContentType = temp.InnerText;

            if ((temp = node.SelectSingleNode("headshot_file_size")) != null)
            {
                long t;
                if (Int64.TryParse(temp.InnerText, out t))
                    item.HeadshotFileSize = t;
            }

            if ((temp = node.SelectSingleNode("headshot_updated_at")) != null)
            {
                DateTime t;
                if (DateTime.TryParse(temp.InnerText, out t))
                    item.HeadshotUpdatedAt = t;
            }

            if ((temp = node.SelectSingleNode("flicker_username")) != null)
                item.FlickrUserName = temp.InnerText;

            if ((temp = node.SelectSingleNode("flickr_userid")) != null)
                item.FlickrUserId = temp.InnerText;

            if ((temp = node.SelectSingleNode("fullname")) != null)
                item.FullName = temp.InnerText;

            if ((temp = node.SelectSingleNode("blog_feed_url")) != null)
            {
                Uri t;
                if (Uri.TryCreate(temp.InnerText, UriKind.Absolute, out t))
                    item.BlogFeedUrl = t;
            }

            if ((temp = node.SelectSingleNode("slug")) != null)
                item.Slug = temp.InnerText;

            return item;
        }

        /// <summary>
        /// Parses the theme.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns></returns>
        private TEDTheme ParseTheme(XmlNode node)
        {
            var item = ParseTEDItem(node, new TEDTheme());
            XmlNode temp = null;

            if ((temp = node.SelectSingleNode("name")) != null)
                item.Name = temp.InnerText;

            if ((temp = node.SelectSingleNode("description")) != null)
                item.Description = temp.InnerText;

            if ((temp = node.SelectSingleNode("shortsummary")) != null)
                item.ShortSummary = temp.InnerText;

            if ((temp = node.SelectSingleNode("talks_description")) != null)
                item.TalksDescription = temp.InnerText;

            if ((temp = node.SelectSingleNode("speakers_description")) != null)
                item.SpeakersDescription = temp.InnerText;

            if ((temp = node.SelectSingleNode("slug")) != null)
                item.Slug = temp.InnerText;

            if ((temp = node.SelectSingleNode("is_featured")) != null)
                item.IsFeatured = String.Equals(temp.InnerText, Boolean.TrueString, StringComparison.OrdinalIgnoreCase);

            return item;
        }

        /// <summary>
        /// Parses the unclassified item.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns></returns>
        private TEDUnclassifiedItem ParseUnclassifiedItem(XmlNode node)
        {
            var item = ParseTEDItem(node, new TEDUnclassifiedItem());
            item.RawXml = node.OuterXml;
            return item;
        }
    }
}
