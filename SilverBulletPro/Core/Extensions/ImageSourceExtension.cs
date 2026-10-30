using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SilverBulletPro.Core.Extensions
{
	// Token: 0x020001EE RID: 494
	public static class ImageSourceExtension
	{
		// Token: 0x06001015 RID: 4117 RVA: 0x0004DE88 File Offset: 0x0004C088
		public static ImageSource GetImage(string image)
		{
			BitmapImage bitmapImage = new BitmapImage();
			bitmapImage.BeginInit();
			int num;
			if (Convert.TryFromBase64String(image, new Span<byte>(new byte[image.Length]), out num))
			{
				byte[] array = Convert.FromBase64String(image);
				MemoryStream memoryStream = new MemoryStream();
				memoryStream.Write(array, 0, array.Length);
				memoryStream.Seek(0L, SeekOrigin.Begin);
				bitmapImage.StreamSource = memoryStream;
				bitmapImage.EndInit();
				bitmapImage.Freeze();
				return bitmapImage;
			}
			bitmapImage.UriSource = new Uri(image, UriKind.RelativeOrAbsolute);
			bitmapImage.EndInit();
			bitmapImage.Freeze();
			return bitmapImage;
		}

		// Token: 0x06001016 RID: 4118 RVA: 0x0004DF0C File Offset: 0x0004C10C
		public static BitmapImage ToImageSource(this Bitmap bitmap)
		{
			BitmapImage result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				bitmap.Save(memoryStream, ImageFormat.Bmp);
				memoryStream.Position = 0L;
				BitmapImage bitmapImage = new BitmapImage();
				bitmapImage.BeginInit();
				bitmapImage.StreamSource = memoryStream;
				bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
				bitmapImage.EndInit();
				bitmapImage.Freeze();
				result = bitmapImage;
			}
			return result;
		}
	}
}
