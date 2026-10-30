using System;
using System.Globalization;
using System.Windows.Data;

namespace SilverBulletPro.Converters
{
	// Token: 0x02000208 RID: 520
	public class ComparisonConverter : IValueConverter
	{
		// Token: 0x0600105B RID: 4187 RVA: 0x0004F394 File Offset: 0x0004D594
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (value != null) ? new bool?(value.Equals(parameter)) : null;
		}

		// Token: 0x0600105C RID: 4188 RVA: 0x0004F3C0 File Offset: 0x0004D5C0
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
