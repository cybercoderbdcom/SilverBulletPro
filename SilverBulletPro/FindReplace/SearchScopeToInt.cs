using System;
using System.Globalization;
using System.Windows.Data;

namespace SilverBulletPro.FindReplace
{
	// Token: 0x020001DB RID: 475
	public class SearchScopeToInt : IValueConverter
	{
		// Token: 0x06000F0C RID: 3852 RVA: 0x0004C029 File Offset: 0x0004A229
		object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (int)value;
		}

		// Token: 0x06000F0D RID: 3853 RVA: 0x0004C036 File Offset: 0x0004A236
		object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (FindReplaceMgr.SearchScope)value;
		}
	}
}
