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
	// Token: 0x020000F9 RID: 249
	public class PageBlockReqsPop3GetMails : Page, IComponentConnector
	{
		// Token: 0x06000673 RID: 1651 RVA: 0x0001ECCF File Offset: 0x0001CECF
		public PageBlockReqsPop3GetMails(BlockPop3GetMails block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000674 RID: 1652 RVA: 0x0001ECE4 File Offset: 0x0001CEE4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/pop3/pageblockreqspop3getmails.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000675 RID: 1653 RVA: 0x0001ED14 File Offset: 0x0001CF14
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000676 RID: 1654 RVA: 0x0001ED1E File Offset: 0x0001CF1E
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000316 RID: 790
		private bool _contentLoaded;
	}
}
