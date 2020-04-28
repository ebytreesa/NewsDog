using Newsdog.iOS.Renderers;
using Newsdog.iOS.Renderers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Button), typeof(AccentColorButtonRenderer))]
namespace Newsdog.iOS.Renderers
{
   
    public class AccentColorButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
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
                return Newsdog.iOS.Helpers.ColorHelper.PlatformColor;
            }
        }

    }
}