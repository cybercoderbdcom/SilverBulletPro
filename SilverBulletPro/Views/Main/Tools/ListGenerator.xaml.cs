using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Microsoft.Win32;
using SilverBulletPro.Core.Models;
using SilverBulletPro.ViewModels;

namespace SilverBulletPro.Views.Main.Tools
{
	// Token: 0x02000189 RID: 393
	public partial class ListGenerator : Page
	{
		// Token: 0x060009C2 RID: 2498 RVA: 0x0002D07D File Offset: 0x0002B27D
		public ListGenerator()
		{
			this.InitializeComponent();
			base.DataContext = this.vm;
		}

		// Token: 0x060009C3 RID: 2499 RVA: 0x0002D0B8 File Offset: 0x0002B2B8
		private void lowercaseButton_Click(object sender, RoutedEventArgs e)
		{
			ListGeneratorViewModel listGeneratorViewModel = this.vm;
			listGeneratorViewModel.AllowedCharacters += "abcdefghijklmnopqrstuvwxyz";
		}

		// Token: 0x060009C4 RID: 2500 RVA: 0x0002D0D5 File Offset: 0x0002B2D5
		private void uppercaseButton_Click(object sender, RoutedEventArgs e)
		{
			ListGeneratorViewModel listGeneratorViewModel = this.vm;
			listGeneratorViewModel.AllowedCharacters += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		}

		// Token: 0x060009C5 RID: 2501 RVA: 0x0002D0F2 File Offset: 0x0002B2F2
		private void digitsButton_Click(object sender, RoutedEventArgs e)
		{
			ListGeneratorViewModel listGeneratorViewModel = this.vm;
			listGeneratorViewModel.AllowedCharacters += "0123456789";
		}

		// Token: 0x060009C6 RID: 2502 RVA: 0x0002D10F File Offset: 0x0002B30F
		private void clearButton_Click(object sender, RoutedEventArgs e)
		{
			this.vm.AllowedCharacters = "";
		}

		// Token: 0x060009C7 RID: 2503 RVA: 0x0002D121 File Offset: 0x0002B321
		private void generateButton_Click(object sender, RoutedEventArgs e)
		{
		}

		// Token: 0x060009C8 RID: 2504 RVA: 0x0002D124 File Offset: 0x0002B324
		private void generateListButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				this.generatedTextBox.Visibility = Visibility.Collapsed;
				this.strings.Clear();
				SaveFileDialog saveFileDialog = new SaveFileDialog();
				saveFileDialog.Filter = "Text File |*.txt";
				saveFileDialog.Title = "Save Output List";
				bool? flag = saveFileDialog.ShowDialog();
				bool flag2 = true;
				if ((flag.GetValueOrDefault() == flag2 & flag != null) && saveFileDialog.FileName != string.Empty)
				{
					this.sw = new StreamWriter(saveFileDialog.FileName);
					this.WriteCombinations(this.vm.Mask);
					this.sw.Close();
					this.sw.Dispose();
					if (this.vm.AutoImport)
					{
						Wordlist wordlist = new Wordlist("Generated" + this.rand.Next().ToString(), saveFileDialog.FileName, "Default", "", true, false, false);
						GlobalData.MainWindow.WordlistManagerPage.AddWordlist(wordlist);
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x060009C9 RID: 2505 RVA: 0x0002D23C File Offset: 0x0002B43C
		private void WriteCombinations(string input)
		{
			if (input.Contains('*'))
			{
				foreach (char c in this.vm.AllowedCharacters)
				{
					this.WriteCombinations(new Regex("\\*").Replace(input, c.ToString(), 1));
				}
				return;
			}
			if ((this.vm.OnlyLuhn && ListGenerator.Luhn(input.Split(':', StringSplitOptions.None)[0])) || !this.vm.OnlyLuhn)
			{
				this.sw.WriteLine(input);
			}
		}

		// Token: 0x060009CA RID: 2506 RVA: 0x0002D2D0 File Offset: 0x0002B4D0
		public static bool Luhn(string digits)
		{
			Func<char, bool> predicate;
			if ((predicate = ListGenerator.<>O.<0>__IsDigit) == null)
			{
				predicate = (ListGenerator.<>O.<0>__IsDigit = new Func<char, bool>(char.IsDigit));
			}
			if (digits.All(predicate))
			{
				return (from c in digits.Reverse<char>()
				select (int)(c - '0')).Select(delegate(int thisNum, int i)
				{
					if (i % 2 == 0)
					{
						return thisNum;
					}
					if ((thisNum *= 2) <= 9)
					{
						return thisNum;
					}
					return thisNum - 9;
				}).Sum() % 10 == 0;
			}
			return false;
		}

		// Token: 0x0400049F RID: 1183
		private ListGeneratorViewModel vm = new ListGeneratorViewModel();

		// Token: 0x040004A0 RID: 1184
		private StreamWriter sw;

		// Token: 0x040004A1 RID: 1185
		private Random rand = new Random();

		// Token: 0x040004A2 RID: 1186
		private List<string> strings = new List<string>();

		// Token: 0x0200026A RID: 618
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x04000829 RID: 2089
			public static Func<char, bool> <0>__IsDigit;
		}
	}
}
