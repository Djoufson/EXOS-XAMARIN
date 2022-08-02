using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DataAccess
{
    public partial class MainPage : ContentPage
    {
        public string Title;
        public MainPage()
        {
            BindingContext = this;
            InitializeComponent();
        }
    }
}
