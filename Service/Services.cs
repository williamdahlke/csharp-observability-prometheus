using System.Windows;
using wpfPocAPI.Interceptors;

namespace wpfPocAPI.Service
{
    internal class Services
    {
        internal Services()
        {
        }

        private static Services _instance;
        internal static Services Instance 
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

        [MetricInterceptor]
        internal void SaveProject()
        {
            MessageBox.Show("Entrou no método SaveProject da classe Services");
        }
    }
}
