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
	// Token: 0x0200013D RID: 317
	public class PageBlockSeleniumGetDOM : Page, IComponentConnector
	{
		// Token: 0x06000788 RID: 1928 RVA: 0x00021AA7 File Offset: 0x0001FCA7
		public PageBlockSeleniumGetDOM(BlockSeleniumGetDOM block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000789 RID: 1929 RVA: 0x00021ABC File Offset: 0x0001FCBC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/selenium/page/pageblockseleniumgetdom.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600078A RID: 1930 RVA: 0x00021AEC File Offset: 0x0001FCEC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600078B RID: 1931 RVA: 0x00021AF6 File Offset: 0x0001FCF6
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000387 RID: 903
		private bool _contentLoaded;
	}
}
