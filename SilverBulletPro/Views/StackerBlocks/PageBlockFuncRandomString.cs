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
	// Token: 0x02000088 RID: 136
	public class PageBlockFuncRandomString : Page, IComponentConnector
	{
		// Token: 0x06000474 RID: 1140 RVA: 0x00017AEF File Offset: 0x00015CEF
		public PageBlockFuncRandomString(BlockRandomString block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000475 RID: 1141 RVA: 0x00017B04 File Offset: 0x00015D04
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/string/pageblockfuncrandomstring.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x00017B34 File Offset: 0x00015D34
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x00017B3E File Offset: 0x00015D3E
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000231 RID: 561
		private bool _contentLoaded;
	}
}
