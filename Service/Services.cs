using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using wpfPocAPI.Controllers;
using wpfPocAPI.Interceptors;

namespace wpfPocAPI.Service
{
    public class Services
    {
        public Services()
        {
            MetricController = new MetricController();
        }

        private static Services _instance;
        public static Services Instance 
        { 
            get
            {
                if (_instance == null)
                {
                    _instance = new Services();
                }                
                return _instance;
            }
        }

        public MetricController MetricController { get; set; }

        [MetricInterceptor]
        public void SaveProject()
        {
            MessageBox.Show("Entrou no método SaveProject da classe Services");
        }

        public async Task PostJsonAsync(string url, object data)
        {
            using (var client = new HttpClient())
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(url, content);

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Request failed with status code: {response.StatusCode}");
                }
            }
        }

        [MetricInterceptor]
        public void UpdateAdvancedBOM()
        {
            MessageBox.Show("Uploading advanced BOM on SAP...");
        }

        [MetricInterceptor]
        public void Checkin()
        {
            MessageBox.Show("Check-in document on SAP...");            
        }

        [MetricInterceptor]
        public void GenerateProject()
        {
            MessageBox.Show("Generating project...");
        }
    }
}
