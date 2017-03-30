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
        string Name;
        /// <summary>
        /// Производитель
        /// </summary>
        Manufacturer Manufacturer;
        /// <summary>
        /// Цена
        /// </summary>
        double Price;
        /// <summary>
        /// Мощность
        /// </summary>
        double Power;
        /// <summary>
        /// Тип привода
        /// </summary>
        DriveUnit DriveUnit;
        /// <summary>
        /// Кузов
        /// </summary>
        BodyType BodyType;
    }
}
