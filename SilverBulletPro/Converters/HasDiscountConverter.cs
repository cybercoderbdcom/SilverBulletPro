using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SilverBulletPro.Converters
{
	// Token: 0x0200020F RID: 527
	public class HasDiscountConverter : IValueConverter
	{
		// Token: 0x06001072 RID: 4210 RVA: 0x0004F60B File Offset: 0x0004D80B
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
			{
				return Visibility.Collapsed;
			}
			if (System.Convert.ToDouble(value.ToString().Replace("%", "")) > 0.0)
			{
				return Visibility.Visible;
			}
			return Visibility.Collapsed;
		}

		// Token: 0x06001073 RID: 4211 RVA: 0x0004F649 File Offset: 0x0004D849
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return DependencyProperty.UnsetValue;
		}
	}
}
