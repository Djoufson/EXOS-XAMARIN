using System;
using System.Collections.Generic;
using System.Text;

namespace Lists.Models
{
    public class Search
    {
        public static int Count = 0;
        public int ID { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string UriSource { get; set; }
        private DateTime CheckIn;
        private DateTime CheckOut;

        public Search(DateTime checkIn, DateTime checkOut)
        {
            ID = Count;
            Count++;
            CheckIn = checkIn;
            CheckOut = checkOut;
            Date = $"{CheckIn.ToString("MMM dd, yyy")} - {CheckOut.ToString("MMM dd, yyy")}";
        }
    }
}
