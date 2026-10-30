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
	// Token: 0x0200009D RID: 157
	public class PageBlockFuncDateToUnixTime : Page, IComponentConnector
	{
		// Token: 0x060004CD RID: 1229 RVA: 0x000187E8 File Offset: 0x000169E8
		public PageBlockFuncDateToUnixTime(BlockDateToUnixTime block)
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

		// Token: 0x060004CE RID: 1230 RVA: 0x0001887C File Offset: 0x00016A7C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/time/pageblockfuncdatetounixtime.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060004CF RID: 1231 RVA: 0x000188AC File Offset: 0x00016AAC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060004D0 RID: 1232 RVA: 0x000188B6 File Offset: 0x00016AB6
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

		// Token: 0x04000250 RID: 592
		internal ComboBox comboBox;

		// Token: 0x04000251 RID: 593
		private bool _contentLoaded;
	}
}
