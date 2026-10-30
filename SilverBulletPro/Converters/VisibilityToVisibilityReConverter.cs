using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SilverBulletPro.Converters
{
	// Token: 0x0200021D RID: 541
	public class VisibilityToVisibilityReConverter : IValueConverter
	{
		// Token: 0x0600109E RID: 4254 RVA: 0x0004FA86 File Offset: 0x0004DC86
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
			{
				return Visibility.Hidden;
			}
			return ((Visibility)value == Visibility.Visible) ? Visibility.Collapsed : Visibility.Visible;
		}

		// Token: 0x0600109F RID: 4255 RVA: 0x0004FAA3 File Offset: 0x0004DCA3
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return DependencyProperty.UnsetValue;
		}
	}
}
