using System;
using System.Globalization;
using System.Windows.Data;

namespace SilverBulletPro.Converters
{
	// Token: 0x02000216 RID: 534
	public class NegatingConverter : IValueConverter
	{
		// Token: 0x06001086 RID: 4230 RVA: 0x0004F83B File Offset: 0x0004DA3B
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is double)
			{
				return -(double)value;
			}
			return value;
		}

		// Token: 0x06001087 RID: 4231 RVA: 0x0004F853 File Offset: 0x0004DA53
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is double)
			{
				return (double)value;
			}
			return value;
		}
	}
}
