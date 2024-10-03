using System;
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

        public static string GetAPIUrl(MetricType metricType)
        {
            return MetricCatalogue.GetAPIUrl(metricType);
        }

        public static string GetAPIKey()
        {
            return MetricCatalogue.GetAPIKey();
        }
    }
}
