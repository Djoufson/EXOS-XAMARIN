using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Navigation.Pages.SubPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePicture : ContentPage
    {
        private string uriSource;
        public string UriSource
        {
            get { return uriSource; }
            set
            {
                uriSource = value;
                OnPropertyChanged();
            }
        }
        public ProfilePicture(string uriSource)
        {
            this.uriSource = uriSource;
            InitializeComponent();
            BindingContext = this;
        }

        private async void profilePicture_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}