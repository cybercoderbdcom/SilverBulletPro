using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Markup;
using Microsoft.Win32;
using SilverBulletPro.Core;
using SilverBulletPro.Core.Configuration;
using SilverBulletPro.Core.LS;
using SilverBulletPro.Core.Models;

namespace SilverBulletPro.Views.Main.Configs.OtherOptions
{
	// Token: 0x020001A1 RID: 417
	public partial class Interpreter : Page
	{
		// Token: 0x06000BA1 RID: 2977 RVA: 0x0003E754 File Offset: 0x0003C954
		public Interpreter()
		{
			this.InitializeComponent();
			base.DataContext = (this.vm = GlobalData.ConfigManager.CurrentConfig.Config.Settings);
			foreach (object obj in Enum.GetValues(typeof(Interpreter)))
			{
				Interpreter interpreter = (Interpreter)obj;
				this.interpreterBox.Items.Add(interpreter);
			}
			this.interpreterBox.SelectedIndex = 0;
		}

		// Token: 0x06000BA2 RID: 2978 RVA: 0x0003E804 File Offset: 0x0003CA04
		private void InterpreterBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				Interpreter interpreter = (Interpreter)this.interpreterBox.SelectedItem;
				this.listBoxMenu.IsOpen = false;
				this.listBoxMenu.Visibility = Visibility.Collapsed;
				switch (interpreter)
				{
				case 0:
					this.listBox.ItemsSource = this.vm.JsLibs;
					this.UpdateLibCount<InteropLib>(this.vm.JsLibs);
					break;
				case 1:
					this.listBox.ItemsSource = this.vm.NodeJsLibs;
					this.UpdateLibCount<string>(this.vm.NodeJsLibs);
					break;
				case 2:
					this.listBox.ItemsSource = this.vm.PythonLibs;
					this.listBoxMenu.Visibility = Visibility.Visible;
					this.listBoxMenu.IsOpen = false;
					this.UpdateLibCount<string>(this.vm.PythonLibs);
					break;
				case 3:
					this.listBox.ItemsSource = this.vm.CsLibs;
					this.UpdateLibCount<InteropLib>(this.vm.CsLibs);
					break;
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000BA3 RID: 2979 RVA: 0x0003E934 File Offset: 0x0003CB34
		private void ClearLibs_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				Interpreter value = (Interpreter)this.interpreterBox.SelectedItem;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(33, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Do you want to delete all libs(");
				defaultInterpolatedStringHandler.AppendFormatted<Interpreter>(value);
				defaultInterpolatedStringHandler.AppendLiteral(")?");
				if (Alert.Choice(defaultInterpolatedStringHandler.ToStringAndClear(), "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) != MessageBoxResult.No)
				{
					switch (value)
					{
					case 0:
						this.vm.JsLibs.Clear();
						this.UpdateLibCount<InteropLib>(this.vm.JsLibs);
						break;
					case 1:
						this.vm.NodeJsLibs.Clear();
						this.UpdateLibCount<string>(this.vm.NodeJsLibs);
						IApplication.NodeJSModulePaths = "";
						break;
					case 2:
						this.vm.PythonLibs.Clear();
						this.UpdateLibCount<string>(this.vm.PythonLibs);
						break;
					case 3:
						this.vm.CsLibs.Clear();
						this.UpdateLibCount<InteropLib>(this.vm.CsLibs);
						break;
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000BA4 RID: 2980 RVA: 0x0003EA68 File Offset: 0x0003CC68
		private void AddLib_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				string path = "";
				switch ((Interpreter)this.interpreterBox.SelectedItem)
				{
				case 0:
				{
					Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog
					{
						Filter = "Script|*.js"
					};
					bool? flag = openFileDialog.ShowDialog();
					bool flag2 = false;
					if (!(flag.GetValueOrDefault() == flag2 & flag != null) && !(Path.GetExtension(path = openFileDialog.FileName).ToLower() != ".js") && !this.vm.JsLibs.Any((InteropLib lib) => lib.Name == Path.GetFileName(path)))
					{
						this.vm.JsLibs.Add(new InteropLib(File.ReadAllBytesAsync(path, default(CancellationToken)).ConfigureAwait(false).GetAwaiter().GetResult(), Path.GetFileName(path)));
						this.UpdateLibCount<InteropLib>(this.vm.JsLibs);
					}
					break;
				}
				case 1:
				{
					FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
					{
						ShowNewFolderButton = false,
						AutoUpgradeEnabled = true
					};
					if (folderBrowserDialog.ShowDialog() == DialogResult.OK || string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
					{
						if (!this.vm.NodeJsLibs.Contains(folderBrowserDialog.SelectedPath) && this.vm.NodeJsLibs.Count < 1)
						{
							this.vm.NodeJsLibs.Add(folderBrowserDialog.SelectedPath);
							this.UpdateLibCount<string>(this.vm.NodeJsLibs);
						}
					}
					break;
				}
				case 2:
				{
					FolderBrowserDialog folderBrowserDialog2 = new FolderBrowserDialog
					{
						ShowNewFolderButton = false,
						AutoUpgradeEnabled = true
					};
					if (folderBrowserDialog2.ShowDialog() == DialogResult.OK || string.IsNullOrWhiteSpace(folderBrowserDialog2.SelectedPath))
					{
						if (!this.vm.PythonLibs.Contains(folderBrowserDialog2.SelectedPath))
						{
							this.vm.PythonLibs.Add(folderBrowserDialog2.SelectedPath);
							this.UpdateLibCount<string>(this.vm.PythonLibs);
						}
					}
					break;
				}
				case 3:
				{
					Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog
					{
						Filter = "DLL|*.dll"
					};
					bool? flag = openFileDialog.ShowDialog();
					bool flag2 = false;
					if (!(flag.GetValueOrDefault() == flag2 & flag != null) && !(Path.GetExtension(path = openFileDialog.FileName).ToLower() != ".dll") && !this.vm.CsLibs.Any((InteropLib lib) => lib.Name == Path.GetFileName(path)))
					{
						this.vm.CsLibs.Add(new InteropLib(File.ReadAllBytesAsync(path, default(CancellationToken)).ConfigureAwait(false).GetAwaiter().GetResult(), Path.GetFileName(path)));
						this.UpdateLibCount<InteropLib>(this.vm.CsLibs);
					}
					break;
				}
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000BA5 RID: 2981 RVA: 0x0003ED8C File Offset: 0x0003CF8C
		private void RemoveLib_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				switch ((Interpreter)this.interpreterBox.SelectedItem)
				{
				case 0:
					this.vm.JsLibs.RemoveAt(this.listBox.SelectedIndex);
					break;
				case 1:
					this.vm.NodeJsLibs.RemoveAt(this.listBox.SelectedIndex);
					IApplication.NodeJSModulePaths = "";
					break;
				case 2:
					this.vm.PythonLibs.RemoveAt(this.listBox.SelectedIndex);
					break;
				case 3:
					this.vm.CsLibs.RemoveAt(this.listBox.SelectedIndex);
					break;
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000BA6 RID: 2982 RVA: 0x0003EE54 File Offset: 0x0003D054
		private void UpdateLibCount<T>(IEnumerable<T> list)
		{
			this.libCount.Text = list.Count<T>().ToString();
		}

		// Token: 0x06000BA7 RID: 2983 RVA: 0x0003EE7C File Offset: 0x0003D07C
		private void GetPySitePkg_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				string item = Cmd.Run("python", "-m site --user-site", false, true).Trim();
				if (!this.vm.PythonLibs.Contains(item))
				{
					this.vm.PythonLibs.Add(item);
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000BA8 RID: 2984 RVA: 0x0003EEDC File Offset: 0x0003D0DC
		private void DropList_DragEnter(object sender, System.Windows.DragEventArgs e)
		{
			e.Effects = System.Windows.DragDropEffects.Copy;
		}

		// Token: 0x06000BA9 RID: 2985 RVA: 0x0003EEE8 File Offset: 0x0003D0E8
		private void DropList_Drop(object sender, System.Windows.DragEventArgs e)
		{
			try
			{
				string path = ((string[])e.Data.GetData(System.Windows.DataFormats.FileDrop))[0];
				switch ((Interpreter)this.interpreterBox.SelectedItem)
				{
				case 0:
					if (!(Path.GetExtension(path).ToLower() != ".js") && !this.vm.JsLibs.Any((InteropLib lib) => lib.Name == Path.GetFileName(path)))
					{
						this.vm.JsLibs.Add(new InteropLib(File.ReadAllBytesAsync(path, default(CancellationToken)).ConfigureAwait(false).GetAwaiter().GetResult(), Path.GetFileName(path)));
						this.UpdateLibCount<InteropLib>(this.vm.JsLibs);
					}
					break;
				case 1:
					if (this.vm.NodeJsLibs.Count < 1)
					{
						this.vm.NodeJsLibs.Add(Path.GetDirectoryName(path));
						IApplication.NodeJSModulePaths = path;
						this.UpdateLibCount<string>(this.vm.NodeJsLibs);
					}
					break;
				case 2:
				{
					string directoryName = Path.GetDirectoryName(path);
					if (!this.vm.PythonLibs.Contains(directoryName))
					{
						this.vm.PythonLibs.Add(directoryName);
						this.UpdateLibCount<string>(this.vm.PythonLibs);
					}
					break;
				}
				case 3:
					if (!(Path.GetExtension(path).ToLower() != ".dll") && !this.vm.CsLibs.Any((InteropLib lib) => lib.Name == Path.GetFileName(path)))
					{
						this.vm.CsLibs.Add(new InteropLib(File.ReadAllBytesAsync(path, default(CancellationToken)).ConfigureAwait(false).GetAwaiter().GetResult(), Path.GetFileName(path)));
						this.UpdateLibCount<InteropLib>(this.vm.CsLibs);
					}
					break;
				}
			}
			catch
			{
			}
		}

		// Token: 0x040005C5 RID: 1477
		private ConfigSettings vm;
	}
}
