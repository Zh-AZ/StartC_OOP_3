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
using StartC_OOP_3.Views.Windows.DepBillWindow;

namespace StartC_OOP_3.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        public static ObservableCollection<Client<string>> Clients { get; set; }
        static BillWindow BillWindow;
        static DepBillWindow DepBillWindow;
        public static string Value { get; set; } = "0";
        public static string DepValue { get; set; } = "0";
        public static string ClientCount { get; set; }
        private MainWindow MainWindow;

        public void OnViewInitialized(MainWindow mainWindow)
        {
            MainWindow = mainWindow;
        }

        private static Client<string> _Selected;
        public Client<string> Selected
        {
            get => _Selected;
            set => Set(ref _Selected, value);
        }

        #region Команды
        /// <summary>
        /// Закрытие главного окна
        /// </summary>
        public ICommand CloseApplicationCommand { get; }
        private bool CanCloseApplicationCommandExecute(object p) => true;
        private void OnCloseApplicationCommandExecute(object p)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Создание дочернего окна с депозитным счётом  
        /// </summary>
        public ICommand TransferDepCommand { get; }
        private bool CanTransferDepCommandExecute(object p) => p is Client<string> client && client.DepBill != "Закрытый";
        private void OnTransferDepCommandExecute(object p)
        {
            DepBillWindow = new DepBillWindow();
            DepBillWindow.Owner = Application.Current.MainWindow;
            DepBillWindow.depTextBill.Text = Selected.DepBill;
            if (DepBillWindow.depTextBill.Text != "0")
            {
                Random rnd = new Random();
                int rndSums = rnd.Next(1, 13);
                int sume = int.Parse(DepBillWindow.depTextBill.Text) - rndSums;
                DepBillWindow.attachmentBlock.Text = sume.ToString();
                DepBillWindow.passedMonthBlock.Text = rndSums.ToString();
            }
            DepBillWindow.ShowDialog();
        }

        /// <summary>
        /// Создание дочернего окна с недепозитным счётом
        /// </summary>
        public ICommand TransferCommand { get; }
        private bool CanTransferCommandExecute(object p) => p is Client<string> client && client.Check != "Закрытый";
        private void OnTransferCommandExecute(object p)
        {
            BillWindow = new BillWindow();
            BillWindow.Owner = Application.Current.MainWindow;
            BillWindow.textBill.Text = Selected.Check;
            BillWindow.ShowDialog();
        }

        /// <summary>
        /// Открытие счёта с нуля
        /// </summary>
        public ICommand OpenBillCommand { get; }
        private bool CanOpenBillCommandExecute(object p) => p is Client<string> client && client.Check == "Закрытый";
        private void OnOpenBillCommandExecute(object p)
        {
            Selected.Check = 0.ToString();
        }

        /// <summary>
        /// Закрытие счёта с обнулением
        /// </summary>
        public ICommand CloseBillCommand { get; }
        private bool CanCloseBillCommandExecute(object p) => p is Client<string> client && client.Check != "Закрытый";
        private void OnCloseBillCommandExecute(object p)
        {
            if (Selected.Check != 0.ToString())
            {
                MessageBoxResult result = MessageBox.Show("Внимание счёт будет обнулён! Вы уверены что хотите закрыть счёт?", "Warning!", MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.Cancel);
                if (result == MessageBoxResult.OK) { Selected.Check = "Закрытый"; }
            }
            else { Selected.Check = "Закрытый"; }
        }

        /// <summary>
        /// Открытие депозитного счёта с нуля
        /// </summary>
        public ICommand OpenDepBillCommmand { get; }
        private bool CanOpenDepBillCommandExecute(object p) => p is Client<string> client && client.DepBill == "Закрытый";
        private void OnOpenDepBillCommmandExecute(object p)
        {
            Selected.DepBill = 0.ToString();
        }

        /// <summary>
        /// Закрытие депозитного счёта с обулением
        /// </summary>
        public ICommand CloseDepBillCommand { get; }
        private bool CanCloseDepBillCommandExecute(object p) => p is Client<string> client && client.DepBill != "Закрытый";
        private void OnCloseDepBillCommandExecute(object p)
        {
            if (Selected.DepBill != 0.ToString())
            {
                MessageBoxResult result = MessageBox.Show("Внимание депозитный счёт будет обнулён! Вы уверены что хотите закрыть депозитный счёт?", "Warning!", MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.Cancel);
                if (result == MessageBoxResult.OK) { Selected.DepBill = "Закрытый"; }
            }
            else { Selected.DepBill = "Закрытый"; }
        }

        /// <summary>
        /// Закрытие дочернего окна с депозитным счётом
        /// </summary>
        public ICommand ClosingDepBillWindowCommand { get; }
        private bool CanClosingDepBillWindowExecute(object p) => true;
        private void OnClosingDepBillWindowExecute(object p)
        {
            DepValue = DepBillWindow.depBillSums.Text;
            _Selected.DepBill = DepBillWindow.depTextBill.Text;
        }
        
        /// <summary>
        /// Закрытие дочернего окна с недерозитным счётом
        /// </summary>
        public ICommand ClosingBillWindowCommand { get; }
        private bool CanClosingCommandExecute(object p) => true;
        private void OnClosingCommandExecute(object p)
        {   
            Value = BillWindow.billSums.Text;
            _Selected.Check = BillWindow.textBill.Text;
        }
        #endregion

        public MainWindowViewModel()
        {
            OpenBillCommand = new LambdaCommand(OnOpenBillCommandExecute, CanOpenBillCommandExecute);
            CloseBillCommand = new LambdaCommand(OnCloseBillCommandExecute, CanCloseBillCommandExecute);
            OpenDepBillCommmand = new LambdaCommand(OnOpenDepBillCommmandExecute, CanOpenDepBillCommandExecute);
            CloseDepBillCommand = new LambdaCommand(OnCloseDepBillCommandExecute, CanCloseDepBillCommandExecute);
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecute, CanCloseApplicationCommandExecute);
            ClosingBillWindowCommand = new LambdaCommand(OnClosingCommandExecute, CanClosingCommandExecute);
            ClosingDepBillWindowCommand = new LambdaCommand(OnClosingDepBillWindowExecute, CanClosingDepBillWindowExecute);
            TransferCommand = new LambdaCommand(OnTransferCommandExecute, CanTransferCommandExecute);
            TransferDepCommand = new LambdaCommand(OnTransferDepCommandExecute, CanTransferDepCommandExecute);
            
            Clients = new ObservableCollection<Client<string>>();

            StateBill();
        }

        /// <summary>
        /// Рандомное создание клиентов c состоянием счёта
        /// </summary>
        void StateBill()
        {
            Random random = new Random();
            Random rand = new Random();
            Random r = new Random();

            string type;
            bool randomBool;
            int randValue;
            int value = random.Next(10, 11);

            string depType;
            int depRandValue;
            bool depRandBool;
            
            for (int i = 0; i < value; i++)
            {   
                randomBool = r.Next(2) == 1;
                depRandBool = r.Next(2) == 1;

                randValue = rand.Next(100, 10001);
                depRandValue = rand.Next(100, 201);

                if (depRandBool == true) { depType = depRandValue.ToString(); }
                else { depType = "Закрытый"; }

                if (randomBool == true) { type = randValue.ToString(); }
                else { type = "Закрытый"; }

                Clients.Add(new Client<string>(Faker.Name.First(), Faker.Name.Middle(), Faker.Name.Last(),
                Faker.Phone.Number(), Faker.Address.StreetAddress(), type, depType));

                ClientCount = $"Клиентов ({Clients.Count})";
            }
        }
    }
}
