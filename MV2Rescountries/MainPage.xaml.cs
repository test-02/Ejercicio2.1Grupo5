using MV2Rescountries.Controller;
using MV2Rescountries.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MV2Rescountries.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {

        RestApi countriesApi;
        List<Countries> listCountries;

        public MainPage()
        {
            InitializeComponent();
            countriesApi = new RestApi();
            listCountries = new List<Countries>();
        }

        private async void cmbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            var region = cmbRegion.SelectedItem as string;

            var internetAccess = Connectivity.NetworkAccess;
            if (internetAccess == NetworkAccess.Internet)
            {
                listCountries = await countriesApi.GetCountries(region);
                ListCountries.ItemsSource = listCountries;
                
            }
            else
            {
                await DisplayAlert("Error", "Verifica que tengas acceso a internet", "OK");
            }
        }

        private async void ListCountries_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var country = (Countries) e.Item;
            MapView pageDetailCountry = new MapView(country);
            pageDetailCountry.BindingContext = country;
            await Navigation.PushAsync(pageDetailCountry);
        }
    }
}