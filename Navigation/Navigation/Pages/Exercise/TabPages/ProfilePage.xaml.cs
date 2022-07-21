using Navigation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Navigation.Pages.Exercise.TabPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        private User user;
        private string name;
        private readonly string imageUrl;
        private string description;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        public string ImageUrl
        {
            get => imageUrl;
        }
        public string Description
        {
            get => description;
            set
            {
                description = value;
                OnPropertyChanged();
            }
        }
        public User _User
        {
            get => user;
            set
            {
                user = value;
                OnPropertyChanged();
            }
        }
        public ProfilePage(User Owner)
        {
            user = Owner;
            BindingContext = this;
            name = this.user.Name;
            imageUrl = this.user.ImageUrl;
            description = this.user.Description;
            InitializeComponent();
        }
    }
}