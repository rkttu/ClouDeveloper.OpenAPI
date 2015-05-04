using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;
using ClouDeveloper.OpenAPI.KolisNet.Search;
using ClouDeveloper.OpenAPI.Naver.Search;
using ClouDeveloper.OpenAPI.TED.Search;

namespace ClouDeveloper.OpenAPI.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            NaverSearchClient nsc = new NaverSearchClient("TEST KEY");
            var blog = nsc.SearchBlog("건축학");
            var news = nsc.SearchNews("건축학");
            var books = nsc.SearchBooks("건축학");
            var isSexual = nsc.IsSexualSearchKeyword("성인용품");
            var encyc = nsc.SearchEncyclopedia("건축학");
            var movie = nsc.SearchMovie("건축학");
            var cafearticle = nsc.SearchCafeArticle("건축학");
            var errata = nsc.SuggestErrata("rjscnrgkr");
            var krweb = nsc.SearchKoreanWeb("건축학");
            var image = nsc.SearchImage("건축학");
            var product = nsc.SearchProduct("건축학");
            var doc = nsc.SearchDocument("건축학");

            KolisSearchClient ksc = new KolisSearchClient();
            var search = ksc.Search(new KolisSearchRequest("건축학"));
            var bibliography = ksc.GetBibliographyInfo("104051917");
            var library = ksc.GetLibraryInfo("011001");

            TEDSearchClient tsc = new TEDSearchClient("TEST KEY");
            var all = tsc.SearchAll("health");
            var posts = tsc.SearchBlogPosts("health");
            var conversations = tsc.SearchConversations("health");
            var fellows = tsc.SearchFellows("health");
            var playlists = tsc.SearchPlaylists("health");
            var speakers = tsc.SearchSpeakers("health");
            var talks = tsc.SearchTalks("health");
            var tedxevents = tsc.SearchTEDLocalEvents("health");
            var themes = tsc.SearchThemes("health");
            return;
        }
    }
}
