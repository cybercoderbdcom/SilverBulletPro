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
	// Token: 0x02000123 RID: 291
	public class PageBlockSeleniumGetAttributeValue : Page, IComponentConnector
	{
		// Token: 0x06000720 RID: 1824 RVA: 0x000205D0 File Offset: 0x0001E7D0
		public PageBlockSeleniumGetAttributeValue(BlockSeleniumGetAttributeValue block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			foreach (object obj in Enum.GetValues(typeof(FindElementBy)))
			{
				FindElementBy findElementBy = (FindElementBy)obj;
				this.findByComboBox.Items.Add(findElementBy);
			}
		}

		// Token: 0x06000721 RID: 1825 RVA: 0x00020658 File Offset: 0x0001E858
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/selenium/elements/pageblockseleniumgetattributevalue.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000722 RID: 1826 RVA: 0x00020688 File Offset: 0x0001E888
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000723 RID: 1827 RVA: 0x00020692 File Offset: 0x0001E892
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

		// Token: 0x04000356 RID: 854
		internal ComboBox findByComboBox;

		// Token: 0x04000357 RID: 855
		private bool _contentLoaded;
	}
}
