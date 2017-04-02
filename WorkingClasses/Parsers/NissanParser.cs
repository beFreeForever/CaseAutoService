using CaseAutoService.Working;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaseAutoService.Model;
using HtmlAgilityPack;
using System.Net.Http;

namespace CaseAutoService.WorkingClasses.Parsers
{
    public class NissanParser : IRequestParser
    {
        public NissanParser()
        {
          
        }
        public List<Auto> GetData()
        {
            List<Auto> AutoList = new List<Auto>();
           

            //Console.WriteLine(document.ToHtml().ToString());
            return AutoList;
        }
    }
}
