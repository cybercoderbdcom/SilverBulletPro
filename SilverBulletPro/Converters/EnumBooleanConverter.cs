using System;
using System.Globalization;
using System.Windows.Data;

namespace SilverBulletPro.Converters
{
	// Token: 0x0200020D RID: 525
	public class EnumBooleanConverter : IValueConverter
	{
		// Token: 0x0600106C RID: 4204 RVA: 0x0004F578 File Offset: 0x0004D778
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (value != null) ? new bool?(value.Equals(parameter)) : null;
		}

		// Token: 0x0600106D RID: 4205 RVA: 0x0004F5A4 File Offset: 0x0004D7A4
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null || !value.Equals(true))
			{
				return Binding.DoNothing;
			}
			return parameter;
		}
	}
}
