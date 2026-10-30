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
	// Token: 0x020000F3 RID: 243
	public class PageBlockReqsImapReadMailRaw : Page, IComponentConnector
	{
		// Token: 0x06000658 RID: 1624 RVA: 0x0001E6BB File Offset: 0x0001C8BB
		public PageBlockReqsImapReadMailRaw(BlockImapReadMailRaw block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000659 RID: 1625 RVA: 0x0001E6D0 File Offset: 0x0001C8D0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/imap/pageblockreqsimapreadmailraw.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600065A RID: 1626 RVA: 0x0001E700 File Offset: 0x0001C900
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600065B RID: 1627 RVA: 0x0001E70A File Offset: 0x0001C90A
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400030B RID: 779
		private bool _contentLoaded;
	}
}
