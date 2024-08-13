using System.Linq;
using Xamarin.Forms;

namespace HamburgerDeliveryApp.Behaviors
{
    public class CVVBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += OnTextChanged;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= OnTextChanged;
            base.OnDetachingFrom(bindable);
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = sender as Entry;
            var text = entry.Text;

            // Eliminar caracteres que no son dígitos
            text = new string(text.Where(char.IsDigit).ToArray());

            // Limitar a 3 caracteres
            if (text.Length > 3)
                text = text.Substring(0, 3);

            // Evitar bucles de cambios
            if (entry.Text != text)
                entry.Text = text;
        }
    }
}
