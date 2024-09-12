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
        public ICommand UpdateAdvancedBomCommand { get; set; }
        public ICommand CheckinCommand { get; set; }
        public ICommand Generate3DCommand { get; set; }


        public MainVM()
        {
            Open();
            SaveProjectCommand = new DelegateCommand(SaveProject);
            UpdateAdvancedBomCommand = new DelegateCommand(UpdateAdvancedBOM);
            CheckinCommand = new DelegateCommand(Checkin);
            Generate3DCommand = new DelegateCommand(GenerateProject);
        }


        private void GenerateProject(object obj)
        {
            Services.Instance.GenerateProject();
        }

        private void Checkin(object obj)
        {
            Services.Instance.Checkin();
        }

        private void UpdateAdvancedBOM(object obj)
        {
            Services.Instance.UpdateAdvancedBOM();
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
