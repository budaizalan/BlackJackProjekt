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

        private int _chips = 0;

        public int chips
        {
            get { return _chips; }
            set { _chips = value; OnPropertyChanged("chips"); }
        }

        private string _priceblue = "150";

        public string priceblue
        {
            get { return _priceblue; }
            set { _priceblue = value; OnPropertyChanged("priceblue"); }
        }

        private string _priceblack = "50";

        public string priceblack
        {
            get { return _priceblack; }
            set { _priceblack = value; OnPropertyChanged("priceblack"); }
        }

        public Megoldas()
        {
            
        }
    }
}
