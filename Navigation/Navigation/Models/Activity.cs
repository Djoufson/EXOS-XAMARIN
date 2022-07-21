using System;
using System.Collections.Generic;
using System.Text;

namespace Navigation.Models
{
    public class Activity
    {
        public int UserId { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public Activity(int userId, string description, string imageUrl)
        {
            UserId = userId;
            Description = description;
            ImageUrl = imageUrl;
        }
    }
}
