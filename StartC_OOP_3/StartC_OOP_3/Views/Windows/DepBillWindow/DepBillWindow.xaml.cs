using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StartC_OOP_3.Views.Windows.DepBillWindow
{
    /// <summary>
    /// Логика взаимодействия для DepBillWindow.xaml
    /// </summary>
    public partial class DepBillWindow : Window
    {
        public DepBillWindow()
        {
            InitializeComponent();
        }

        private void BillWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.billText.Text = depTextBill.Text;
            MessageBox.Show("ClosingWindow");
        }

        private void HereButton_Click(object sender, RoutedEventArgs e)
        {
            int sums = int.Parse(depTextBill.Text) + int.Parse(depBillSums.Text);
            int minusSums = int.Parse(depBillSums.Text) - int.Parse(depBillSums.Text);
            depBillSums.Text = minusSums.ToString();
            depTextBill.Text = sums.ToString();
        }

        private void ThereButton_Click(object sender, RoutedEventArgs e)
        {
            if (DepBillBox.Text == "")
            {
                DepBillBox.Text = "0";
            }
            int sums = int.Parse(depTextBill.Text) - int.Parse(DepBillBox.Text);
            depTextBill.Text = sums.ToString();

            int minusSum = int.Parse(depBillSums.Text) + int.Parse(DepBillBox.Text);
            depBillSums.Text = minusSum.ToString();
        }

        private void Button_CloseClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Topup_Click(object sender, RoutedEventArgs e)
        {
            if (DepBillBox.Text == "")
            {
                DepBillBox.Text = "0";
            }
            int sums =  int.Parse(depTextBill.Text) + int.Parse(DepBillBox.Text); 
            depTextBill.Text = sums.ToString();
            attachmentBlock.Text = depTextBill.Text;
        }
    }
}
