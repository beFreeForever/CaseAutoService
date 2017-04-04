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
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}
