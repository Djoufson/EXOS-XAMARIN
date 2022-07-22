using Formulaires.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Formulaires.ViewsModels
{
    public partial class MainPage : ContentPage
    {
        public static List<ContactsGroup> contactsGroups;
        public MainPage()
        {
            contactsGroups = GetContacts();
            InitializeComponent();
        }

        public void LoadContacts(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ContactsHomePage());
        }

        public static List<ContactsGroup> GetContacts()
        {
            var list = new List<ContactsGroup>()
            {
                new ContactsGroup("A", "A")
                {
                    new Contact(){Name = "Abana", ImageUrl = "https://th.bing.com/th/id/R.9c4e178147598c7de18e741259e6f44f?rik=Qcc3M2QQdHEAFQ&pid=ImgRaw&r=0"},
                    new Contact(){Name = "Atan"},
                    new Contact(){Name = "Abesso"},
                    new Contact(){Name = "Abiba"},
                    new Contact(){Name = "Andrea Cortez", ImageUrl = "https://img.izismile.com/img/img3/20100428/640/she_makes_random_640_12.jpg"}
                },
                new ContactsGroup("E", "E")
                {
                    new Contact(){Name = "Ererah Ricardo", ImageUrl = "https://th.bing.com/th/id/R.9c4e178147598c7de18e741259e6f44f?rik=Qcc3M2QQdHEAFQ&pid=ImgRaw&r=0"}
                },
                new ContactsGroup("M", "M")
                {
                    new Contact(){Name = "Marco ALABAMA", ImageUrl = "https://img.izismile.com/img/img3/20100428/640/she_makes_random_640_03.jpg"},
                    new Contact(){Name = "Micho Santos", ImageUrl = "https://th.bing.com/th/id/R.ee83a3b667ee093844c81ded6920c33e?rik=WhyheqLhel1ENw&pid=ImgRaw&r=0"}
                },
                new ContactsGroup("Y", "Y")
                {
                    new Contact(){Name = "Ygor Crepu", ImageUrl = "https://th.bing.com/th/id/OIP.1O8f7eP2gSL2S4-cvkBu8QHaHW?pid=ImgDet&rs=1"}
                },
                new ContactsGroup("J", "J")
                {
                    new Contact(){Name = "Jenny Dalby", ImageUrl = "https://th.bing.com/th/id/OIP.oQct2AToyBsqQjjPzZp9AwHaLH?pid=ImgDet&w=1200&h=1800&rs=1"}
                },
                new ContactsGroup("L", "L")
                {
                    new Contact(){Name = "Lusandro Xander", ImageUrl = "https://th.bing.com/th/id/R.1a61d9ec1c4e4848104b9c246c6d4d77?rik=6Srugoq9f9%2bAqA&riu=http%3a%2f%2fi.imgur.com%2f1C3zq3e.jpg&ehk=dBy7WlpDkmQ78ZsKQuo9Z9HtSX3rtkVkPw0qlSLzotE%3d&risl=&pid=ImgRaw&r=0"}
                },
                new ContactsGroup("B", "B")
                {
                    new Contact(){Name = "Banana"}
                }
            };

            list.Sort();
            foreach(var contact in list)
            {
                contact.Sort();
            }
            return list;
        }
    }
}
