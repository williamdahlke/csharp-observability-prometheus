using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfPocAPI.Models;

namespace wpfPocAPI.Controllers
{
    internal static class MetricController
    {
        private static Dictionary<string, Metric> _metricsDictionary = new Dictionary<string, Metric>();

        static MetricController()
        {
            _metricsDictionary.Add("wpfPocAPI.Service.Services.SaveProject", new Metric("gis_usuarios_online_total", Models.Enums.MetricType.Gauge));
        }

        internal static Metric GetMetricByName(string name)
        {
            Metric metric = new Metric();
            _metricsDictionary.TryGetValue(name, out metric);
            return metric;
        }
    }
}
