using System;
using System.Runtime.CompilerServices;

namespace SilverBulletPro.Plugins
{
	// Token: 0x020001E3 RID: 483
	public interface IControl
	{
		// Token: 0x06000F53 RID: 3923
		[return: Dynamic]
		dynamic GetValue();

		// Token: 0x06000F54 RID: 3924
		void SetValue(dynamic value);
	}
}
