using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfPocAPI.Models.Enums;

namespace wpfPocAPI.Models
{
    public class GaugeMetric : Metric
    {
        public MetricOperationType Operation { get; set; }
    }
}
