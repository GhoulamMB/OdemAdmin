using System.Globalization;

namespace OdemAdmin.Resources;

public class MessageTypeToStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        bool isClientMessage = (bool)value;
        return isClientMessage ? "client: " : "admin: ";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return "test";
    }
}