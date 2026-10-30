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
	// Token: 0x020000F7 RID: 247
	public class PageBlockReqsPop3DeleteMail : Page, IComponentConnector
	{
		// Token: 0x0600066B RID: 1643 RVA: 0x0001EC1F File Offset: 0x0001CE1F
		public PageBlockReqsPop3DeleteMail(BlockPop3DeleteMail block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x0600066C RID: 1644 RVA: 0x0001EC34 File Offset: 0x0001CE34
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/pop3/pageblockreqspop3deletemail.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600066D RID: 1645 RVA: 0x0001EC64 File Offset: 0x0001CE64
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600066E RID: 1646 RVA: 0x0001EC6E File Offset: 0x0001CE6E
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000314 RID: 788
		private bool _contentLoaded;
	}
}
