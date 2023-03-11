using StartC_OOP_3.ViewModels;
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
using System.Windows.Shapes;

namespace StartC_OOP_3.Views.Windows.BillWindow
{
    /// <summary>
    /// Логика взаимодействия для BillWindow.xaml
    /// </summary>
    public partial class BillWindow : Window
    {
        public BillWindow()
        {
            InitializeComponent();
        }

        private void BillWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.billText.Text = textBill.Text;
            MessageBox.Show("ClosingWindow");
        }
        
        private void HereButton_Click(object sender, RoutedEventArgs e) 
        {
            int sums = int.Parse(textBill.Text) + int.Parse(billSums.Text);
            int minusSums = int.Parse(billSums.Text) - int.Parse(billSums.Text);
            billSums.Text = minusSums.ToString();
            textBill.Text = sums.ToString();
        }

        private void ThereButton_Click(object sender, RoutedEventArgs e)
        {   
            if (billBox.Text == "") { billBox.Text = "0"; }

            bool result = Int32.TryParse(billBox.Text, out int val);
            if (result == true)
            {
                int sums = int.Parse(textBill.Text) - int.Parse(billBox.Text);
                textBill.Text = sums.ToString();

                int minusSum = int.Parse(billSums.Text) + int.Parse(billBox.Text);
                billSums.Text = minusSum.ToString();
            }
            else { MessageBox.Show("Неправильный ввод счёта", "Warning!", MessageBoxButton.OK, MessageBoxImage.Information); }
        }

        private void Button_CloseClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Topup_Click(object sender, RoutedEventArgs e)
        {
            if (billBox.Text == "") { billBox.Text = "0"; }
            bool result = Int32.TryParse(billBox.Text, out int val);

            if (result == true) 
            {
                int sums = int.Parse(textBill.Text) + int.Parse(billBox.Text);
                textBill.Text = sums.ToString();
            }
            else { MessageBox.Show("Неправильный ввод счёта", "Warning", MessageBoxButton.OK, MessageBoxImage.Information); }
        }
    }
}
