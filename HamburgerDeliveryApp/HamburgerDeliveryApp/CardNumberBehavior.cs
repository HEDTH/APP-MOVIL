using System;
using System.Linq;
using Xamarin.Forms;

namespace HamburgerDeliveryApp.Behaviors
{
    public class CardNumberBehavior : Behavior<Entry>
    {
        private const int MaxLength = 16;
        private const int GroupSize = 4;
        private bool _isUpdating;

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
            if (_isUpdating)
                return;

            var entry = sender as Entry;
            var text = entry?.Text;

            if (string.IsNullOrWhiteSpace(text))
                return;

            _isUpdating = true;

            // Eliminar caracteres que no son dígitos
            text = new string(text.Where(char.IsDigit).ToArray());

            // Limitar a 16 caracteres
            if (text.Length > MaxLength)
                text = text.Substring(0, MaxLength);

            // Agrupar en conjuntos de 4
            var formattedText = string.Empty;
            for (int i = 0; i < text.Length; i += GroupSize)
            {
                if (i + GroupSize <= text.Length)
                {
                    formattedText += text.Substring(i, GroupSize) + " ";
                }
                else
                {
                    formattedText += text.Substring(i);
                }
            }

            // Quitar espacio al final
            formattedText = formattedText.TrimEnd();

            // Actualizar el texto de la entrada
            entry.Text = formattedText;

            _isUpdating = false;
        }
    }
}




