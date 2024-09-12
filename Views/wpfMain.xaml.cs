using System.Threading.Tasks;
using System.Windows;
using wpfPocAPI.ViewModels;

namespace wpfPocAPI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainVM myVM = new MainVM();

        public MainWindow()
        {
            InitializeComponent();
            LoadViewContext();
        }

        private void LoadViewContext()
        {
            this.DataContext = myVM;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Task task = myVM.Shutdown();
            Application.Current.Shutdown();
        }
    }
}
