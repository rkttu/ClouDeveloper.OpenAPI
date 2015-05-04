using System;
using System.Collections.Generic;

namespace ClouDeveloper.OpenAPI.KolisNet.Search
{
    public sealed class KolisSearchRequest
    {
        public KolisSearchRequest(string query, int page)
            : base()
        {
            this.SearchField1 = SearchField.All;
            this.Value1 = query;
            this.Page = page;
            this.PerPage = 10;
        }

        public KolisSearchRequest(string query)
            : this(query, 1)
        {
        }

        public CollectionSet? CollectionSet { get; set; }
        public int Page { get; set; }

        public SearchField? SearchField1 { get; set; }
        public string Value1 { get; set; }
        public Operator? AndOrNot1 { get; set; }

        public SearchField? SearchField2 { get; set; }
        public string Value2 { get; set; }
        public Operator? AndOrNot2 { get; set; }

        public SearchField? SearchField3 { get; set; }
        public string Value3 { get; set; }
        public Operator? AndOrNot3 { get; set; }

        public SearchField? SearchField4 { get; set; }
        public string Value4 { get; set; }
        public Operator? AndOrNot4 { get; set; }

        public SearchField? SearchField5 { get; set; }
        public string Value5 { get; set; }

        public StandardCode? Gubun1 { get; set; }
        public string Code1 { get; set; }

        public ClassificationCode? Gubun2 { get; set; }
        public string Code2 { get; set; }

        public int? StartYear { get; set; }
        public int? EndYear { get; set; }
        public int? MaxCount { get; set; }

        public SearchResultSort? SortKSJ { get; set; }
        public bool HanjaTrans { get; set; }
        public int PerPage { get; set; }
        public string FormClass { get; set; }

        public int? LibTypeDetail { get; set; }
        public string Library { get; set; }

        private string GetSearchFieldString(SearchField value)
        {
            switch (value)
            {
                case SearchField.All: return "total_field";
                case SearchField.Title: return "title";
                case SearchField.Author: return "author";
                case SearchField.Publisher: return "publisher";
                default: return null;
            }
        }

        private string GetOperatorString(Operator value)
        {
            switch (value)
            {
                case Operator.And: return "AND";
                case Operator.Or: return "OR";
                case Operator.Not: return "NOT";
                default: return null;
            }
        }

        private string GetStandardCodeString(StandardCode value)
        {
            switch (value)
            {
                case StandardCode.CAN:
                case StandardCode.CBN:
                case StandardCode.CODEN:
                case StandardCode.ISBN:
                case StandardCode.ISSN:
                case StandardCode.RNSTRN:
                case StandardCode.STRN:
                    return value.ToString("F").ToUpperInvariant();
                default:
                    return null;
            }
        }

        private string GetClassificationCodeString(ClassificationCode value)
        {
            switch (value)
            {
                case ClassificationCode.CEC:
                case ClassificationCode.COC:
                case ClassificationCode.CWC:
                case ClassificationCode.DDC:
                case ClassificationCode.KDC:
                case ClassificationCode.KDCP:
                    return value.ToString("F").ToUpperInvariant();
                default:
                    return null;
            }
        }

        private string GetSortKSJString(SearchResultSort value)
        {
            switch (value)
            {
                case SearchResultSort.ByTitleAscending: return "SORT_TITLE ASC";
                case SearchResultSort.ByTitleDescending: return "SORT_TITLE DESC";
                case SearchResultSort.ByPublishedYearAscending: return "SORT_PUBLISHER ASC";
                case SearchResultSort.ByPublishedYearDescending: return "SORT_PUBLISHER DESC";
                case SearchResultSort.ByPublisherAscending: return "PUB_YEAR_INFO ASC";
                case SearchResultSort.ByPublisherDescending: return "PUB_YEAR_INFO DESC";
                default: return null;
            }
        }

        public KeyValuePair<string, string>[] ToKeyValuePairs()
        {
            List<KeyValuePair<string, string>> kvpList = new List<KeyValuePair<string, string>>();

            if (this.CollectionSet.HasValue)
                kvpList.Add(new KeyValuePair<string, string>("collection_set", ((int)this.CollectionSet.Value).ToString()));

            kvpList.Add(new KeyValuePair<string, string>("page", this.Page.ToString()));

            bool @continue = false;

            do
            {
                @continue = this.SearchField1.HasValue &&
                    Enum.IsDefined(typeof(SearchField), this.SearchField1.Value);

                if (!@continue) break;
                kvpList.Add(new KeyValuePair<string, string>("search_field1", this.GetSearchFieldString(this.SearchField1.Value)));
                kvpList.Add(new KeyValuePair<string, string>("value1", this.Value1 ?? String.Empty));

                @continue = this.AndOrNot1.HasValue &&
                    Enum.IsDefined(typeof(Operator), this.AndOrNot1.Value) &&
                    this.SearchField2.HasValue &&
                    Enum.IsDefined(typeof(SearchField), this.SearchField2.Value) &&
                    this.SearchField2.Value != SearchField.All;

                if (!@continue) break;
                kvpList.Add(new KeyValuePair<string, string>("and_or_not1", this.GetOperatorString(this.AndOrNot1.Value)));
                kvpList.Add(new KeyValuePair<string, string>("search_field2", this.GetSearchFieldString(this.SearchField2.Value)));
                kvpList.Add(new KeyValuePair<string, string>("value2", this.Value2 ?? String.Empty));

                @continue = this.AndOrNot2.HasValue &&
                    Enum.IsDefined(typeof(Operator), this.AndOrNot2.Value) &&
                    this.SearchField3.HasValue &&
                    Enum.IsDefined(typeof(SearchField), this.SearchField3.Value) &&
                    this.SearchField3.Value != SearchField.All;

                if (!@continue) break;
                kvpList.Add(new KeyValuePair<string, string>("and_or_not2", this.GetOperatorString(this.AndOrNot2.Value)));
                kvpList.Add(new KeyValuePair<string, string>("search_field3", this.GetSearchFieldString(this.SearchField3.Value)));
                kvpList.Add(new KeyValuePair<string, string>("value3", this.Value3 ?? String.Empty));

                @continue = this.AndOrNot3.HasValue &&
                    Enum.IsDefined(typeof(Operator), this.AndOrNot3.Value) &&
                    this.SearchField4.HasValue &&
                    Enum.IsDefined(typeof(SearchField), this.SearchField4.Value) &&
                    this.SearchField4.Value != SearchField.All;

                if (!@continue) break;
                kvpList.Add(new KeyValuePair<string, string>("and_or_not3", this.GetOperatorString(this.AndOrNot3.Value)));
                kvpList.Add(new KeyValuePair<string, string>("search_field4", this.GetSearchFieldString(this.SearchField4.Value)));
                kvpList.Add(new KeyValuePair<string, string>("value4", this.Value4 ?? String.Empty));

                @continue = this.AndOrNot4.HasValue &&
                    Enum.IsDefined(typeof(Operator), this.AndOrNot4.Value) &&
                    this.SearchField5.HasValue &&
                    Enum.IsDefined(typeof(SearchField), this.SearchField5.Value) &&
                    this.SearchField5.Value != SearchField.All;

                if (!@continue) break;
                kvpList.Add(new KeyValuePair<string, string>("and_or_not4", this.GetOperatorString(this.AndOrNot4.Value)));
                kvpList.Add(new KeyValuePair<string, string>("search_field5", this.GetSearchFieldString(this.SearchField5.Value)));
                kvpList.Add(new KeyValuePair<string, string>("value5", this.Value5 ?? String.Empty));
            }
            while (false);

            if (this.Gubun1.HasValue)
            {
                kvpList.Add(new KeyValuePair<string, string>("gubun1", this.GetStandardCodeString(this.Gubun1.Value)));
                kvpList.Add(new KeyValuePair<string, string>("code1", this.Code1 ?? String.Empty));
            }

            if (this.Gubun2.HasValue)
            {
                kvpList.Add(new KeyValuePair<string, string>("gubun2", this.GetClassificationCodeString(this.Gubun2.Value)));
                kvpList.Add(new KeyValuePair<string, string>("code2", this.Code2 ?? String.Empty));
            }

            if (this.StartYear.HasValue)
                kvpList.Add(new KeyValuePair<string, string>("start_year", this.StartYear.Value.ToString()));
            if (this.EndYear.HasValue)
                kvpList.Add(new KeyValuePair<string, string>("end_year", this.EndYear.Value.ToString()));
            if (this.SortKSJ.HasValue)
                kvpList.Add(new KeyValuePair<string, string>("sort_ksj", this.GetSortKSJString(this.SortKSJ.Value)));
            if (this.HanjaTrans)
                kvpList.Add(new KeyValuePair<string, string>("hanja_trans", "Y"));

            kvpList.Add(new KeyValuePair<string, string>("per_page", this.PerPage.ToString()));

            if (this.FormClass != null)
                kvpList.Add(new KeyValuePair<string, string>("form_class", this.FormClass));
            if (this.Library != null)
            {
                kvpList.Add(new KeyValuePair<string, string>("lib_type_detail", "2"));
                kvpList.Add(new KeyValuePair<string, string>("library", this.Library));
            }
            else if (this.LibTypeDetail.HasValue)
                kvpList.Add(new KeyValuePair<string, string>("lib_type_detail", this.LibTypeDetail.Value.ToString()));

            return kvpList.ToArray();
        }
    }
}
