using wpfPocAPI.Models.Enums;
using wpfPocAPI.Resources;

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
        public WegUser User
        {
            get
            {
                //return BaseCAT.CurrentUser.Name
                return new WegUser("jessicasilva", WegUnities.WTD_BNU.GetDescription());
            }
        }

    }
}
