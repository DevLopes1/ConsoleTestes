using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;

namespace ConsoleTestes.Programas
{
    public class NoticiasNewsAPI
    {
        NewsApiClient newsApiClient = new NewsApiClient("689e0983da2e43c1b5432c9391d4319e");

        public static void menuPrograma()
        {
            Console.WriteLine(" === Bem Vindo ao NewsAPI - Notícias ===");

            NoticiasNewsAPI nna = new NoticiasNewsAPI();
            Console.Write("Qual o tema? digite: \n=>");
            string query = Console.ReadLine();
            nna.consultarNewsAPI(query);
        }

        public void consultarNewsAPI(string query)
        {
            var now = DateTime.Now;
            var lastMonth = DateTime.Now.Month - 1;
            var firstDay = DateTime.MinValue.Day;
            var yearNow = DateTime.Now.Year;
            var dayLast = DateTime.Now.Day -1;

            // new DateTime(yearNow, lastMonth, firstDay), 
            //new DateTime(yearNow, now.Month, dayLast)
            var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
            {
                Q = query,
                PageSize = 12,
                SortBy = SortBys.Popularity,
                Language = Languages.PT,
                From = new DateTime(yearNow, now.Month, dayLast),
                To = DateTime.Now,
            });




            if (articlesResponse.Status == Statuses.Ok)
            {
                // total results found
               
                Console.WriteLine("Resultados das Notícias de hoje: " + articlesResponse.TotalResults);
                // here's the first 20
                foreach (var article in articlesResponse.Articles)
                {

                    Console.WriteLine("==========" + article.Title + "==========");
                    // title
                    // author
                    Console.WriteLine(article.Author);
                    // description
                    Console.WriteLine(article.Description.Trim());
                    // url
                    Console.WriteLine(article.Url);
                    // published at
                    Console.WriteLine("==========" + article.PublishedAt + "==========");
                    Console.WriteLine("\n");
                }
            }
            Console.WriteLine("Acabou...");
        }
    }
}
