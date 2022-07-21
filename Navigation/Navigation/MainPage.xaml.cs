using Navigation.Pages;
using Navigation.Pages.Exercise;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Navigation
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Hierarchical_Navigation_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HierarchicalNavigation());
        }
        private void Modal_Navigation_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ModalNavigation());
        }
        private void Details_Navigation_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ContactsPage());
        }

        private async void Tabbed_Navigation_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TabbedNavigation());
        }

        private async void LoadInstagram(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomePage());
        }
    }
}
