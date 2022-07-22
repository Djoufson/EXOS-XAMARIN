using System;
using System.Collections.Generic;
using System.Text;

namespace Navigation.Models
{
    public class User
    {
        private static int Count = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; private set; }
        public int Followers { get; set; }
        public int Following { get; set; }
        public User(string name, string description, string imageUrl)
        {
            Id = Count;
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
            Count++;
        }
    }
}
