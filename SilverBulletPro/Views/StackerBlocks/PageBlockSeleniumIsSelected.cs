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
	// Token: 0x0200012C RID: 300
	public class PageBlockSeleniumIsSelected : Page, IComponentConnector
	{
		// Token: 0x06000744 RID: 1860 RVA: 0x00020D8C File Offset: 0x0001EF8C
		public PageBlockSeleniumIsSelected(BlockSeleniumIsSelected block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			foreach (object obj in Enum.GetValues(typeof(FindElementBy)))
			{
				FindElementBy findElementBy = (FindElementBy)obj;
				this.findByComboBox.Items.Add(findElementBy);
			}
		}

		// Token: 0x06000745 RID: 1861 RVA: 0x00020E14 File Offset: 0x0001F014
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/selenium/elements/pageblockseleniumisselected.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000746 RID: 1862 RVA: 0x00020E44 File Offset: 0x0001F044
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000747 RID: 1863 RVA: 0x00020E4E File Offset: 0x0001F04E
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

		// Token: 0x04000368 RID: 872
		internal ComboBox findByComboBox;

		// Token: 0x04000369 RID: 873
		private bool _contentLoaded;
	}
}
