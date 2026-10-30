using System;
using System.Windows;
using System.Windows.Media;

namespace SilverBulletPro.Extensions
{
	// Token: 0x020001FB RID: 507
	public static class ResourceExtension
	{
		// Token: 0x0600102D RID: 4141 RVA: 0x0004E8BC File Offset: 0x0004CABC
		public static Color GetColor(string propertyName, string defaultPropName = "")
		{
			Color color;
			try
			{
				color = ((SolidColorBrush)Application.Current.Resources[propertyName]).Color;
			}
			catch
			{
				color = ((SolidColorBrush)Application.Current.Resources[defaultPropName]).Color;
			}
			return color;
		}

		// Token: 0x0600102E RID: 4142 RVA: 0x0004E918 File Offset: 0x0004CB18
		public static SolidColorBrush GetBrush(string propertyName, string defaultPropName = "")
		{
			SolidColorBrush result;
			try
			{
				result = (SolidColorBrush)Application.Current.Resources[propertyName];
			}
			catch
			{
				result = (SolidColorBrush)Application.Current.Resources[defaultPropName];
			}
			return result;
		}

		// Token: 0x0600102F RID: 4143 RVA: 0x0004E968 File Offset: 0x0004CB68
		public static T Get<T>(string propertyName, string defaultPropName = "")
		{
			T result;
			try
			{
				result = (T)((object)Application.Current.Resources[propertyName]);
			}
			catch
			{
				result = (T)((object)Application.Current.Resources[defaultPropName]);
			}
			return result;
		}

		// Token: 0x06001030 RID: 4144 RVA: 0x0004E9B8 File Offset: 0x0004CBB8
		public static string FindResource(this string resourceKey)
		{
			return Application.Current.FindResource(resourceKey) as string;
		}
	}
}
