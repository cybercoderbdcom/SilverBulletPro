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
	// Token: 0x0200009B RID: 155
	public class PageBlockFuncCurrentUnixTime : Page, IComponentConnector
	{
		// Token: 0x060004C5 RID: 1221 RVA: 0x000186A4 File Offset: 0x000168A4
		public PageBlockFuncCurrentUnixTime(BlockCurrentUnixTime block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			this.comboBox.Items.Add("Seconds");
			this.comboBox.Items.Add("Milliseconds");
			this.comboBox.Items.Add("Microseconds");
			this.comboBox.Items.Add("Nanoseconds");
			if (this.comboBox.SelectedIndex == -1)
			{
				this.comboBox.SelectedIndex = 0;
			}
		}

		// Token: 0x060004C6 RID: 1222 RVA: 0x00018738 File Offset: 0x00016938
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/time/pageblockfunccurrentunixtime.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060004C7 RID: 1223 RVA: 0x00018768 File Offset: 0x00016968
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060004C8 RID: 1224 RVA: 0x00018772 File Offset: 0x00016972
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.comboBox = (ComboBox)target;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x0400024D RID: 589
		internal ComboBox comboBox;

		// Token: 0x0400024E RID: 590
		private bool _contentLoaded;
	}
}
