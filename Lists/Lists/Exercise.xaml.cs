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
        public static Search current;
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
            _searches = new ObservableCollection<SearchesGroup>(GetSearches(e.NewTextValue));
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
                        new Search(new DateTime(2016, 9, 1), new DateTime(2016, 9, 1)){Location="West Holliwood, CA, United States", Price=15.4, Description="Lorem ipsum dolor sit amet consectetur adipisicing elit. Sequi nihil ex nostrum temporibus. Voluptate minima natus iure culpa totam illo, corrupti blanditiis! Assumenda eaque illum, amet ab veniam rerum expedita."},
                        new Search(new DateTime(2017, 9, 1), new DateTime(2016, 9, 1)){Location="Santa Monica, CA, United States", Price=12.4, Description="Lorem ipsum, dolor sit amet consectetur adipisicing elit. Neque porro qui nemo illo odit fuga accusamus maiores incidunt, exercitationem iste cumque debitis! Explicabo, excepturi atque. "},
                        new Search(new DateTime(2015, 9, 1), new DateTime(2016, 9, 1)){Location="West Coast, CA", Price=15.4, Description="Lorem ipsum dolor sit, amet consectetur adipisicing elit. Aperiam praesentium, impedit odit sequi minus magnam exercitationem nulla aspernatur ipsum recusandae corrupti ipsa laborum, iusto harum, at consequatur ratione et dicta?"},
                        new Search(new DateTime(2018, 9, 1), new DateTime(2016, 9, 1)){Location="Santa Maria, CA, United States", Price=25.4, Description="Lorem ipsum dolor sit amet consectetur, adipisicing elit. Ab eaque provident earum perspiciatis eligendi quo, quae reprehenderit placeat amet libero quod neque, rerum officia unde. Culpa quibusdam est, excepturi iste dolor id quo odio alias accusantium, reiciendis molestiae omnis, placeat ad at quas provident perferendis deserunt sed. Nesciunt, impedit a?"},
                        new Search(new DateTime(2020, 9, 1), new DateTime(2016, 9, 1)){Location="Nevada, CA, United States", Price=10.45, Description="Lorem ipsum dolor sit amet consectetur adipisicing elit. Quas modi at aperiam nisi tempore cupiditate magnam deserunt, itaque laboriosam neque asperiores ratione necessitatibus ducimus alias excepturi, praesentium ipsam doloribus dolor quod beatae mollitia? Eaque eius natus itaque necessitatibus, iure ut."},
                        new Search(new DateTime(2015, 9, 1), new DateTime(2016, 9, 1)){Location="New York, CA, United States", Price=16.4, Description="Lorem ipsum, dolor sit amet consectetur adipisicing elit. Adipisci sit assumenda laborum, nisi hic facere commodi maxime magni qui cumque inventore, tenetur modi perferendis ipsa in nemo quasi voluptas sint!"},
                        new Search(new DateTime(2017, 9, 1), new DateTime(2016, 9, 1)){Location="Atlanta, CA", Price=11.4, Description="Lorem ipsum dolor, sit amet consectetur adipisicing elit. Eos non quia, pariatur esse dolore, obcaecati aliquam aperiam amet odit autem expedita enim voluptate inventore optio in suscipit veritatis minima similique!"},
                        new Search(new DateTime(2018, 9, 1), new DateTime(2016, 9, 1)){Location="Ohayo, CA, United States", Price=22.4, Description="Lorem ipsum dolor sit amet consectetur adipisicing elit. Odit excepturi, sequi praesentium voluptas soluta placeat voluptate quibusdam, dicta corporis eum repellendus sed ipsa dolorum illo!"},
                        new Search(new DateTime(2017, 9, 1), new DateTime(2016, 9, 1)){Location="Arkansas, CA, United States", Price=24.4, Description="Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime nihil cumque harum mollitia eaque provident voluptates commodi sequi! Sequi adipisci expedita, corrupti fuga perspiciatis enim?"},
                        new Search(new DateTime(2011, 9, 1), new DateTime(2016, 9, 1)){Location="Calfornia", Price=15.4, Description="Lorem ipsum dolor sit amet consectetur adipisicing elit. Sequi nihil ex nostrum temporibus. Voluptate minima natus iure culpa totam illo, corrupti blanditiis! Assumenda eaque illum, amet ab veniam rerum expedita."},
                        new Search(new DateTime(2016, 9, 1), new DateTime(2016, 9, 1)){Location="Alaska, CA, United States", Price=35.4, Description="Lorem ipsum dolor sit amet consectetur adipisicing elit. Sequi nihil ex nostrum temporibus. Voluptate minima natus iure culpa totam illo, corrupti blanditiis! Assumenda eaque illum, amet ab veniam rerum expedita."},
                        new Search(new DateTime(2013, 9, 1), new DateTime(2016, 9, 1)){Location="Washington, CA, United States", Price=25.24, Description="Lorem ipsum dolor sit amet consectetur adipisicing elit. Sequi nihil ex nostrum temporibus. Voluptate minima natus iure culpa totam illo, corrupti blanditiis! Assumenda eaque illum, amet ab veniam rerum expedita."}
                    }
                };
                return searches;
            }
            else
            {
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
                    if (search.Location.ToUpper().Contains(searchWord.ToUpper()))
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
            current = e.Item as Search;
            Navigation.PushAsync(new Pages.DescriptionPage());
        }

        private void searchesList_Refreshing(object sender, EventArgs e)
        {
            var searches = GetSearches();
            _searches = new ObservableCollection<SearchesGroup>(searches);
            searchesList.ItemsSource = _searches;
            searchesList.EndRefresh();
        }
    }
}