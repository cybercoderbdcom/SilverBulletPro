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
	// Token: 0x02000072 RID: 114
	public class PageBlockCreateListOfNumbers : Page, IComponentConnector
	{
		// Token: 0x0600041C RID: 1052 RVA: 0x0001714B File Offset: 0x0001534B
		public PageBlockCreateListOfNumbers(BlockCreateListOfNumbers block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			this.inputControl.Minimum = -2147483648.0;
		}

		// Token: 0x0600041D RID: 1053 RVA: 0x00017174 File Offset: 0x00015374
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/list/pageblockcreatelistofnumbers.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600041E RID: 1054 RVA: 0x000171A4 File Offset: 0x000153A4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600041F RID: 1055 RVA: 0x000171AE File Offset: 0x000153AE
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.inputControl = (NumStrInputBox)target;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x04000215 RID: 533
		internal NumStrInputBox inputControl;

		// Token: 0x04000216 RID: 534
		private bool _contentLoaded;
	}
}
