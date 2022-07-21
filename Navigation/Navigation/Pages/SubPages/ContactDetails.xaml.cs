using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Navigation.Models;
using Navigation.Pages.SubPages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Navigation.Pages.SubPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactDetails : ContentPage
    {
        private string name;
        private string description;
        public string Description
        {
            get => description;
            set
            {
                description = value;
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
        private string uriSource;
        public Contact contact;
        public string UriSource
        {
            get => uriSource;
            set
            {
                if(uriSource != value)
                    uriSource = value;
                OnPropertyChanged();
            }
        }
        public ContactDetails(Contact contact)
        {
            this.contact = contact ?? throw new ArgumentNullException();
            uriSource = contact.UriSource;
            name = contact.Name;
            description = contact.Description;
            InitializeComponent();
            BindingContext = this;
        }

        private async void profilePicture_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ProfilePicture(uriSource));
        }
    }
}