using System;
using System.Windows.Threading;

namespace SilverBulletPro.Extensions
{
	// Token: 0x020001F7 RID: 503
	internal static class DispatcherExtension
	{
		// Token: 0x06001027 RID: 4135 RVA: 0x0004E771 File Offset: 0x0004C971
		public static void InvokeIfRequired(this Dispatcher dispatcher, Action action, DispatcherPriority priority = DispatcherPriority.ContextIdle)
		{
			if (dispatcher == null)
			{
				return;
			}
			if (!dispatcher.CheckAccess())
			{
				dispatcher.BeginInvoke(action, priority, Array.Empty<object>());
				return;
			}
			action();
		}
	}
}
