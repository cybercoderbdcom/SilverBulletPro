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
	// Token: 0x02000106 RID: 262
	public class PageBlockReqsSshRunCommand : Page, IComponentConnector
	{
		// Token: 0x060006AC RID: 1708 RVA: 0x0001F8F3 File Offset: 0x0001DAF3
		public PageBlockReqsSshRunCommand(BlockSshRunCommand block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060006AD RID: 1709 RVA: 0x0001F908 File Offset: 0x0001DB08
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/ssh/pageblockreqssshruncommand.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060006AE RID: 1710 RVA: 0x0001F938 File Offset: 0x0001DB38
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060006AF RID: 1711 RVA: 0x0001F942 File Offset: 0x0001DB42
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000332 RID: 818
		private bool _contentLoaded;
	}
}
