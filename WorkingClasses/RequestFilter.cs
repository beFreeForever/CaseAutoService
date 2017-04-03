using CaseAutoService.Enumerations;
using CaseAutoService.Model;
using CaseAutoService.Model.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseAutoService.Working
{
    /// <summary>
    /// Фильтрует данные
    /// </summary>
    public static class RequestFilter
    {
        public static List<Auto> GetFilterRequest(List<Auto> AutoList, double MinPrice, double MaxPrice, string BodyType)
        {
            List<Auto> FilterListAuto = new List<Auto>();
            foreach (var Auto in AutoList)
            {
                if((Auto.Price >= MinPrice && Auto.Price <= MaxPrice) && 
                   Auto.BodyType == BodyType)
                {
                    FilterListAuto.Add(Auto);
                }
            }
            return FilterListAuto;
        }
    }
}
