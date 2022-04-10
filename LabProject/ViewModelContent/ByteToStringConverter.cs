using System;
using System.Globalization;
using System.Windows.Data;

namespace LabProject
{
    public class ByteToStringConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
                return ((byte)value).ToString();
            else
                return Byte.MaxValue.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (Byte.TryParse(value as string, out byte res))
                return res;
            else
                return byte.MaxValue;
        }
    }
}
