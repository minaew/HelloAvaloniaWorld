using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;
using HelloAvaloniaWorld.ViewModels;

namespace HelloAvaloniaWorld
{
    internal class FileEntryBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var entry = value as Entry;
            if (entry?.IsDIrectory == true)
            {
                return new SolidColorBrush(Color.FromRgb(0, 0xFF, 0));
            }

            return new SolidColorBrush(Color.FromRgb(0x80, 0x80, 0xFF));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
