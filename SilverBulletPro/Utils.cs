using System;
using System.Windows;
using System.Windows.Media;

namespace SilverBulletPro
{
	// Token: 0x0200000F RID: 15
	public static class Utils
	{
		// Token: 0x06000071 RID: 113 RVA: 0x00002D78 File Offset: 0x00000F78
		public static Color GetColor(string propertyName)
		{
			Color color;
			try
			{
				color = ((SolidColorBrush)Application.Current.Resources[propertyName]).Color;
			}
			catch
			{
				color = ((SolidColorBrush)Application.Current.Resources["ForegroundMain"]).Color;
			}
			return color;
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00002DD8 File Offset: 0x00000FD8
		public static SolidColorBrush GetBrush(string propertyName)
		{
			SolidColorBrush result;
			try
			{
				result = (SolidColorBrush)Application.Current.Resources[propertyName];
			}
			catch
			{
				result = (SolidColorBrush)Application.Current.Resources["ForegroundMain"];
			}
			return result;
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00002E2C File Offset: 0x0000102C
		internal static string GetMainForeColor()
		{
			return Utils.GetColor("ForegroundMain").ToString();
		}
	}
}
