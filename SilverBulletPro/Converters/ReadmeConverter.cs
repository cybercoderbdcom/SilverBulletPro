using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SilverBulletPro.Converters
{
	// Token: 0x02000218 RID: 536
	public class ReadmeConverter : IValueConverter
	{
		// Token: 0x0600108C RID: 4236 RVA: 0x0004F890 File Offset: 0x0004DA90
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			object result;
			try
			{
				if (value == null)
				{
					result = "None";
				}
				else
				{
					result = (value as string).Split(new string[]
					{
						"\r",
						"\n"
					}, StringSplitOptions.RemoveEmptyEntries)[0];
				}
			}
			catch
			{
				result = "None";
			}
			return result;
		}

		// Token: 0x0600108D RID: 4237 RVA: 0x0004F8EC File Offset: 0x0004DAEC
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return DependencyProperty.UnsetValue;
		}
	}
}
