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
	// Token: 0x0200013B RID: 315
	public class PageBlockSeleniumExecuteJs : Page, IComponentConnector
	{
		// Token: 0x06000780 RID: 1920 RVA: 0x000219F7 File Offset: 0x0001FBF7
		public PageBlockSeleniumExecuteJs(BlockSeleniumExecuteJs block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000781 RID: 1921 RVA: 0x00021A0C File Offset: 0x0001FC0C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/selenium/page/pageblockseleniumexecutejs.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000782 RID: 1922 RVA: 0x00021A3C File Offset: 0x0001FC3C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000783 RID: 1923 RVA: 0x00021A46 File Offset: 0x0001FC46
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000385 RID: 901
		private bool _contentLoaded;
	}
}
