using Navigation.Models;
using Navigation.Pages.Exercise.Modals;
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
        private bool isFollowing;
        private User user;
        private string name;
        private int followers;
        private int following;
        private readonly string imageUrl;
        private string description;

        public int Followers
        {
            get => followers;
            set
            {
                followers = value;
                OnPropertyChanged();
            }
        }
        public int Following
        {
            get => following;
            set
            {
                following = value;
                OnPropertyChanged();
            }
        }
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
            followers = this.user.Followers;
            following = this.user.Following;
            InitializeComponent();
            followOrEdit.Text = "Follow";
            if (Owner == HomePage.Owner)
            {
                followOrEdit.Text = "Edit";
            }
        }

        private async void followOrEdit_Clicked(object sender, EventArgs e)
        {
            Button followButton = sender as Button;
            string text = followButton.Text;
            if(text.Equals("Edit", StringComparison.OrdinalIgnoreCase))
            {
                await Navigation.PushModalAsync(new EditProfile());
                return;
            }
            isFollowing = text.Equals("Following", StringComparison.OrdinalIgnoreCase);
            if (isFollowing)
            {
                followButton.Text = "Follow";
                Followers--;
                HomePage.Owner.Following--;
            }
            else
            {
                followButton.Text = "Following";
                Followers++;
                HomePage.Owner.Following++;
            }
        }
    }
}