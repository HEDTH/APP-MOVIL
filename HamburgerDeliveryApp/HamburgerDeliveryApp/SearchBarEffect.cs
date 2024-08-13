using Xamarin.Forms;

namespace HamburgerDeliveryApp
{
    public class SearchBarEffect : RoutingEffect
    {
        public static readonly BindableProperty LineColorProperty =
            BindableProperty.CreateAttached(
                "LineColor",
                typeof(Color),
                typeof(SearchBarEffect),
                Color.Default);

        public static Color GetLineColor(BindableObject view)
        {
            return (Color)view.GetValue(LineColorProperty);
        }

        public static void SetLineColor(BindableObject view, Color value)
        {
            view.SetValue(LineColorProperty, value);
        }

        public SearchBarEffect() : base("HamburgerDeliveryApp.SearchBarEffect")
        {
        }
    }
}



