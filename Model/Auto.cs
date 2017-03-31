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
        public string Name;
        /// <summary>
        /// Производитель
        /// </summary>
        public Manufacturer Manufacturer;
        /// <summary>
        /// Цена
        /// </summary>
        public double Price;
        /// <summary>
        /// Мощность
        /// </summary>
        public double Power;
        /// <summary>
        /// Тип привода
        /// </summary>
        public DriveUnit DriveUnit;
        /// <summary>
        /// Кузов
        /// </summary>
        public BodyType BodyType;
        /// <summary>
        /// Ссылка на авто
        /// </summary>
        public string LinkToCar;
    }
}
