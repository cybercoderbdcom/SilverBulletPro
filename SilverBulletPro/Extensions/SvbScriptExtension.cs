using System;
using System.Linq;
using SilverBulletPro.Core.Blocks;
using SilverBulletPro.Core.Extensions;
using SilverBulletPro.Core.LS;
using SilverBulletPro.ViewModels;

namespace SilverBulletPro.Extensions
{
	// Token: 0x020001FD RID: 509
	internal class SvbScriptExtension
	{
		// Token: 0x0600103B RID: 4155 RVA: 0x0004EC18 File Offset: 0x0004CE18
		public static string[] GetListOfVariables(BlockBase take)
		{
			if (!GlobalData.SBSettings.General.AutoCompleteDefinedVariables)
			{
				return null;
			}
			int count = GlobalData.Stacker.Stack.IndexOf(GlobalData.Stacker.Stack.First((StackerBlockViewModel b) => b.Block == take));
			SvbScript svbScript = new SvbScript();
			svbScript.FromBlocks(GlobalData.Stacker.LS.ToBlocks().Take(count).ToList<BlockBase>());
			return ScriptExtension.GetListOfVariables(svbScript.Script);
		}
	}
}
