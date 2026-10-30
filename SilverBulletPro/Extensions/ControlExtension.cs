using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace SilverBulletPro.Extensions
{
	// Token: 0x020001F6 RID: 502
	public static class ControlExtension
	{
		// Token: 0x06001025 RID: 4133 RVA: 0x0004E708 File Offset: 0x0004C908
		public static T GetVisualChild<T>(this Visual parent) where T : Visual
		{
			T t = default(T);
			int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
			for (int i = 0; i < childrenCount; i++)
			{
				Visual visual = (Visual)VisualTreeHelper.GetChild(parent, i);
				t = (visual as T);
				if (t == null)
				{
					t = visual.GetVisualChild<T>();
				}
				if (t != null)
				{
					break;
				}
			}
			return t;
		}

		// Token: 0x06001026 RID: 4134 RVA: 0x0004E761 File Offset: 0x0004C961
		public static IEnumerable<T> FindVisualChildren<T>([NotNull] this DependencyObject parent) where T : DependencyObject
		{
			if (parent == null)
			{
				throw new ArgumentNullException("parent");
			}
			Queue<DependencyObject> queue = new Queue<DependencyObject>(new DependencyObject[]
			{
				parent
			});
			while (queue.Any<DependencyObject>())
			{
				DependencyObject reference = queue.Dequeue();
				int count = VisualTreeHelper.GetChildrenCount(reference);
				int num;
				for (int i = 0; i < count; i = num + 1)
				{
					DependencyObject child = VisualTreeHelper.GetChild(reference, i);
					T t = child as T;
					if (t != null)
					{
						yield return t;
					}
					queue.Enqueue(child);
					child = null;
					num = i;
				}
				reference = null;
			}
			yield break;
		}
	}
}
