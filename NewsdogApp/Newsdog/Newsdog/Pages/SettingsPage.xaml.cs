using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newsdog.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Newsdog.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            InitializeSettings();
            base.OnAppearing();
        }
        private void InitializeSettings()
        {
            //this.currentUser = new UserInformation
            //{
            //    DisplayName = "Eby",
            //    BioContent = "ghg kghhhhhhhhhhhhhhhhhhhhhhhh",
            //    ProfileImageUrl = "https://www.thespruce.com/thmb/LCyupmFhZf0tXxj6TpBwWS6ZSfo=/3867x2578/filters:fill(auto,1)/GettyImages-153342142-56a75f045f9b58b7d0e9bee6.jpg"
            //};
            this.BindingContext = App.ViewModel;
            articleCountSlider.Value = 10;
            //categoryPicker.SelectedIndex = 2;

            var label = Helpers.GeneralHelper.GetLabel();
            var extendedLabel = Helpers.GeneralHelper.GetLabel("Running NewsDog on", true);

            var orientation = Helpers.GeneralHelper.GetOrientation();

            App.ViewModel.PlatformLabel = label;
            App.ViewModel.ExtendedPlatformLabel = extendedLabel;
           App.ViewModel.CurrentOrientation = orientation;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            App.Current.Resources["ListTextColor"] = Color.Blue;
        }
    }
}