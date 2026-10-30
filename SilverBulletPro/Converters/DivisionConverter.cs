using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace SilverBulletPro.Converters
{
	// Token: 0x0200020B RID: 523
	public class DivisionConverter : MarkupExtension, IValueConverter
	{
		// Token: 0x06001065 RID: 4197 RVA: 0x0004F4EC File Offset: 0x0004D6EC
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			object result;
			try
			{
				result = System.Convert.ToDouble(value) / System.Convert.ToDouble(parameter);
			}
			catch
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x06001066 RID: 4198 RVA: 0x0004F52C File Offset: 0x0004D72C
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return DependencyProperty.UnsetValue;
		}

		// Token: 0x06001067 RID: 4199 RVA: 0x0004F533 File Offset: 0x0004D733
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			DivisionConverter result;
			if ((result = DivisionConverter._instance) == null)
			{
				result = (DivisionConverter._instance = new DivisionConverter());
			}
			return result;
		}

		// Token: 0x04000782 RID: 1922
		private static DivisionConverter _instance;
	}
}
