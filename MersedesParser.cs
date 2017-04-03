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
            List<Auto> AutoList = new List<Auto>();
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load("http://sales.mercedes-avilon.ru/special/goryachee-predlozhenie-table/?csref=avilon_volg:pkw:Mercedes:cpc:Google.Adwords&csref=avilon_volg:pkw:NEW:cpc:Google.Adwords&utm_source=Google.Adwords&utm_medium=cpc&utm_campaign=general_reg&utm_content=ST:g::S:::AP:::PT:1t1::P:1t1::DT:c::RI:1011981::RN:1011981::CI:743824508::GI:42576317487::PI:kwd-16822931::AI:189100468533::KW:mercedes&utm_term=mercedes&gclid=Cj0KEQjwwoLHBRDD0beVheu3lt0BEiQAvU4CKvwRMRFEZMO7i7YYpcleZ9JssEFKzmZeGcp9ZmQIZl8aAq9f8P8HAQ");
            for (int i = 1; i <= 120; i++)
            {
                for (int j = 1; j <= 6; j++)
                {
                    if (j == 5 || j == 4)
                    {
                        continue;
                    }
                    HtmlNode[] nodes = document.DocumentNode.SelectNodes("//*[@id='th_" + i + "']//td[" + j + "]").ToArray();
                    List<string> AutoTemp = new List<string>();
                    foreach(var item in nodes)
                    {
                        AutoTemp.Add(item.InnerText);
                    }
                    AutoList.Add(new Auto {
                        Name = AutoTemp[0],
                        Manufacturer = "Mersedes",
                        BodyType = AutoTemp[1],
                        Price = Double.Parse(AutoTemp[2])
                    });
                }
            }
            return AutoList;
        }
    }
}