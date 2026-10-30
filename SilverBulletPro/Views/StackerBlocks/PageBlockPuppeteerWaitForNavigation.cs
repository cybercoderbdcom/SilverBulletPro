using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using PuppeteerSharp;
using SilverBulletPro.Core.Blocks;

namespace SilverBulletPro.Views.StackerBlocks
{
	// Token: 0x020000D6 RID: 214
	public class PageBlockPuppeteerWaitForNavigation : Page, IComponentConnector
	{
		// Token: 0x060005D3 RID: 1491 RVA: 0x0001C3C0 File Offset: 0x0001A5C0
		public PageBlockPuppeteerWaitForNavigation(BlockPuppeteerWaitForNavigation block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			foreach (object obj in Enum.GetValues(typeof(WaitUntilNavigation)))
			{
				WaitUntilNavigation waitUntilNavigation = (WaitUntilNavigation)obj;
				this.loadedEventComboBox.Items.Add(waitUntilNavigation);
			}
		}

		// Token: 0x060005D4 RID: 1492 RVA: 0x0001C448 File Offset: 0x0001A648
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/puppeteer/page/pageblockpuppeteerwaitfornavigation.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060005D5 RID: 1493 RVA: 0x0001C478 File Offset: 0x0001A678
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060005D6 RID: 1494 RVA: 0x0001C482 File Offset: 0x0001A682
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.loadedEventComboBox = (ComboBox)target;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x040002BA RID: 698
		internal ComboBox loadedEventComboBox;

		// Token: 0x040002BB RID: 699
		private bool _contentLoaded;
	}
}
