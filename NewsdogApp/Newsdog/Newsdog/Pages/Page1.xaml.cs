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
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            corona.BindingContext = App.ViewModel;
            list.BindingContext = App.FilterViewModel;
            selectedFilter.BindingContext = App.FilterViewModel;

            base.OnAppearing();
        }

       
    }
}