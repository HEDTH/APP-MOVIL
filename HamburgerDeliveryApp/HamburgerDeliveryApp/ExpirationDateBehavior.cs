using System.Linq;
using Xamarin.Forms;

namespace HamburgerDeliveryApp.Behaviors
{
    public class ExpirationDateBehavior : Behavior<Entry>
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

            // Eliminar caracteres que no son dígitos o '/'
            text = new string(text.Where(c => char.IsDigit(c) || c == '/').ToArray());

            // Limitar a 5 caracteres
            if (text.Length > 5)
                text = text.Substring(0, 5);

            // Formato MM/YY
            if (text.Length > 2 && !text.Contains("/"))
                text = text.Insert(2, "/");

            // Evitar bucles de cambios
            if (entry.Text != text)
                entry.Text = text;
        }
    }
}
