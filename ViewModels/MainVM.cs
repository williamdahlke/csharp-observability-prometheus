using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using wpfPocAPI.Controllers;
using wpfPocAPI.Interceptors;
using wpfPocAPI.Resources;
using wpfPocAPI.Service;

namespace wpfPocAPI.ViewModels
{
    public class MainVM : GenericPropertiesVM
    {
        public ICommand SaveProjectCommand { get; set; }


        public MainVM()
        {
            Open();
            SaveProjectCommand = new DelegateCommand(SaveProject);
        }

        [MetricInterceptor]
        private void Open()
        {            
        }

        private void SaveProject(object obj)
        {
            Services.Instance.SaveProject();
        }

        [MetricInterceptor]
        public async Task Shutdown()
        {
            
        }
    }
}
