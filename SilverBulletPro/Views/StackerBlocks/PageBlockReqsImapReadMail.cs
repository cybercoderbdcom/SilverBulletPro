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
	// Token: 0x020000F2 RID: 242
	public class PageBlockReqsImapReadMail : Page, IComponentConnector
	{
		// Token: 0x06000654 RID: 1620 RVA: 0x0001E662 File Offset: 0x0001C862
		public PageBlockReqsImapReadMail(BlockImapReadMail block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000655 RID: 1621 RVA: 0x0001E678 File Offset: 0x0001C878
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/imap/pageblockreqsimapreadmail.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000656 RID: 1622 RVA: 0x0001E6A8 File Offset: 0x0001C8A8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000657 RID: 1623 RVA: 0x0001E6B2 File Offset: 0x0001C8B2
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400030A RID: 778
		private bool _contentLoaded;
	}
}
