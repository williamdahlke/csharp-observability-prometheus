using System.Collections.Generic;
using wpfPocAPI.Catalogue;
using wpfPocAPI.Models;
using wpfPocAPI.Models.Enums;
using wpfPocAPI.Resources;

namespace wpfPocAPI.Controllers
{
    public class MetricController
    {
        public static Metric GetMetricByName(string name)
        {
            return MetricCatalogue.GetMetricByName(name);
        }
    }
}
