using GridLayouts.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GridLayouts
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void LoadExercice1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Exercice1());
        }
        private void LoadExercice2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Exercice2());
        }
    }
}
