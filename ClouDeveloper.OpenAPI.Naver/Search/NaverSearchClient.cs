using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml;

namespace ClouDeveloper.OpenAPI.Naver.Search
{
    public sealed class NaverSearchClient
    {
        public NaverSearchClient(string key)
            : base()
        {
            this.Key = key;
        }

        public string Key { get; set; }

        private static XmlDocument AssertResponse(XmlDocument doc)
        {
            if (doc == null)
                throw new ArgumentNullException("doc");
            if (doc.DocumentElement == null)
                throw new ArgumentNullException("doc");
            if (String.Equals(doc.DocumentElement.Name, "error", StringComparison.OrdinalIgnoreCase))
                throw new NaverSearchException(doc);
            return doc;
        }

        private static Uri BuildRequestUri(params KeyValuePair<string, string>[] items)
        {
            UriBuilder requestUriBuilder = new UriBuilder(new Uri("http://openapi.naver.com/search", UriKind.Absolute));

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

        public XmlDocument SearchBlogRaw(
            string query,
            int display = 10,
            int start = 1,
            BlogSearchSort orderBy = default(BlogSearchSort))
        {
            string convertedSortMethod = String.Empty;
            switch (orderBy)
            {
                default:
                    convertedSortMethod = "sim";
                    break;
                case BlogSearchSort.ByDate:
                    convertedSortMethod = "date";
                    break;
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(BuildRequestUri(
                new KeyValuePair<string, string>("key", this.Key),
                new KeyValuePair<string, string>("target", "blog"),
                new KeyValuePair<string, string>("query", query),
                new KeyValuePair<string, string>("display", display.ToString()),
                new KeyValuePair<string, string>("start", start.ToString()),
                new KeyValuePair<string, string>("sort", convertedSortMethod)
                ).AbsoluteUri);
            return AssertResponse(doc);
        }

        public NaverSearchResponseContainer<BlogSearchResult> SearchBlog(
            string query,
            int display = 10,
            int start = 1,
            BlogSearchSort orderBy = default(BlogSearchSort))
        {
            XmlDocument doc = this.SearchBlogRaw(query, display, start, orderBy);
            var result = new NaverSearchResponseContainer<BlogSearchResult>();
            XmlNode temp;

            if ((temp = doc.SelectSingleNode("/rss/channel/title")) != null)
                result.Title = temp.InnerText;
            if ((temp = doc.SelectSingleNode("/rss/channel/link")) != null)
                result.Link = new Uri(temp.InnerText, UriKind.Absolute);
            if ((temp = doc.SelectSingleNode("/rss/channel/description")) != null)
                result.Description = temp.InnerText;
            if ((temp = doc.SelectSingleNode("/rss/channel/lastBuildDate")) != null)
                result.LastBuildDate = DateTime.Parse(temp.InnerText);
            if ((temp = doc.SelectSingleNode("/rss/channel/total")) != null)
                result.Total = Int32.Parse(temp.InnerText);
            if ((temp = doc.SelectSingleNode("/rss/channel/start")) != null)
                result.Start = Int32.Parse(temp.InnerText);
            if ((temp = doc.SelectSingleNode("/rss/channel/display")) != null)
                result.Display = Int32.Parse(temp.InnerText);

            foreach (XmlNode eachNode in doc.SelectNodes("/rss/channel/item"))
            {
                BlogSearchResult item = new BlogSearchResult();
                if ((temp = eachNode.SelectSingleNode("title")) != null)
                    item.Title = temp.InnerText;
                if ((temp = eachNode.SelectSingleNode("link")) != null)
                    item.Link = new Uri(temp.InnerText, UriKind.Absolute);
                if ((temp = eachNode.SelectSingleNode("description")) != null)
                    item.Description = temp.InnerText;
                if ((temp = eachNode.SelectSingleNode("bloggername")) != null)
                    item.BloggerName = temp.InnerText;
                if ((temp = eachNode.SelectSingleNode("bloggerlink")) != null &&
                    !String.IsNullOrWhiteSpace(temp.InnerText))
                {
                    string uri = temp.InnerText;
                    if (!uri.StartsWith(Uri.UriSchemeHttp, StringComparison.OrdinalIgnoreCase) &&
                        !uri.StartsWith(Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase))
                        uri = Uri.UriSchemeHttp + "://" + uri;
                    item.BloggerLink = new Uri(uri, UriKind.Absolute);
                }
                result.Add(item);
            }

            return result;
        }

        public XmlDocument SearchNewsRaw(
            string query,
            int display = 10,
            int start = 1,
            NewsSearchSort orderBy = default(NewsSearchSort))
        {
            string convertedSortMethod = String.Empty;
            switch (orderBy)
            {
                default:
                    convertedSortMethod = "date";
                    break;
                case NewsSearchSort.BySimilarity:
                    convertedSortMethod = "sim";
                    break;
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(BuildRequestUri(
                new KeyValuePair<string, string>("key", this.Key),
                new KeyValuePair<string, string>("target", "news"),
                new KeyValuePair<string, string>("query", query),
                new KeyValuePair<string, string>("display", display.ToString()),
                new KeyValuePair<string, string>("start", start.ToString()),
                new KeyValuePair<string, string>("sort", convertedSortMethod)
                ).AbsoluteUri);
            return AssertResponse(doc);
        }

        public NaverSearchResponseContainer<NewsSearchResult> SearchNews(
            string query,
            int display = 10,
            int start = 1,
            NewsSearchSort orderBy = default(NewsSearchSort))
        {
            XmlDocument doc = this.SearchNewsRaw(query, display, start, orderBy);
            var result = new NaverSearchResponseContainer<NewsSearchResult>();
            XmlNode temp;

            if ((temp = doc.SelectSingleNode("/rss/channel/title")) != null)
                result.Title = temp.InnerText;
            if ((temp = doc.SelectSingleNode("/rss/channel/link")) != null)
                result.Link = new Uri(temp.InnerText, UriKind.Absolute);
            if ((temp = doc.SelectSingleNode("/rss/channel/description")) != null)
                result.Description = temp.InnerText;
            if ((temp = doc.SelectSingleNode("/rss/channel/lastBuildDate")) != null)
                result.LastBuildDate = DateTime.Parse(temp.InnerText);
            if ((temp = doc.SelectSingleNode("/rss/channel/total")) != null)
                result.Total = Int32.Parse(temp.InnerText);
            if ((temp = doc.SelectSingleNode("/rss/channel/start")) != null)
                result.Start = Int32.Parse(temp.InnerText);
            if ((temp = doc.SelectSingleNode("/rss/channel/display")) != null)
                result.Display = Int32.Parse(temp.InnerText);

            foreach (XmlNode eachNode in doc.SelectNodes("/rss/channel/item"))
            {
                NewsSearchResult item = new NewsSearchResult();
                if ((temp = eachNode.SelectSingleNode("title")) != null)
                    item.Title = temp.InnerText;
                if ((temp = eachNode.SelectSingleNode("originallink")) != null)
                {
                    Uri t;
                    if (Uri.TryCreate(temp.InnerText, UriKind.Absolute, out t))
                        item.OriginalLink = t;
                }
                if ((temp = eachNode.SelectSingleNode("link")) != null)
                    item.Link = new Uri(temp.InnerText, UriKind.Absolute);
                if ((temp = eachNode.SelectSingleNode("description")) != null)
                    item.Description = temp.InnerText;
                if ((temp = eachNode.SelectSingleNode("pubDate")) != null)
                    item.PublishedDateTime = DateTime.Parse(temp.InnerText);
                result.Add(item);
            }

            return result;
        }

        public XmlDocument SearchBooksRaw(
            string query,
            int display = 10,
            int start = 1,
            string title = default(string),
            string author = default(string),
            string contents = default(string),
            string isbn = default(string),
            string publisher = default(string),
            DateTime? publishedDateFrom = default(DateTime?),
            DateTime? publishedDateTo = default(DateTime?),
            string category = default(string))
        {
            XmlDocument doc = new XmlDocument();
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>(new KeyValuePair<string, string>[] {
                new KeyValuePair<string, string>("key", this.Key),
                new KeyValuePair<string, string>("query", query),
                new KeyValuePair<string, string>("display", display.ToString()),
                new KeyValuePair<string, string>("start", start.ToString())
            });

            bool hasAdvancedParameters = false;

            if (title != default(string))
            {
                hasAdvancedParameters = true;
                parameters.Add(new KeyValuePair<string, string>("d_titl", title));
            }

            if (author != default(string))
            {
                hasAdvancedParameters = true;
                parameters.Add(new KeyValuePair<string, string>("d_auth", author));
            }

            if (contents != default(string))
            {
                hasAdvancedParameters = true;
                parameters.Add(new KeyValuePair<string, string>("d_cont", contents));
            }

            if (isbn != default(string))
            {
                hasAdvancedParameters = true;
                parameters.Add(new KeyValuePair<string, string>("d_isbn", isbn));
            }

            if (publisher != default(string))
            {
                hasAdvancedParameters = true;
                parameters.Add(new KeyValuePair<string, string>("d_publ", publisher));
            }

            if (publishedDateFrom.HasValue)
            {
                hasAdvancedParameters = true;
                parameters.Add(new KeyValuePair<string, string>("d_dafr", publishedDateFrom.Value.ToString("yyyyMMdd")));
            }

            if (publishedDateTo.HasValue)
            {
                hasAdvancedParameters = true;
                parameters.Add(new KeyValuePair<string, string>("d_dato", publishedDateTo.Value.ToString("yyyyMMdd")));
            }

            if (category != default(string))
            {
                hasAdvancedParameters = true;
                parameters.Add(new KeyValuePair<string, string>("d_catg", category));
            }

            if (hasAdvancedParameters)
                parameters.Add(new KeyValuePair<string, string>("target", "book_adv"));
            else
                parameters.Add(new KeyValuePair<string, string>("target", "book"));

            doc.Load(BuildRequestUri(parameters.ToArray()).AbsoluteUri);
            return AssertResponse(doc);
        }

        public NaverSearchResponseContainer<BooksSearchResult> SearchBooks(
            string query,
            int display = 10,
            int start = 1,
            string title = default(string),
            string author = default(string),
            string contents = default(string),
            string isbn = default(string),
            string publisher = default(string),
            DateTime? publishedDateFrom = default(DateTime?),
            DateTime? publishedDateTo = default(DateTime?),
            string category = default(string))
        {
            XmlDocument doc = this.SearchBooksRaw(query, display, start, title, author, contents, isbn, publisher, publishedDateFrom, publishedDateTo, category);
            var result = new NaverSearchResponseContainer<BooksSearchResult>();
            XmlNode temp;

            if ((temp = doc.SelectSingleNode("/rss/channel/title")) != null)
                result.Title = temp.InnerText;
            if ((temp = doc.SelectSingleNode("/rss/channel/link")) != null)
                result.Link = new Uri(temp.InnerText, UriKind.Absolute);
            if ((temp = doc.SelectSingleNode("/rss/channel/description")) != null)
                result.Description = temp.InnerText;
            if ((temp = doc.SelectSingleNode("/rss/channel/lastBuildDate")) != null)
                result.LastBuildDate = DateTime.Parse(temp.InnerText);
            if ((temp = doc.SelectSingleNode("/rss/channel/total")) != null)
                result.Total = Int32.Parse(temp.InnerText);
            if ((temp = doc.SelectSingleNode("/rss/channel/start")) != null)
                result.Start = Int32.Parse(temp.InnerText);
            if ((temp = doc.SelectSingleNode("/rss/channel/display")) != null)
                result.Display = Int32.Parse(temp.InnerText);

            foreach (XmlNode eachNode in doc.SelectNodes("/rss/channel/item"))
            {
                BooksSearchResult item = new BooksSearchResult();
                if ((temp = eachNode.SelectSingleNode("title")) != null)
                    item.Title = temp.InnerText;
                if ((temp = eachNode.SelectSingleNode("link")) != null)
                    item.Link = new Uri(temp.InnerText, UriKind.Absolute);
                if ((temp = eachNode.SelectSingleNode("image")) != null)
                    item.Image = new Uri(temp.InnerText, UriKind.Absolute);
                if ((temp = eachNode.SelectSingleNode("author")) != null)
                    item.Author = temp.InnerText;
                if ((temp = eachNode.SelectSingleNode("price")) != null)
                {
                    decimal price;
                    if (Decimal.TryParse(temp.InnerText, out price))
                        item.Price = price;
                }
                if ((temp = eachNode.SelectSingleNode("discount")) != null)
                {
                    float discount;
                    if (Single.TryParse(temp.InnerText, out discount))
                        item.Discount = discount;
                }
                if ((temp = eachNode.SelectSingleNode("publisher")) != null)
                    item.Publisher = temp.InnerText;
                if ((temp = eachNode.SelectSingleNode("pubdate")) != null)
                    item.PublishedDateTime = DateTime.ParseExact(temp.InnerText, "yyyyMMdd", CultureInfo.InvariantCulture);
                if ((temp = eachNode.SelectSingleNode("isbn")) != null)
                    item.ISBN = temp.InnerText;
                if ((temp = eachNode.SelectSingleNode("description")) != null)
                    item.Description = temp.InnerText;
                result.Add(item);
            }

            return result;
        }

        public XmlDocument ClassifySexualSearchKeywordRaw(
            string query)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(BuildRequestUri(
                new KeyValuePair<string, string>("key", this.Key),
                new KeyValuePair<string, string>("target", "adult"),
                new KeyValuePair<string, string>("query", query)
                ).AbsoluteUri);
            return AssertResponse(doc);
        }

        public bool IsSexualSearchKeyword(
            string query)
        {
            XmlDocument doc = this.ClassifySexualSearchKeywordRaw(query);
            XmlNode adultNode = doc.SelectSingleNode("/result/item/adult");
            if (adultNode == null)
                throw new Exception("adult node is not available.");
            return ((Int32.Parse(adultNode.InnerText)) != 0);
        }

        public XmlDocument SearchEncyclopediaRaw(
            string query,
            int display = 10,
            int start = 1)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(BuildRequestUri(
                new KeyValuePair<string, string>("key", this.Key),
                new KeyValuePair<string, string>("target", "encyc"),
                new KeyValuePair<string, string>("query", query),
                new KeyValuePair<string, string>("display", display.ToString()),
                new KeyValuePair<string, string>("start", start.ToString())
                ).AbsoluteUri);
            return AssertResponse(doc);
        }

        public NaverSearchResponseContainer<EncyclopediaSearchResult> SearchEncyclopedia(
            string query,
            int display = 10,
            int start = 1)
        {
            XmlDocument doc = this.SearchEncyclopediaRaw(query, display, start);
            var result = new NaverSearchResponseContainer<EncyclopediaSearchResult>();
            XmlNode temp;

            if ((temp = doc.SelectSingleNode("/rss/channel/title")) != null)
                result.Title = temp.InnerText;
            if ((temp = doc.SelectSingleNode("/rss/channel/link")) != null)
                result.Link = new Uri(temp.InnerText, UriKind.Absolute);
            if ((temp = doc.SelectSingleNode("/rss/channel/description")) != null)
                result.Description = temp.InnerText;
            if ((temp = doc.SelectSingleNode("/rss/channel/lastBuildDate")) != null)
                result.LastBuildDate = DateTime.Parse(temp.InnerText);
            if ((temp = doc.SelectSingleNode("/rss/channel/total")) != null)
                result.Total = Int32.Parse(temp.InnerText);
            if ((temp = doc.SelectSingleNode("/rss/channel/start")) != null)
                result.Start = Int32.Parse(temp.InnerText);
            if ((temp = doc.SelectSingleNode("/rss/channel/display")) != null)
                result.Display = Int32.Parse(temp.InnerText);

            foreach (XmlNode eachNode in doc.SelectNodes("/rss/channel/item"))
            {
                EncyclopediaSearchResult item = new EncyclopediaSearchResult();
                if ((temp = eachNode.SelectSingleNode("title")) != null)
                    item.Title = temp.InnerText;
                if ((temp = eachNode.SelectSingleNode("link")) != null)
                    item.Link = new Uri(temp.InnerText, UriKind.Absolute);
                if ((temp = eachNode.SelectSingleNode("description")) != null)
                    item.Description = temp.InnerText;
                if ((temp = eachNode.SelectSingleNode("thumbnail")) != null &&
                    !String.IsNullOrWhiteSpace(temp.InnerText))
                    item.Thumbnail = new Uri(temp.InnerText, UriKind.Absolute);
                result.Add(item);
            }

            return result;
        }

        public XmlDocument SearchMovieRaw(
            string query,
            int display = 10,
            int start = 1,
            MovieGenre genre = default(MovieGenre),
            RegionInfo country = default(RegionInfo),
            Tuple<int, int> yearFromTo = default(Tuple<int, int>))
        {
            XmlDocument doc = new XmlDocument();
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>(new KeyValuePair<string, string>[] {
                new KeyValuePair<string, string>("key", this.Key),
                new KeyValuePair<string, string>("target", "movie"),
                new KeyValuePair<string, string>("query", query),
                new KeyValuePair<string, string>("display", display.ToString()),
                new KeyValuePair<string, string>("start", start.ToString())
            });

            int? convertedGenreCode = null;
            if (Enum.IsDefined(typeof(MovieGenre), genre) &&
                genre != MovieGenre.Undefined)
                convertedGenreCode = (int)genre;

            string convertedCountry = null;
            if (country != null)
            {
                convertedCountry = country.TwoLetterISORegionName.ToUpperInvariant();
                switch (convertedCountry)
                {
                    case "KR":
                    case "JP":
                    case "US":
                    case "HK":
                    case "GB":
                    case "FR":
                        convertedCountry = country.TwoLetterISORegionName.ToUpperInvariant();
                        break;
                    default:
                        convertedCountry = "ETC";
                        break;
                }
            }

            if (convertedGenreCode.HasValue)
                parameters.Add(new KeyValuePair<string, string>("genre", convertedGenreCode.Value.ToString()));

            if (convertedCountry != null)
                parameters.Add(new KeyValuePair<string, string>("country", convertedCountry));

            if (yearFromTo != null)
            {
                parameters.Add(new KeyValuePair<string, string>(
                    "yearfrom",
                    Math.Min(yearFromTo.Item1, yearFromTo.Item2).ToString()));
                parameters.Add(new KeyValuePair<string, string>(
                    "yearto",
                    Math.Max(yearFromTo.Item1, yearFromTo.Item2).ToString()));
            }

            doc.Load(BuildRequestUri(parameters.ToArray()).AbsoluteUri);
            return AssertResponse(doc);
        }

        public NaverSearchResponseContainer<MovieSearchResult> SearchMovie(
            string query,
            int display = 10,
            int start = 1,
            MovieGenre genre = default(MovieGenre),
            RegionInfo country = default(RegionInfo),
            Tuple<int, int> yearFromTo = default(Tuple<int, int>))
        {
            XmlDocument doc = this.SearchMovieRaw(query, display, start);
            var result = new NaverSearchResponseContainer<MovieSearchResult>();
            XmlNode temp;

            if ((temp = doc.SelectSingleNode("/rss/channel/title")) != null)
                result.Title = temp.InnerText;
            if ((temp = doc.SelectSingleNode("/rss/channel/link")) != null)
                result.Link = new Uri(temp.InnerText, UriKind.Absolute);
            if ((temp = doc.SelectSingleNode("/rss/channel/description")) != null)
                result.Description = temp.InnerText;
            if ((temp = doc.SelectSingleNode("/rss/channel/lastBuildDate")) != null)
                result.LastBuildDate = DateTime.Parse(temp.InnerText);
            if ((temp = doc.SelectSingleNode("/rss/channel/total")) != null)
                result.Total = Int32.Parse(temp.InnerText);
            if ((temp = doc.SelectSingleNode("/rss/channel/start")) != null)
                result.Start = Int32.Parse(temp.InnerText);
            if ((temp = doc.SelectSingleNode("/rss/channel/display")) != null)
                result.Display = Int32.Parse(temp.InnerText);

            foreach (XmlNode eachNode in doc.SelectNodes("/rss/channel/item"))
            {
                MovieSearchResult item = new MovieSearchResult();
                if ((temp = eachNode.SelectSingleNode("title")) != null)
                    item.Title = temp.InnerText;
                if ((temp = eachNode.SelectSingleNode("link")) != null)
                    item.Link = new Uri(temp.InnerText, UriKind.Absolute);
                if ((temp = eachNode.SelectSingleNode("image")) != null)
                    item.Image = new Uri(temp.InnerText, UriKind.Absolute);
                if ((temp = eachNode.SelectSingleNode("subtitle")) != null)
                    item.Subtitle = temp.InnerText;
                if ((temp = eachNode.SelectSingleNode("pubDate")) != null)
                    item.PublishedDateTime = DateTime.ParseExact(temp.InnerText, "yyyy", CultureInfo.InvariantCulture);
                if ((temp = eachNode.SelectSingleNode("director")) != null)
                    item.Directors = (temp.InnerText ?? String.Empty).Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                if ((temp = eachNode.SelectSingleNode("actor")) != null)
                    item.Actors = (temp.InnerText ?? String.Empty).Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                if ((temp = eachNode.SelectSingleNode("userRating")) != null)
                    item.UserRating = Single.Parse(temp.InnerText);
                result.Add(item);
            }

            return result;
        }

        public XmlDocument SearchCafeArticleRaw(
            string query,
            int display = 10,
            int start = 1,
            CafeArticleSearchSort orderBy = default(CafeArticleSearchSort))
        {
            string convertedSortMethod = String.Empty;
            switch (orderBy)
            {
                default:
                    convertedSortMethod = "sim";
                    break;
                case CafeArticleSearchSort.ByDate:
                    convertedSortMethod = "date";
                    break;
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(BuildRequestUri(
                new KeyValuePair<string, string>("key", this.Key),
                new KeyValuePair<string, string>("target", "cafearticle"),
                new KeyValuePair<string, string>("query", query),
                new KeyValuePair<string, string>("display", display.ToString()),
                new KeyValuePair<string, string>("start", start.ToString()),
                new KeyValuePair<string, string>("sort", convertedSortMethod)
                ).AbsoluteUri);
            return AssertResponse(doc);
        }

        public NaverSearchResponseContainer<CafeArticleSearchResult> SearchCafeArticle(
            string query,
            int display = 10,
            int start = 1,
            CafeArticleSearchSort orderBy = default(CafeArticleSearchSort))
        {
            XmlDocument doc = this.SearchCafeArticleRaw(query, display, start, orderBy);
            var result = new NaverSearchResponseContainer<CafeArticleSearchResult>();
            XmlNode temp;

            if ((temp = doc.SelectSingleNode("/rss/channel/title")) != null)
                result.Title = temp.InnerText;
            if ((temp = doc.SelectSingleNode("/rss/channel/link")) != null)
                result.Link = new Uri(temp.InnerText, UriKind.Absolute);
            if ((temp = doc.SelectSingleNode("/rss/channel/description")) != null)
                result.Description = temp.InnerText;
            if ((temp = doc.SelectSingleNode("/rss/channel/lastBuildDate")) != null)
                result.LastBuildDate = DateTime.Parse(temp.InnerText);
            if ((temp = doc.SelectSingleNode("/rss/channel/total")) != null)
                result.Total = Int32.Parse(temp.InnerText);
            if ((temp = doc.SelectSingleNode("/rss/channel/start")) != null)
                result.Start = Int32.Parse(temp.InnerText);
            if ((temp = doc.SelectSingleNode("/rss/channel/display")) != null)
                result.Display = Int32.Parse(temp.InnerText);

            foreach (XmlNode eachNode in doc.SelectNodes("/rss/channel/item"))
            {
                CafeArticleSearchResult item = new CafeArticleSearchResult();
                if ((temp = eachNode.SelectSingleNode("title")) != null)
                    item.Title = temp.InnerText;
                if ((temp = eachNode.SelectSingleNode("link")) != null)
                    item.Link = new Uri(temp.InnerText, UriKind.Absolute);
                if ((temp = eachNode.SelectSingleNode("description")) != null)
                    item.Description = temp.InnerText;
                if ((temp = eachNode.SelectSingleNode("cafename")) != null)
                    item.CafeName = temp.InnerText;
                if ((temp = eachNode.SelectSingleNode("cafeurl")) != null)
                    item.CafeUrl = new Uri(temp.InnerText, UriKind.Absolute);
                result.Add(item);
            }

            return result;
        }

        public XmlDocument SearchKnowledgeInRaw(
            string query,
            int display = 10,
            int start = 1,
            KnowledgeInSearchSort orderBy = default(KnowledgeInSearchSort))
        {
            string convertedSortMethod = String.Empty;
            switch (orderBy)
            {
                default:
                    convertedSortMethod = "sim";
                    break;
                case KnowledgeInSearchSort.ByDate:
                    convertedSortMethod = "date";
                    break;
                case KnowledgeInSearchSort.ByCount:
                    convertedSortMethod = "count";
                    break;
                case KnowledgeInSearchSort.ByPoint:
                    convertedSortMethod = "point";
                    break;
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(BuildRequestUri(
                new KeyValuePair<string, string>("key", this.Key),
                new KeyValuePair<string, string>("target", "kin"),
                new KeyValuePair<string, string>("query", query),
                new KeyValuePair<string, string>("display", display.ToString()),
                new KeyValuePair<string, string>("start", start.ToString()),
                new KeyValuePair<string, string>("sort", convertedSortMethod)
                ).AbsoluteUri);
            return AssertResponse(doc);
        }

        public NaverSearchResponseContainer<KnowledgeInSearchResult> SearchKnowledgeIn(
            string query,
            int display = 10,
            int start = 1,
            KnowledgeInSearchSort orderBy = default(KnowledgeInSearchSort))
        {
            XmlDocument doc = this.SearchKnowledgeInRaw(query, display, start, orderBy);
            var result = new NaverSearchResponseContainer<KnowledgeInSearchResult>();
            XmlNode temp;

            if ((temp = doc.SelectSingleNode("/rss/channel/title")) != null)
                result.Title = temp.InnerText;
            if ((temp = doc.SelectSingleNode("/rss/channel/link")) != null)
                result.Link = new Uri(temp.InnerText, UriKind.Absolute);
            if ((temp = doc.SelectSingleNode("/rss/channel/description")) != null)
                result.Description = temp.InnerText;
            if ((temp = doc.SelectSingleNode("/rss/channel/lastBuildDate")) != null)
                result.LastBuildDate = DateTime.Parse(temp.InnerText);
            if ((temp = doc.SelectSingleNode("/rss/channel/total")) != null)
                result.Total = Int32.Parse(temp.InnerText);
            if ((temp = doc.SelectSingleNode("/rss/channel/start")) != null)
                result.Start = Int32.Parse(temp.InnerText);
            if ((temp = doc.SelectSingleNode("/rss/channel/display")) != null)
                result.Display = Int32.Parse(temp.InnerText);

            foreach (XmlNode eachNode in doc.SelectNodes("/rss/channel/item"))
            {
                KnowledgeInSearchResult item = new KnowledgeInSearchResult();
                if ((temp = eachNode.SelectSingleNode("title")) != null)
                    item.Title = temp.InnerText;
                if ((temp = eachNode.SelectSingleNode("link")) != null)
                    item.Link = new Uri(temp.InnerText, UriKind.Absolute);
                if ((temp = eachNode.SelectSingleNode("description")) != null)
                    item.Description = temp.InnerText;
                result.Add(item);
            }

            return result;
        }

        public XmlDocument SearchLocalRaw(
            string query,
            int display = 10,
            int start = 1,
            LocalSearchSort orderBy = default(LocalSearchSort))
        {
            string convertedSortMethod = String.Empty;
            switch (orderBy)
            {
                default:
                    convertedSortMethod = "random";
                    break;
                case LocalSearchSort.ByCommentCount:
                    convertedSortMethod = "comment";
                    break;
                case LocalSearchSort.ByVote:
                    convertedSortMethod = "vote";
                    break;
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(BuildRequestUri(
                new KeyValuePair<string, string>("key", this.Key),
                new KeyValuePair<string, string>("target", "local"),
                new KeyValuePair<string, string>("query", query),
                new KeyValuePair<string, string>("display", display.ToString()),
                new KeyValuePair<string, string>("start", start.ToString()),
                new KeyValuePair<string, string>("sort", convertedSortMethod)
                ).AbsoluteUri);
            return AssertResponse(doc);
        }

        public NaverSearchResponseContainer<LocalSearchResult> SearchLocal(
            string query,
            int display = 10,
            int start = 1,
            LocalSearchSort orderBy = default(LocalSearchSort))
        {
            XmlDocument doc = this.SearchLocalRaw(query, display, start, orderBy);
            var result = new NaverSearchResponseContainer<LocalSearchResult>();
            XmlNode temp;

            if ((temp = doc.SelectSingleNode("/rss/channel/title")) != null)
                result.Title = temp.InnerText;
            if ((temp = doc.SelectSingleNode("/rss/channel/link")) != null)
                result.Link = new Uri(temp.InnerText, UriKind.Absolute);
            if ((temp = doc.SelectSingleNode("/rss/channel/description")) != null)
                result.Description = temp.InnerText;
            if ((temp = doc.SelectSingleNode("/rss/channel/lastBuildDate")) != null)
                result.LastBuildDate = DateTime.Parse(temp.InnerText);
            if ((temp = doc.SelectSingleNode("/rss/channel/total")) != null)
                result.Total = Int32.Parse(temp.InnerText);
            if ((temp = doc.SelectSingleNode("/rss/channel/start")) != null)
                result.Start = Int32.Parse(temp.InnerText);
            if ((temp = doc.SelectSingleNode("/rss/channel/display")) != null)
                result.Display = Int32.Parse(temp.InnerText);

            foreach (XmlNode eachNode in doc.SelectNodes("/rss/channel/item"))
            {
                LocalSearchResult item = new LocalSearchResult();
                if ((temp = eachNode.SelectSingleNode("title")) != null)
                    item.Title = temp.InnerText;
                if ((temp = eachNode.SelectSingleNode("link")) != null &&
                    !String.IsNullOrWhiteSpace(temp.InnerText))
                    item.Link = new Uri(temp.InnerText, UriKind.Absolute);
                if ((temp = eachNode.SelectSingleNode("category")) != null)
                    item.Category = (temp.InnerText ?? String.Empty).Split(new char[] { '>' }, StringSplitOptions.RemoveEmptyEntries);
                if ((temp = eachNode.SelectSingleNode("description")) != null)
                    item.Description = temp.InnerText;
                if ((temp = eachNode.SelectSingleNode("telephone")) != null)
                    item.Telephone = temp.InnerText;
                if ((temp = eachNode.SelectSingleNode("address")) != null)
                    item.Address = temp.InnerText;
                if ((temp = eachNode.SelectSingleNode("roadAddress")) != null)
                    item.RoadAddress = temp.InnerText;
                if ((temp = eachNode.SelectSingleNode("mapx")) != null)
                    item.MapX = Double.Parse(temp.InnerText);
                if ((temp = eachNode.SelectSingleNode("mapy")) != null)
                    item.MapY = Double.Parse(temp.InnerText);
                result.Add(item);
            }

            return result;
        }

        public XmlDocument SuggestErrataRaw(
            string query)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(BuildRequestUri(
                new KeyValuePair<string, string>("key", this.Key),
                new KeyValuePair<string, string>("target", "errata"),
                new KeyValuePair<string, string>("query", query)
                ).AbsoluteUri);
            return AssertResponse(doc);
        }

        public string SuggestErrata(
            string query)
        {
            XmlDocument doc = this.SuggestErrataRaw(query);
            XmlNode errataNode = doc.SelectSingleNode("/result/item/errata");
            if (errataNode == null)
                throw new Exception("errata node is not available.");
            return errataNode.InnerText;
        }

        public XmlDocument SearchKoreanWebRaw(
            string query,
            int display = 10,
            int start = 1,
            string domain = default(string))
        {
            XmlDocument doc = new XmlDocument();
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>(new KeyValuePair<string, string>[] {
                new KeyValuePair<string, string>("key", this.Key),
                new KeyValuePair<string, string>("target", "webkr"),
                new KeyValuePair<string, string>("query", query),
                new KeyValuePair<string, string>("display", display.ToString()),
                new KeyValuePair<string, string>("start", start.ToString())
            });

            if (domain != default(string))
                parameters.Add(new KeyValuePair<string, string>("domain", domain));

            doc.Load(BuildRequestUri(parameters.ToArray()).AbsoluteUri);
            return AssertResponse(doc);
        }

        public NaverSearchResponseContainer<KoreanWebSearchResult> SearchKoreanWeb(
            string query,
            int display = 10,
            int start = 1,
            string domain = default(string))
        {
            XmlDocument doc = this.SearchKoreanWebRaw(query, display, start, domain);
            var result = new NaverSearchResponseContainer<KoreanWebSearchResult>();
            XmlNode temp;

            if ((temp = doc.SelectSingleNode("/rss/channel/title")) != null)
                result.Title = temp.InnerText;
            if ((temp = doc.SelectSingleNode("/rss/channel/link")) != null)
                result.Link = new Uri(temp.InnerText, UriKind.Absolute);
            if ((temp = doc.SelectSingleNode("/rss/channel/description")) != null)
                result.Description = temp.InnerText;
            if ((temp = doc.SelectSingleNode("/rss/channel/lastBuildDate")) != null)
                result.LastBuildDate = DateTime.Parse(temp.InnerText);
            if ((temp = doc.SelectSingleNode("/rss/channel/total")) != null)
                result.Total = Int32.Parse(temp.InnerText);
            if ((temp = doc.SelectSingleNode("/rss/channel/start")) != null)
                result.Start = Int32.Parse(temp.InnerText);
            if ((temp = doc.SelectSingleNode("/rss/channel/display")) != null)
                result.Display = Int32.Parse(temp.InnerText);

            foreach (XmlNode eachNode in doc.SelectNodes("/rss/channel/item"))
            {
                KoreanWebSearchResult item = new KoreanWebSearchResult();
                if ((temp = eachNode.SelectSingleNode("title")) != null)
                    item.Title = temp.InnerText;
                if ((temp = eachNode.SelectSingleNode("link")) != null)
                    item.Link = new Uri(temp.InnerText, UriKind.Absolute);
                if ((temp = eachNode.SelectSingleNode("description")) != null)
                    item.Description = temp.InnerText;
                result.Add(item);
            }

            return result;
        }

        public XmlDocument SearchImageRaw(
            string query,
            int display = 10,
            int start = 1,
            ImageSearchSort orderBy = default(ImageSearchSort),
            ImageSizeCriteria filter = default(ImageSizeCriteria))
        {
            string convertedSortMethod = String.Empty;
            switch (orderBy)
            {
                default:
                    convertedSortMethod = "sim";
                    break;
                case ImageSearchSort.ByDate:
                    convertedSortMethod = "date";
                    break;
            }

            string convertedFilter = String.Empty;
            switch (filter)
            {
                default:
                    convertedFilter = "all";
                    break;
                case ImageSizeCriteria.Large:
                    convertedFilter = "large";
                    break;
                case ImageSizeCriteria.Medium:
                    convertedFilter = "medium";
                    break;
                case ImageSizeCriteria.Small:
                    convertedFilter = "small";
                    break;
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(BuildRequestUri(
                new KeyValuePair<string, string>("key", this.Key),
                new KeyValuePair<string, string>("target", "image"),
                new KeyValuePair<string, string>("query", query),
                new KeyValuePair<string, string>("display", display.ToString()),
                new KeyValuePair<string, string>("start", start.ToString()),
                new KeyValuePair<string, string>("sort", convertedSortMethod),
                new KeyValuePair<string, string>("filter", convertedFilter)
                ).AbsoluteUri);
            return AssertResponse(doc);
        }

        public NaverSearchResponseContainer<ImageSearchResult> SearchImage(
            string query,
            int display = 10,
            int start = 1,
            ImageSearchSort orderBy = default(ImageSearchSort),
            ImageSizeCriteria filter = default(ImageSizeCriteria))
        {
            XmlDocument doc = this.SearchImageRaw(query, display, start, orderBy, filter);
            var result = new NaverSearchResponseContainer<ImageSearchResult>();
            XmlNode temp;

            if ((temp = doc.SelectSingleNode("/rss/channel/title")) != null)
                result.Title = temp.InnerText;
            if ((temp = doc.SelectSingleNode("/rss/channel/link")) != null)
                result.Link = new Uri(temp.InnerText, UriKind.Absolute);
            if ((temp = doc.SelectSingleNode("/rss/channel/description")) != null)
                result.Description = temp.InnerText;
            if ((temp = doc.SelectSingleNode("/rss/channel/lastBuildDate")) != null)
                result.LastBuildDate = DateTime.Parse(temp.InnerText);
            if ((temp = doc.SelectSingleNode("/rss/channel/total")) != null)
                result.Total = Int32.Parse(temp.InnerText);
            if ((temp = doc.SelectSingleNode("/rss/channel/start")) != null)
                result.Start = Int32.Parse(temp.InnerText);
            if ((temp = doc.SelectSingleNode("/rss/channel/display")) != null)
                result.Display = Int32.Parse(temp.InnerText);

            foreach (XmlNode eachNode in doc.SelectNodes("/rss/channel/item"))
            {
                ImageSearchResult item = new ImageSearchResult();
                if ((temp = eachNode.SelectSingleNode("title")) != null)
                    item.Title = temp.InnerText;
                if ((temp = eachNode.SelectSingleNode("link")) != null)
                    item.Link = new Uri(temp.InnerText, UriKind.Absolute);
                if ((temp = eachNode.SelectSingleNode("thumbnail")) != null)
                    item.Thumbnail = new Uri(temp.InnerText, UriKind.Absolute);
                if ((temp = eachNode.SelectSingleNode("sizeheight")) != null)
                    item.Height = Int32.Parse(temp.InnerText);
                if ((temp = eachNode.SelectSingleNode("sizewidth")) != null)
                    item.Width = Int32.Parse(temp.InnerText);
                result.Add(item);
            }

            return result;
        }

        public XmlDocument SearchProductRaw(
            string query,
            int display = 10,
            int start = 1,
            ProductSearchSort orderBy = default(ProductSearchSort))
        {
            string convertedSortMethod = String.Empty;
            switch (orderBy)
            {
                default:
                    convertedSortMethod = "sim";
                    break;
                case ProductSearchSort.ByDate:
                    convertedSortMethod = "date";
                    break;
                case ProductSearchSort.ByPriceAscending:
                    convertedSortMethod = "asc";
                    break;
                case ProductSearchSort.ByPriceDescending:
                    convertedSortMethod = "desc";
                    break;
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(BuildRequestUri(
                new KeyValuePair<string, string>("key", this.Key),
                new KeyValuePair<string, string>("target", "shop"),
                new KeyValuePair<string, string>("query", query),
                new KeyValuePair<string, string>("display", display.ToString()),
                new KeyValuePair<string, string>("start", start.ToString()),
                new KeyValuePair<string, string>("sort", convertedSortMethod)
                ).AbsoluteUri);
            return AssertResponse(doc);
        }

        public NaverSearchResponseContainer<ProductSearchResult> SearchProduct(
            string query,
            int display = 10,
            int start = 1,
            ProductSearchSort orderBy = default(ProductSearchSort))
        {
            XmlDocument doc = this.SearchProductRaw(query, display, start, orderBy);
            var result = new NaverSearchResponseContainer<ProductSearchResult>();
            XmlNode temp;

            if ((temp = doc.SelectSingleNode("/rss/channel/title")) != null)
                result.Title = temp.InnerText;
            if ((temp = doc.SelectSingleNode("/rss/channel/link")) != null)
                result.Link = new Uri(temp.InnerText, UriKind.Absolute);
            if ((temp = doc.SelectSingleNode("/rss/channel/description")) != null)
                result.Description = temp.InnerText;
            if ((temp = doc.SelectSingleNode("/rss/channel/lastBuildDate")) != null)
                result.LastBuildDate = DateTime.Parse(temp.InnerText);
            if ((temp = doc.SelectSingleNode("/rss/channel/total")) != null)
                result.Total = Int32.Parse(temp.InnerText);
            if ((temp = doc.SelectSingleNode("/rss/channel/start")) != null)
                result.Start = Int32.Parse(temp.InnerText);
            if ((temp = doc.SelectSingleNode("/rss/channel/display")) != null)
                result.Display = Int32.Parse(temp.InnerText);

            foreach (XmlNode eachNode in doc.SelectNodes("/rss/channel/item"))
            {
                ProductSearchResult item = new ProductSearchResult();
                if ((temp = eachNode.SelectSingleNode("title")) != null)
                    item.Title = temp.InnerText;
                if ((temp = eachNode.SelectSingleNode("link")) != null)
                    item.Link = new Uri(temp.InnerText, UriKind.Absolute);
                if ((temp = eachNode.SelectSingleNode("image")) != null)
                    item.Image = new Uri(temp.InnerText, UriKind.Absolute);
                if ((temp = eachNode.SelectSingleNode("lprice")) != null)
                    item.LowestPrice = Decimal.Parse(temp.InnerText);
                if ((temp = eachNode.SelectSingleNode("hprice")) != null)
                    item.HighestPrice = Decimal.Parse(temp.InnerText);
                if ((temp = eachNode.SelectSingleNode("mallName")) != null)
                    item.MallName = temp.InnerText;
                if ((temp = eachNode.SelectSingleNode("productId")) != null)
                    item.ProductId = temp.InnerText;
                if ((temp = eachNode.SelectSingleNode("productType")) != null)
                    item.ProductType = (ProductType)Int32.Parse(temp.InnerText);
                result.Add(item);
            }

            return result;
        }

        public XmlDocument SearchDocumentRaw(
            string query,
            int display = 10,
            int start = 1)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(BuildRequestUri(
                new KeyValuePair<string, string>("key", this.Key),
                new KeyValuePair<string, string>("target", "doc"),
                new KeyValuePair<string, string>("query", query),
                new KeyValuePair<string, string>("display", display.ToString()),
                new KeyValuePair<string, string>("start", start.ToString())
                ).AbsoluteUri);
            return AssertResponse(doc);
        }

        public NaverSearchResponseContainer<DocumentSearchResult> SearchDocument(
            string query,
            int display = 10,
            int start = 1)
        {
            XmlDocument doc = this.SearchDocumentRaw(query, display, start);
            var result = new NaverSearchResponseContainer<DocumentSearchResult>();
            XmlNode temp;

            if ((temp = doc.SelectSingleNode("/rss/channel/title")) != null)
                result.Title = temp.InnerText;
            if ((temp = doc.SelectSingleNode("/rss/channel/link")) != null)
                result.Link = new Uri(temp.InnerText, UriKind.Absolute);
            if ((temp = doc.SelectSingleNode("/rss/channel/description")) != null)
                result.Description = temp.InnerText;
            if ((temp = doc.SelectSingleNode("/rss/channel/lastBuildDate")) != null)
                result.LastBuildDate = DateTime.Parse(temp.InnerText);
            if ((temp = doc.SelectSingleNode("/rss/channel/total")) != null)
                result.Total = Int32.Parse(temp.InnerText);
            if ((temp = doc.SelectSingleNode("/rss/channel/start")) != null)
                result.Start = Int32.Parse(temp.InnerText);
            if ((temp = doc.SelectSingleNode("/rss/channel/display")) != null)
                result.Display = Int32.Parse(temp.InnerText);

            foreach (XmlNode eachNode in doc.SelectNodes("/rss/channel/item"))
            {
                DocumentSearchResult item = new DocumentSearchResult();
                if ((temp = eachNode.SelectSingleNode("title")) != null)
                    item.Title = temp.InnerText;
                if ((temp = eachNode.SelectSingleNode("link")) != null)
                    item.Link = new Uri(temp.InnerText, UriKind.Absolute);
                if ((temp = eachNode.SelectSingleNode("description")) != null)
                    item.Description = temp.InnerText;
                result.Add(item);
            }

            return result;
        }
    }
}
