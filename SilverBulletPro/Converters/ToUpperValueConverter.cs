using System;
using System.Globalization;
using System.Windows.Data;

namespace SilverBulletPro.Converters
{
	// Token: 0x0200021C RID: 540
	public class ToUpperValueConverter : IValueConverter
	{
		// Token: 0x0600109B RID: 4251 RVA: 0x0004FA54 File Offset: 0x0004DC54
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			string text = value as string;
			if (text != null)
			{
				return text.ToUpper();
			}
			return string.Empty;
		}

		// Token: 0x0600109C RID: 4252 RVA: 0x0004FA77 File Offset: 0x0004DC77
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Binding.DoNothing;
		}
	}
}
