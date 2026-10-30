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
	// Token: 0x0200013F RID: 319
	public class PageBlockSeleniumPageKeyDown : Page, IComponentConnector
	{
		// Token: 0x06000790 RID: 1936 RVA: 0x00021B57 File Offset: 0x0001FD57
		public PageBlockSeleniumPageKeyDown(BlockSeleniumPageKeyDown block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000791 RID: 1937 RVA: 0x00021B6C File Offset: 0x0001FD6C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/selenium/page/pageblockseleniumpagekeydown.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000792 RID: 1938 RVA: 0x00021B9C File Offset: 0x0001FD9C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000793 RID: 1939 RVA: 0x00021BA6 File Offset: 0x0001FDA6
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000389 RID: 905
		private bool _contentLoaded;
	}
}
