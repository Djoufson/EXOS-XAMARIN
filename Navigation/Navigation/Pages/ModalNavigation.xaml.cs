using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Navigation.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModalNavigation : ContentPage
    {
        public ModalNavigation()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}