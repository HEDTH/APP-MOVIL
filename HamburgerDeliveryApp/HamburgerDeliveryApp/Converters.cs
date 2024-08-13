using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace HamburgerDeliveryApp
{
    public class SelectedImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isSelected && isSelected)
            {
                return "selected.png"; // Ruta de la imagen para el ícono seleccionado
            }
            return "unselected.png"; // Ruta de la imagen para el ícono no seleccionado
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
