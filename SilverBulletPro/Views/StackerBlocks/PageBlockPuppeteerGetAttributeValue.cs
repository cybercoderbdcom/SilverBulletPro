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
	// Token: 0x020000B0 RID: 176
	public class PageBlockPuppeteerGetAttributeValue : Page, IComponentConnector
	{
		// Token: 0x06000535 RID: 1333 RVA: 0x0001A83C File Offset: 0x00018A3C
		public PageBlockPuppeteerGetAttributeValue(BlockPuppeteerGetAttributeValue block)
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

		// Token: 0x06000536 RID: 1334 RVA: 0x0001A8D0 File Offset: 0x00018AD0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/puppeteer/elements/pageblockpuppeteergetattributevalue.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000537 RID: 1335 RVA: 0x0001A900 File Offset: 0x00018B00
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000538 RID: 1336 RVA: 0x0001A90A File Offset: 0x00018B0A
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

		// Token: 0x0400027C RID: 636
		internal ComboBox findByComboBox;

		// Token: 0x0400027D RID: 637
		private bool _contentLoaded;
	}
}
