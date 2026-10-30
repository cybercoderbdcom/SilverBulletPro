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
	// Token: 0x02000104 RID: 260
	public class PageBlockReqsSshAuthPk : Page, IComponentConnector
	{
		// Token: 0x060006A4 RID: 1700 RVA: 0x0001F843 File Offset: 0x0001DA43
		public PageBlockReqsSshAuthPk(BlockSshAuthenticateWithPK block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060006A5 RID: 1701 RVA: 0x0001F858 File Offset: 0x0001DA58
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/ssh/pageblockreqssshauthpk.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060006A6 RID: 1702 RVA: 0x0001F888 File Offset: 0x0001DA88
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060006A7 RID: 1703 RVA: 0x0001F892 File Offset: 0x0001DA92
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000330 RID: 816
		private bool _contentLoaded;
	}
}
