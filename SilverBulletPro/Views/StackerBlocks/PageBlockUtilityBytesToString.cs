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
	// Token: 0x0200015D RID: 349
	public class PageBlockUtilityBytesToString : Page, IComponentConnector
	{
		// Token: 0x0600082B RID: 2091 RVA: 0x00024123 File Offset: 0x00022323
		public PageBlockUtilityBytesToString(BlockBytesToString block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x0600082C RID: 2092 RVA: 0x00024138 File Offset: 0x00022338
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/utility/conversion/pageblockutilitybytestostring.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600082D RID: 2093 RVA: 0x00024168 File Offset: 0x00022368
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600082E RID: 2094 RVA: 0x00024172 File Offset: 0x00022372
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040003CE RID: 974
		private bool _contentLoaded;
	}
}
