using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfPocAPI.Models;
using wpfPocAPI.Models.Enums;
using wpfPocAPI.Resources;

namespace wpfPocAPI.Controllers
{
    internal static class MetricController
    {
        private static Dictionary<string, Metric> _metricsDictionary = new Dictionary<string, Metric>();

        static MetricController()
        {
            _metricsDictionary.Add("wpfPocAPI.ViewModels.MainVM.Shutdown", new Metric("gis_usuarios_online_total", MetricType.Gauge, MetricOperationType.Decrement, WegUnities.WTD_BNU.GetDescription().Split()));
            _metricsDictionary.Add("wpfPocAPI.ViewModels.MainVM.Open", new Metric("gis_usuarios_online_total", MetricType.Gauge, MetricOperationType.Increment, WegUnities.WTD_BNU.GetDescription().Split()));
            _metricsDictionary.Add("wpfPocAPI.Service.Services.SaveProject", new HistogramMetric("gis_tempo_salvarproj_ms", MetricType.Histogram, MetricOperationType.Timer));
        }

        internal static Metric GetMetricByName(string name)
        {
            Metric metric = new Metric();
            _metricsDictionary.TryGetValue(name, out metric);
            return metric;
        }
    }
}
