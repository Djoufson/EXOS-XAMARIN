using Lists.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lists
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Exercise : ContentPage
    {
        public ObservableCollection<SearchesGroup> _searches;
        public Exercise()
        {
            InitializeComponent();

            var searches = GetSearches();
            _searches = new ObservableCollection<SearchesGroup>(searches);
            searchesList.ItemsSource = _searches;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searches = GetSearches(e.NewTextValue);
            _searches = new ObservableCollection<SearchesGroup>(searches);
            searchesList.ItemsSource = _searches;
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var search = menuItem.CommandParameter as Search;

            _searches[0].Remove(search);
            searchesList.ItemsSource = _searches;
        }

        private IEnumerable<SearchesGroup> GetSearches(string search = "")
        {
            ObservableCollection<SearchesGroup> searches;
            if (string.IsNullOrEmpty(search))
            {
                searches = new ObservableCollection<SearchesGroup>
                {
                    new SearchesGroup("Recent Searches")
                    {
                        new Search{Location="West Holliwood, CA, United States", Date="Sep 1, 2016 - Nov 1, 2016"},
                        new Search{Location="Santa Monica, CA, United States", Date="Sept 1, 2016 - Nov 1, 2016"}
                    }
                };
                return searches;
            }
            else
            {
                Console.WriteLine("Else statement");
                searches = new ObservableCollection<SearchesGroup>();
                searches = SEARCH(search, _searches);
                return searches;

            }
        }

        private ObservableCollection<SearchesGroup> SEARCH(string searchWord, ObservableCollection<SearchesGroup> searches)
        {
            ObservableCollection<SearchesGroup> result = new ObservableCollection<SearchesGroup>()
            {
                new SearchesGroup("Recent Searches")
            };
            foreach(var searchGroup in searches)
            {
                foreach(var search in searchGroup)
                {
                    if (search.Location.StartsWith(searchWord,StringComparison.OrdinalIgnoreCase))
                    {
                        result[0].Add(search);
                    }
                }
            }

            return result;
        }

        private void searchesList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            searchesList.SelectedItem = null;
        }

        private void searchesList_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}