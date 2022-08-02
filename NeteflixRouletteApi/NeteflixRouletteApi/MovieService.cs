using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NeteflixRouletteApi
{
    public class MovieService
    {
        private const string Url = "https://jsonplaceholder.typicode.com/photos";
        private static HttpClient client = new HttpClient();

        public static async Task<ObservableCollection<Movie>> FindMoviesByActor(string actor)
        {
            var content = await client.GetStringAsync(Url);

            if (String.IsNullOrEmpty(actor))
            {
                return null;
            }
            return JsonConvert.DeserializeObject<ObservableCollection<Movie>>(content);
        }
        public static Movie GetMovie(string title)
        {
            Movie movie = null;
            return movie;
        }
    }
}
