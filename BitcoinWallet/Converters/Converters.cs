using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinWallet.Converters
{
    public class ConditionToStyleConverter : IValueConverter
    {
        public Style SuccessStyle { get; set; }

        public Style FailureStyle { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? SuccessStyle : FailureStyle;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new InvalidOperationException();
        }
    }
}
