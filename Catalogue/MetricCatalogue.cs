using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfPocAPI.Models;
using wpfPocAPI.Models.Enums;
using wpfPocAPI.Resources;

namespace wpfPocAPI.Catalogue
{
    public static class MetricCatalogue
    {
        private static Dictionary<string, Metric> _metricsDictionary = new Dictionary<string, Metric>();
        private const string API_URL = @"http://localhost:3031/api/metrics/";
        private const string API_URI_GAUGE = API_URL + "insert/gauge";
        private const string API_URI_HISTOGRAM = API_URL + "insert/histogram";
        private static readonly string API_KEY = ConfigurationManager.AppSettings["API_METRICS"];

        static MetricCatalogue()
        {
            _metricsDictionary.Add("wpfPocAPI.ViewModels.MainVM.Shutdown", CreateUsersOnlineMetric(MetricOperationType.Decrement));
            _metricsDictionary.Add("wpfPocAPI.ViewModels.MainVM.Open", CreateUsersOnlineMetric(MetricOperationType.Increment));
            _metricsDictionary.Add("wpfPocAPI.Service.Services.UpdateAdvancedBOM", CreateTimeIntegrationSAPMetric("AdvancedBOM".Split()));
            _metricsDictionary.Add("wpfPocAPI.Service.Services.Checkin", CreateTimeIntegrationSAPMetric("Checkin".Split()));

            HistogramMetric timeToGenerateProject = new HistogramMetric()
            {
                MetricName = "cm_tempo_gerarproj_minutos",
                Help = "Tempo em minutos que o CM leva para gerar o projeto",
                Type = MetricType.Histogram,
                Buckets = getBucketTimeToGenerateProject()
            };
            _metricsDictionary.Add("wpfPocAPI.Service.Services.GenerateProject", timeToGenerateProject);
        }

        private static HistogramMetric CreateTimeIntegrationSAPMetric(string[] labelValues)
        {
            return new HistogramMetric()
            {
                MetricName = "gis_tempo_op_sap_segundos",
                Help = "Tempo em segundos que o GIS levou para realizar as integrações com o SAP",
                Type = MetricType.Histogram,
                Label = new Label() { LabelNames = "operation".Split(), LabelValues = labelValues},
                Buckets = new int[] { 100, 300, 500, 800, 1000, 3000, 5000, 8000, 10000 }
            };
        }

        private static GaugeMetric CreateUsersOnlineMetric(MetricOperationType operation)
        {
            return new GaugeMetric()
            {
                MetricName = "gis_usuarios_online_total",
                Help = "Número de usuários logados no momento",
                Type = MetricType.Gauge,
                Operation = operation,
                Label = new Label() { LabelNames = "unity".Split(), LabelValues = WegUnities.WTD_BNU.GetDescription().Split() }
            };
        }

        public static Metric GetMetricByName(string name)
        {
            Metric metric = new Metric();
            _metricsDictionary.TryGetValue(name, out metric);
            return metric;
        }

        private static int[] getBucketTimeToGenerateProject()
        {
            return getArrayConvertedMinutesToMs(new int[10] {15, 20, 25, 30, 35, 40, 45, 50, 55, 60});                                   
        }

        private static int[] getArrayConvertedMinutesToMs(int[] minutes)
        {
            int[] timesInMs = new int[minutes.Length];

            for (int i = 0; i < minutes.Length; i++) 
            {
                timesInMs[i] = minutes[i] * 60000;
            }

            return timesInMs;
        }

        public static string GetAPIUrl(MetricType metricType)
        {
            switch (metricType) 
            { 
                case MetricType.Gauge:
                    return API_URI_GAUGE;
                case MetricType.Histogram: 
                    return API_URI_HISTOGRAM;
                default:
                    return API_URL;
            }
        }

        public static string GetAPIKey()
        {
            return API_KEY;
        }
    }
}
