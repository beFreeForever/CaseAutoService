using CaseAutoService.Enumerations;
using CaseAutoService.Model.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseAutoService.Model
{
    /// <summary>
    /// Модель машины
    /// </summary>
    public class Auto
    {
        /// <summary>
        /// Название машины
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Производитель
        /// </summary>
        public string Manufacturer { get; set; }
        /// <summary>
        /// Цена
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// Кузов
        /// </summary>
        public string BodyType { get; set; }
    }
}
