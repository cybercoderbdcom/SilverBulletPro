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
	// Token: 0x02000117 RID: 279
	public class PageBlockSeleniumGoBack : Page, IComponentConnector
	{
		// Token: 0x060006F0 RID: 1776 RVA: 0x00020023 File Offset: 0x0001E223
		public PageBlockSeleniumGoBack(BlockSeleniumGoBack block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060006F1 RID: 1777 RVA: 0x00020038 File Offset: 0x0001E238
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/selenium/browser/pageblockseleniumgoback.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060006F2 RID: 1778 RVA: 0x00020068 File Offset: 0x0001E268
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060006F3 RID: 1779 RVA: 0x00020072 File Offset: 0x0001E272
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000347 RID: 839
		private bool _contentLoaded;
	}
}
