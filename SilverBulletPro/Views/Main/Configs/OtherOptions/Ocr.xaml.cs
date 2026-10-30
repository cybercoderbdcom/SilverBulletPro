using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using SilverBulletPro.Core;
using SilverBulletPro.Core.Enums;
using SilverBulletPro.Core.Models;

namespace SilverBulletPro.Views.Main.Configs.OtherOptions
{
	// Token: 0x020001A2 RID: 418
	public partial class Ocr : Page
	{
		// Token: 0x06000BAC RID: 2988 RVA: 0x0003F2AC File Offset: 0x0003D4AC
		public Ocr()
		{
			this.InitializeComponent();
			base.DataContext = (this.vm = GlobalData.ConfigManager.CurrentConfig.Config.Settings);
			foreach (object obj in Enum.GetValues(typeof(VariableValueType)))
			{
				VariableValueType variableValueType = (VariableValueType)obj;
				this.varValueType.Items.Add(variableValueType);
			}
		}

		// Token: 0x06000BAD RID: 2989 RVA: 0x0003F350 File Offset: 0x0003D550
		private void btnVariableAdd_Click(object sender, RoutedEventArgs e)
		{
			this.vm.VariableList.Add(new TesseractVariable
			{
				Name = this.varName.Text,
				Value = this.varValue.Text,
				ValueType = (VariableValueType)this.varValueType.SelectedItem
			});
		}

		// Token: 0x06000BAE RID: 2990 RVA: 0x0003F3AC File Offset: 0x0003D5AC
		private void btnVariableUp_Click(object sender, RoutedEventArgs e)
		{
			int selectedIndex = this.variableLB.SelectedIndex;
			if (selectedIndex > 0)
			{
				object obj = this.variableLB.Items[selectedIndex];
				this.vm.VariableList.RemoveAt(selectedIndex);
				this.vm.VariableList.Insert(selectedIndex - 1, (TesseractVariable)obj);
				this.variableLB.SelectedIndex = selectedIndex - 1;
			}
		}

		// Token: 0x06000BAF RID: 2991 RVA: 0x0003F414 File Offset: 0x0003D614
		private void btnVariableDown_Click(object sender, RoutedEventArgs e)
		{
			int selectedIndex = this.variableLB.SelectedIndex;
			if (selectedIndex + 1 < this.variableLB.Items.Count)
			{
				object obj = this.variableLB.Items[selectedIndex];
				this.vm.VariableList.RemoveAt(selectedIndex);
				this.vm.VariableList.Insert(selectedIndex + 1, (TesseractVariable)obj);
				this.variableLB.SelectedIndex = selectedIndex + 1;
			}
		}

		// Token: 0x06000BB0 RID: 2992 RVA: 0x0003F48C File Offset: 0x0003D68C
		private void btnVariableRemove_Click(object sender, RoutedEventArgs e)
		{
			if (this.variableLB.SelectedIndex == -1)
			{
				return;
			}
			this.vm.VariableList.RemoveAt(this.variableLB.SelectedIndex);
		}

		// Token: 0x06000BB1 RID: 2993 RVA: 0x0003F4B8 File Offset: 0x0003D6B8
		private void btnVariableClear_Click(object sender, RoutedEventArgs e)
		{
			this.vm.VariableList.Clear();
		}

		// Token: 0x06000BB2 RID: 2994 RVA: 0x0003F4CC File Offset: 0x0003D6CC
		private void MenuItem_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				TesseractVariable tesseractVariable = this.vm.VariableList[this.variableLB.SelectedIndex];
				Clipboard.SetText(string.Concat(new string[]
				{
					tesseractVariable.Name,
					":",
					tesseractVariable.Value,
					":",
					tesseractVariable.ValueType.ToString()
				}));
			}
			catch
			{
			}
		}

		// Token: 0x06000BB3 RID: 2995 RVA: 0x0003F554 File Offset: 0x0003D754
		private void EnableTestMode_Click(object sender, RoutedEventArgs e)
		{
			GlobalData.MainWindow.ConfigsSecionPage.StackerPage.OcrTestModeClicked();
		}

		// Token: 0x06000BB4 RID: 2996 RVA: 0x0003F56A File Offset: 0x0003D76A
		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
		}

		// Token: 0x040005CE RID: 1486
		private ConfigSettings vm;
	}
}
