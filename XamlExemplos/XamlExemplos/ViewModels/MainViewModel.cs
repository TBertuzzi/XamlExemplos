using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace XamlExemplos.ViewModels
{
    public class MainViewModel:INotifyPropertyChanged
    {
        #region Property
      
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion

      

        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set { SetProperty(ref _nome, value); }
        }


        private DateTime _data;
        public DateTime Data
        {
            get { return _data; }
            set { SetProperty(ref _data, value); }
        }

        public MainViewModel()
        {
            Nome = "Bertuzzi";
            Data = DateTime.Now;
        }
    }
}
