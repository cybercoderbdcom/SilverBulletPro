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
	// Token: 0x02000141 RID: 321
	public class PageBlockSeleniumPageKeyUp : Page, IComponentConnector
	{
		// Token: 0x06000798 RID: 1944 RVA: 0x00021C07 File Offset: 0x0001FE07
		public PageBlockSeleniumPageKeyUp(BlockSeleniumPageKeyUp block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000799 RID: 1945 RVA: 0x00021C1C File Offset: 0x0001FE1C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/selenium/page/pageblockseleniumpagekeyup.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600079A RID: 1946 RVA: 0x00021C4C File Offset: 0x0001FE4C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600079B RID: 1947 RVA: 0x00021C56 File Offset: 0x0001FE56
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400038B RID: 907
		private bool _contentLoaded;
	}
}
