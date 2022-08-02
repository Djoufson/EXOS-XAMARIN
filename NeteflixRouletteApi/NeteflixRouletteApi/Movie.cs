using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeteflixRouletteApi
{
    public class Movie
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Description { get; set; }
        public int ReleaseDate { get; set; }

        [JsonProperty("url")]
        public string ImageSource { get; set; }
    }
}
