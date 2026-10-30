using System;
using System.Globalization;
using System.Windows.Data;

namespace SilverBulletPro.FindReplace
{
	// Token: 0x020001DC RID: 476
	public class BoolToInt : IValueConverter
	{
		// Token: 0x06000F0F RID: 3855 RVA: 0x0004C04B File Offset: 0x0004A24B
		object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if ((bool)value)
			{
				return 1;
			}
			return 0;
		}

		// Token: 0x06000F10 RID: 3856 RVA: 0x0004C062 File Offset: 0x0004A262
		object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
