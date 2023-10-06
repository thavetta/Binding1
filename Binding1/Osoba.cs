using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Binding1
{
    public class Osoba : INotifyPropertyChanged
    {
        private string jmeno;

        public string Jmeno
        {
            get => jmeno;
            set
            {
                if (jmeno == value)
                    return;
                jmeno = value;
                OnPropertyChanged(nameof(Jmeno));
                OnPropertyChanged(nameof(KompletJmeno));
            }
        }

        private string prijmeni;

        public string Prijmeni
        {
            get => prijmeni;
            set
            {
                if (value == prijmeni)
                    return;
                prijmeni = value;
                OnPropertyChanged(nameof(Prijmeni));
                OnPropertyChanged(nameof(KompletJmeno));
            }
        }

        private string mesto;

        public string Mesto
        {
            get => mesto;
            set
            {
                if (value == mesto)
                    return;
                mesto = value;
                OnPropertyChanged(nameof(Mesto));
            }
        }

        private int plat;

        public int Plat
        {
            get => plat;
            set
            {
                if (value == plat)
                    return;
                plat = value;
                OnPropertyChanged(nameof(Plat));
            }
        }
        
        public string KompletJmeno => Jmeno + " " + Prijmeni;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
