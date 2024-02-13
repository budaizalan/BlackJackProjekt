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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Windows.Controls.Image;

namespace FeketeJanos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        Megoldas m = new Megoldas();

        int playerWin = 0;
        int machineWin = 0;
        

        bool endOfGame = false;
        Kartya[] selectedCards = new Kartya[4];
        List<Kartya> kartyak = new List<Kartya>();
        List<Kartya> MachineCards = new List<Kartya>();
        List<Kartya> PlayerCards = new List<Kartya>();
        public MainWindow()
        {
            InitializeComponent();
            InitializeCards();
            this.DataContext = m;
            m.chips += 100;
            Play();
        }

        private void InitializeCards()
        {
            for (int i = 1; i <= 52; i++)
            {
                Kartya k = new Kartya(i);
                kartyak.Add(k);

            }
        }

        private void Play()
        {
            PlayerCards.Clear();
            MachineCards.Clear();
            getRandomCard(MachineCards);
            displayCards();
            endOfGame = false;
            displayWinner("");

        }

        private void calcWinner()
        {
            endOfGame = true;
            int playerSum = 0;
            int machineSum = 0;
            bool machineHasAce = false;
            bool playerHasAce = false;
            int bet = int.Parse(betTxb.Text);
            foreach (Kartya k in PlayerCards)
            {
                playerSum += k.Value;
                if (k.Value == 1)
                {
                    playerHasAce = true;
                }
                
            }
            foreach (Kartya k in MachineCards)
            {
                machineSum += k.Value;
                if (k.Value == 1)
                {
                    machineHasAce = true;
                }
            }
            if (machineSum + 10 <= 21 && machineHasAce)
            {
                machineSum += 10;

            }
            if (playerSum + 10 <= 21 && playerHasAce)
            {
                playerSum += 10;
                
            }
            if (playerSum == machineSum) {
                displayWinner("Döntetlen");
                

            }

            if (playerSum <= 21 && (playerSum > machineSum || machineSum > 21))
            {
                playerWin += 1;
                displayWinner("Győztél");
                m.chips += bet;
                lblChipSzámláló.Content = $": {m.chips}";
            }
            else
            {
                machineWin += 1;
                displayWinner("Vesztettél");
                m.chips -= bet;
                lblChipSzámláló.Content = $": {m.chips}";

            }
            //lblCurrentNumber.Content = playerSum.ToString();
            betTxb.Text = "20";
            slValue.IsEnabled = true;
            betTxb.IsEnabled = true;
            if(m.chips < 0)
            {
                lblChipSzámláló.Content = ": núúla'";
            }

        }

        private void displayWinner(string msg)
        {
            lblEredmeny.Content = msg;
            lblOsztoWin.Content = $"Osztó győzelmei: {machineWin}";
            lblJatekosWin.Content = $"Játékos győzelmei: {playerWin}";
        }

        private void getRandomCard(List<Kartya> klist)
        {
            Random r = new Random();
            if (kartyak.Count < 4)
            {
                InitializeCards();
            }
            int kIndex = r.Next(0, kartyak.Count - 1);

            klist.Add(kartyak[kIndex]);
            kartyak.RemoveAt(kIndex);
        }

        private void displayCards()
        {
            //ImgLap1.Source = new ImageSourceConverter().ConvertFromString("Imgs/" + selectedCards[0].src) as ImageSource;
            SpPlayer.Children.Clear();
            foreach (Kartya k in PlayerCards)
            {
                Image Img = new Image();
                Img.Source = new ImageSourceConverter().ConvertFromString("Imgs/" + k.src) as ImageSource;
                Img.Width = 50;
                Img.Height = 110;
                Img.Margin = new Thickness(10, 0, 10, 0);

                Img.Stretch = Stretch.Uniform;
                SpPlayer.Children.Add(Img);

            }
            SpMachine.Children.Clear();
            foreach (Kartya k in MachineCards)
            {
                Image Img = new Image();
                Img.Source = new ImageSourceConverter().ConvertFromString("Imgs/" + k.src) as ImageSource;
                Img.Width = 50;
                Img.Height = 110;
                Img.Margin = new Thickness(10, 0, 10, 0);
                SpMachine.Children.Add(Img);

            }
        }



        private void MachinePlay()
        {
            int machineSum = 0;
            foreach (Kartya k in MachineCards)
            {
                machineSum += k.Value;
                lblMachineCurrentNumber.Content = machineSum.ToString();
            }
            if (machineSum < 17)
            {
                getRandomCard(MachineCards);
                displayCards();
                MachinePlay();
            }
            else
            {
                calcWinner();
            }
        }

        private void btnOsztas_Click(object sender, RoutedEventArgs e)
        {
            if (endOfGame)
            {
                return;
            }
            getRandomCard(PlayerCards);
            displayCards();
            checkIfLost();
            lblChipSzámláló.Content = $": {m.chips}";
            //lblCurrentNumber.Content = calcWinner().ToString();
            slValue.IsEnabled = false ;
            betTxb.IsEnabled = false ; 
        }

        private void checkIfLost()
        {
            int playerSum = 0;
            foreach (Kartya k in PlayerCards)
            {
                playerSum += k.Value;
            }
            if (playerSum > 21)
            {
                calcWinner();
            }
            lblCurrentNumber.Content = playerSum.ToString();
        }

        private void btnUjra_Click(object sender, RoutedEventArgs e)
        {
            if (!endOfGame)
            {
                return;
            }
            if (m.chips <= 0)
            {
                m.chips = 0;
                MessageBox.Show("Nincs több pízed");
                return;

            }
            lblCurrentNumber.Content = "";
            lblMachineCurrentNumber.Content = "";

            Play();
        }

        private void btnElég_Click(object sender, RoutedEventArgs e)
        {
            if (endOfGame || PlayerCards.Count < 2)
            {
                return;
            }

            MachinePlay();
            

        }

        private void imgChip_Click(object sender, RoutedEventArgs e)
        {
            Shop shop = new Shop(m);
            shop.Show();
        }
    }
}
