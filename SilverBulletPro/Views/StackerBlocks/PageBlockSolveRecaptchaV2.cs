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
	// Token: 0x02000152 RID: 338
	public class PageBlockSolveRecaptchaV2 : Page, IComponentConnector
	{
		// Token: 0x060007FF RID: 2047 RVA: 0x00023B83 File Offset: 0x00021D83
		public PageBlockSolveRecaptchaV2(BlockSolveRecaptchaV2 block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000800 RID: 2048 RVA: 0x00023B98 File Offset: 0x00021D98
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/solvers/pageblocksolverecaptchav2.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000801 RID: 2049 RVA: 0x00023BC8 File Offset: 0x00021DC8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000802 RID: 2050 RVA: 0x00023BD2 File Offset: 0x00021DD2
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040003B9 RID: 953
		private bool _contentLoaded;
	}
}
