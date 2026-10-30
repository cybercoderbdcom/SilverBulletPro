using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace SilverBulletPro.Extensions
{
	// Token: 0x020001F9 RID: 505
	public static class FrameExtension
	{
		// Token: 0x0600102A RID: 4138 RVA: 0x0004E818 File Offset: 0x0004CA18
		public static Frame CreateWithoutNavigation(Thickness borderThickness = default(Thickness))
		{
			Frame frame = new Frame
			{
				NavigationUIVisibility = NavigationUIVisibility.Hidden
			};
			if (borderThickness != default(Thickness))
			{
				frame.BorderThickness = borderThickness;
			}
			Frame frame2 = frame;
			NavigatedEventHandler value;
			if ((value = FrameExtension.<>O.<0>__Frame_Navigated) == null)
			{
				value = (FrameExtension.<>O.<0>__Frame_Navigated = new NavigatedEventHandler(FrameExtension.Frame_Navigated));
			}
			frame2.Navigated += value;
			return frame;
		}

		// Token: 0x0600102B RID: 4139 RVA: 0x0004E86C File Offset: 0x0004CA6C
		private static void Frame_Navigated(object sender, NavigationEventArgs e)
		{
			try
			{
				(sender as Frame).NavigationService.RemoveBackEntry();
			}
			catch
			{
			}
		}

		// Token: 0x020002E9 RID: 745
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x040009C6 RID: 2502
			public static NavigatedEventHandler <0>__Frame_Navigated;
		}
	}
}
