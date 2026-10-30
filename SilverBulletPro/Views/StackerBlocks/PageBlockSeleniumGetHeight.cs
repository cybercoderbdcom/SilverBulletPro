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
	// Token: 0x02000125 RID: 293
	public class PageBlockSeleniumGetHeight : Page, IComponentConnector
	{
		// Token: 0x06000728 RID: 1832 RVA: 0x00020788 File Offset: 0x0001E988
		public PageBlockSeleniumGetHeight(BlockSeleniumGetHeight block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			foreach (object obj in Enum.GetValues(typeof(FindElementBy)))
			{
				FindElementBy findElementBy = (FindElementBy)obj;
				this.findByComboBox.Items.Add(findElementBy);
			}
		}

		// Token: 0x06000729 RID: 1833 RVA: 0x00020810 File Offset: 0x0001EA10
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/selenium/elements/pageblockseleniumgetheight.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600072A RID: 1834 RVA: 0x00020840 File Offset: 0x0001EA40
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600072B RID: 1835 RVA: 0x0002084A File Offset: 0x0001EA4A
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

		// Token: 0x0400035A RID: 858
		internal ComboBox findByComboBox;

		// Token: 0x0400035B RID: 859
		private bool _contentLoaded;
	}
}
