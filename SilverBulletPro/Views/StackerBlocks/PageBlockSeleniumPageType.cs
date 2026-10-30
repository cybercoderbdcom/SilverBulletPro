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
	// Token: 0x02000142 RID: 322
	public class PageBlockSeleniumPageType : Page, IComponentConnector
	{
		// Token: 0x0600079C RID: 1948 RVA: 0x00021C5F File Offset: 0x0001FE5F
		public PageBlockSeleniumPageType(BlockSeleniumPageType block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x0600079D RID: 1949 RVA: 0x00021C74 File Offset: 0x0001FE74
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/selenium/page/pageblockseleniumpagetype.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600079E RID: 1950 RVA: 0x00021CA4 File Offset: 0x0001FEA4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600079F RID: 1951 RVA: 0x00021CAE File Offset: 0x0001FEAE
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400038C RID: 908
		private bool _contentLoaded;
	}
}
