using CaseAutoService.Working;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaseAutoService.Model;
using HtmlAgilityPack;

namespace SelectAutoServise.WorkingClasses.Parsers
{
    public class MersedesParser : IRequestParser
    {
        public List<Auto> GetData()
        {
            //List<Auto> AutoList = new List<Auto>();
            //HtmlWeb web = new HtmlWeb();
            //HtmlDocument document = web.Load("http://sales.mercedes-avilon.ru/special/goryachee-predlozhenie-table/?csref=avilon_volg:pkw:Mercedes:cpc:Google.Adwords&csref=avilon_volg:pkw:NEW:cpc:Google.Adwords&utm_source=Google.Adwords&utm_medium=cpc&utm_campaign=general_reg&utm_content=ST:g::S:::AP:::PT:1t1::P:1t1::DT:c::RI:1011981::RN:1011981::CI:743824508::GI:42576317487::PI:kwd-16822931::AI:189100468533::KW:mercedes&utm_term=mercedes&gclid=Cj0KEQjwwoLHBRDD0beVheu3lt0BEiQAvU4CKvwRMRFEZMO7i7YYpcleZ9JssEFKzmZeGcp9ZmQIZl8aAq9f8P8HAQ");
            //List<string> s = new List<string>();
            //for (int i = 1; i <= 120; i++)
            //{
            //    for (int j = 2; j <= 6; j++)
            //    {
            //        string[] Auto = new string[3];
            //        if (j == 4 || j == 5)
            //        {
            //            continue;
            //        }
            //        HtmlNode[] nodes = document.DocumentNode.SelectNodes("//*[@id='th_" + i + "']/td[" + j + "]").ToArray();
            //        if (!String.IsNullOrEmpty(nodes[0].InnerText))
            //        {
            //            s.Add(nodes[0].InnerText);
            //        }
            //    }
            //}
            //int k = 0;
            //while (k < s.Count / 3)
            //{
            //    AutoList.Add(new Auto
            //    {
            //        Name = s[k * 3],
            //        Manufacturer = "Mersedes",
            //        BodyType = s[k * 3 + 1],
            //        Price = GetPrice(s[k * 3 + 2])
            //    });
            //    k++;
            //}
            //return AutoList;

            List<Auto> AutoList = new List<Auto>();
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load("http://sales.mercedes-avilon.ru/special/goryachee-predlozhenie-table/?csref=avilon_volg:pkw:Mercedes:cpc:Google.Adwords&csref=avilon_volg:pkw:NEW:cpc:Google.Adwords&utm_source=Google.Adwords&utm_medium=cpc&utm_campaign=general_reg&utm_content=ST:g::S:::AP:::PT:1t1::P:1t1::DT:c::RI:1011981::RN:1011981::CI:743824508::GI:42576317487::PI:kwd-16822931::AI:189100468533::KW:mercedes&utm_term=mercedes&gclid=Cj0KEQjwwoLHBRDD0beVheu3lt0BEiQAvU4CKvwRMRFEZMO7i7YYpcleZ9JssEFKzmZeGcp9ZmQIZl8aAq9f8P8HAQ");
            List<string> s = new List<string>();
            int i = 1, iMax = 1000;
            while (i <= iMax)
            {
                for (int j = 2; j <= 6; j++)
                {
                    string[] Auto = new string[3];
                    if (j == 4 || j == 5)
                    {
                        continue;
                    }
                    HtmlNode[] nodes;
                    try
                    {
                        nodes = document.DocumentNode.SelectNodes("//*[@id='th_" + i + "']/td[" + j + "]").ToArray();
                        if (!String.IsNullOrEmpty(nodes[0].InnerText))
                        {
                            Console.WriteLine(nodes[0].InnerText);
                            s.Add(nodes[0].InnerText);
                        }
                    }
                    catch (Exception ex)
                    {
                        i = iMax;
                    }

                }
                i++;
            }
            int k = 0;
            while (k < s.Count / 3)
            {
                AutoList.Add(new Auto
                {
                    Name = s[k * 3],
                    Manufacturer = "Mersedes",
                    BodyType = s[k * 3 + 1],
                    Price = GetPrice(s[k * 3 + 2])
                });
                k++;
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