
using Newsdog.UWP.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(Xamarin.Forms.Button), typeof(AccentColorButtonRenderer))]
namespace Newsdog.UWP.Renderers
{
    public class AccentColorButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                var button = (Xamarin.Forms.Button)e.NewElement;
                button.BackgroundColor = AccentColor;
                button.TextColor = Color.White;
                button.FontAttributes = FontAttributes.Bold;
                button.CornerRadius = 22;

            }
        }

        private Color AccentColor
        {
            get
            {
                return Color.FromHex("#01AEF2");
            }
        }


    }
}