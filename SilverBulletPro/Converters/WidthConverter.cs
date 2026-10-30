using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SilverBulletPro.Converters
{
	// Token: 0x0200021E RID: 542
	public class WidthConverter : IValueConverter
	{
		// Token: 0x060010A1 RID: 4257 RVA: 0x0004FAB4 File Offset: 0x0004DCB4
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			object result;
			try
			{
				result = (double)value - System.Convert.ToDouble(parameter);
			}
			catch
			{
				result = value;
			}
			return result;
		}

		// Token: 0x060010A2 RID: 4258 RVA: 0x0004FAEC File Offset: 0x0004DCEC
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return DependencyProperty.UnsetValue;
		}
	}
}
