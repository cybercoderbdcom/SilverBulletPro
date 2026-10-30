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
	// Token: 0x0200008B RID: 139
	public class PageBlockFuncRemoveString : Page, IComponentConnector
	{
		// Token: 0x06000482 RID: 1154 RVA: 0x00017E87 File Offset: 0x00016087
		public PageBlockFuncRemoveString(BlockRemoveStr block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000483 RID: 1155 RVA: 0x00017E9C File Offset: 0x0001609C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/string/pageblockfuncremovestring.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000484 RID: 1156 RVA: 0x00017ECC File Offset: 0x000160CC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000485 RID: 1157 RVA: 0x00017ED6 File Offset: 0x000160D6
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000238 RID: 568
		private bool _contentLoaded;
	}
}
