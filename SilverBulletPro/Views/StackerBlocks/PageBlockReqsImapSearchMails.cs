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
	// Token: 0x020000F4 RID: 244
	public class PageBlockReqsImapSearchMails : Page, IComponentConnector
	{
		// Token: 0x0600065C RID: 1628 RVA: 0x0001E713 File Offset: 0x0001C913
		public PageBlockReqsImapSearchMails(BlockImapSearchMails block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x0600065D RID: 1629 RVA: 0x0001E728 File Offset: 0x0001C928
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/imap/pageblockreqsimapsearchmails.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600065E RID: 1630 RVA: 0x0001E758 File Offset: 0x0001C958
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600065F RID: 1631 RVA: 0x0001E762 File Offset: 0x0001C962
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400030C RID: 780
		private bool _contentLoaded;
	}
}
