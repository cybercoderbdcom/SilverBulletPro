using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using SilverBulletPro.Core;
using SilverBulletPro.Core.Models;

namespace SilverBulletPro.Views.Main.Configs.OtherOptions
{
	// Token: 0x0200019E RID: 414
	public partial class Data : Page, IStyleConnector
	{
		// Token: 0x06000B81 RID: 2945 RVA: 0x0003DA44 File Offset: 0x0003BC44
		public Data()
		{
			this.vm = GlobalData.ConfigManager.CurrentConfig.Config.Settings;
			base.DataContext = this.vm;
			this.InitializeComponent();
			List<string> list = new List<string>();
			foreach (string item in GlobalData.Settings.Environment.GetWordlistTypeNames())
			{
				list.Add(item);
			}
			this.vm.TestAllowedWordlistTypes = list.ToArray();
			this.testAllowedWordlistTypeComboBox.SelectedIndex = 0;
			if (this.vm.DataRules.Count > 0)
			{
				this.gridTestData.Visibility = Visibility.Visible;
			}
		}

		// Token: 0x06000B82 RID: 2946 RVA: 0x0003DB14 File Offset: 0x0003BD14
		private void AddSimpleDataRuleButton_Click(object sender, RoutedEventArgs e)
		{
			this.vm.DataRules.Add(new SimpleDataRule());
			this.gridTestData.Visibility = Visibility.Visible;
		}

		// Token: 0x06000B83 RID: 2947 RVA: 0x0003DB37 File Offset: 0x0003BD37
		private void AddRegexDataRuleButton_Click(object sender, RoutedEventArgs e)
		{
			this.vm.DataRules.Add(new RegexDataRule());
			this.gridTestData.Visibility = Visibility.Visible;
		}

		// Token: 0x06000B84 RID: 2948 RVA: 0x0003DB5A File Offset: 0x0003BD5A
		private void RemoveDataRuleButton_Click(object sender, RoutedEventArgs e)
		{
			this.vm.RemoveDataRule((DataRule)(sender as Button).Tag);
			if (this.vm.DataRules.Count == 0)
			{
				this.gridTestData.Visibility = Visibility.Collapsed;
			}
		}

		// Token: 0x06000B85 RID: 2949 RVA: 0x0003DB95 File Offset: 0x0003BD95
		private void AddLinesFromFileResourceButton_Click(object sender, RoutedEventArgs e)
		{
			this.vm.Resources.Add(new LinesFromFileResourceOptions());
		}

		// Token: 0x06000B86 RID: 2950 RVA: 0x0003DBAC File Offset: 0x0003BDAC
		private void AddRandomLinesFromFileResourceButton_Click(object sender, RoutedEventArgs e)
		{
			this.vm.Resources.Add(new RandomLinesFromFileResourceOptions());
		}

		// Token: 0x06000B87 RID: 2951 RVA: 0x0003DBC3 File Offset: 0x0003BDC3
		private void RemoveResourceButton_Click(object sender, RoutedEventArgs e)
		{
			this.vm.RemoveResourceOption((ConfigResourceOptions)(sender as Button).Tag);
		}

		// Token: 0x06000B88 RID: 2952 RVA: 0x0003DBE0 File Offset: 0x0003BDE0
		private void AddAllowedWordlistTypeButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (!string.IsNullOrWhiteSpace(this.allowedWordlistTypeComboBox.Text))
				{
					HashSet<string> hashSet = new HashSet<string>(this.vm.AllowedWordlistType);
					hashSet.Add(this.allowedWordlistTypeComboBox.Text);
					this.vm.AllowedWordlistType = hashSet.ToArray<string>();
					this.allowedWordlistTypeComboBox.SelectedIndex = this.allowedWordlistTypeComboBox.Items.Count - 1;
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000B89 RID: 2953 RVA: 0x0003DC68 File Offset: 0x0003BE68
		private void RemoveAllowedWordlistTypeButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (this.allowedWordlistTypeComboBox.SelectedIndex != -1)
				{
					HashSet<string> hashSet = new HashSet<string>(this.vm.AllowedWordlistType);
					hashSet.Remove(this.allowedWordlistTypeComboBox.Text);
					this.vm.AllowedWordlistType = hashSet.ToArray<string>();
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000B8A RID: 2954 RVA: 0x0003DCD0 File Offset: 0x0003BED0
		private void TestDataRuleButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				new MainDialog(new MainDialog.InputDialog
				{
					Dialog = new DialogTestDataRules(this.vm.TestDataForRules, this.vm.TestWordlistTypeForRules, this.vm.DataRules),
					Title = "Test Results"
				}).ShowDialog();
			}
			catch
			{
			}
		}

		// Token: 0x06000B8D RID: 2957 RVA: 0x0003DE70 File Offset: 0x0003C070
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IStyleConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 8:
				((Button)target).Click += this.RemoveDataRuleButton_Click;
				return;
			case 9:
				((Button)target).Click += this.RemoveDataRuleButton_Click;
				return;
			case 10:
			case 11:
				break;
			case 12:
				((Button)target).Click += this.RemoveResourceButton_Click;
				return;
			case 13:
				((Button)target).Click += this.RemoveResourceButton_Click;
				break;
			default:
				return;
			}
		}

		// Token: 0x040005B4 RID: 1460
		private ConfigSettings vm;
	}
}
