using StartC_OOP_3.ViewModels;
using StartC_OOP_3.Views.Windows.BillWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StartC_OOP_3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //var viewModel = new MainWindowViewModel();
            //BillWindow billWindow = new BillWindow();
            //billWindow.DataContext = viewModel;
            //billWindow.Show();
            InitializeComponent();
            //DataContext = viewModel;
        }
    }
}
