using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeketeJanos
{
    public class Megoldas : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string tulajdonsagNev)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(tulajdonsagNev));
        }

        private string _hatter = "background.png";

        public string hatter
        {
            get { return _hatter; }
            set { _hatter = value; OnPropertyChanged("hatter"); }
        }

        public Megoldas()
        {
            
        }
    }
}
