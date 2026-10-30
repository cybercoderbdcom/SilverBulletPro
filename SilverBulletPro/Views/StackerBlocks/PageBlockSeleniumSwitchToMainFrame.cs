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
	// Token: 0x02000148 RID: 328
	public class PageBlockSeleniumSwitchToMainFrame : Page, IComponentConnector
	{
		// Token: 0x060007B6 RID: 1974 RVA: 0x00021F4F File Offset: 0x0002014F
		public PageBlockSeleniumSwitchToMainFrame(BlockSeleniumSwitchToMainFrame block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060007B7 RID: 1975 RVA: 0x00021F64 File Offset: 0x00020164
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/selenium/page/pageblockseleniumswitchtomainframe.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060007B8 RID: 1976 RVA: 0x00021F94 File Offset: 0x00020194
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060007B9 RID: 1977 RVA: 0x00021F9E File Offset: 0x0002019E
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000393 RID: 915
		private bool _contentLoaded;
	}
}
