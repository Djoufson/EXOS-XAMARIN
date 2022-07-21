using Navigation.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Navigation.Pages.Exercise.TabPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActivitiesPage : ContentPage
    {
        private ObservableCollection<Activity> activities;
        private ObservableCollection<User> users;

        public ObservableCollection<Activity> Activities
        {
            get => activities;
            set
            {
                activities = value;
                OnPropertyChanged();
            }
        }
        public ActivitiesPage(ObservableCollection<Activity> activities, ObservableCollection<User> users)
        {
            this.activities = activities;
            BindingContext = this;
            InitializeComponent();
            this.users = users;
        }

        private async void Activity_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            var activity = e.SelectedItem as Activity;
            activitiesList.SelectedItem = null;
            await Navigation.PushAsync(new ProfilePage(users[activity.UserId]));
        }
    }
}