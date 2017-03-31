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
        public IActionResult CaseAuto()
        {
            return View();
        }
        /// <summary>
        /// Берет данные с формы и посылает запрос
        /// </summary>
        /// <param name="MinPrice">Минимальная цена</param>
        /// <param name="MaxPrice">Максимальная</param>
        /// <param name="ManufactererAuto">Производитель</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CaseAuto(double MinPrice, double MaxPrice, string ManufactererAuto)
        {
            return View();
        }
    }
}
