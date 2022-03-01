using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebSpider
{
    class Program
    {
        static void Main(string[] args)
        {

            // 1) User enters a web address
            string url = "https://www.greggs.co.uk/";
            Console.WriteLine($"Please enter a URL to start searching from (or leave blank to search from {url})");

            string input = Console.ReadLine();
            if(input.Length > 0)
            {
                url = input;
            }

            // 2) User enters a search term 
            string searchTerm = "pig";
            Console.WriteLine($"Please enter a search term to look for (or leave blank to search for {searchTerm})");
            input = Console.ReadLine();
            if(input != "")
            {
                searchTerm = input;
            }

            // 3) Fetch that web page
            string firstWebPageFound = FetchWebPage(url, searchTerm);

            
        }

        private static string FetchWebPage(string url, string searchTerm)
        {
            using (WebClient web = new WebClient()) {
                Console.WriteLine($"Downloading {url}");
                string html = web.DownloadString(url);

                foreach(Match m in Regex.Matches(html, @"\b" + searchTerm + @"\b", RegexOptions.IgnoreCase))
                {
                    Console.WriteLine($"{searchTerm} found from {url}");
                }
                
                //Console.WriteLine(html);
            }
            // 4) Extract all links from the web page
            List<string> links = new List<string>();

            Regex.Matches(html, "<a href=\"(http.*?)\"");

            // 5) repeat the process until we find the search term

            return "";
        }
    }
}
