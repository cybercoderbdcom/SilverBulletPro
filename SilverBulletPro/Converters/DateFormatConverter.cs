using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SilverBulletPro.Converters
{
	// Token: 0x0200020A RID: 522
	public class DateFormatConverter : IValueConverter
	{
		// Token: 0x06001062 RID: 4194 RVA: 0x0004F4AC File Offset: 0x0004D6AC
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
			{
				return null;
			}
			return DateTime.Parse(value.ToString()).ToString(parameter as string, DateTimeFormatInfo.InvariantInfo);
		}

		// Token: 0x06001063 RID: 4195 RVA: 0x0004F4DC File Offset: 0x0004D6DC
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return DependencyProperty.UnsetValue;
		}
	}
}
