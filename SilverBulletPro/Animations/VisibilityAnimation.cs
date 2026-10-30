using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media.Animation;

namespace SilverBulletPro.Animations
{
	// Token: 0x02000222 RID: 546
	public static class VisibilityAnimation
	{
		// Token: 0x060010AA RID: 4266 RVA: 0x0004FCCC File Offset: 0x0004DECC
		public static void BeginAnimation(DependencyObject dp, Visibility visibility, int animationDuration = 300)
		{
			DoubleAnimation doubleAnimation = new DoubleAnimation
			{
				Duration = new Duration(TimeSpan.FromMilliseconds((double)animationDuration))
			};
			FrameworkElement frameworkElement = dp as FrameworkElement;
			doubleAnimation.Completed += delegate([Nullable(2)] object sender, EventArgs eventArgs)
			{
				frameworkElement.Visibility = visibility;
			};
			if (visibility == Visibility.Collapsed || visibility == Visibility.Hidden)
			{
				doubleAnimation.From = new double?(1.0);
				doubleAnimation.To = new double?(0.0);
			}
			else
			{
				frameworkElement.Visibility = Visibility.Visible;
				doubleAnimation.From = new double?(0.0);
				doubleAnimation.To = new double?(1.0);
			}
			frameworkElement.BeginAnimation(UIElement.OpacityProperty, doubleAnimation);
		}
	}
}
