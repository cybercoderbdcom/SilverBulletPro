using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SilverBulletPro.Converters
{
	// Token: 0x0200021A RID: 538
	public class StringEmptyToIsEnabledConverter : IValueConverter
	{
		// Token: 0x06001092 RID: 4242 RVA: 0x0004F9F9 File Offset: 0x0004DBF9
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return !string.IsNullOrWhiteSpace((string)value);
		}

		// Token: 0x06001093 RID: 4243 RVA: 0x0004FA0E File Offset: 0x0004DC0E
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return DependencyProperty.UnsetValue;
		}
	}
}
