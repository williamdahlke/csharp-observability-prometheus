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

        public Metric(string name, MetricType type, MetricOperationType operation)
        {
            MetricName = name;
            Type = type;
            Operation = operation;
        }

        public Metric(string name, MetricType type, MetricOperationType operation, string[] labels)
        {
            MetricName = name;
            Type = type;
            Labels = labels;
            Operation = operation;
        }

        public string MetricName { get; private set; }
        public MetricType Type { get; private set; }
        public MetricOperationType Operation { get; set; }
        public string[] Labels { get; private set; }
    }
}
