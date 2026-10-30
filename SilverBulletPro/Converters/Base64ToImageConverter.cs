using System;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Data;
using SilverBulletPro.Core.Extensions;
using SilverBulletPro.Extensions;

namespace SilverBulletPro.Converters
{
	// Token: 0x02000203 RID: 515
	public class Base64ToImageConverter : IValueConverter
	{
		// Token: 0x0600104B RID: 4171 RVA: 0x0004F084 File Offset: 0x0004D284
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			object result;
			try
			{
				string text = (string)value;
				if (((parameter != null) ? parameter.ToString() : null) == "Ads" || ((parameter != null) ? parameter.ToString() : null) == "Notif")
				{
					if (string.IsNullOrWhiteSpace(text))
					{
						result = text;
					}
					else if (StringExtension.IsBase64(text))
					{
						result = ImageExtension.Base64ToBytes(text).ToImage();
					}
					else
					{
						result = value;
					}
				}
				else
				{
					if (value != null && text != null && !string.IsNullOrWhiteSpace(text))
					{
						if (StringExtension.IsBase64(text))
						{
							return ImageExtension.Base64ToBytes(text).ToImage();
						}
						if (File.Exists(text))
						{
							return ImageExtension.Base64ToBytes(ImageExtension.ToBase64(text)).ToImage();
						}
					}
					result = ImageExtension.Base64ToBytes("R0lGODlhAQABAIAAAP///wAAACH5BAEAAAAALAAAAAABAAEAAAICRAEAOw==").ToImage();
				}
			}
			catch
			{
				result = ImageExtension.Base64ToBytes("R0lGODlhAQABAIAAAP///wAAACH5BAEAAAAALAAAAAABAAEAAAICRAEAOw==").ToImage();
			}
			return result;
		}

		// Token: 0x0600104C RID: 4172 RVA: 0x0004F164 File Offset: 0x0004D364
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return DependencyProperty.UnsetValue;
		}
	}
}
