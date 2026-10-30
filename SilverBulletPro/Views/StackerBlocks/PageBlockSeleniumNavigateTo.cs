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
	// Token: 0x0200013E RID: 318
	public class PageBlockSeleniumNavigateTo : Page, IComponentConnector
	{
		// Token: 0x0600078C RID: 1932 RVA: 0x00021AFF File Offset: 0x0001FCFF
		public PageBlockSeleniumNavigateTo(BlockSeleniumNavigateTo block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x0600078D RID: 1933 RVA: 0x00021B14 File Offset: 0x0001FD14
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/selenium/page/pageblockseleniumnavigateto.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600078E RID: 1934 RVA: 0x00021B44 File Offset: 0x0001FD44
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600078F RID: 1935 RVA: 0x00021B4E File Offset: 0x0001FD4E
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000388 RID: 904
		private bool _contentLoaded;
	}
}
