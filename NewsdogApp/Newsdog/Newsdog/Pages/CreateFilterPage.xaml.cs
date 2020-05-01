using Newsdog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Newsdog.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateFilterPage : ContentPage
    {
        public NewsFilter currentFilter { get; set; }
        public CreateFilterPage()
        {
            currentFilter = new NewsFilter();
            this.BindingContext = currentFilter;
            InitializeComponent();
        }
    }
}