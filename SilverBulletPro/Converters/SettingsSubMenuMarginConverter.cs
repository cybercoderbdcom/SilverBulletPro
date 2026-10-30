using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SilverBulletPro.Converters
{
	// Token: 0x02000219 RID: 537
	internal class SettingsSubMenuMarginConverter : IMultiValueConverter
	{
		// Token: 0x0600108F RID: 4239 RVA: 0x0004F8FC File Offset: 0x0004DAFC
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			Thickness thickness = new Thickness(188.0, 31.0, 0.0, 0.0);
			if (values == null)
			{
				return thickness;
			}
			if (values.Length == 0 || values.Length == 1)
			{
				return thickness;
			}
			double? num = (double?)values[0] + (double?)values[1];
			if (num == null || num.Value == 0.0)
			{
				return thickness;
			}
			return new Thickness(num.Value, 31.0, 0.0, 0.0);
		}

		// Token: 0x06001090 RID: 4240 RVA: 0x0004F9E1 File Offset: 0x0004DBE1
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			return new object[]
			{
				DependencyProperty.UnsetValue
			};
		}
	}
}
