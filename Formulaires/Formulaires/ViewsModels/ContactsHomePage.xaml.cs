using Formulaires.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Formulaires.ViewsModels
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsHomePage : ContentPage
    {
        private string imageSource;
        private List<ContactsGroup> contactsGroups;
        private string name;

        public bool IsEmpty { get; set; }
        public List<ContactsGroup> ContactsGroups
        {
            get => contactsGroups;
            set
            {
                contactsGroups = value;
                OnPropertyChanged();
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        public string ImageSource
        {
            get => imageSource;
            set
            {
                imageSource = value;
                OnPropertyChanged();
            }
        }
        public ContactsHomePage()
        {
            name = "Djoufson";
            imageSource = "https://th.bing.com/th/id/R.9c4e178147598c7de18e741259e6f44f?rik=Qcc3M2QQdHEAFQ&pid=ImgRaw&r=0";
            BindingContext = this;
            contactsGroups = MainPage.contactsGroups;
            IsEmpty = !contactsGroups.Any();
            InitializeComponent();
            MyContact.ContactName = Name;
            MyContact.ContactImageSource = ImageSource;
        }

        public async void AddContact(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ContactPage());
        }
        public async void Handle_ContactSelection(object sender, EventArgs e)
        {
            if (contactsListView.SelectedItem == null)
                return;
            var contact = contactsListView.SelectedItem as Contact;
            contactsListView.SelectedItem = null;
            await Navigation.PushAsync(new ContactPresentation(contact));
        }
        public void Handle_ContactRefresh(object sender, EventArgs e)
        {
            ContactsGroups = MainPage.contactsGroups;
            contactsListView.EndRefresh();
        }
    }
}