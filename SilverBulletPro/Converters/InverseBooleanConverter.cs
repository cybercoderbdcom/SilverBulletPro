using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SilverBulletPro.Converters
{
	// Token: 0x02000213 RID: 531
	[ValueConversion(typeof(bool), typeof(bool))]
	public class InverseBooleanConverter : IValueConverter
	{
		// Token: 0x0600107D RID: 4221 RVA: 0x0004F783 File Offset: 0x0004D983
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (targetType != typeof(bool))
			{
				throw new InvalidOperationException("The target must be a boolean");
			}
			return !(bool)value;
		}

		// Token: 0x0600107E RID: 4222 RVA: 0x0004F7B0 File Offset: 0x0004D9B0
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return DependencyProperty.UnsetValue;
		}
	}
}
