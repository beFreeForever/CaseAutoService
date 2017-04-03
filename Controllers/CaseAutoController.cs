using CaseAutoService.Enumerations;
using CaseAutoService.Model;
using CaseAutoService.Working;
using CaseAutoService.WorkingClasses.Parsers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using SelectAutoServise.WorkingClasses.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        /// <param name="MinPrice">Минимальная цена</param>
        /// <param name="MaxPrice">Максимальная цена</param>
        /// <param name="MinPower">Минимальная мощность</param>
        /// <param name="MaxPower">Максимальная мощность</param>
        /// <param name="ManufactererAuto">Производитель</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SelectAuto(string ManufactererAuto, string BodyTypeAuto)
        {
            return RedirectToAction("AnswerOfRequestAuto", "CaseAuto", new { ManufactererAuto = ManufactererAuto, BodyTypeAuto = BodyTypeAuto });
        }

        public IActionResult AnswerOfRequestAuto(string ManufactererAuto, string BodyTypeAuto)
        {
            //ViewBag.List = new List<Auto>(AutoList);
            //ViewBag.List = new List<Auto>();
            switch (ManufactererAuto)
            {
                case "Mersedes":
                    {
                        IRequestParser Parser = new MersedesParser();
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
