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
	// Token: 0x02000089 RID: 137
	public class PageBlockFuncRegexMatch : Page, IComponentConnector
	{
		// Token: 0x06000478 RID: 1144 RVA: 0x00017B48 File Offset: 0x00015D48
		public PageBlockFuncRegexMatch(BlockRegexMatch block)
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

		// Token: 0x06000479 RID: 1145 RVA: 0x00017C28 File Offset: 0x00015E28
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

		// Token: 0x0600047A RID: 1146 RVA: 0x00017C7C File Offset: 0x00015E7C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/string/pageblockfuncregexmatch.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600047B RID: 1147 RVA: 0x00017CAC File Offset: 0x00015EAC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x00017CB6 File Offset: 0x00015EB6
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

		// Token: 0x04000232 RID: 562
		private BlockRegexMatch vm;

		// Token: 0x04000233 RID: 563
		internal ComboBox regexOptionComboBox;

		// Token: 0x04000234 RID: 564
		private bool _contentLoaded;
	}
}
