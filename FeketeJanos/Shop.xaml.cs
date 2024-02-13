using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FeketeJanos
{
    /// <summary>
    /// Interaction logic for Shop.xaml
    /// </summary>
    public partial class Shop : Window
    {
        Megoldas m = new Megoldas();

        public Shop(Megoldas m)
        {
            InitializeComponent();
            this.m = m;
            this.DataContext = this.m;
            Szamos();
        }
        string chips = ((MainWindow)Application.Current.MainWindow).lblChipSzámláló.Content.ToString();
        bool owned_blue = false;
        bool owned_black = false;

        public void Szamos()
        {
            h.Content = "Balance: " + m.chips;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            m.hatter = "background.png";
            Szamos();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (owned_blue)
            {
                m.hatter = "/Imgs/blue_background.jpg";

            }
            else
            {
                if (m.chips >= 50)
                {
                    m.hatter = "/Imgs/blue_background.jpg";
                    m.priceblue = "Owned";
                    owned_blue = true;
                    m.chips -= 50;
                }
                else
                {
                    m.priceblue = "Not enough chips";
                }
            }
            Szamos();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (owned_black)
            {
                m.hatter = "/Imgs/black_background.jpg";

            }
            else
            { 
                if (m.chips >= 50)
                {
                    m.hatter = "/Imgs/black_background.jpg";
                    m.priceblack = "Owned";
                    owned_black = true;
                    m.chips -= 50;
                }
                else
                {
                    m.priceblack = "Not enough chips";
                }
            }
            Szamos();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

        }
    }

}
