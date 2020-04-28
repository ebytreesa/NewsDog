using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Android.Support.V7.Widget;
using Newsdog.Droid.Renderers;

[assembly: ExportRenderer(typeof(Xamarin.Forms.Button), typeof(AccentColorButtonRenderer))]
namespace Newsdog.Droid.Renderers
{
    public class AccentColorButtonRenderer : ButtonRenderer
    {
        public AccentColorButtonRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                var button = (Xamarin.Forms.Button)e.NewElement;
                button.BackgroundColor = AccentColor;
                button.TextColor = Color.White;
                button.FontAttributes = FontAttributes.Bold;
                button.BorderRadius = 22;

            }
        }

        private Color AccentColor
        {
            get
            {
                return Newsdog.Droid.Helpers.ColorHelper.PlatformColor;
            }
        }
    }
}
