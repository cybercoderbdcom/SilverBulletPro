using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;
using SilverBulletPro.Models;

namespace SilverBulletPro.Converters
{
	// Token: 0x02000206 RID: 518
	public class CalcDiscountConverter : IValueConverter
	{
		// Token: 0x06001054 RID: 4180 RVA: 0x0004F21C File Offset: 0x0004D41C
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			MarketModel marketModel = (MarketModel)value;
			if (marketModel == null)
			{
				return -1;
			}
			if (marketModel.Discount == null)
			{
				return 0;
			}
			double num = System.Convert.ToDouble(marketModel.Discount.Replace("%", ""));
			double num2 = System.Convert.ToDouble(this.CleanPrice(marketModel.Price));
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendLiteral("$");
			defaultInterpolatedStringHandler.AppendFormatted<double>(num2 - num2 * num / 100.0);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x06001055 RID: 4181 RVA: 0x0004F2A8 File Offset: 0x0004D4A8
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return DependencyProperty.UnsetValue;
		}

		// Token: 0x06001056 RID: 4182 RVA: 0x0004F2AF File Offset: 0x0004D4AF
		private string CleanPrice(string price)
		{
			if (!char.IsDigit(price[0]))
			{
				return price.Remove(0, 1);
			}
			if (!char.IsDigit(price[price.Length - 1]))
			{
				return price.Remove(price.Length - 1, 1);
			}
			return price;
		}
	}
}
