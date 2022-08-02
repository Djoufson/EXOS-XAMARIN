using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NeteflixRouletteApi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieDetailsPage : ContentPage
    {
        private Movie movie;
        public Movie _Movie
        {
            get => movie;
            set
            {
                movie = value;
                OnPropertyChanged();
            }
        }
        public MovieDetailsPage(Movie _movie)
        {
            movie = _movie;
            BindingContext = this;
            InitializeComponent();
        }
    }
}