using System;
using Xamarin.Forms;

namespace HamburgerDeliveryApp.Behaviors
{
    public class ButtonPressBehavior : Behavior<Button>
    {
        protected override void OnAttachedTo(Button button)
        {
            base.OnAttachedTo(button);
            button.Clicked += OnButtonClicked;
            UpdateButtonState(button);
        }

        protected override void OnDetachingFrom(Button button)
        {
            base.OnDetachingFrom(button);
            button.Clicked -= OnButtonClicked;
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null && button.Command != null && button.Command.CanExecute(button.CommandParameter))
            {
                button.Command.Execute(button.CommandParameter);
            }
            SetIsSelected(button, !GetIsSelected(button)); // Toggle the IsSelected state
        }

        public static readonly BindableProperty IsSelectedProperty =
            BindableProperty.CreateAttached("IsSelected", typeof(bool), typeof(ButtonPressBehavior), false, propertyChanged: OnIsSelectedChanged);

        public static bool GetIsSelected(BindableObject view)
        {
            return (bool)view.GetValue(IsSelectedProperty);
        }

        public static void SetIsSelected(BindableObject view, bool value)
        {
            view.SetValue(IsSelectedProperty, value);
        }

        private static void OnIsSelectedChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var button = bindable as Button;
            if (button != null)
            {
                UpdateButtonState(button);
            }
        }

        private static void UpdateButtonState(Button button)
        {
            if (GetIsSelected(button))
            {
                button.BackgroundColor = Color.FromHex("#FFCA1A");
                button.TextColor = Color.Black;
                button.BorderColor = Color.Transparent;
            }
            else
            {
                button.BackgroundColor = Color.Transparent;
                button.TextColor = Color.Black;
                button.BorderColor = Color.FromHex("#FFCA1A");
                button.BorderWidth = 2;
            }
        }
    }
}





