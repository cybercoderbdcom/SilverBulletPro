using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using HandyControl.Controls;
using Microsoft.Win32;

namespace SilverBulletPro.Views.Main.Tools
{
	// Token: 0x0200018B RID: 395
	public partial class WordlistTools : Page
	{
		// Token: 0x060009E1 RID: 2529 RVA: 0x0002DAF4 File Offset: 0x0002BCF4
		public WordlistTools()
		{
			this.InitializeComponent();
		}

		// Token: 0x060009E2 RID: 2530 RVA: 0x0002DB10 File Offset: 0x0002BD10
		private void LoadWordlist_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.Filter = "Wordlist files | *.txt";
				openFileDialog.FilterIndex = 1;
				bool? flag = openFileDialog.ShowDialog();
				bool flag2 = false;
				if (!(flag.GetValueOrDefault() == flag2 & flag != null))
				{
					this.wordlistName = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
					try
					{
						this.locTextBox.Text = openFileDialog.FileName;
						this.wordList.AddRange(File.ReadLines(openFileDialog.FileName));
						this.loaded.Text = this.wordList.Count.ToString();
						string text = this.wordList.First<string>();
						this.recognizeWordlistType = GlobalData.Settings.Environment.RecognizeWordlistType(text);
					}
					catch
					{
					}
				}
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x060009E3 RID: 2531 RVA: 0x0002DC00 File Offset: 0x0002BE00
		private void RemoveDuplicates_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				List<string> list = this.wordList.Distinct<string>().ToList<string>();
				this.removedDup.Text = (this.wordList.Count - list.Count).ToString();
				this.SaveFile("Remove Duplicate", list.ToArray());
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060009E4 RID: 2532 RVA: 0x0002DC6C File Offset: 0x0002BE6C
		private void Split_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				List<string> list = (from w in this.wordList.Select(delegate(string w)
				{
					string result;
					try
					{
						result = w.Split(new string[]
						{
							this.splitTextBox.Text
						}, StringSplitOptions.RemoveEmptyEntries)[(int)this.splitIndex.Value - 1];
					}
					catch
					{
						result = w;
					}
					return result;
				})
				where !w.Contains(this.splitTextBox.Text)
				select w).ToList<string>();
				this.splited.Text = list.Count.ToString();
				this.SaveFile("Splitter", list.ToArray());
			}
			catch (Exception ex)
			{
				GlobalData.Logger.Log(ex.Message, 2, true, 0);
			}
		}

		// Token: 0x060009E5 RID: 2533 RVA: 0x0002DCFC File Offset: 0x0002BEFC
		private void ChangeSeparator_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				StreamReader streamReader = new StreamReader(this.locTextBox.Text);
				string text = streamReader.ReadToEnd();
				streamReader.Close();
				text = Regex.Replace(text, this.currentSepTextBox.Text.Trim(), this.newSepTextBox.Text.Trim());
				this.changed.Text = this.wordList.Count((string w) => w.Contains(this.currentSepTextBox.Text)).ToString();
				SaveFileDialog saveFileDialog = new SaveFileDialog
				{
					Title = "Change Separator",
					Filter = "Text File|*.txt"
				};
				bool? flag = saveFileDialog.ShowDialog();
				bool flag2 = true;
				if (flag.GetValueOrDefault() == flag2 & flag != null)
				{
					StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
					streamWriter.Write(text);
					streamWriter.Close();
				}
			}
			catch (Exception ex)
			{
				GlobalData.Logger.Log(ex.Message, 2, true, 0);
			}
		}

		// Token: 0x060009E6 RID: 2534 RVA: 0x0002DDF4 File Offset: 0x0002BFF4
		private void SaveFile(string title, string[] contents)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				Title = title,
				Filter = "Text File|*.txt"
			};
			bool? flag = saveFileDialog.ShowDialog();
			bool flag2 = true;
			if (flag.GetValueOrDefault() == flag2 & flag != null)
			{
				File.WriteAllLines(saveFileDialog.FileName, contents);
			}
		}

		// Token: 0x040004B3 RID: 1203
		private string recognizeWordlistType;

		// Token: 0x040004B4 RID: 1204
		private string wordlistName;

		// Token: 0x040004B5 RID: 1205
		private List<string> wordList = new List<string>();
	}
}
