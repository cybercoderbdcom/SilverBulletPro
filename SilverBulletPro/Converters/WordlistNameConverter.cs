using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;
using SilverBulletPro.Core.Enums;

namespace SilverBulletPro.Converters
{
	// Token: 0x0200021F RID: 543
	public class WordlistNameConverter : IMultiValueConverter
	{
		// Token: 0x060010A4 RID: 4260 RVA: 0x0004FAFC File Offset: 0x0004DCFC
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			object result;
			try
			{
				bool flag = (DataPoolType)values[0] != null;
				string text = values[1] as string;
				long value = (long)values[2];
				if (!flag)
				{
					string str = text;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 1);
					defaultInterpolatedStringHandler.AppendLiteral(" (");
					defaultInterpolatedStringHandler.AppendFormatted<long>(value);
					defaultInterpolatedStringHandler.AppendLiteral(")");
					result = str + defaultInterpolatedStringHandler.ToStringAndClear();
				}
				else
				{
					result = string.Empty;
				}
			}
			catch
			{
				result = string.Empty;
			}
			return result;
		}

		// Token: 0x060010A5 RID: 4261 RVA: 0x0004FB80 File Offset: 0x0004DD80
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			return new object[]
			{
				DependencyProperty.UnsetValue
			};
		}
	}
}
