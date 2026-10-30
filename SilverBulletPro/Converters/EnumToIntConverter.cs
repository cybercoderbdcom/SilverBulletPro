using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SilverBulletPro.Converters
{
	// Token: 0x0200020E RID: 526
	public class EnumToIntConverter : IValueConverter
	{
		// Token: 0x0600106F RID: 4207 RVA: 0x0004F5C8 File Offset: 0x0004D7C8
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			object result;
			try
			{
				result = (int)value;
			}
			catch
			{
				result = parameter;
			}
			return result;
		}

		// Token: 0x06001070 RID: 4208 RVA: 0x0004F5FC File Offset: 0x0004D7FC
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return DependencyProperty.UnsetValue;
		}
	}
}
