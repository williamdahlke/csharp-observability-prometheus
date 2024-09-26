using wpfPocAPI.Models.Enums;
using wpfPocAPI.Resources;

namespace wpfPocAPI.Models
{
    public class Metric
    {
        public string MetricName { get; set; }
        public string Help { get; set; }
        public MetricType Type { get; set; }
        public Label Label { get; set; }

        public WegUser User
        {
            get
            {
                return new WegUser("jessicasilva", WegUnities.WTD_BNU.GetDescription());
            }
        }
    }
}
