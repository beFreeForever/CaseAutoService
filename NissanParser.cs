using CaseAutoService.Working;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaseAutoService.Model;
using HtmlAgilityPack;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace CaseAutoService.WorkingClasses.Parsers
{
    public class NissanParser : IRequestParser
    {
       
        public List<Auto> GetData()
        {
            List<Auto> AutoList = new List<Auto>();
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load("http://sovaz-auto.ru/new-auto/modelnyj-ryad-nissan/");
            for (int i = 2; i <= 4; i++)
            {
                for (int j = 1; j <= 5; j++)
                {
                    List<string> AutoTemp = new List<string>();

                    HtmlNode[] nodes = document.DocumentNode.SelectNodes("//*[@id='post-2155']/table/tbody/tr[" + j + "]/th[" + i + "]").ToArray();

                    foreach (HtmlNode item in nodes)
                    {

                        Console.WriteLine(item.InnerText);
                        //Regex regex = new Regex(" ");
                        //Regex regix = new Regex(" руб.");
                        //if (regex.IsMatch(item.InnerText) || regix.IsMatch(item.InnerText)) 
                        //{

                        //}

                    }
                }
            }
            //Console.WriteLine(document.ToHtml().ToString());
            return AutoList;
        }
    }
}
