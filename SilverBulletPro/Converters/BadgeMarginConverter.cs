using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SilverBulletPro.Converters
{
	// Token: 0x02000202 RID: 514
	public class BadgeMarginConverter : IValueConverter
	{
		// Token: 0x06001048 RID: 4168 RVA: 0x0004EFB8 File Offset: 0x0004D1B8
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			object result;
			try
			{
				if ((int)value <= 9)
				{
					result = new Thickness(0.0, 2.0, 11.0, 0.0);
				}
				else
				{
					result = new Thickness(0.0, 2.0, 0.0, 0.0);
				}
			}
			catch
			{
				result = new Thickness(0.0, 2.0, 11.0, 0.0);
			}
			return result;
		}

		// Token: 0x06001049 RID: 4169 RVA: 0x0004F074 File Offset: 0x0004D274
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return DependencyProperty.UnsetValue;
		}
	}
}
