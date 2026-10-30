using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using AngleSharp.Text;
using SilverBulletPro.Core.Blocks;

namespace SilverBulletPro.Views.StackerBlocks
{
	// Token: 0x0200008A RID: 138
	public class PageBlockFuncRegexReplace : Page, IComponentConnector
	{
		// Token: 0x0600047D RID: 1149 RVA: 0x00017CE8 File Offset: 0x00015EE8
		public PageBlockFuncRegexReplace(BlockRegexReplace block)
		{
			this.InitializeComponent();
			this.vm = block;
			base.DataContext = block;
			foreach (object obj in Enum.GetValues(typeof(RegexOptions)))
			{
				RegexOptions regexOptions = (RegexOptions)obj;
				this.regexOptionComboBox.Items.Add(regexOptions);
			}
			if (block.RegexOptions.ToString().Contains(","))
			{
				this.regexOptionComboBox.Text = block.RegexOptions.ToString().Replace(" ", string.Empty);
			}
		}

		// Token: 0x0600047E RID: 1150 RVA: 0x00017DC8 File Offset: 0x00015FC8
		private void RegexOptionComboBox_LostFocus(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(this.regexOptionComboBox.Text))
			{
				return;
			}
			try
			{
				this.vm.RegexOptions = StringExtensions.ToEnum<RegexOptions>(this.regexOptionComboBox.Text, RegexOptions.Singleline);
			}
			catch
			{
			}
		}

		// Token: 0x0600047F RID: 1151 RVA: 0x00017E1C File Offset: 0x0001601C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/string/pageblockfuncregexreplace.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x00017E4C File Offset: 0x0001604C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000481 RID: 1153 RVA: 0x00017E56 File Offset: 0x00016056
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.regexOptionComboBox = (ComboBox)target;
				this.regexOptionComboBox.LostFocus += this.RegexOptionComboBox_LostFocus;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x04000235 RID: 565
		private BlockRegexReplace vm;

		// Token: 0x04000236 RID: 566
		internal ComboBox regexOptionComboBox;

		// Token: 0x04000237 RID: 567
		private bool _contentLoaded;
	}
}
