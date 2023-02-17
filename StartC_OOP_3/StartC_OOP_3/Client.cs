using StartC_OOP_3.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StartC_OOP_3
{
    internal class Client : INotifyPropertyChanged
    {
        private string _Name;
        private string _Surname;
        private string _Patronymic;
        private string _NumberPhone;
        private string _Address;
        private string _Check;
        private int _Type;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Name
        {
            get { return _Name; }
            set
            {
                if (Equals(_Name, value)) return;
                _Name = value;
                OnPropertyChanged();
            }
        }

        public string Surname
        {
            get { return _Surname; }
            set
            {
                if (Equals(_Surname, value)) return;
                _Surname = value;
                OnPropertyChanged();
            }
        }

        public string Patronymic
        {
            get { return _Patronymic; }
            set
            {
                if (Equals(_Patronymic, value)) return;
                _Patronymic = value;
                OnPropertyChanged();
            }
        }

        public string NumberPhone
        {
            get { return _NumberPhone; }
            set
            {
                if (Equals(_NumberPhone, value)) return;
                _NumberPhone = value;
                OnPropertyChanged();
            }
        }

        public string Address
        {
            get { return _Address; }
            set
            {
                if (Equals(_Address, value)) return;
                _Address = value;
                OnPropertyChanged();
            }
        }

        public string Check
        {
            get { return _Check; }
            set
            {
                if (Equals(_Check, value)) return;
                _Check = value;
                OnPropertyChanged();
            }
        }

        public int Type
        {
            get { return _Type; }
            set
            {
                if (Equals(_Type, value)) return;
                _Type = value;
                OnPropertyChanged();
            }
        }

        public Client(string name, string surname, string patronymic, string numberPhone, string address, string check, int type)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            NumberPhone = numberPhone;
            Address = address;
            Check = check;
            Type = type;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            NumberPhone = numberPhone;
            Address = address;
            Check = check;
            Type = type;
        }
        
        //public ICollection<Client> Clients { get; set; }
    }

    internal class ClientCollection
    {
        public ICollection<Client> Cliented { get; set; }
    }
}
