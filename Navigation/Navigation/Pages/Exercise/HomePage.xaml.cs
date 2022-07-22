using Navigation.Models;
using Navigation.Pages.Exercise.TabPages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Navigation.Pages.Exercise
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : TabbedPage
    {
        public ObservableCollection<User> users;
        public ObservableCollection<Activity> activities;

        public static User Owner = new User("Infinite Solutions", "A solution to all IT ptoblems you may have", "https://th.bing.com/th/id/OIP.nE4XgUdZjH3hjnQSWeb0TwHaFc?pid=ImgDet&rs=1") { Followers = 2541, Following = 310 };


        public ObservableCollection<User> Users
        {
            get => users;
            set
            {
                users = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Activity> Activities
        {
            get => activities;
            set
            {
                activities = value;
                OnPropertyChanged();
            }
        }
        public HomePage()
        {
            BindingContext = this;
            InitializeUsers();
            InitializeActivities();
            InitializeComponent();
            this.Children.Add(new ActivitiesPage(Activities, Users)
            {
                Title="Activities",
                IconImageSource = "heart"
            });
            this.Children.Add(new ProfilePage(Owner)
            {
                Title = "Profile",
                IconImageSource = "user.png"
            });
        }

        private void InitializeUsers()
        {
            users = new ObservableCollection<User>()
            {
                new User("Ererah Ricardo", "Hi I'm Ricardo, want to chat??", "https://th.bing.com/th/id/R.9c4e178147598c7de18e741259e6f44f?rik=Qcc3M2QQdHEAFQ&pid=ImgRaw&r=0"){Followers = 540, Following=135},
                new User("Micho Santos", "Holla from Santos Micho", "https://th.bing.com/th/id/R.ee83a3b667ee093844c81ded6920c33e?rik=WhyheqLhel1ENw&pid=ImgRaw&r=0"){Followers = 1440, Following=335},
                new User("Ygor Crepu", "Bonjour euh... Bah voici mon compte", "https://th.bing.com/th/id/OIP.1O8f7eP2gSL2S4-cvkBu8QHaHW?pid=ImgDet&rs=1"){Followers = 866, Following=245},
                new User("Jenny Dalby", "My Name is Jenny Dalby ;-*", "https://th.bing.com/th/id/OIP.oQct2AToyBsqQjjPzZp9AwHaLH?pid=ImgDet&w=1200&h=1800&rs=1"){Followers = 440, Following=635},
                new User("Marco ALABAMA", "Muchachos holla, comos te vas??", "https://img.izismile.com/img/img3/20100428/640/she_makes_random_640_03.jpg"){Followers = 5400, Following=635},
                new User("Lusandro Xander", "Hey amigos, do ya wanna dance?", "https://th.bing.com/th/id/R.1a61d9ec1c4e4848104b9c246c6d4d77?rik=6Srugoq9f9%2bAqA&riu=http%3a%2f%2fi.imgur.com%2f1C3zq3e.jpg&ehk=dBy7WlpDkmQ78ZsKQuo9Z9HtSX3rtkVkPw0qlSLzotE%3d&risl=&pid=ImgRaw&r=0"){Followers = 1540, Following=235},
                new User("Andrea Cortez", "Hi.", "https://img.izismile.com/img/img3/20100428/640/she_makes_random_640_12.jpg") { Followers = 740, Following = 435 }
            };
        }
        private void InitializeActivities()
        {
            activities = new ObservableCollection<Activity>()
            {
                new Activity(1, $"Your Facebook friend {Users[1].Name} is on Instagram", $"{Users[1].ImageUrl}"),
                new Activity(2, $"{Users[2].Name} started following you", $"{Users[2].ImageUrl}"),
                new Activity(4, $"{Users[4].Name} liked your photo", $"{Users[4].ImageUrl}"),
                new Activity(1, $"Your Facebook friend {Users[1].Name} is on Instagram", $"{Users[1].ImageUrl}"),
                new Activity(3, $"Your Facebook friend {Users[3].Name} sent you a photo posted by @brookeisep", $"{Users[3].ImageUrl}"),
                new Activity(5, $"{Users[5].Name} started following you", $"{Users[5].ImageUrl}"),
                new Activity(4, $"Your Facebook friend {Users[4].Name} is on Instagram", $"{Users[4].ImageUrl}"),
                new Activity(0, $"Your Facebook friend {Users[0].Name} is on Instagram", $"{Users[0].ImageUrl}"),
                new Activity(6, $"Your Facebook friend {Users[6].Name} is on Instagram", $"{Users[6].ImageUrl}")
            };
        }
    }
}