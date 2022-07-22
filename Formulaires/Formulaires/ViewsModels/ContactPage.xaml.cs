using Formulaires.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Formulaires.ViewsModels
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactPage : ContentPage
    {
        private Contact contact { get; set; }
        private bool isAddMode;
        public string Name { get; set; }
        public string Pseudo { get; set; }
        public int PhoneNumber { get; set; }
        public int AdditionalPhoneNumber { get; set; }
        public string Mail { get; set; }
        public string ImageUrl { get; set; }
        public string _Title { get; set; }
        public ContactPage(Contact contact = null)
        {
            isAddMode = true;
            this.contact = contact;

            if (!(contact == null))
            {
                isAddMode = false;
                _Title = "Edit Contact";
                this.Name = contact.Name;
                this.Pseudo = contact.Pseudo;
            }
            else
            {
                _Title = "Add Contact";
            }
            InitializeComponent();
            BindingContext = this;
        }

        public async void SubmitClicked(object sender, EventArgs e)
        {
            string msg = "";
            if (String.IsNullOrEmpty(Name))
            {
                msg = "The Name field is REQUIRED";
            }
            else
            {
                if (String.IsNullOrEmpty(PhoneEntry.Text))
                {
                    msg = "Can't create a contact with empty Phone";
                }
                else
                {
                    PhoneNumber = int.Parse(PhoneEntry.Text);
                }
            }
            if (!String.IsNullOrEmpty(msg))
            {
                await DisplayAlert("Warning!!", msg, "OK");
                return;
            }

            Contact newContact = new Contact()
            {
                Name = Name,
                PhoneNumber = PhoneNumber,
                Mail = Mail,
                ImageUrl = ImageUrl,
                AdditionalPhoneNumber = AdditionalPhoneNumber,
                Pseudo = Pseudo
            };
            string firstLetter = newContact.Name.ToCharArray()[0].ToString();
            List<ContactsGroup> contacts = MainPage.contactsGroups;

            foreach(var contact in contacts)
            {
                if(contact.Title == firstLetter)
                {
                    int index = contacts.IndexOf(contact);
                    MainPage.contactsGroups[index].Add(newContact);
                    MainPage.contactsGroups[index].Sort();
                    await Navigation.PopAsync();
                    return;
                }
            }

            MainPage.contactsGroups.Add(new ContactsGroup(firstLetter, firstLetter)
            {
                newContact
            });
            MainPage.contactsGroups.Sort();
            await Navigation.PopAsync();
        }
    }
}