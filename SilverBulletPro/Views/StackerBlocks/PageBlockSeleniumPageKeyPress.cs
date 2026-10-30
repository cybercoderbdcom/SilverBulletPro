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
	// Token: 0x02000140 RID: 320
	public class PageBlockSeleniumPageKeyPress : Page, IComponentConnector
	{
		// Token: 0x06000794 RID: 1940 RVA: 0x00021BAF File Offset: 0x0001FDAF
		public PageBlockSeleniumPageKeyPress(BlockSeleniumPageKeyPress block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000795 RID: 1941 RVA: 0x00021BC4 File Offset: 0x0001FDC4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/selenium/page/pageblockseleniumpagekeypress.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000796 RID: 1942 RVA: 0x00021BF4 File Offset: 0x0001FDF4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000797 RID: 1943 RVA: 0x00021BFE File Offset: 0x0001FDFE
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400038A RID: 906
		private bool _contentLoaded;
	}
}
