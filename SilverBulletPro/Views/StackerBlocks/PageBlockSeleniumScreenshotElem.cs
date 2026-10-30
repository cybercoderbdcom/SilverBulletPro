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
	// Token: 0x0200012F RID: 303
	public class PageBlockSeleniumScreenshotElem : Page, IComponentConnector
	{
		// Token: 0x06000750 RID: 1872 RVA: 0x00021020 File Offset: 0x0001F220
		public PageBlockSeleniumScreenshotElem(BlockSeleniumScreenshotElement block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			foreach (object obj in Enum.GetValues(typeof(FindElementBy)))
			{
				FindElementBy findElementBy = (FindElementBy)obj;
				this.findByComboBox.Items.Add(findElementBy);
			}
		}

		// Token: 0x06000751 RID: 1873 RVA: 0x000210A8 File Offset: 0x0001F2A8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/selenium/elements/pageblockseleniumscreenshotelem.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000752 RID: 1874 RVA: 0x000210D8 File Offset: 0x0001F2D8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000753 RID: 1875 RVA: 0x000210E2 File Offset: 0x0001F2E2
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.findByComboBox = (ComboBox)target;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x0400036E RID: 878
		internal ComboBox findByComboBox;

		// Token: 0x0400036F RID: 879
		private bool _contentLoaded;
	}
}
