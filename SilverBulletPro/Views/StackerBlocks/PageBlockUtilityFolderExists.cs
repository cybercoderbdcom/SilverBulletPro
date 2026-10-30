using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using SilverBulletPro.Core.Blocks;

namespace SilverBulletPro.Views.StackerBlocks
{
	// Token: 0x02000172 RID: 370
	public class PageBlockUtilityFolderExists : Page, IComponentConnector
	{
		// Token: 0x0600088B RID: 2187 RVA: 0x00025193 File Offset: 0x00023393
		public PageBlockUtilityFolderExists(BlockFolderExists block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x0600088C RID: 2188 RVA: 0x000251A8 File Offset: 0x000233A8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/utility/files/pageblockutilityfolderexists.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600088D RID: 2189 RVA: 0x000251D8 File Offset: 0x000233D8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600088E RID: 2190 RVA: 0x000251E2 File Offset: 0x000233E2
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040003F9 RID: 1017
		private bool _contentLoaded;
	}
}
