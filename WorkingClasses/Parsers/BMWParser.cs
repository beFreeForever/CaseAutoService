using CaseAutoService.Working;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaseAutoService.Model;
using HtmlAgilityPack;

namespace SelectAutoServise.WorkingClasses.Parsers
{
    public class BMWParser : IRequestParser
    {
        public List<Auto> GetData()
        {
            List<Auto> AutoList = new List<Auto>();
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load("http://www.motorpage.ru/BMW/");
            for (int i = 5; i < 28; i++)
            {
                List<string> AutoTemp = new List<string>();

                HtmlNode[] nodesNames = document.DocumentNode.SelectNodes("/html/body/div[4]/div[1]/div[1]/div[" + i + "]/div[1]/a/h2").ToArray();
                HtmlNode[] nodesBodyType = document.DocumentNode.SelectNodes("/html/body/div[4]/div[1]/div[1]/div[" + i + "]/div[1]/dl/dd[3]").ToArray();
                HtmlNode[] nodesPrices = document.DocumentNode.SelectNodes("/html/body/div[4]/div[1]/div[1]/div[" + i + "]/div[3]/p/b").ToArray();

                AutoList.Add(new Auto
                {
                    Name = nodesNames[0].InnerText,
                    Manufacturer = "BWM",
                    BodyType = nodesBodyType[0].InnerText,
                    Price = GetPrice(nodesPrices[0].InnerText)
                });
            }
            return AutoList;
        }
        public double GetPrice(string Price)
        {
            double NewPrice = 0;
            string PriceTemp = "";
            for (int i = 0; i < Price.Length; i++)
            {
                if (Price[i] == 'р')
                {
                    break;
                }
                PriceTemp += Price[i];
            }
            NewPrice = Double.Parse(PriceTemp);
            return NewPrice;
        }
    }
}
