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
	// Token: 0x02000153 RID: 339
	public class PageBlockSolveRecaptchaV3 : Page, IComponentConnector
	{
		// Token: 0x06000803 RID: 2051 RVA: 0x00023BDB File Offset: 0x00021DDB
		public PageBlockSolveRecaptchaV3(BlockSolveRecaptchaV3 block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			this.inputControl.Minimum = -3.4028234663852886E+38;
			this.inputControl.Maximum = 3.4028234663852886E+38;
		}

		// Token: 0x06000804 RID: 2052 RVA: 0x00023C18 File Offset: 0x00021E18
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/solvers/pageblocksolverecaptchav3.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000805 RID: 2053 RVA: 0x00023C48 File Offset: 0x00021E48
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000806 RID: 2054 RVA: 0x00023C52 File Offset: 0x00021E52
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

		// Token: 0x040003BA RID: 954
		internal NumStrInputBox inputControl;

		// Token: 0x040003BB RID: 955
		private bool _contentLoaded;
	}
}
