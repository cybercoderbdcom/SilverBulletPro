using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using SilverBulletPro.Core.Blocks;

namespace SilverBulletPro.Converters
{
	// Token: 0x02000205 RID: 517
	internal class CalcDateTimeDifferenceConverter : IValueConverter
	{
		// Token: 0x06001051 RID: 4177 RVA: 0x0004F1CC File Offset: 0x0004D3CC
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			object result;
			try
			{
				result = BlockCalcRelativeTime.Calculate(DateTime.Parse(value.ToString()));
			}
			catch
			{
				result = BlockCalcRelativeTime.Calculate(DateTime.Now);
			}
			return result;
		}

		// Token: 0x06001052 RID: 4178 RVA: 0x0004F20C File Offset: 0x0004D40C
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return DependencyProperty.UnsetValue;
		}
	}
}
