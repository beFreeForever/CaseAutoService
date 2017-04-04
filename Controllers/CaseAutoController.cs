using CaseAutoService.Model;
using CaseAutoService.Working;
using CaseAutoService.WorkingClasses.Parsers;
using Microsoft.AspNetCore.Mvc;
using SelectAutoServise.WorkingClasses.Parsers;
using System.Collections.Generic;

namespace CaseAutoService.Controllers
{
    public class CaseAutoController : Controller
    {
        [HttpGet]
        public IActionResult SelectAuto()
        {
            return View();
        }
        /// <summary>
        /// Берет данные с формы и посылает запрос
        /// </summary>
        /// <param name="ManufactererAuto"></param>
        /// <param name="BodyTypeAuto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SelectAuto(string ManufactererAuto)
        {
            return RedirectToAction("AnswerOfRequestAuto", "CaseAuto", new { ManufactererAuto = ManufactererAuto });
        }

        public IActionResult AnswerOfRequestAuto(string ManufactererAuto)
        {
            switch (ManufactererAuto)
            {
                case "Mersedes":
                    {
                        IRequestParser Parser = new MercedesParser();
                        ViewBag.List = new List<Auto>(Parser.GetData());
                        break;
                    }                   
                case "Nissan":
                    {
                        IRequestParser Parser = new NissanParser();
                        ViewBag.List = new List<Auto>(Parser.GetData());
                        break;
                    }
                case "BMW":
                    {
                        IRequestParser Parser = new BMWParser();
                        ViewBag.List = new List<Auto>(Parser.GetData());
                        break;
                    }
            }         
            return View();
        }
    }
}
