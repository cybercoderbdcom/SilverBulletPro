using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SilverBulletPro.Converters
{
	// Token: 0x02000217 RID: 535
	public class NullToVisibilityConverter : IValueConverter
	{
		// Token: 0x06001089 RID: 4233 RVA: 0x0004F872 File Offset: 0x0004DA72
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (value == null) ? Visibility.Visible : Visibility.Collapsed;
		}

		// Token: 0x0600108A RID: 4234 RVA: 0x0004F880 File Offset: 0x0004DA80
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return DependencyProperty.UnsetValue;
		}
	}
}
