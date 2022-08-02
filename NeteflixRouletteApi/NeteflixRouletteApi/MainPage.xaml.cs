using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using NeteflixRouletteApi.Views;
using Newtonsoft.Json;

namespace NeteflixRouletteApi
{
    public partial class MainPage : ContentPage
    {
        private string actorName;
        private ObservableCollection<Movie> movies;
        public ObservableCollection<Movie> Movies
        {
            get => movies;
            set
            {
                if(movies != value)
                {
                    movies = value;
                    OnPropertyChanged();
                }
            }
        }
        public string ActorName
        {
            get => actorName;
            set
            {
                if (actorName != value)
                {
                    actorName = value;
                    OnPropertyChanged();
                }
            }
        }
        public MainPage()
        {
            actorName = "";
            BindingContext = this;
            InitializeComponent();
        }

        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            Movies = null;
            if (e.NewTextValue.ToCharArray().Length >= 4)
            {
                Movies = await MovieService.FindMoviesByActor(ActorName);
            }
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var _movie = e.SelectedItem as Movie;
            if (_movie == null)
                return;
            moviesList.SelectedItem = null;
            Navigation.PushAsync(new MovieDetailsPage(_movie));
        }
    }
}
