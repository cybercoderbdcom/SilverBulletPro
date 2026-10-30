using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using PuppeteerSharp.Input;
using SilverBulletPro.Core.Blocks;
using SilverBulletPro.Core.Extensions;

namespace SilverBulletPro.Views.StackerBlocks
{
	// Token: 0x020000AE RID: 174
	public class PageBlockPuppeteerClick : Page, IComponentConnector
	{
		// Token: 0x0600052D RID: 1325 RVA: 0x0001A5F8 File Offset: 0x000187F8
		public PageBlockPuppeteerClick(BlockPuppeteerClick block)
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
			foreach (object obj2 in Enum.GetValues(typeof(MouseButton)))
			{
				MouseButton mouseButton = (MouseButton)obj2;
				this.mouseButtonComboBox.Items.Add(mouseButton);
			}
		}

		// Token: 0x0600052E RID: 1326 RVA: 0x0001A6EC File Offset: 0x000188EC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/puppeteer/elements/pageblockpuppeteerclick.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600052F RID: 1327 RVA: 0x0001A71C File Offset: 0x0001891C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000530 RID: 1328 RVA: 0x0001A726 File Offset: 0x00018926
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
			if (connectionId != 2)
			{
				this._contentLoaded = true;
				return;
			}
			this.mouseButtonComboBox = (ComboBox)target;
		}

		// Token: 0x04000277 RID: 631
		internal ComboBox findByComboBox;

		// Token: 0x04000278 RID: 632
		internal ComboBox mouseButtonComboBox;

		// Token: 0x04000279 RID: 633
		private bool _contentLoaded;
	}
}
