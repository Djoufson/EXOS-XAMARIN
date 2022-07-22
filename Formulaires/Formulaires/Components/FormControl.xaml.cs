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
    public partial class FormControl : ViewCell
    {
        public FormControl()
        {
            InitializeComponent();
        }
    }
}