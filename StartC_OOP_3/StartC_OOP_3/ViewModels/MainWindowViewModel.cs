using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using StartC_OOP_3.Infrastructure.Commands;
using StartC_OOP_3.ViewModels.Base;
using StartC_OOP_3.Views.Windows.BillWindow;

namespace StartC_OOP_3.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        public static ObservableCollection<Client> Clients { get; set; }
        
        private Client _Selected;
        public Client Selected
        {
            get => _Selected;
            set => Set(ref _Selected, value);
        }

        public ICommand CloseApplicationCommand { get; }
        private bool CanCloseApplicationCommandExecute(object p) => true;
        private void OnCloseApplicationCommandExecute(object p)
        {
            Application.Current.Shutdown();
        }
        
        public ICommand TransferCommand { get; }
        private bool CanTransferCommandExecute(object p) => p is Client client && client.Check != "Закрытый";
        private void OnTransferCommandExecute(object p)
        {
            BillWindow BillWindow = new BillWindow();
            BillWindow.Owner = Application.Current.MainWindow;
            BillWindow.textBill.Text = Selected.Check;
            BillWindow.ShowDialog();
        }

        public ICommand OpenBillCommand { get; }
        private bool CanOpenBillCommandExecute(object p) => p is Client client && client.Check == "Закрытый";
        private void OnOpenBillCommandExecute(object p)
        {
            Selected.Check = 0.ToString();
        }

        public ICommand CloseBillCommand { get; }
        private bool CanCloseBillCommandExecute(object p) => p is Client client && client.Check != "Закрытый";
        private void OnCloseBillCommandExecute(object p)
        {
            if (Selected.Check != 0.ToString())
            {
                MessageBoxResult result = MessageBox.Show("Внимание счёт будет обнулён! Вы уверены что хотите закрыть счёт?", "Warning!", MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.Cancel);
                if (result == MessageBoxResult.OK) { Selected.Check = "Закрытый"; }
            }
            else { Selected.Check = "Закрытый"; }
        }

        public ICommand ClosingBillWindowCommand { get; }
        private bool CanClosingCommandExecute(object p) => true;
        private void OnClosingCommandExecute(object p)
        {
            Selected.Check = "123"; //Вызывает ошибку. BillWindow не имеет этого свойства, но ведь MainWindow еще не закрыт. Как может быть null?
        }

        public MainWindowViewModel()
        {
            OpenBillCommand = new LambdaCommand(OnOpenBillCommandExecute, CanOpenBillCommandExecute);
            CloseBillCommand = new LambdaCommand(OnCloseBillCommandExecute, CanCloseBillCommandExecute);
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecute, CanCloseApplicationCommandExecute);
            ClosingBillWindowCommand = new LambdaCommand(OnClosingCommandExecute, CanClosingCommandExecute);
            TransferCommand = new LambdaCommand(OnTransferCommandExecute, CanTransferCommandExecute);

            Clients = new ObservableCollection<Client>();

            Random random = new Random();
            Random rand = new Random();
            Random r = new Random();

            string type;
            bool randomBool;
            int randValue;
            int value = random.Next(10, 11);

            for (int i = 0; i < value; i++)
            {
                randomBool = r.Next(2) == 1;
                randValue = rand.Next(100, 10001);
                if (randomBool == true)
                {
                    type = randValue.ToString();
                }
                else { type = "Закрытый"; }

                Clients.Add(new Client(Faker.Name.First(), Faker.Name.Middle(), Faker.Name.Last(),
                Faker.Phone.Number(), Faker.Address.StreetAddress(), type, 0));
            }
        }
    }
}
