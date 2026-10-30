using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using SilverBulletPro.Core.Blocks;
using SilverBulletPro.Core.Extensions;

namespace SilverBulletPro.Views.StackerBlocks
{
	// Token: 0x020000C2 RID: 194
	public class PageBlockPuppeteerWaitForElem : Page, IComponentConnector
	{
		// Token: 0x0600057F RID: 1407 RVA: 0x0001B994 File Offset: 0x00019B94
		public PageBlockPuppeteerWaitForElem(BlockPuppeteerWaitForElement block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			foreach (object obj in Enum.GetValues(typeof(FindElementBy)))
			{
				FindElementBy findElementBy = (FindElementBy)obj;
				if (ReflectionExtension.GetAttribute<IgnorePuppeteer>(findElementBy) == null)
				{
					this.findByComboBox.Items.Add(findElementBy);
				}
			}
		}

		// Token: 0x06000580 RID: 1408 RVA: 0x0001BA28 File Offset: 0x00019C28
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/puppeteer/elements/pageblockpuppeteerwaitforelem.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000581 RID: 1409 RVA: 0x0001BA58 File Offset: 0x00019C58
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000582 RID: 1410 RVA: 0x0001BA62 File Offset: 0x00019C62
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

		// Token: 0x040002A1 RID: 673
		internal ComboBox findByComboBox;

		// Token: 0x040002A2 RID: 674
		private bool _contentLoaded;
	}
}
