using System;
using System.Windows;
using System.Windows.Media;

namespace SilverBulletPro.Extensions
{
	// Token: 0x020001FF RID: 511
	public static class VisualTreeExtensions
	{
		// Token: 0x0600103F RID: 4159 RVA: 0x0004EE00 File Offset: 0x0004D000
		public static T FindParent<T>(this DependencyObject child, string parentName) where T : DependencyObject
		{
			if (child == null)
			{
				return default(T);
			}
			T result = default(T);
			DependencyObject parent = VisualTreeHelper.GetParent(child);
			for (;;)
			{
				FrameworkElement frameworkElement = parent as FrameworkElement;
				if (frameworkElement.Name == parentName && frameworkElement is T)
				{
					break;
				}
				parent = VisualTreeHelper.GetParent(parent);
				if (parent == null)
				{
					return result;
				}
			}
			result = (T)((object)parent);
			return result;
		}

		// Token: 0x06001040 RID: 4160 RVA: 0x0004EE5C File Offset: 0x0004D05C
		public static T FindChild<T>(this DependencyObject parent, string childName) where T : DependencyObject
		{
			if (parent == null)
			{
				return default(T);
			}
			T t = default(T);
			int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
			for (int i = 0; i < childrenCount; i++)
			{
				DependencyObject child = VisualTreeHelper.GetChild(parent, i);
				if (!(child is T))
				{
					t = child.FindChild(childName);
					if (t != null)
					{
						break;
					}
				}
				else
				{
					if (string.IsNullOrEmpty(childName))
					{
						t = (T)((object)child);
						break;
					}
					FrameworkElement frameworkElement = child as FrameworkElement;
					if (frameworkElement != null && frameworkElement.Name == childName)
					{
						t = (T)((object)child);
						break;
					}
				}
			}
			return t;
		}
	}
}
