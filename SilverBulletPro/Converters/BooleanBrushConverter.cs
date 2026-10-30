using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace SilverBulletPro.Converters
{
	// Token: 0x02000204 RID: 516
	public class BooleanBrushConverter : IValueConverter
	{
		// Token: 0x0600104E RID: 4174 RVA: 0x0004F174 File Offset: 0x0004D374
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return new SolidColorBrush(((value != null) ? new bool?(value.Equals(true)) : null).Value ? Colors.Tomato : Colors.Yellow);
		}

		// Token: 0x0600104F RID: 4175 RVA: 0x0004F1BB File Offset: 0x0004D3BB
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return false;
		}
	}
}
