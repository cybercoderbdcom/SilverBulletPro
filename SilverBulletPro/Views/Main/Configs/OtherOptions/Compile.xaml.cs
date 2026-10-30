using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Threading;
using System.Xml;
using GalaSoft.MvvmLight.Command;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Folding;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using ICSharpCode.AvalonEdit.Indentation.CSharp;
using Microsoft.Win32;
using SilverBulletPro.Core;
using SilverBulletPro.Core.Configuration;
using SilverBulletPro.Core.Extensions;
using SilverBulletPro.Extensions;
using SilverBulletPro.FindReplace;

namespace SilverBulletPro.Views.Main.Configs.OtherOptions
{
	// Token: 0x0200019D RID: 413
	public partial class Compile : Page
	{
		// Token: 0x06000B66 RID: 2918 RVA: 0x0003CDD4 File Offset: 0x0003AFD4
		public Compile()
		{
			this.InitializeComponent();
			base.DataContext = (this.vm = GlobalData.ConfigManager.CurrentConfig.Config.Settings);
			foreach (object newItem in Enum.GetValues(typeof(ScriptCompiler.TargetFramework)))
			{
				this.targetFrameworkBox.Items.Add(newItem);
			}
			this.compilerVersion.Content = IApplication.CompilerVersion;
			if (string.IsNullOrEmpty(this.vm.AssemblyName))
			{
				this.vm.AssemblyName = this.vm.Name;
			}
			this.csEditor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("C#");
			this.csEditor.Text = this.vm.CsScriptComp;
			this.csEditor.ShowLineNumbers = true;
			this.csEditor.TextArea.Foreground = new SolidColorBrush(Colors.Gainsboro);
			this.csEditor.TextArea.TextView.LinkTextForegroundBrush = new SolidColorBrush(Colors.DodgerBlue);
			using (XmlReader xmlReader = XmlReader.Create(Constants.HighlightingFolder + "\\CSharp-Mode.xshd"))
			{
				this.csEditor.SyntaxHighlighting = HighlightingLoader.Load(xmlReader, HighlightingManager.Instance);
				this.HighlightingComboBox_SelectionChanged(null, null);
				this.foldingUpdateTimer = new DispatcherTimer();
				this.foldingUpdateTimer.Interval = TimeSpan.FromSeconds(2.0);
				this.foldingUpdateTimer.Tick += this.FoldingUpdateTimer_Tick;
				this.foldingUpdateTimer.Start();
				this.EditorInitSettings();
			}
		}

		// Token: 0x06000B67 RID: 2919 RVA: 0x0003CFC0 File Offset: 0x0003B1C0
		private void SelectIcon_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				OpenFileDialog openFileDialog = new OpenFileDialog
				{
					Filter = "Icon|*.ico"
				};
				bool? flag = openFileDialog.ShowDialog();
				bool flag2 = true;
				if ((flag.GetValueOrDefault() == flag2 & flag != null) && Path.GetExtension(openFileDialog.FileName).ToLower() == ".ico")
				{
					this.vm.IconPath = openFileDialog.FileName;
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000B68 RID: 2920 RVA: 0x0003D040 File Offset: 0x0003B240
		private void IconPath_TextChanged(object sender, TextChangedEventArgs e)
		{
			try
			{
				TextBox textBox = sender as TextBox;
				if (File.Exists(textBox.Text) && Path.GetExtension(textBox.Text).ToLower() == ".ico")
				{
					this.vm.IconPath = textBox.Text;
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000B69 RID: 2921 RVA: 0x0003D0A4 File Offset: 0x0003B2A4
		private void CsEditor_LostFocus(object sender, RoutedEventArgs e)
		{
			this.vm.CsScriptComp = this.csEditor.Text;
		}

		// Token: 0x06000B6A RID: 2922 RVA: 0x0003D0BC File Offset: 0x0003B2BC
		private void TextEditor_TextArea_TextEntered(object sender, TextCompositionEventArgs e)
		{
			if (e.Text == ".")
			{
				this.completionWindow = new CompletionWindow(this.csEditor.TextArea);
				IList<ICompletionData> completionData = this.completionWindow.CompletionList.CompletionData;
				completionData.Add(new CSharpCompletionData("Item1"));
				completionData.Add(new CSharpCompletionData("Item2"));
				completionData.Add(new CSharpCompletionData("Item3"));
				completionData.Add(new CSharpCompletionData("Another item"));
				this.completionWindow.Show();
				this.completionWindow.Closed += delegate([Nullable(2)] object <p0>, EventArgs <p1>)
				{
					this.completionWindow = null;
				};
			}
		}

		// Token: 0x06000B6B RID: 2923 RVA: 0x0003D165 File Offset: 0x0003B365
		private void TextEditor_TextArea_TextEntering(object sender, TextCompositionEventArgs e)
		{
			if (e.Text.Length > 0 && this.completionWindow != null && !char.IsLetterOrDigit(e.Text[0]))
			{
				this.completionWindow.CompletionList.RequestInsertion(e);
			}
		}

		// Token: 0x06000B6C RID: 2924 RVA: 0x0003D1A4 File Offset: 0x0003B3A4
		private void HighlightingComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			this.csEditor.TextArea.IndentationStrategy = new CSharpIndentationStrategy(this.csEditor.Options);
			this.braceFoldingStrategy = new BraceFoldingStrategy();
			if (this.braceFoldingStrategy != null)
			{
				if (this.foldingManager == null)
				{
					this.foldingManager = FoldingManager.Install(this.csEditor.TextArea);
				}
				this.braceFoldingStrategy.UpdateFoldings(this.foldingManager, this.csEditor.Document);
				return;
			}
			if (this.foldingManager != null)
			{
				FoldingManager.Uninstall(this.foldingManager);
				this.foldingManager = null;
			}
		}

		// Token: 0x06000B6D RID: 2925 RVA: 0x0003D23C File Offset: 0x0003B43C
		private void FoldingUpdateTimer_Tick(object sender, EventArgs e)
		{
			try
			{
				if (this.braceFoldingStrategy != null)
				{
					this.braceFoldingStrategy.UpdateFoldings(this.foldingManager, this.csEditor.Document);
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000B6E RID: 2926 RVA: 0x0003D284 File Offset: 0x0003B484
		private void ClearLibs_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (Alert.Choice("Do you want to delete all reference(s) ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) != MessageBoxResult.No)
				{
					this.vm.CsRefs.Clear();
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000B6F RID: 2927 RVA: 0x0003D2D0 File Offset: 0x0003B4D0
		private void AddLib_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				string path = "";
				OpenFileDialog openFileDialog = new OpenFileDialog
				{
					Filter = "DLL|*.dll"
				};
				bool? flag = openFileDialog.ShowDialog();
				bool flag2 = false;
				if (!(flag.GetValueOrDefault() == flag2 & flag != null) && !(Path.GetExtension(path = openFileDialog.FileName).ToLower() != ".dll") && !this.vm.CsRefs.Any((string r) => r == path))
				{
					this.vm.CsRefs.Add(path);
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000B70 RID: 2928 RVA: 0x0003D390 File Offset: 0x0003B590
		private void RemoveLib_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				this.vm.CsRefs.RemoveAt(this.refsComboBox.SelectedIndex);
			}
			catch
			{
			}
		}

		// Token: 0x06000B71 RID: 2929 RVA: 0x0003D3D0 File Offset: 0x0003B5D0
		private void EditorInitSettings()
		{
			ContextMenu contextMenu = new ContextMenu();
			contextMenu.Items.Add(ContextMenuItemExtension.CreateMenuItem<TextEditor>(ContextMenuItemType.Start, "Run", new RelayCommand<TextEditor>(delegate(TextEditor e)
			{
				this.vm.CsScriptComp = this.csEditor.Text;
				Stacker stackerPage = GlobalData.MainWindow.ConfigsSecionPage.StackerPage;
				if (stackerPage == null)
				{
					return;
				}
				stackerPage.Compile_Click(new object[]
				{
					this,
					true
				}, null);
			}, (TextEditor e) => !string.IsNullOrEmpty(e.Text) && e.Text.Length > 0), this.csEditor));
			contextMenu.Items.Add(ContextMenuItemExtension.CreateMenuItem<TextEditor>(ContextMenuItemType.Stop, "Stop", new RelayCommand<TextEditor>(delegate(TextEditor e)
			{
				Stacker stackerPage = GlobalData.MainWindow.ConfigsSecionPage.StackerPage;
				if (stackerPage == null)
				{
					return;
				}
				Process processComp = stackerPage.ProcessComp;
				if (processComp == null)
				{
					return;
				}
				processComp.Dispose();
			}, delegate(TextEditor e)
			{
				if (!string.IsNullOrEmpty(e.Text) && e.Text.Length > 0)
				{
					Stacker stackerPage = GlobalData.MainWindow.ConfigsSecionPage.StackerPage;
					return ((stackerPage != null) ? stackerPage.ProcessComp : null) != null;
				}
				return false;
			}), this.csEditor));
			contextMenu.Items.Add(new Separator
			{
				Margin = new Thickness(0.0, 2.0, 0.0, 2.0)
			});
			contextMenu.Items.Add(ContextMenuItemExtension.CreateMenuItem(ContextMenuItemType.Cut, "Cut", new RelayCommand(new Action(this.csEditor.Cut), () => this.csEditor.SelectionLength > 0), null));
			contextMenu.Items.Add(ContextMenuItemExtension.CreateMenuItem(ContextMenuItemType.Copy, "Copy", new RelayCommand(new Action(this.csEditor.Copy), () => this.csEditor.SelectionLength > 0), null));
			contextMenu.Items.Add(ContextMenuItemExtension.CreateMenuItem(ContextMenuItemType.Paste, "Paste", ApplicationCommands.Paste, null));
			contextMenu.Items.Add(ContextMenuItemExtension.CreateMenuItem(ContextMenuItemType.Delete, "Delete", ApplicationCommands.Delete, null));
			contextMenu.Items.Add(ContextMenuItemExtension.CreateMenuItem(ContextMenuItemType.SelectAll, "Select All", new RelayCommand(new Action(this.csEditor.SelectAll), () => !string.IsNullOrEmpty(this.csEditor.Text)), null));
			contextMenu.Items.Add(new Separator
			{
				Margin = new Thickness(0.0, 2.0, 0.0, 2.0)
			});
			contextMenu.Items.Add(ContextMenuItemExtension.CreateMenuItem<TextEditor>(ContextMenuItemType.Find, "Find", new RelayCommand<TextEditor>(delegate(TextEditor e)
			{
				this.ShowFindReplace(new TextEditorAdapter(e), false);
			}, (TextEditor e) => !string.IsNullOrEmpty(e.Text)), this.csEditor));
			contextMenu.Items.Add(ContextMenuItemExtension.CreateMenuItem<TextEditor>(ContextMenuItemType.Replace, "Replace", new RelayCommand<TextEditor>(delegate(TextEditor e)
			{
				this.ShowFindReplace(new TextEditorAdapter(e), true);
			}, (TextEditor e) => !string.IsNullOrEmpty(e.Text)), this.csEditor));
			this.csEditor.ContextMenu = contextMenu;
		}

		// Token: 0x06000B72 RID: 2930 RVA: 0x0003D6A0 File Offset: 0x0003B8A0
		private void ShowFindReplace(object editor, bool selectReplaceTab = false)
		{
			this.findReplaceMgr.CurrentEditor = editor;
			DialogFindReplace.ShowFindReplace(this.findReplaceMgr, selectReplaceTab);
		}

		// Token: 0x06000B73 RID: 2931 RVA: 0x0003D6BA File Offset: 0x0003B8BA
		private void ShowFind(object editor)
		{
			this.findReplaceMgr.CurrentEditor = editor;
			DialogFindReplace.ShowFind(this.findReplaceMgr);
		}

		// Token: 0x06000B74 RID: 2932 RVA: 0x0003D6D3 File Offset: 0x0003B8D3
		private void ShowReplace(object editor)
		{
			this.findReplaceMgr.CurrentEditor = editor;
			DialogFindReplace.ShowReplace(this.findReplaceMgr);
		}

		// Token: 0x06000B75 RID: 2933 RVA: 0x0003D6EC File Offset: 0x0003B8EC
		private void Compile_Click(object sender, RoutedEventArgs e)
		{
			GlobalData.MainWindow.ConfigsSecionPage.StackerPage.Compile_Click(new object[]
			{
				this,
				false
			}, e);
		}

		// Token: 0x06000B76 RID: 2934 RVA: 0x0003D718 File Offset: 0x0003B918
		private void csEditor_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyboardDevice.Modifiers == ModifierKeys.Control)
				{
					Key key = e.Key;
					if (key != Key.F)
					{
						if (key == Key.H)
						{
							this.ShowFindReplace(new TextEditorAdapter(this.csEditor), true);
						}
					}
					else
					{
						this.ShowFindReplace(new TextEditorAdapter(this.csEditor), false);
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000B77 RID: 2935 RVA: 0x0003D784 File Offset: 0x0003B984
		private void OpenFolder_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				string text = Path.Combine(Constants.CompiledFolder, Path.GetFileNameWithoutExtension(GlobalData.ConfigManager.CurrentConfig.FileName));
				if (!Directory.Exists(text))
				{
					Alert.ShowNotif(AlertType.Error, "Directory path not found");
				}
				else
				{
					ProcessExtension.Start(text);
				}
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x040005A6 RID: 1446
		private ConfigSettings vm;

		// Token: 0x040005A7 RID: 1447
		private FoldingManager foldingManager;

		// Token: 0x040005A8 RID: 1448
		private BraceFoldingStrategy braceFoldingStrategy;

		// Token: 0x040005A9 RID: 1449
		private CompletionWindow completionWindow;

		// Token: 0x040005AA RID: 1450
		private DispatcherTimer foldingUpdateTimer;

		// Token: 0x040005AB RID: 1451
		private FindReplaceMgr findReplaceMgr = new FindReplaceMgr();
	}
}
