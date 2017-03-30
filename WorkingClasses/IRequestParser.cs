using CaseAutoService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseAutoService.Working
{
    interface IRequestParser
    {
        /// <summary>
        /// Метод где происходит парсинг
        /// </summary>
        List<Auto> GetData();
    }
}
