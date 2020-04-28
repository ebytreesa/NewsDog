﻿using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using Xamarin.Forms;

namespace Newsdog.iOS.Helpers
{
    public static class ColorHelper
    {
        public static UIColor PlatformAccentColor
        {
            get
            {
                return UIColor.FromRGB(139, 96, 168);
            }
        }

        public static Xamarin.Forms.Color PlatformColor
        {
            get
            {
                return Xamarin.Forms.Color.FromHex("#8B60A8");
            }
        }


    }
}
