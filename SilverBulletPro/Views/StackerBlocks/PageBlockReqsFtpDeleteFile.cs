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
	// Token: 0x020000DB RID: 219
	public class PageBlockReqsFtpDeleteFile : Page, IComponentConnector
	{
		// Token: 0x060005EA RID: 1514 RVA: 0x0001CA88 File Offset: 0x0001AC88
		public PageBlockReqsFtpDeleteFile(BlockFtpDeleteFile block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060005EB RID: 1515 RVA: 0x0001CAA0 File Offset: 0x0001ACA0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/ftp/pageblockreqsftpdeletefile.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060005EC RID: 1516 RVA: 0x0001CAD0 File Offset: 0x0001ACD0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060005ED RID: 1517 RVA: 0x0001CADA File Offset: 0x0001ACDA
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040002C6 RID: 710
		private bool _contentLoaded;
	}
}
