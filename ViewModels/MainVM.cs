using System.Windows.Input;
using wpfPocAPI.Resources;
using wpfPocAPI.Service;

namespace wpfPocAPI.ViewModels
{
    public class MainVM : GenericPropertiesVM
    {
        public ICommand SaveProjectCommand { get; set; }

        public MainVM()
        {
            SaveProjectCommand = new DelegateCommand(SaveProject);
        }

        private void SaveProject(object obj)
        {
            Services.Instance.SaveProject();
        }
    }
}
