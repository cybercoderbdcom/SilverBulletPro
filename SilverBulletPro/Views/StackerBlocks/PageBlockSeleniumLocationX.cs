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
	// Token: 0x0200012D RID: 301
	public class PageBlockSeleniumLocationX : Page, IComponentConnector
	{
		// Token: 0x06000748 RID: 1864 RVA: 0x00020E68 File Offset: 0x0001F068
		public PageBlockSeleniumLocationX(BlockSeleniumLocationX block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			foreach (object obj in Enum.GetValues(typeof(FindElementBy)))
			{
				FindElementBy findElementBy = (FindElementBy)obj;
				this.findByComboBox.Items.Add(findElementBy);
			}
		}

		// Token: 0x06000749 RID: 1865 RVA: 0x00020EF0 File Offset: 0x0001F0F0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/selenium/elements/pageblockseleniumlocationx.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600074A RID: 1866 RVA: 0x00020F20 File Offset: 0x0001F120
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600074B RID: 1867 RVA: 0x00020F2A File Offset: 0x0001F12A
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

		// Token: 0x0400036A RID: 874
		internal ComboBox findByComboBox;

		// Token: 0x0400036B RID: 875
		private bool _contentLoaded;
	}
}
