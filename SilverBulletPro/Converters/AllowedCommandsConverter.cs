using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace SilverBulletPro.Converters
{
	// Token: 0x02000201 RID: 513
	public class AllowedCommandsConverter : IValueConverter
	{
		// Token: 0x06001045 RID: 4165 RVA: 0x0004EF64 File Offset: 0x0004D164
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			object result;
			try
			{
				if (value == null)
				{
					result = "";
				}
				else
				{
					result = string.Join(parameter.ToString(), (IEnumerable<string>)value);
				}
			}
			catch
			{
				result = value;
			}
			return result;
		}

		// Token: 0x06001046 RID: 4166 RVA: 0x0004EFA8 File Offset: 0x0004D1A8
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Binding.DoNothing;
		}
	}
}
