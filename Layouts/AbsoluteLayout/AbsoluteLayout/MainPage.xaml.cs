using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbsoluteLayout.Views;
using Xamarin.Forms;

namespace AbsoluteLayout
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void LoadExercice1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Exercice1());
        }
        public void LoadExercice2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Exercice2());
        }
    }
}
