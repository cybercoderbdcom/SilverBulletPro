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
	// Token: 0x020000BC RID: 188
	public class PageBlockPuppeteerSetAttributeValue : Page, IComponentConnector
	{
		// Token: 0x06000565 RID: 1381 RVA: 0x0001B31C File Offset: 0x0001951C
		public PageBlockPuppeteerSetAttributeValue(BlockPuppeteerSetAttributeValue block)
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

		// Token: 0x06000566 RID: 1382 RVA: 0x0001B3B0 File Offset: 0x000195B0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/puppeteer/elements/pageblockpuppeteersetattributevalue.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000567 RID: 1383 RVA: 0x0001B3E0 File Offset: 0x000195E0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000568 RID: 1384 RVA: 0x0001B3EA File Offset: 0x000195EA
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

		// Token: 0x04000294 RID: 660
		internal ComboBox findByComboBox;

		// Token: 0x04000295 RID: 661
		private bool _contentLoaded;
	}
}
