using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CaseAutoService.Working;
using CaseAutoService.WorkingClasses.Parsers;

namespace CaseAutoService.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult About()
        {
            ViewData["Message"] = "Select the car of interest in the desired range.";
            IRequestParser Parser = new NissanParser();
            Console.WriteLine(Parser.GetData());
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
