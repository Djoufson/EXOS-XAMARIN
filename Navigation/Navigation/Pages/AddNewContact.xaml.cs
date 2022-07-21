using Navigation.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Navigation.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewContact : ContentPage
    {
        private ObservableCollection<Contact> contacts;
        public AddNewContact(ObservableCollection<Contact> contacts)
        {
            this.contacts = contacts;
            InitializeComponent();
        }

        private async void Submit(object sender, EventArgs e)
        {
            string errorMessage = "";
            string Name = NameEntry.Text;
            string Status = StatusEntry.Text;
            string Description = DescriptionEditor.Text;
            string UriSource = "";
            if (String.IsNullOrEmpty(Name))
            {
                errorMessage = "Fill out the name field";
                NameEntry.Focus();
            }
            else
            {
                if (String.IsNullOrEmpty(Status))
                {
                    errorMessage = "Fill out the Status field";
                    StatusEntry.Focus();
                }
                else
                {
                    if (String.IsNullOrEmpty(Description))
                    {
                        errorMessage = "Fill out the Description field";
                        DescriptionEditor.Focus();
                    }
                }
            }
            if (!String.IsNullOrEmpty(errorMessage))
            {
                await DisplayAlert("Warning !", errorMessage, "OK");
                return;
            }
            contacts.Add(new Contact()
            {
                Name = Name,
                Status = Status,
                Description = Description,
                UriSource = UriSource,
            });
            await Navigation.PopModalAsync();
        }
    }
}