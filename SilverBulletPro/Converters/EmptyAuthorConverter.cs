using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SilverBulletPro.Converters
{
	// Token: 0x0200020C RID: 524
	public class EmptyAuthorConverter : IValueConverter
	{
		// Token: 0x06001069 RID: 4201 RVA: 0x0004F551 File Offset: 0x0004D751
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (string.IsNullOrWhiteSpace(value as string))
			{
				return "Anonymous";
			}
			return value;
		}

		// Token: 0x0600106A RID: 4202 RVA: 0x0004F567 File Offset: 0x0004D767
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return DependencyProperty.UnsetValue;
		}
	}
}
