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
	// Token: 0x0200009E RID: 158
	public class PageBlockFuncUnixTimeToDate : Page, IComponentConnector
	{
		// Token: 0x060004D1 RID: 1233 RVA: 0x000188D0 File Offset: 0x00016AD0
		public PageBlockFuncUnixTimeToDate(BlockUnixTimeToDate block)
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

		// Token: 0x060004D2 RID: 1234 RVA: 0x00018964 File Offset: 0x00016B64
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/time/pageblockfuncunixtimetodate.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x00018994 File Offset: 0x00016B94
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060004D4 RID: 1236 RVA: 0x0001899E File Offset: 0x00016B9E
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

		// Token: 0x04000252 RID: 594
		internal ComboBox comboBox;

		// Token: 0x04000253 RID: 595
		private bool _contentLoaded;
	}
}
