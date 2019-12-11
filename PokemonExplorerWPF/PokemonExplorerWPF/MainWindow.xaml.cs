using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
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


namespace PokemonExplorerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private readonly HttpClient Client = new HttpClient();
        public List<PokemonDetail> PokemonsValue;
        public List<PokemonDetail> PokemonDetailList { get => PokemonsValue; set { PokemonsValue = value; OnPropertyChanged(nameof(PokemonsValue)); } }

        public MainWindow()
        {
            InitializeComponent();
            getPokemons();
        }

        public async void getPokemons()
        {
            PokemonDetailList = new List<PokemonDetail>();
            var response = await Client.GetAsync("https://pokeapi.co/api/v2/pokemon/");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var PokemonList = JsonSerializer.Deserialize<Pokemons>(responseBody).Results;
            foreach (Pokemon pok in PokemonList)
            {
                var retDetail = await Client.GetAsync(pok.Url);
                retDetail.EnsureSuccessStatusCode();
                var retDetailBody = await retDetail.Content.ReadAsStringAsync();
                var PokemonDetail = JsonSerializer.Deserialize<PokemonDetail>(retDetailBody);
                PokemonDetailList.Add(PokemonDetail);

            }
            list.ItemsSource = PokemonDetailList;

        }
        private void OnItemSelected(object sender, MouseButtonEventArgs e)
        {
            ListViewItem list = sender as ListViewItem;
            PokemonDetail pokemon = list.DataContext as PokemonDetail;
            var detailPage = new Detail(pokemon);
            detailPage.Owner = this;
            detailPage.Show();
            //   await Navigation.PushModalAsync(detailPage);
        }
        private void OnPropertyChanged(string propertyName) =>
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
