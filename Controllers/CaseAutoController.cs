using CaseAutoService.Enumerations;
using CaseAutoService.Model;
using CaseAutoService.Working;
using Microsoft.AspNetCore.Mvc;
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
            List<Auto> AutoListTemp = new List<Auto>();
            AutoListTemp.Add(new Auto
            {
                Name = "Nissan",
                BodyType = BodyTypeAuto,
                DriveUnit = "FourWheelDrive",
                Price = 3000,
                Manufacturer = ManufactererAuto,
                Power = 123123,
                LinkToCar = "vk.com"
            });
            //будут классы запросов
            // AutoList = RequestFilter.GetFilterRequest();
            return RedirectToAction("AnswerOfRequestAuto", "CaseAuto", new { AutoList = AutoListTemp });
        }

        public IActionResult AnswerOfRequestAuto(List<Auto> AutoList)
        {
            ViewBag.List = new List<Auto>(AutoList);
            return View();
        }
    }
}
