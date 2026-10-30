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
	// Token: 0x020000EF RID: 239
	public class PageBlockReqsImapDisconnect : Page, IComponentConnector
	{
		// Token: 0x06000647 RID: 1607 RVA: 0x0001E387 File Offset: 0x0001C587
		public PageBlockReqsImapDisconnect(BlockImapDisconnect block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000648 RID: 1608 RVA: 0x0001E39C File Offset: 0x0001C59C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/imap/pageblockreqsimapdisconnect.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000649 RID: 1609 RVA: 0x0001E3CC File Offset: 0x0001C5CC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600064A RID: 1610 RVA: 0x0001E3D6 File Offset: 0x0001C5D6
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000302 RID: 770
		private bool _contentLoaded;
	}
}
