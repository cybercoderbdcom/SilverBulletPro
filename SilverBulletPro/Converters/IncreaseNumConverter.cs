using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SilverBulletPro.Converters
{
	// Token: 0x02000211 RID: 529
	public class IncreaseNumConverter : IValueConverter
	{
		// Token: 0x06001077 RID: 4215 RVA: 0x0004F70C File Offset: 0x0004D90C
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return System.Convert.ToDouble(value) + System.Convert.ToDouble(parameter);
		}

		// Token: 0x06001078 RID: 4216 RVA: 0x0004F720 File Offset: 0x0004D920
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return DependencyProperty.UnsetValue;
		}
	}
}
