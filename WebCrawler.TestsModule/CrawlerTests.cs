using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HtmlAgilityPack;
using System.Collections.Generic;
using WebCrawler.CoreConsoleApp;

namespace WebCrawler.TestModule
{
    [TestClass()]
    public class CrawlerTests
    {
        [TestMethod()]
        public void BeginCrawlTest()
        {
            Uri testUrl = new Uri("https://connectforhealthco.com/");
            // Assert values return for objects
            var sitemap = new HtmlDocument();
            var url = testUrl;
            var web = new HtmlWeb();
            var doc = web.Load(url);

            // assert those items above return things.
            Assert.IsNotNull(web);
            Assert.IsNotNull(doc);
        }

        [TestMethod()]
        public void MainTest()
        {
            // domain isnt null
            Assert.IsNotNull(Program.gobjDomain);
        }

        [TestMethod()]
        ///GetNodeAttributesByTag(HtmlNodeCollection colHtmlNode, string strAttribute, string tagType)
        public void GetNodeAttributesByTagTest()
        {
            // values from BeginCrawl create the items for this
            Uri testUrl = new Uri("https://connectforhealthco.com/");
            // Assert values return for objects
            var sitemap = new HtmlDocument();
            var url = testUrl;
            var web = new HtmlWeb();
            var doc = web.Load(url);

            // node collections
            var link = doc.DocumentNode.SelectNodes("//link[@href]");
            var images = doc.DocumentNode.SelectNodes("//img[@src]");
            var cssLinks = doc.DocumentNode.SelectNodes("//link[@rel]");
            var atagLinks = doc.DocumentNode.SelectNodes("//a[@href]");

            // run these through the function and add them to the global list
            var pageColReturn = Program.GetNodeAttributesByTag(atagLinks, "href", "a");
            var contentColReturn = Program.GetNodeAttributesByTag(images, "src", "img");
            var linkColReturn = Program.GetNodeAttributesByTag(link, "href", "link");
            var cssColReturn = Program.GetNodeAttributesByTag(cssLinks, "rel", "link");

            var returnedList = Program.gobjPageOutput;

            Assert.IsNotNull(web);
            Assert.IsNotNull(doc);
            Assert.IsNotNull(pageColReturn);
            Assert.IsNotNull(contentColReturn);
            Assert.IsNotNull(linkColReturn);
            Assert.IsNotNull(cssColReturn);

            //Assert this returns a List<List<DisplayModel>>
            Assert.IsInstanceOfType(returnedList, typeof(List<List<WebCrawler.Models.DisplayModel>>));
        }
    }
}

