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
            Szamos();
        }

        public void Szamos()
        {
            string chips = ((MainWindow)Application.Current.MainWindow).lblChipSzámláló.Content.ToString();
            h.Content = "Balance" + chips;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            m.hatter = "1.png";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

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
