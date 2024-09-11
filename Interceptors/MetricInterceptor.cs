using AspectInjector.Broker;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using wpfPocAPI.Controllers;
using wpfPocAPI.Models;

namespace wpfPocAPI.Interceptors
{
    [Aspect(Scope.Global)]
    [Injection(typeof(MetricInterceptor))]
    public class MetricInterceptor : Attribute
    {
        const string API_URL = @"http://localhost:3031/api/metrics/insert";

        /// <summary>
        /// If the parameter returnObj come null, it's because the method has a void return
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="returnObj"></param>
        [Advice(Kind.After, Targets = Target.Method)]
        public void OnExit([Argument(Source.Name)] string name, [Argument(Source.Type)] Type type)
        {
            string fullFileName = type.FullName + "." + name;
            try
            {
                SetMetricOnPrometheus(MetricController.GetMetricByName(fullFileName));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetMetricOnPrometheus(Metric metric)
        {
            Task.Run(() => PostJsonAsync(API_URL, metric));
        }

        private static async Task PostJsonAsync(string url, object data)
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
    }
}
