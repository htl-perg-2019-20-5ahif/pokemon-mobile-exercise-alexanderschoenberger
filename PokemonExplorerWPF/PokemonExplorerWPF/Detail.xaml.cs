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
    public partial class Detail : Window, INotifyPropertyChanged
    {
        public PokemonDetail PokemonDetailValue;
        public PokemonDetail PokemonDetail { get => PokemonDetailValue; set { PokemonDetailValue = value; OnPropertyChanged(nameof(PokemonDetailValue)); } }
        public Detail(PokemonDetail pokemon)
        {
            this.PokemonDetail = pokemon;
            this.DataContext = this.PokemonDetail;
        }

        private void CloseWindow(object sender, EventArgs e)
        {
            NavigationService.GetNavigationService(this).GoBack();

            //       await Navigation.PopModalAsync();
        }
        private void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
