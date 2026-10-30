using System;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SilverBulletPro.Extensions
{
	// Token: 0x020001FA RID: 506
	public static class MemoryStreamExtension
	{
		// Token: 0x0600102C RID: 4140 RVA: 0x0004E8A0 File Offset: 0x0004CAA0
		public static ImageSource ToImage(this MemoryStream ms)
		{
			BitmapImage bitmapImage = new BitmapImage();
			bitmapImage.BeginInit();
			bitmapImage.StreamSource = ms;
			bitmapImage.EndInit();
			return bitmapImage;
		}
	}
}
