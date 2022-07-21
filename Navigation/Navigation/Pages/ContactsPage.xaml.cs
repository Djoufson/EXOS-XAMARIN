using Navigation.Models;
using Navigation.Pages.SubPages;
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
    public partial class ContactsPage : ContentPage
    {
        private ObservableCollection<Contact> contacts;
        public ObservableCollection<Contact> Contacts
        {
            get => contacts;
            set
            {
                contacts = value;
                OnPropertyChanged();
            }
        }
        public ContactsPage()
        {
            Contacts = GetContacts();
            BindingContext = this;
            InitializeComponent();
        }

        private async void contactsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            Contact contact = e.SelectedItem as Contact;
            contactsList.SelectedItem = null;
            await Navigation.PushAsync(new ContactDetails(contact));
        }

        private void contactsList_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        private void contactsList_Refreshing(object sender, EventArgs e)
        {
            Contacts = GetContacts();

            contactsList.EndRefresh();
        }

        private ObservableCollection<Contact> GetContacts()
        {
            return new ObservableCollection<Contact>()
            {
                new Contact(){ Name = "Mbing BOSSECK", Status="Looking for a wife", Description = "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Quo ullam beatae vel ut facilis voluptas assumenda laborum, enim sint totam vitae rem distinctio debitis iste provident id explicabo commodi possimus!Lorem ipsum dolor sit amet, consectetur adipisicing elit. Quasi, aut id. Facere nulla nobis quibusdam tempore sequi quo rem dignissimos dolores corporis veniam consequatur asperiores ullam iure ipsam, laborum ad.Lorem ipsum dolor sit amet consectetur adipisicing elit. Magnam, nulla possimus quisquam delectus nemo provident culpa sit iure corrupti doloribus consequuntur iusto dolore laudantium sed, inventore ipsum non deleniti fuga!",UriSource="https://i.pinimg.com/originals/61/25/59/6125595537c8fb5fc9c7e6cb256155e9.png" },
                new Contact(){ Name = "John DOE", Status = "English Teacher in Harvard", UriSource="https://i.pinimg.com/originals/2e/c6/b5/2ec6b5e14fe0cba0cb0aa5d2caeeccc6.jpg", Description="Lorem ipsum dolor sit amet consectetur adipisicing elit. Qui, ipsum! Dolores ipsa, consequatur similique eos numquam modi voluptatibus praesentium, aspernatur eveniet dolor officia architecto explicabo sit iure reiciendis est doloremque nihil aliquam eaque aut dicta animi molestiae quidem dignissimos. Sequi, reprehenderit facere? Facilis fugiat architecto delectus accusantium. Animi explicabo ullam laborum modi. Officia rem laudantium dolorem, delectus inventore possimus. Pariatur quasi rem iste laudantium quibusdam vitae vero ratione doloremque doloribus labore, excepturi quis ipsa placeat eius aperiam aut accusantium nam quod reprehenderit. Ipsa ab sunt mollitia beatae cum quas ad voluptas a labore veniam et, quod blanditiis aspernatur. Velit tempora cumque quos aliquid nisi totam sunt perferendis officiis recusandae quasi animi voluptatibus voluptas modi ducimus saepe, maiores autem voluptates. Error, architecto obcaecati dolorem animi nobis labore corrupti hic excepturi beatae placeat laborum sint recusandae ratione repudiandae adipisci ipsum. Fugit illum aliquam officiis animi sapiente nostrum cumque iste assumenda facilis, accusantium delectus culpa laborum, quibus" },
                new Contact(){ Name = "Jane SMITH", Status = "Love cooking and make people happy with food", UriSource="https://cdn.wallpapersafari.com/31/22/DGBpWh.jpg", Description="Lorem ipsum dolor sit amet consectetur adipisicing elit. Qui, ipsum! Dolores ipsa, consequatur similique eos numquam modi voluptatibus praesentium, aspernatur eveniet dolor officia architecto explicabo sit iure reiciendis est doloremque nihil aliquam eaque aut dicta animi molestiae quidem dignissimos. Sequi, reprehenderit facere? Facilis fugiat architecto delectus accusantium. Animi explicabo ullam laborum modi. Officia rem laudantium dolorem, delectus inventore possimus. Pariatur quasi rem iste laudantium quibusdam vitae vero ratione doloremque doloribus labore, excepturi quis ipsa placeat eius aperiam aut accusantium nam quod reprehenderit. Ipsa ab sunt mollitia beatae cum quas ad voluptas a labore veniam et, quod blanditiis aspernatur. Velit tempora cumque quos aliquid nisi totam sunt perferendis"}
            };
        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            string response = await DisplayActionSheet("Actions", "Cancel", "Delete", "Call", "E-mail");
            switch (response)
            {
                case "Call":
                    await DisplayAlert("ALERT", "Call", "OK");
                    break;
                case "E-mail":
                    await DisplayAlert("ALERT", "Email", "OK");
                    break;
                case "Delete":
                    Contacts.Remove(menuItem.CommandParameter as Contact);
                    break;
            }
            //await DisplayAlert("Warning !!", "Are you sure you want to remove this contact?", "YES", "NO");
            /*
            if (reaponse)
            {
                Contacts.Remove(menuItem.CommandParameter as Contact);
            } */
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddNewContact(contacts));
        }
    }
}