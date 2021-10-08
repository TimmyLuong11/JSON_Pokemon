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
            PokemonName poke = (PokemonName)listBox.SelectedItem;

            using (var client = new HttpClient())
            {
                string jsonData = client.GetStringAsync(poke.url).Result;
                PokemonInfo poki = JsonConvert.DeserializeObject<PokemonInfo>(jsonData);
                imgBox.Source = new BitmapImage(new Uri(poki.sprites.front_default));
            }
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            PokemonName poke = (PokemonName)listBox.SelectedItem;

            using (var client = new HttpClient())
            {
                string jsonData = client.GetStringAsync(poke.url).Result;
                PokemonInfo poki = JsonConvert.DeserializeObject<PokemonInfo>(jsonData);
                imgBox.Source = new BitmapImage(new Uri(poki.sprites.back_default));
            }
        }

        private void listBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            PokemonName poke = (PokemonName)listBox.SelectedItem;
            
            using (var client = new HttpClient())
            {
                string jsonData = client.GetStringAsync(poke.url).Result;
                PokemonInfo poki = JsonConvert.DeserializeObject<PokemonInfo>(jsonData);
                imgBox.Source = new BitmapImage(new Uri(poki.sprites.front_default));
                txtBlockHeight.Text = poki.height;
                txtBlockWeight.Text = poki.weight;
            }
        }
    }
}
