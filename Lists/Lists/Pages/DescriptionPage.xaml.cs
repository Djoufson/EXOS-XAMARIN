using Lists.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lists.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DescriptionPage : ContentPage
    {
        private Search vaccation;
        private string title;
        private string location;
        private string description;
        private double price;
        private string date;
        private string _source;

        public string _Source 
        {
            get => _source;
            set
            {
                _source = value;
                OnPropertyChanged();
            }
        }

        public string Location
        {
            get => location;
            set
            {
                if(value == location)
                    location = value;
                OnPropertyChanged();
            }
        }
        public string _Title
        {
            get => title;
            set
            {
                if (value != title)
                    title = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get => description;
            set
            {
                if(value != description)
                    description = value;
                OnPropertyChanged();
            }
        }
        public double Price
        {
            get => price;
            set
            {
                if (value != price)
                    price = value;
                OnPropertyChanged();
            }
        }

        public string Date
        {
            get => date;
            set
            {
                if (value != date)
                    date = value;
                OnPropertyChanged();
            }
        }

        public DescriptionPage()
        {
            _source = "http://lorempixel.com/400/200t";
            vaccation = Exercise.current;
            title = "";
            location = vaccation.Location;
            description = vaccation.Description;
            price = vaccation.Price;
            date = vaccation.Date;
            InitializeComponent();
            BindingContext = this;
        }

        private void Home_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}