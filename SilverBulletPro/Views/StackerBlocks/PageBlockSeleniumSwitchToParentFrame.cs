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
	// Token: 0x02000149 RID: 329
	public class PageBlockSeleniumSwitchToParentFrame : Page, IComponentConnector
	{
		// Token: 0x060007BA RID: 1978 RVA: 0x00021FA7 File Offset: 0x000201A7
		public PageBlockSeleniumSwitchToParentFrame(BlockSeleniumSwitchToParentFrame block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060007BB RID: 1979 RVA: 0x00021FBC File Offset: 0x000201BC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/selenium/page/pageblockseleniumswitchtoparentframe.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060007BC RID: 1980 RVA: 0x00021FEC File Offset: 0x000201EC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060007BD RID: 1981 RVA: 0x00021FF6 File Offset: 0x000201F6
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000394 RID: 916
		private bool _contentLoaded;
	}
}
