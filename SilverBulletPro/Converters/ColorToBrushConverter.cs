using System;
using System.Drawing;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace SilverBulletPro.Converters
{
	// Token: 0x02000207 RID: 519
	public class ColorToBrushConverter : IValueConverter
	{
		// Token: 0x06001058 RID: 4184 RVA: 0x0004F2F8 File Offset: 0x0004D4F8
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			object result;
			try
			{
				System.Drawing.Color color = (System.Drawing.Color)value;
				result = new SolidColorBrush(new System.Windows.Media.Color
				{
					A = color.A,
					R = color.R,
					G = color.G,
					B = color.B
				});
			}
			catch
			{
				result = new SolidColorBrush(System.Windows.Media.Color.FromRgb(byte.MaxValue, byte.MaxValue, byte.MaxValue));
			}
			return result;
		}

		// Token: 0x06001059 RID: 4185 RVA: 0x0004F384 File Offset: 0x0004D584
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return DependencyProperty.UnsetValue;
		}
	}
}
