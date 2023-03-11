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
    internal class Client<T> : INotifyPropertyChanged
        where T : class
    {
        private T _Name;
        private T _Surname;
        private T _Patronymic;
        private T _NumberPhone;
        private T _Address;
        private T _Check;
        private T _DepBill;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public T Name
        {
            get { return _Name; }
            set
            {
                if (Equals(_Name, value)) return;
                _Name = value;
                OnPropertyChanged();
            }
        }

        public T Surname
        {
            get { return _Surname; }
            set
            {
                if (Equals(_Surname, value)) return;
                _Surname = value;
                OnPropertyChanged();
            }
        }

        public T Patronymic
        {
            get { return _Patronymic; }
            set
            {
                if (Equals(_Patronymic, value)) return;
                _Patronymic = value;
                OnPropertyChanged();
            }
        }

        public T NumberPhone
        {
            get { return _NumberPhone; }
            set
            {
                if (Equals(_NumberPhone, value)) return;
                _NumberPhone = value;
                OnPropertyChanged();
            }
        }

        public T Address
        {
            get { return _Address; }
            set
            {
                if (Equals(_Address, value)) return;
                _Address = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Недепозитный счёт
        /// </summary>
        public T Check
        {
            get { return _Check; }
            set
            {
                if (Equals(_Check, value)) return;
                _Check = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Депозитный счёт
        /// </summary>
        public T DepBill
        {
            get { return _DepBill; }
            set
            {
                if (Equals(_DepBill, value)) return;
                _DepBill = value;
                OnPropertyChanged();
            }
        }

        public Client(T name, T surname, T patronymic, T numberPhone, T address, T check, T depBill)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            NumberPhone = numberPhone;
            Address = address;
            Check = check;
            DepBill = depBill;
        }
    }
}
