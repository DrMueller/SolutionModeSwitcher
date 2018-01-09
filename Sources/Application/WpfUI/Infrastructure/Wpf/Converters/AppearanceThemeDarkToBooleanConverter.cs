using System;
using System.Globalization;
using System.Windows.Data;
using Mmu.Sms.WpfUI.Infrastructure.Services.Appearance.Models;

namespace Mmu.Sms.WpfUI.Infrastructure.Wpf.Converters
{
    internal class AppearanceThemeDarkToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var appearanceTheme = (AppearanceTheme)value;
            return appearanceTheme == AppearanceTheme.Dark;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var appearanceThemeIsDark = (bool)value;
            return appearanceThemeIsDark ? AppearanceTheme.Dark : AppearanceTheme.Light;
        }
    }
}