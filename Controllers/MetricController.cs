using System.Collections.Generic;
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
            _metricsDictionary.Add("wpfPocAPI.Service.Services.SaveProject", new HistogramMetric("gis_tempo_salvarproj_segundos", MetricType.Histogram, MetricOperationType.Timer));
            
            _metricsDictionary.Add("wpfPocAPI.Service.Services.GenerateProject", new HistogramMetric("cm_tempo_gerarproj_minutos", MetricType.Histogram, MetricOperationType.Timer));
            _metricsDictionary.Add("wpfPocAPI.Service.Services.UpdateAdvancedBOM", new HistogramMetric("gis_tempo_op_sap_segundos", MetricType.Histogram, MetricOperationType.Timer, "AdvancedBOM".Split()));
            _metricsDictionary.Add("wpfPocAPI.Service.Services.Checkin", new HistogramMetric("gis_tempo_op_sap_segundos", MetricType.Histogram, MetricOperationType.Timer, "Checkin".Split()));
        }

        internal static Metric GetMetricByName(string name)
        {
            Metric metric = new Metric();
            _metricsDictionary.TryGetValue(name, out metric);
            return metric;
        }
    }
}
