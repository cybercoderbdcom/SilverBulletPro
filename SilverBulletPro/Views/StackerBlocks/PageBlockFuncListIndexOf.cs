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
	// Token: 0x02000078 RID: 120
	public class PageBlockFuncListIndexOf : Page, IComponentConnector
	{
		// Token: 0x06000434 RID: 1076 RVA: 0x000173BF File Offset: 0x000155BF
		public PageBlockFuncListIndexOf(BlockListIndexOf block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x000173D4 File Offset: 0x000155D4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/list/pageblockfunclistindexof.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000436 RID: 1078 RVA: 0x00017404 File Offset: 0x00015604
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000437 RID: 1079 RVA: 0x0001740E File Offset: 0x0001560E
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400021D RID: 541
		private bool _contentLoaded;
	}
}
