using System;
using System.Collections.Generic;
using System.Linq;
using WebCrawler.Models;
using HtmlAgilityPack;

namespace WebCrawler.CoreConsoleApp
{
    public abstract class Program
    {
        public static string gobjDomain = "connectforhealthco.com";
        public static List<List<DisplayModel>> gobjPageOutput = new List<List<DisplayModel>>();
        public static Dictionary<string, List<Uri>> gobjLinks = new Dictionary<string, List<Uri>>();

        public static void Main(string[] args)
        {
            Console.WriteLine("Start crawling");

            // get url of site to crawl
            Uri builditBaseUrl = new Uri("https://" + gobjDomain + "/");

            // jump into method to search the site and do the heavy lifting
            BeginCrawl(builditBaseUrl);

        }

        public static void BeginCrawl(Uri builditBaseUrl)
        {
            var sitemap = new HtmlDocument();
            var url = builditBaseUrl;
            var web = new HtmlWeb();
            var doc = web.Load(url);

            var atagLinks = doc.DocumentNode.SelectNodes("//a[@href]");
            
            GetNodeAttributesByTag(web, doc, atagLinks);


            #region TODO: if more time, group these better and use this as the data context
            //var colReturn = from x in pageColReturn
            //                from y in contentColReturn
            //                from z in cssColReturn
            //                select new
            //                {
            //                    page = x.Select(x => x.PageUri),
            //                    image = y.Select(y => y.PageUri),
            //                    css = z.Select(z => z.PageUri),
            //                };
            //Console.WriteLine(colReturn); 

            var itemsList = gobjPageOutput;

            #endregion
        }

        /// <summary>
        /// Iterates over node collection (parent/child), outputs results to console. 
        /// </summary>
        /// <param name="parentWeb"></param>
        /// <param name="parentDocument"></param>
        /// <param name="nodes"></param>
        public static void GetNodeAttributesByTag(HtmlWeb parentWeb, HtmlDocument parentDocument, HtmlNodeCollection nodes)
        {
            Uri validUri;
            HtmlDocument document;
            HtmlWeb websiteUrl = new HtmlWeb();

            List<Uri> linkList = new List<Uri>();
            Dictionary<string, List<Uri>> outputUriList = new Dictionary<string, List<Uri>>();

            foreach (HtmlNode node in nodes)
            {
                var attribute = node.Attributes["href"];
                if (attribute != null && node.OriginalName == "a")
                {
                    validUri = ValidateUri(linkList, attribute);

                    // iterate over the links found on the page(s)
                    foreach (var link in linkList)
                    {
                        if (link != null && link.AbsoluteUri.Contains(gobjDomain))
                        {
                            document = websiteUrl.Load(link);

                            var childPages = GetSubPages(websiteUrl, document.DocumentNode.SelectNodes("//a[@href]"), linkList);
                            outputUriList.TryAdd(link.ToString(), childPages.ToList());
                        }
                        // iterate over the key/value pairs and output in a readable format to the console
                        foreach (var item in outputUriList.Keys)
                        {
                            if (item != null)
                            {
                                Console.WriteLine($"{link}");
                                foreach (var valueSet in outputUriList[item])
                                {
                                    if (valueSet != null)
                                    {
                                        Console.WriteLine($"\t {(valueSet?.AbsolutePath)}");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Validate the URI structure via TryCreate. Out a valid Uri
        /// </summary>
        /// <param name="linkList"></param>
        /// <param name="attribute"></param>
        /// <returns></returns>
        private static Uri ValidateUri(List<Uri> linkList, HtmlAttribute attribute)
        {
            Uri validUri;
            // go through all 'a' tags, pull the url/href values
            Uri.TryCreate(attribute.Value, UriKind.Absolute, out validUri);
            // append those valid urls into the list
            linkList.Add(validUri);
            return validUri;
        }

        /// <summary>
        /// Returns Enumerated list of Uri. 
        /// </summary>
        /// <param name="websiteUrl"></param>
        /// <param name="htmlNodeCollection"></param>
        /// <param name="childlinkList"></param>
        /// <returns></returns>
        private static IEnumerable<Uri> GetSubPages(HtmlWeb websiteUrl, HtmlNodeCollection htmlNodeCollection, List<Uri> childlinkList)
        {
            Uri validUri;
            List<Uri> childList = new List<Uri>(childlinkList);

            if (htmlNodeCollection != null)
            {
                foreach (var node in htmlNodeCollection)
                {
                    var attribute = node.Attributes["href"];
                    if (attribute != null && node.OriginalName == "a")
                    {
                        validUri = ValidateUri(childList, attribute);
                    }
                }
            }
            return childList;
        }

    }
}
