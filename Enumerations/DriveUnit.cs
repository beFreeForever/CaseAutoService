using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseAutoService.Model.Enumerations
{
    /// <summary>
    /// Тип привода
    /// </summary>
    public enum DriveUnit
    {
        /// <summary>
        /// Задний привод
        /// </summary>
        RearDrive,
        /// <summary>
        /// Передний привод
        /// </summary>
        FrontWheelDrive,
        /// <summary>
        /// Полный привод
        /// </summary>
        FourWheelDrive
    }
}
