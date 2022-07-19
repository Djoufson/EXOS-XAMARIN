using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Images
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GaleryPage : ContentPage
    {
        private int indicator;
        private string[] uriSources;
        private string uriSource;
        public string UriSource
        {
            get => uriSource;
            set
            {
                uriSource = value;
                OnPropertyChanged();
            }
        }

        public GaleryPage()
        {
            BindingContext = this;
            indicator = 0;
            uriSources = new string[] { "https://cdn.wallpapersafari.com/31/22/DGBpWh.jpg",
                "https://i.pinimg.com/originals/2e/c6/b5/2ec6b5e14fe0cba0cb0aa5d2caeeccc6.jpg",
                "https://i.pinimg.com/originals/61/25/59/6125595537c8fb5fc9c7e6cb256155e9.png" };
            uriSource = uriSources[indicator];
            InitializeComponent();
        }

        private void NextImage(object sender, EventArgs e)
        {
            if(indicator < 2)
            {
                indicator++;
                UriSource = uriSources[indicator];
            }
        }

        private void PreviousImage(object sender, EventArgs e)
        {
            if (indicator > 0)
            {
                indicator--;
                UriSource = uriSources[indicator];
            }
        }
    }
}