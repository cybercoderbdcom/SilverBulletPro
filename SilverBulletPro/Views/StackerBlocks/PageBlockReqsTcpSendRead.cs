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
	// Token: 0x0200010B RID: 267
	public class PageBlockReqsTcpSendRead : Page, IComponentConnector
	{
		// Token: 0x060006C0 RID: 1728 RVA: 0x0001FAAB File Offset: 0x0001DCAB
		public PageBlockReqsTcpSendRead(BlockTcpSendRead block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060006C1 RID: 1729 RVA: 0x0001FAC0 File Offset: 0x0001DCC0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/tcp/pageblockreqstcpsendread.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060006C2 RID: 1730 RVA: 0x0001FAF0 File Offset: 0x0001DCF0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060006C3 RID: 1731 RVA: 0x0001FAFA File Offset: 0x0001DCFA
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000337 RID: 823
		private bool _contentLoaded;
	}
}
