using Xamarin.Forms;
using NewsDog.UWP;
using Windows.UI.ViewManagement;
using Newsdog;

[assembly: Dependency(typeof(DeviceOrientation))]
namespace NewsDog.UWP
{
    public class DeviceOrientation : IDeviceOrientation
    {
        public DeviceOrientation() { }

        public DeviceOrientations GetOrientation()
        {
            var orientation = ApplicationView.GetForCurrentView().Orientation;
            if (orientation == ApplicationViewOrientation.Landscape)
                return DeviceOrientations.Landscape;
            else
                return DeviceOrientations.Portrait;
        }
    }
}