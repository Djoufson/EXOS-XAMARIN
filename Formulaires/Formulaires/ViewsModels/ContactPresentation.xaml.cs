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
    public partial class ContactPresentation : ContentPage
    {
        private Contact contact;
        public ContactPresentation(Contact contact = null)
        {
            this.contact = contact;
            InitializeComponent();
        }

        public async void EditClicked(object sender, EventArgs e)
        {
            if(contact == null)
            {
                await Navigation.PushAsync(new ContactPage());
                return;
            }
            await Navigation.PushAsync(new ContactPage(contact));
        }
    }
}