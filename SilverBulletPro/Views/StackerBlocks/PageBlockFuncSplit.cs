using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using AngleSharp.Text;
using SilverBulletPro.Core.Blocks;

namespace SilverBulletPro.Views.StackerBlocks
{
	// Token: 0x0200008E RID: 142
	public class PageBlockFuncSplit : Page, IComponentConnector
	{
		// Token: 0x0600048E RID: 1166 RVA: 0x00017F90 File Offset: 0x00016190
		public PageBlockFuncSplit(BlockSplit block)
		{
			this.InitializeComponent();
			this.vm = block;
			base.DataContext = block;
			foreach (object newItem in Enum.GetValues(typeof(StringSplitOptions)))
			{
				this.stringSplitOptionsComboBox.Items.Add(newItem);
			}
			if (block.StringSplitOption.ToString().Contains(","))
			{
				this.stringSplitOptionsComboBox.Text = block.StringSplitOption.ToString().Replace(" ", string.Empty);
			}
		}

		// Token: 0x0600048F RID: 1167 RVA: 0x00018064 File Offset: 0x00016264
		private void StringSplitOptionsComboBox_LostFocus(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(this.stringSplitOptionsComboBox.Text))
			{
				return;
			}
			try
			{
				this.vm.StringSplitOption = StringExtensions.ToEnum<StringSplitOptions>(this.stringSplitOptionsComboBox.Text, StringSplitOptions.None);
			}
			catch
			{
			}
		}

		// Token: 0x06000490 RID: 1168 RVA: 0x000180B8 File Offset: 0x000162B8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/string/pageblockfuncsplit.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000491 RID: 1169 RVA: 0x000180E8 File Offset: 0x000162E8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000492 RID: 1170 RVA: 0x000180F2 File Offset: 0x000162F2
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.stringSplitOptionsComboBox = (ComboBox)target;
				this.stringSplitOptionsComboBox.LostFocus += this.StringSplitOptionsComboBox_LostFocus;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x0400023B RID: 571
		private BlockSplit vm;

		// Token: 0x0400023C RID: 572
		internal ComboBox stringSplitOptionsComboBox;

		// Token: 0x0400023D RID: 573
		private bool _contentLoaded;
	}
}
