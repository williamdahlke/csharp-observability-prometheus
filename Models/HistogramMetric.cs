using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using wpfPocAPI.Models.Enums;

namespace wpfPocAPI.Models
{
    public class HistogramMetric : Metric
    {
        public long ElapsedTimeMs { get; set; }

        public HistogramMetric(string name, MetricType type, MetricOperationType operation) : base(name, type, operation)
        {
        }

        public HistogramMetric(string name, MetricType type, MetricOperationType operation, string[] labels) : base(name, type, operation, labels) 
        { 
        }
    }
}
