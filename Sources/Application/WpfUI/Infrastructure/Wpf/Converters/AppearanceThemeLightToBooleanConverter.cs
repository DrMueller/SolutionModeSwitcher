using System;
using System.Globalization;
using System.Windows.Data;
using Mmu.Sms.WpfUI.Infrastructure.Services.Appearance.Models;

namespace Mmu.Sms.WpfUI.Infrastructure.Wpf.Converters
{
    public class AppearanceThemeLightToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var appearanceTheme = (AppearanceTheme)value;
            return appearanceTheme == AppearanceTheme.Light;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var appearanceThemeIsLight = (bool)value;
            return appearanceThemeIsLight ? AppearanceTheme.Light : AppearanceTheme.Dark;
        }
    }
}