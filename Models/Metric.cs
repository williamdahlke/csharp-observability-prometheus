using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfPocAPI.Models.Enums;

namespace wpfPocAPI.Models
{
    public class Metric
    {
        public Metric()
        {

        }

        public Metric(string name, MetricType type)
        {
            MetricName = name;
            Type = type;
        }

        public Metric(string name, MetricType type, string[] labels)
        {
            MetricName = name;
            Type = type;
            Labels = labels;
        }

        public string MetricName { get; private set; }
        public MetricType Type { get; private set; }
        public MetricOperationType Operation { get; set; }
        public string[] Labels { get; private set; }
    }
}
