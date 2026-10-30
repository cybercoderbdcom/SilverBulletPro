using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace SilverBulletPro.Converters
{
	// Token: 0x0200021B RID: 539
	public class SubtractConverter : MarkupExtension, IValueConverter
	{
		// Token: 0x17000244 RID: 580
		// (get) Token: 0x06001095 RID: 4245 RVA: 0x0004FA1D File Offset: 0x0004DC1D
		// (set) Token: 0x06001096 RID: 4246 RVA: 0x0004FA25 File Offset: 0x0004DC25
		public double Value { get; set; }

		// Token: 0x06001097 RID: 4247 RVA: 0x0004FA2E File Offset: 0x0004DC2E
		public object Convert(object baseValue, Type targetType, object parameter, CultureInfo culture)
		{
			return System.Convert.ToDouble(baseValue) - this.Value;
		}

		// Token: 0x06001098 RID: 4248 RVA: 0x0004FA42 File Offset: 0x0004DC42
		public object ConvertBack(object baseValue, Type targetType, object parameter, CultureInfo culture)
		{
			return DependencyProperty.UnsetValue;
		}

		// Token: 0x06001099 RID: 4249 RVA: 0x0004FA49 File Offset: 0x0004DC49
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return this;
		}
	}
}
