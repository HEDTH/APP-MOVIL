using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using HamburgerDeliveryApp.Droid;
using Android.Widget;
using Android.Content;
using Android.Graphics.Drawables;

[assembly: ExportEffect(typeof(SearchBarEffectRenderer), "SearchBarEffect")]
namespace HamburgerDeliveryApp.Droid
{
    public class SearchBarEffectRenderer : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                var searchView = Control as SearchView;
                if (searchView != null)
                {
                    int plateId = searchView.Context.Resources.GetIdentifier("android:id/search_plate", null, null);
                    var plate = searchView.FindViewById(plateId);
                    if (plate != null)
                    {
                        plate.SetBackgroundColor(SearchBarEffect.GetLineColor(Element).ToAndroid());
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Unable to set property on attached control: {ex}");
            }
        }

        protected override void OnDetached()
        {
        }
    }
}

