using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using SilverBulletPro.Core.Blocks;
using SilverBulletPro.Views.UserControls;

namespace SilverBulletPro.Views.StackerBlocks
{
	// Token: 0x020000A0 RID: 160
	public class PageBlockNativeLibInvoke : Page, IComponentConnector
	{
		// Token: 0x060004D9 RID: 1241 RVA: 0x00018A13 File Offset: 0x00016C13
		public PageBlockNativeLibInvoke(BlockNativeLibInvoke block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			this.rtParameters.AddItems(block.Parameters);
		}

		// Token: 0x060004DA RID: 1242 RVA: 0x00018A3C File Offset: 0x00016C3C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/interop/pageblocknativelibinvoke.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x00018A6C File Offset: 0x00016C6C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x00018A76 File Offset: 0x00016C76
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.rtParameters = (RichTextInputBox)target;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x04000255 RID: 597
		internal RichTextInputBox rtParameters;

		// Token: 0x04000256 RID: 598
		private bool _contentLoaded;
	}
}
