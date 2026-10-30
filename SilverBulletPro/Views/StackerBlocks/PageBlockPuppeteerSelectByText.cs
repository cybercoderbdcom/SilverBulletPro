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
	// Token: 0x020000BB RID: 187
	public class PageBlockPuppeteerSelectByText : Page, IComponentConnector
	{
		// Token: 0x06000561 RID: 1377 RVA: 0x0001B234 File Offset: 0x00019434
		public PageBlockPuppeteerSelectByText(BlockPuppeteerSelectByText block)
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

		// Token: 0x06000562 RID: 1378 RVA: 0x0001B2C8 File Offset: 0x000194C8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/puppeteer/elements/pageblockpuppeteerselectbytext.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000563 RID: 1379 RVA: 0x0001B2F8 File Offset: 0x000194F8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000564 RID: 1380 RVA: 0x0001B302 File Offset: 0x00019502
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

		// Token: 0x04000292 RID: 658
		internal ComboBox findByComboBox;

		// Token: 0x04000293 RID: 659
		private bool _contentLoaded;
	}
}
