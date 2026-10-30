using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace SilverBulletPro.Animations
{
	// Token: 0x02000220 RID: 544
	public static class BackgroundColorAnimation
	{
		// Token: 0x060010A7 RID: 4263 RVA: 0x0004FB98 File Offset: 0x0004DD98
		public static void BeginAnimation(DependencyObject dp, Brush color, int animationDuration = 300)
		{
			Control control = dp as Control;
			try
			{
				if (control.Background.IsFrozen)
				{
					control.Background = control.Background.CloneCurrentValue();
				}
				ColorAnimation animation = new ColorAnimation
				{
					To = new Color?((Color)color.GetValue(SolidColorBrush.ColorProperty)),
					Duration = new Duration(TimeSpan.FromMilliseconds((double)animationDuration))
				};
				control.Background.BeginAnimation(SolidColorBrush.ColorProperty, animation);
			}
			catch
			{
				control.Background = color;
			}
		}
	}
}
