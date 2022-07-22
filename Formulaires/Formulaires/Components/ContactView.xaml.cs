using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Formulaires.Components
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactView : ContentView
    {
        public static readonly BindableProperty NameProperty =
            BindableProperty.Create("ContactName", typeof(string), typeof(ContactView));
        public static readonly BindableProperty ImageSourceProperty =
            BindableProperty.Create("ContactImageSource", typeof(string), typeof(ContactView));

        public string ContactName
        {
            get => (string)GetValue(NameProperty);
            set
            {
                SetValue(NameProperty, value);
                OnPropertyChanged();
            }
        }
        public string ContactImageSource
        {
            get => (string)GetValue(ImageSourceProperty);
            set
            {
                SetValue(ImageSourceProperty, value);
                OnPropertyChanged();
            }
        }
        public ContactView()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}