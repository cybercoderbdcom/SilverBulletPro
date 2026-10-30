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
	// Token: 0x02000109 RID: 265
	public class PageBlockReqsTcpRead : Page, IComponentConnector
	{
		// Token: 0x060006B8 RID: 1720 RVA: 0x0001F9FB File Offset: 0x0001DBFB
		public PageBlockReqsTcpRead(BlockTcpRead block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060006B9 RID: 1721 RVA: 0x0001FA10 File Offset: 0x0001DC10
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/tcp/pageblockreqstcpread.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060006BA RID: 1722 RVA: 0x0001FA40 File Offset: 0x0001DC40
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060006BB RID: 1723 RVA: 0x0001FA4A File Offset: 0x0001DC4A
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000335 RID: 821
		private bool _contentLoaded;
	}
}
