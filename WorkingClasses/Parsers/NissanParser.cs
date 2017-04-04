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
            for (int i = 2; i <= 4; i *= 2)
            {
                for (int j = 1; j <= 5; j++)
                {
                    List<string> AutoTemp = new List<string>();
                    HtmlNode[] nodes = document.DocumentNode.SelectNodes("//*[@id='post-2155']/table/tbody/tr[" + j + "]/th[" + i + "]").ToArray();
                    if(GetPrice(nodes[0].InnerText) != 0)
                    {
                        AutoList.Add(new Auto
                        {
                            Name = GetName(nodes[0].InnerText),
                            Manufacturer = "Nissan",
                            BodyType = GetBodyType(nodes[0].InnerText),
                            Price = GetPrice(nodes[0].InnerText)
                        });
                    }                 
                }
            }
            return AutoList;
        }
        private string GetBodyType(string FullString)
        {
            string BodyType = "";
            int StartI = 0;
            for (int i = 0; i < FullString.Length; i++)
            {
                if (FullString[i] == '.')
                {
                    StartI = i + 1;
                    break;
                }
            }
            for (int i = StartI; i < FullString.Length; i++)
            {
                BodyType += FullString[i];
            }
            return BodyType;
        }
        private string GetName(string FullString)
        {
            string Name = "";
            string NameTemp = FullString.Trim();
            int SpaceValue = 0, StartI = 0, EndI = 0;
            for (int i = 0; i < NameTemp.Length; i++)
            {
                if (NameTemp[i] == ' ')
                {
                    SpaceValue++;
                    if (SpaceValue == 1)
                    {
                        StartI = i;
                    }
                    if (SpaceValue == 2)
                    {
                        EndI = i;
                    }
                }
            }
            for (int i = StartI + 1; i < EndI; i++)
            {

                if (NameTemp[i] == 'о' || NameTemp[i] == 'т')
                {
                    continue;
                }
                Name += NameTemp[i];
            }
            return Name;
        }
        private double GetPrice(string FullString)
        {
            double Price = 0;
            int StartI = 0;
            string TempPriceMaster = "";
            string TempPrice = "";
            string pattern = @"\b(\d*\W+\d+\W\d+\W+руб)";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(FullString);
            if (match.Success)
            {
                TempPrice = match.Groups[1].Value;
                for (int i = 0; i < TempPrice.Length; i++)
                {
                    if (TempPrice[i] == 'р')
                    {
                        StartI = i - 1;
                    }
                }
                for (int i = 0; i < StartI; i++)
                {
                    TempPriceMaster += TempPrice[i];
                }
                if (!String.IsNullOrEmpty(TempPriceMaster))
                {
                    Price = Double.Parse(TempPriceMaster);
                }
            }
            return Price;
        }   
    }   
}
