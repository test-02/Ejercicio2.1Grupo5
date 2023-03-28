using MV2Rescountries.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace MV2Rescountries.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapView : ContentPage
    {

        Countries PaisSeleccionado;

        public MapView(Countries country)
        {
            PaisSeleccionado = country;
            InitializeComponent();
            loadConfiguration();
        }

        private void loadConfiguration()
        {

            var pin = new Pin()
            {
                Type = PinType.SavedPin,
                Position = new Position(PaisSeleccionado.latlng[0], PaisSeleccionado.latlng[1]),
                Label = PaisSeleccionado.NameCountry.official,
                Address = "Capital: "+PaisSeleccionado.capital


            };

            mapa.Pins.Add(pin);
            mapa.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(PaisSeleccionado.latlng[0], PaisSeleccionado.latlng[1]), Distance.FromKilometers(41)));
        }
    }
}