using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace SilverBulletPro.Animations
{
	// Token: 0x02000221 RID: 545
	public class ForegroundColorAnimation
	{
		// Token: 0x060010A8 RID: 4264 RVA: 0x0004FC2C File Offset: 0x0004DE2C
		public static void BeginAnimation(DependencyObject dp, Brush color, int animationDuration = 300)
		{
			if (dp == null)
			{
				return;
			}
			Control control = dp as Control;
			try
			{
				if (control.Foreground.IsFrozen)
				{
					control.Foreground = control.Foreground.CloneCurrentValue();
				}
				ColorAnimation animation = new ColorAnimation
				{
					To = new Color?((Color)color.GetValue(SolidColorBrush.ColorProperty)),
					Duration = new Duration(TimeSpan.FromMilliseconds((double)animationDuration))
				};
				control.Foreground.BeginAnimation(SolidColorBrush.ColorProperty, animation);
			}
			catch
			{
				control.Foreground = color;
			}
		}
	}
}
