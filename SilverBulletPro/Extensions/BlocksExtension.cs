using System;
using System.Collections.Generic;
using System.Linq;
using PluginFrameworkPro;
using SilverBulletPro.Core.Blocks;

namespace SilverBulletPro.Extensions
{
	// Token: 0x020001F1 RID: 497
	public static class BlocksExtension
	{
		// Token: 0x0600101A RID: 4122 RVA: 0x0004E0B7 File Offset: 0x0004C2B7
		public static IEnumerable<BlockBase> OnlyPlugins(this IEnumerable<BlockBase> blocks)
		{
			return from b in blocks
			where b.IsPlugin()
			select b;
		}

		// Token: 0x0600101B RID: 4123 RVA: 0x0004E0DE File Offset: 0x0004C2DE
		public static bool IsPlugin(this BlockBase block)
		{
			return block.GetType().GetInterface("IBlockPlugin") == typeof(IBlockPlugin);
		}
	}
}
