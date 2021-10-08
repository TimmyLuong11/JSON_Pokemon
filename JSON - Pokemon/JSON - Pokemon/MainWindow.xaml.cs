using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace JSON___Pokemon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using (var client = new HttpClient())
            {
                string jsonData = client.GetStringAsync("https://pokeapi.co/api/v2/pokemon?offset=0&limit=1118").Result;
                PokemonAPI poki = JsonConvert.DeserializeObject<PokemonAPI>(jsonData);
                foreach (var item in poki.results)
                {
                    listBox.Items.Add(item);
                }
            }
        }

        private void buttonFront_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {

        }

        private void listBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            PokemonInfo pinfo = (PokemonInfo)listBox.SelectedItem;
            
            using (var client = new HttpClient())
            {
                string jsonData = client.GetStringAsync("").Result;
                PokemonAPI poki = JsonConvert.DeserializeObject<PokemonAPI>(jsonData);

            }
            txtBlockHeight.Text = pinfo.height;
            txtBlockWeight.Text = pinfo.weight;
        }
    }
}
