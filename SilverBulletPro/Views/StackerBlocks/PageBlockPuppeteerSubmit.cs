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
	// Token: 0x020000BD RID: 189
	public class PageBlockPuppeteerSubmit : Page, IComponentConnector
	{
		// Token: 0x06000569 RID: 1385 RVA: 0x0001B404 File Offset: 0x00019604
		public PageBlockPuppeteerSubmit(BlockPuppeteerSubmit block)
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

		// Token: 0x0600056A RID: 1386 RVA: 0x0001B498 File Offset: 0x00019698
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/puppeteer/elements/pageblockpuppeteersubmit.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600056B RID: 1387 RVA: 0x0001B4C8 File Offset: 0x000196C8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600056C RID: 1388 RVA: 0x0001B4D2 File Offset: 0x000196D2
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

		// Token: 0x04000296 RID: 662
		internal ComboBox findByComboBox;

		// Token: 0x04000297 RID: 663
		private bool _contentLoaded;
	}
}
