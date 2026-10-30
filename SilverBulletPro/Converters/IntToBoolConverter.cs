using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SilverBulletPro.Converters
{
	// Token: 0x02000212 RID: 530
	public class IntToBoolConverter : IValueConverter
	{
		// Token: 0x0600107A RID: 4218 RVA: 0x0004F730 File Offset: 0x0004D930
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			object result;
			try
			{
				result = !value.Equals(System.Convert.ToInt32(parameter));
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600107B RID: 4219 RVA: 0x0004F774 File Offset: 0x0004D974
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return DependencyProperty.UnsetValue;
		}
	}
}
