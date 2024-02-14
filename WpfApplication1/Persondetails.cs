using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApplication1
{
    public class Persondetails : INotifyPropertyChanged
    {
        private string _firstname = "Bob";
        private string _lastname = "Smith";

        public string FirstName
        {
            get { return _firstname;}
            set
            {
                _firstname = value;
                OnPropertyChanged("FullName");
            }
        }
        
        public string LastName
        {
            get { return _lastname;}
            set
            {
                _lastname = value;
                OnPropertyChanged("FullName");
            }
        }

        public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }

        /*public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }*/
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}