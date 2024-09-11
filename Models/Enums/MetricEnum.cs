using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfPocAPI.Models.Enums
{
    public enum MetricType
    {
        Undefined = 0,
        Counter = 1,
        Gauge = 2,
        Histogram = 3
    }

    public enum MetricOperationType
    {
        Undefined = 0,
        Increment = 1,
        Decrement = 2
    }
}
