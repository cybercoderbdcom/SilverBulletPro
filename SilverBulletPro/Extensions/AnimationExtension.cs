using System;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;

namespace SilverBulletPro.Extensions
{
	// Token: 0x020001EF RID: 495
	public static class AnimationExtension
	{
		// Token: 0x06001017 RID: 4119 RVA: 0x0004DF78 File Offset: 0x0004C178
		public static void BlurApply(this UIElement element, double from, double to, TimeSpan duration, bool autoReverse = false)
		{
			Storyboard storyboard = new Storyboard();
			DoubleAnimation value = new DoubleAnimation
			{
				From = new double?(from),
				To = new double?(to),
				Duration = duration,
				AutoReverse = autoReverse
			};
			BlurEffect effect = new BlurEffect();
			element.Effect = effect;
			storyboard.Children.Add(value);
			Storyboard.SetTarget(storyboard, element.Effect);
			Storyboard.SetTargetProperty(storyboard, new PropertyPath("Radius", Array.Empty<object>()));
			storyboard.Begin();
		}

		// Token: 0x06001018 RID: 4120 RVA: 0x0004DFFC File Offset: 0x0004C1FC
		public static void BlurDisable(this UIElement element, TimeSpan duration)
		{
			BlurEffect blurEffect = element.Effect as BlurEffect;
			if (blurEffect == null || blurEffect.Radius == 0.0)
			{
				return;
			}
			DoubleAnimation animation = new DoubleAnimation(blurEffect.Radius, 0.0, duration);
			blurEffect.BeginAnimation(BlurEffect.RadiusProperty, animation);
		}
	}
}
