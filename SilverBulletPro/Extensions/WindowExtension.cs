using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace SilverBulletPro.Extensions
{
	// Token: 0x02000200 RID: 512
	internal static class WindowExtension
	{
		// Token: 0x06001041 RID: 4161
		[DllImport("user32.dll")]
		private static extern int GetWindowLong(IntPtr hwnd, int index);

		// Token: 0x06001042 RID: 4162
		[DllImport("user32.dll")]
		private static extern int SetWindowLong(IntPtr hwnd, int index, int value);

		// Token: 0x06001043 RID: 4163 RVA: 0x0004EEFC File Offset: 0x0004D0FC
		internal static void DisableMinimizeAndMaximizeButtons(this Window window)
		{
			IntPtr handle = new WindowInteropHelper(window).Handle;
			int windowLong = WindowExtension.GetWindowLong(handle, -16);
			WindowExtension.SetWindowLong(handle, -16, windowLong & -65537 & -131073);
		}

		// Token: 0x06001044 RID: 4164 RVA: 0x0004EF34 File Offset: 0x0004D134
		internal static void DisableMinimizeButton(this Window window)
		{
			IntPtr handle = new WindowInteropHelper(window).Handle;
			WindowExtension.SetWindowLong(handle, -16, WindowExtension.GetWindowLong(handle, -16) & -65537);
		}

		// Token: 0x0400077E RID: 1918
		private const int GWL_STYLE = -16;

		// Token: 0x0400077F RID: 1919
		private const int WS_MAXIMIZEBOX = 65536;

		// Token: 0x04000780 RID: 1920
		private const int WS_MINIMIZEBOX = 131072;
	}
}
