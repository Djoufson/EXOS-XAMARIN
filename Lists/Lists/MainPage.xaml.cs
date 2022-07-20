using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lists.Models;
using Xamarin.Forms;

namespace Lists
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<Contact> _contacts;
        public MainPage()
        {
            InitializeComponent();
            _contacts = new ObservableCollection<Contact>
            {
                new Contact{ Name="Mosh", Status="Teacher at Udemy", ImageUrl=""},
                new Contact{ Name="Magalie", Status="Trying to find a husband", ImageUrl=""},
                new Contact{ Name="Marly", Status="", ImageUrl=""},
                new Contact{ Name="Megan", Status="Not Megan Thee Stalion, But Megan Fox", ImageUrl=""},
                new Contact{ Name="Laure", Status="Hey DM for commissions", ImageUrl=""},
                new Contact{ Name="Lucas", Status="I'm Lucas, How can I help you", ImageUrl=""},
                new Contact{ Name="Lionel", Status="", ImageUrl=""},
                new Contact{ Name="Leo", Status="", ImageUrl="Leo, like the LION I am"}
            };

            list.ItemsSource = _contacts;
        }

        private void list_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            list.SelectedItem = null;
        }
        private void list_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        private void Call_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var contact = menuItem.CommandParameter as Contact;
            var response = DisplayAlert("CALL", $"Would you like tou call {contact.Name} ??", "YES", "NO");
        }
        private void Delete_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var contact = menuItem.CommandParameter as Contact;

            //DisplayAlert("DELETE", $"Would you like tou REMOVE {contact.Name} from contacts ??", "YES", "NO");
            
            _contacts.Remove(contact);
        }
        ObservableCollection<Contact> GetContacts()
        {
            return new ObservableCollection<Contact>
            {
                new Contact{ Name="Mosh", Status="Teacher at Udemy", ImageUrl=""},
                new Contact{ Name="Magalie", Status="Trying to find a husband", ImageUrl=""},
                new Contact{ Name="Marly", Status="", ImageUrl=""},
                new Contact{ Name="Megan", Status="Not Megan Thee Stalion, But Megan Fox", ImageUrl=""},
                new Contact{ Name="Laure", Status="Hey DM for commissions", ImageUrl=""},
                new Contact{ Name="Lucas", Status="I'm Lucas, How can I help you", ImageUrl=""},
                new Contact{ Name="Lionel", Status="", ImageUrl=""},
                new Contact{ Name="Leo", Status="", ImageUrl="Leo, like the LION I am"}
            };
        }
        private void Handle_Refreshing(object sender, EventArgs e)
        {
            _contacts = GetContacts();
            list.ItemsSource = _contacts;
            list.EndRefresh();
        }

        private void Load_Exercise_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Exercise());
        }
    }
}
