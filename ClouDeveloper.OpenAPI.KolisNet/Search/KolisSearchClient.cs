using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Xml;

namespace ClouDeveloper.OpenAPI.KolisNet.Search
{
    public class KolisSearchClient
    {
        public KolisSearchClient()
            : base()
        {
        }

        private Lazy<HttpClient> clientFactory = new Lazy<HttpClient>(true);

        private static XmlDocument AssertResponse(XmlDocument doc)
        {
            if (doc == null)
                throw new ArgumentNullException("doc");
            if (doc.DocumentElement == null)
                throw new ArgumentNullException("doc");
            XmlNode targetNode = null;
            if ((targetNode = doc.SelectSingleNode("/METADATA/ERR_INFO")) != null)
                throw new KolisSearchException(doc);
            return doc;
        }

        private static Uri BuildRequestUri(
            string targetUri = "http://nl.go.kr/kolisnet/openApi/open.php",
            params KeyValuePair<string, string>[] items)
        {
            UriBuilder requestUriBuilder = new UriBuilder(new Uri(targetUri, UriKind.Absolute));

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

        public XmlDocument SearchRaw(KolisSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            XmlDocument doc = new XmlDocument();
            doc.Load(BuildRequestUri("http://nl.go.kr/kolisnet/openApi/open.php", request.ToKeyValuePairs()).AbsoluteUri);
            return AssertResponse(doc);
        }

        public KolisSearchResponse Search(KolisSearchRequest request)
        {
            XmlDocument doc = this.SearchRaw(request);
            KolisSearchResponse response = new KolisSearchResponse();
            XmlNode node = null;

            if ((node = doc.SelectSingleNode("/METADATA/TOTAL")) != null)
                response.Total = Int32.Parse(node.InnerText);

            foreach (XmlNode eachNode in doc.SelectNodes("/METADATA/RECORD"))
            {
                BibliographyInfo info = new BibliographyInfo();

                if ((node = eachNode.SelectSingleNode("NUMBER")) != null)
                    info.Number = Int32.Parse(node.InnerText);

                if ((node = eachNode.SelectSingleNode("TITLE")) != null)
                    info.Title = node.InnerText;

                if ((node = eachNode.SelectSingleNode("AUTHOR")) != null)
                    info.Author = node.InnerText;

                if ((node = eachNode.SelectSingleNode("PUBLISHER")) != null)
                    info.Publisher = node.InnerText;

                if ((node = eachNode.SelectSingleNode("PUBYEAR")) != null)
                    info.PublishedYear = node.InnerText;

                if ((node = eachNode.SelectSingleNode("TYPE")) != null)
                    info.Type = node.InnerText;

                if ((node = eachNode.SelectSingleNode("CONTENTS")) != null)
                    info.HasContents = String.Equals(node.InnerText, "Y", StringComparison.OrdinalIgnoreCase);

                if ((node = eachNode.SelectSingleNode("COVER_YN")) != null)
                    info.HasCover = String.Equals(node.InnerText, "Y", StringComparison.OrdinalIgnoreCase);

                if (info.HasCover &&
                    (node = eachNode.SelectSingleNode("COVER_URL")) != null)
                    info.CoverImage = new Uri(node.InnerText, UriKind.Absolute);

                if ((node = eachNode.SelectSingleNode("LIB_NAME")) != null)
                    info.LibraryName = node.InnerText;

                if ((node = eachNode.SelectSingleNode("LIB_CODE")) != null)
                    info.LibraryCode = node.InnerText;

                if ((node = eachNode.SelectSingleNode("REC_KEY")) != null)
                    info.BibliographyKey = node.InnerText;

                response.Add(info);
            }

            return response;
        }

        public XmlDocument GetBibliographyInfoRaw(string bibliographyKey, string controlNo = default(string))
        {
            List<KeyValuePair<string, string>> kvpList = new List<KeyValuePair<string, string>>();
            kvpList.Add(new KeyValuePair<string, string>("rec_key", bibliographyKey));

            if (controlNo != null)
                kvpList.Add(new KeyValuePair<string, string>("control_no", controlNo));

            XmlDocument doc = new XmlDocument();
            doc.Load(BuildRequestUri("http://nl.go.kr/kolisnet/openApi/open.php", kvpList.ToArray()).AbsoluteUri);
            return AssertResponse(doc);
        }

        public BibliographyDetailInfoResponse GetBibliographyInfo(string bibliographyKey, string controlNo = default(string))
        {
            XmlDocument doc = this.GetBibliographyInfoRaw(bibliographyKey, controlNo);
            BibliographyDetailInfoResponse response = new BibliographyDetailInfoResponse();
            XmlNode node = null;

            if ((node = doc.SelectSingleNode("/METADATA/BIBINFO/REC_KEY")) != null)
                response.BibliographyKey = node.InnerText;

            if ((node = doc.SelectSingleNode("/METADATA/BIBINFO/TITLE_INFO")) != null)
                response.TitleInfo = node.InnerText;

            if ((node = doc.SelectSingleNode("/METADATA/BIBINFO/PUBLISH_INFO")) != null)
                response.PublishInfo = node.InnerText;

            if ((node = doc.SelectSingleNode("/METADATA/BIBINFO/FORM_INFO")) != null)
                response.FormInfo = node.InnerText;

            if ((node = doc.SelectSingleNode("/METADATA/BIBINFO/NOTE_INFO")) != null)
                response.NoteInfo = node.InnerText;

            if ((node = doc.SelectSingleNode("/METADATA/BIBINFO/CLASFY_INFO")) != null)
                response.ClassificationInfo = node.InnerText;

            if ((node = doc.SelectSingleNode("/METADATA/BIBINFO/CONTENTS_YN")) != null)
                response.HasContents = String.Equals(node.InnerText, "Y", StringComparison.OrdinalIgnoreCase);

            if ((node = doc.SelectSingleNode("/METADATA/BIBINFO/ABSTRACTS_YN")) != null)
                response.HasAbstracts = String.Equals(node.InnerText, "Y", StringComparison.OrdinalIgnoreCase);

            if ((node = doc.SelectSingleNode("/METADATA/BIBINFO/COVER_YN")) != null)
                response.HasCover = String.Equals(node.InnerText, "Y", StringComparison.OrdinalIgnoreCase);

            if (response.HasCover &&
                (node = doc.SelectSingleNode("/METADATA/BIBINFO/COVER_URL")) != null)
                response.CoverImage = new Uri(node.InnerText, UriKind.Absolute);

            if ((node = doc.SelectSingleNode("/METADATA/BIBINFO/UB_CONTROL_NO")) != null)
                response.UBControlNumber = node.InnerText;

            if ((node = doc.SelectSingleNode("/METADATA/BIBINFO/ORIGINAL_YN")) != null)
                response.HasOriginal = String.Equals(node.InnerText, "Y", StringComparison.OrdinalIgnoreCase);

            if ((node = doc.SelectSingleNode("/METADATA/BIBINFO/SUBJECT_NAME")) != null)
                response.SubjectName = node.InnerText;

            if ((node = doc.SelectSingleNode("/METADATA/BIBINFO/LOCAL_CONTROL_NO")) != null)
                response.LocalControlNumber = node.InnerText;

            if ((node = doc.SelectSingleNode("/METADATA/BIBINFO/PRICE_INFO")) != null)
                response.PriceInfo = node.InnerText;

            if (response.HoldLibraries == null)
                response.HoldLibraries = new List<BibiliographyHoldInfo>();

            foreach (XmlNode eachNode in doc.SelectNodes("/METADATA/HOLDINFO"))
            {
                BibiliographyHoldInfo hold = new BibiliographyHoldInfo();

                if ((node = eachNode.SelectSingleNode("NUMBER")) != null)
                    hold.Number = Int32.Parse(node.InnerText);

                if ((node = eachNode.SelectSingleNode("LOCAL")) != null)
                    hold.LibraryLocalArea = (LibraryLocalAreaCode)Enum.Parse(typeof(LibraryLocalAreaCode), node.InnerText);

                if ((node = eachNode.SelectSingleNode("LIB_CODE")) != null)
                    hold.LibraryCode = node.InnerText;

                if ((node = eachNode.SelectSingleNode("LIB_NAME")) != null)
                    hold.LibraryName = node.InnerText;

                if ((node = eachNode.SelectSingleNode("CALL_NO")) != null)
                    hold.CallNumber = node.InnerText;

                if ((node = eachNode.SelectSingleNode("START_VOL")) != null)
                    hold.StartVolume = node.InnerText;

                if ((node = eachNode.SelectSingleNode("ORIGINAL_YN")) != null)
                    hold.HasOriginal = String.Equals(node.InnerText, "Y", StringComparison.OrdinalIgnoreCase);

                response.HoldLibraries.Add(hold);
            }

            return response;
        }

        public XmlDocument GetLibraryInfoRaw(string libraryCode)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(BuildRequestUri(
                "http://nl.go.kr/kolisnet/openApi/open.php", 
                new KeyValuePair<string, string>("lib_code", libraryCode)
                ).AbsoluteUri);
            return AssertResponse(doc);
        }

        public LibraryInfo GetLibraryInfo(string libraryCode)
        {
            XmlDocument doc = this.GetLibraryInfoRaw(libraryCode);
            LibraryInfo response = new LibraryInfo();
            XmlNode node = null;

            if ((node = doc.SelectSingleNode("/METADATA/LIBINFO/LIB_CODE")) != null)
                response.LibraryCode = node.InnerText;

            if ((node = doc.SelectSingleNode("/METADATA/LIBINFO/LIB_NAME")) != null)
                response.LibraryName = node.InnerText;

            if ((node = doc.SelectSingleNode("/METADATA/LIBINFO/DIVISION")) != null)
                response.Division = node.InnerText;

            if ((node = doc.SelectSingleNode("/METADATA/LIBINFO/ZIP_CODE")) != null)
                response.ZipCode = node.InnerText;

            if ((node = doc.SelectSingleNode("/METADATA/LIBINFO/TEL")) != null)
                response.Telephone = node.InnerText;

            if ((node = doc.SelectSingleNode("/METADATA/LIBINFO/FAX")) != null)
                response.Fax = node.InnerText;

            if ((node = doc.SelectSingleNode("/METADATA/LIBINFO/ADDRESS")) != null)
                response.Address = node.InnerText;

            if ((node = doc.SelectSingleNode("/METADATA/LIBINFO/E_MAIL")) != null)
                response.EMail = new Uri(String.Concat("mailto:", node.InnerText));

            if ((node = doc.SelectSingleNode("/METADATA/LIBINFO/HOMEPAGE")) != null &&
                !String.IsNullOrWhiteSpace(node.InnerText))
            {
                string temp = node.InnerText;
                if (!temp.StartsWith(Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase) &&
                    !temp.StartsWith(Uri.UriSchemeHttp, StringComparison.OrdinalIgnoreCase))
                    temp = Uri.UriSchemeHttp + "://" + temp;
                response.WebSite = new Uri(temp, UriKind.Absolute);
            }

            return response;
        }

        public string GetBibliographyMarcDocument(string libraryCode, string bibliographyKey, string authKey)
        {
            Uri targetUri = BuildRequestUri(
                "http://nl.go.kr/kolisnet/openApi/api/request/getMarc.php",
                new KeyValuePair<string, string>("lib_code", libraryCode),
                new KeyValuePair<string, string>("auth_key", authKey),
                new KeyValuePair<string, string>("rec_key", bibliographyKey));

            var message = new HttpRequestMessage(HttpMethod.Get, targetUri);
            var client = this.clientFactory.Value;
            var response = client.SendAsync(message).Result.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;

            if (String.Equals(
                response.Content.Headers.ContentType.MediaType,
                "text/xml", StringComparison.OrdinalIgnoreCase))
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(content);
                AssertResponse(doc);
                return null;
            }

            return content;
        }
    }
}
