using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Threading;
using System.Xml;
using AngleSharp.Text;
using EO.Base;
using EO.WebBrowser;
using EO.WebEngine;
using EO.Wpf;
using GalaSoft.MvvmLight.Command;
using HandyControl.Controls;
using HexView.Wpf;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using Jering.Javascript.NodeJS;
using JsonControls.JsonViewer;
using MahApps.Metro.IconPacks;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SilverBulletPro.Animations;
using SilverBulletPro.Converters;
using SilverBulletPro.Core;
using SilverBulletPro.Core.Blocks;
using SilverBulletPro.Core.Configuration;
using SilverBulletPro.Core.Extensions;
using SilverBulletPro.Core.LS;
using SilverBulletPro.Core.Models;
using SilverBulletPro.Core.Runners;
using SilverBulletPro.Core.ViewModels;
using SilverBulletPro.Extensions;
using SilverBulletPro.FindReplace;
using SilverBulletPro.Requests;
using SilverBulletPro.ViewModels;
using SilverBulletPro.Views.Dialogs;

namespace SilverBulletPro.Views.Main.Configs
{
	// Token: 0x0200019C RID: 412
	public partial class Stacker : Page, IStyleConnector
	{
		// Token: 0x1400000E RID: 14
		// (add) Token: 0x06000ADC RID: 2780 RVA: 0x00036B9C File Offset: 0x00034D9C
		// (remove) Token: 0x06000ADD RID: 2781 RVA: 0x00036BD4 File Offset: 0x00034DD4
		public event Stacker.SaveConfigEventHandler SaveConfig;

		// Token: 0x06000ADE RID: 2782 RVA: 0x00036C0C File Offset: 0x00034E0C
		protected virtual void OnSaveConfig()
		{
			try
			{
				this.SvbScriptEditor_LostFocus(this, null);
			}
			catch
			{
			}
			Stacker.SaveConfigEventHandler saveConfig = this.SaveConfig;
			if (saveConfig != null)
			{
				saveConfig(this, EventArgs.Empty);
			}
			try
			{
				LogEntry logEntry = GlobalData.Logger.Entries.LastOrDefault<LogEntry>();
				if ((logEntry != null && !logEntry.LogString.StartsWith("Failed to save the config. Reason:") && logEntry.LogLevel != 2) || logEntry == null)
				{
					this.<OnSaveConfig>g__Saved|15_2();
				}
				else
				{
					this.<OnSaveConfig>g__CouldNotSave|15_1();
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000ADF RID: 2783 RVA: 0x00036CA0 File Offset: 0x00034EA0
		public Stacker()
		{
			this.vm = GlobalData.Stacker;
			base.DataContext = this.vm;
			this.InitializeComponent();
			this.VarLogsInitSettings();
			this.LogsInitSettings();
			this.SvbScriptEditorInitSettings();
			this.RawLogInitSettings();
			this.ButtonShowVariables_Click(this.showVarsButton, null);
			this.EnableScrolling = (Action)Delegate.Combine(this.EnableScrolling, new Action(delegate()
			{
				try
				{
					this.BlockInfoScrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
					this.BlockInfoScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
				}
				catch
				{
				}
			}));
			this.svbScriptEditor.TextArea.TextView.LinkTextForegroundBrush = new SolidColorBrush(Colors.DodgerBlue);
			this.logs.TextArea.TextView.LinkTextForegroundBrush = new SolidColorBrush(Colors.DodgerBlue);
			using (XmlReader xmlReader = XmlReader.Create(Constants.HighlightingFolder + "\\ScriptHighlighting.xshd"))
			{
				this.svbScriptEditor.SyntaxHighlighting = HighlightingLoader.Load(xmlReader, HighlightingManager.Instance);
				this.svbScriptEditor.KeyDown += this.SvbScriptEditor_KeyDown;
				this.svbScriptEditor.TextArea.TextEntering += this.TextArea_TextEntering;
				this.svbScriptEditor.TextArea.TextEntered += this.TextArea_TextEntered;
				this.vm.LS = new SvbScript((GlobalData.ConfigManager.CurrentConfig != null) ? GlobalData.ConfigManager.CurrentConfig.Config.Script : "");
				this.svbScriptEditor.Text = this.vm.LS.Script;
				if (!GlobalData.SBSettings.General.DisplaySvbScriptOnLoad)
				{
					this.StackButton_Click(this, null);
				}
				foreach (object obj in Enum.GetValues(typeof(ProxyType)))
				{
					ProxyType proxyType = (ProxyType)obj;
					if (proxyType != 4)
					{
						this.proxyTypeCombobox.Items.Add(proxyType);
					}
				}
				this.proxyTypeCombobox.SelectedIndex = 0;
				foreach (string newItem in GlobalData.Settings.Environment.GetWordlistTypeNames())
				{
					this.testDataTypeComboBox.Items.Add(newItem);
				}
				this.testDataTypeComboBox.SelectedIndex = 0;
				this.debugger.WorkerSupportsCancellation = true;
				this.debugger.Status = 0;
				this.debugger.DoWork += this.DebuggerCheck;
				this.debugger.RunWorkerCompleted += this.DebuggerCompleted;
				this.SaveConfig += GlobalData.MainWindow.ConfigsSecionPage.ConfigManagerPage.OnSaveConfig;
				this.SetCommandMethods();
				this.SetBlocksToComboBox();
				this.vm.Stack.CollectionChanged += this.Stack_CollectionChanged;
				this.persistLogCheckBox.IsChecked = new bool?(GlobalData.SBSettings.General.PersistDebuggerLog);
				try
				{
					WebViewOptions defaultWebViewOptions = new WebViewOptions
					{
						EnableWebSecurity = new bool?(false),
						AllowJavaScriptCloseWindow = new bool?(true),
						AllowJavaScriptAccessClipboard = new bool?(false),
						AllowZooming = new bool?(true)
					};
					EngineOptions.Default.SetDefaultWebViewOptions(defaultWebViewOptions);
				}
				catch
				{
				}
				this.SetBrowserStatus("Initialized!");
				foreach (object obj2 in Enum.GetValues(typeof(Stretch)))
				{
					Stretch stretch = (Stretch)obj2;
					this.origImgStretchComboBox.Items.Add(stretch);
					this.procImgStretchComboBox.Items.Add(stretch);
				}
			}
		}

		// Token: 0x06000AE0 RID: 2784 RVA: 0x0003710C File Offset: 0x0003530C
		private void TextArea_TextEntered(object sender, TextCompositionEventArgs e)
		{
			try
			{
				if (!(e.Text == "\n") && GlobalData.SBSettings.General.ScriptCompletion)
				{
					if (this.completionWindow == null && Keyboard.Modifiers == ModifierKeys.Control && Keyboard.IsKeyDown(Key.Space))
					{
						if (e.Text == " ")
						{
							this.svbScriptEditor.TextArea.Document.Remove(this.svbScriptEditor.CaretOffset - 1, 1);
						}
						this.InvokeCompletionWindow(this.vm.GetAutoCompleteList(e.Text), System.Windows.Media.Brushes.White);
					}
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000AE1 RID: 2785 RVA: 0x000371C0 File Offset: 0x000353C0
		private void TextArea_TextEntering(object sender, TextCompositionEventArgs e)
		{
			if (!GlobalData.SBSettings.General.ScriptCompletion)
			{
				return;
			}
			if (e.Text.Length > 0 && this.completionWindow != null && char.IsLetter(e.Text[0]))
			{
				this.completionWindow.CompletionList.RequestInsertion(e);
			}
		}

		// Token: 0x06000AE2 RID: 2786 RVA: 0x0003721C File Offset: 0x0003541C
		private void InvokeCompletionWindow([TupleElementNames(new string[]
		{
			"Text",
			"Description"
		})] IEnumerable<ValueTuple<string, string>> scriptAutoCompleteList, System.Windows.Media.Brush foreground)
		{
			CompletionWindow completionWindow = new CompletionWindow(this.svbScriptEditor.TextArea);
			completionWindow.CompletionList.ListBox.SetResourceReference(Control.BackgroundProperty, "BackgroundSecondary");
			completionWindow.CompletionList.SetResourceReference(Control.BackgroundProperty, "BackgroundSecondary");
			completionWindow.CompletionList.SetResourceReference(Control.ForegroundProperty, "ForegroundMain");
			completionWindow.CompletionList.ListBox.SetResourceReference(Control.ForegroundProperty, "ForegroundMain");
			IList<ICompletionData> completionData = completionWindow.CompletionList.CompletionData;
			if (scriptAutoCompleteList.Any<ValueTuple<string, string>>())
			{
				foreach (ValueTuple<string, string> valueTuple in scriptAutoCompleteList)
				{
					completionData.Add(new ScriptCompletionData(valueTuple.Item1, valueTuple.Item2));
				}
				completionWindow.Show();
				completionWindow.Closed += delegate([Nullable(2)] object <p0>, EventArgs <p1>)
				{
					completionWindow = null;
				};
			}
		}

		// Token: 0x06000AE3 RID: 2787 RVA: 0x00037340 File Offset: 0x00035540
		private void SetCommandMethods()
		{
		}

		// Token: 0x06000AE4 RID: 2788 RVA: 0x00037342 File Offset: 0x00035542
		private void SetBlocksToComboBox()
		{
			this.vm.Blocks = new ObservableCollection<SilverBlock>(GlobalData.BlockMappings);
		}

		// Token: 0x06000AE5 RID: 2789 RVA: 0x0003735C File Offset: 0x0003555C
		private void AddBlock_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (this.selectBlockComboBox.SelectedIndex < 0)
				{
					if (!string.IsNullOrWhiteSpace(this.selectBlockComboBox.Text) && this.selectBlockComboBox.Text.Contains(">"))
					{
						string[] array = this.selectBlockComboBox.Text.Split('>', StringSplitOptions.None);
						for (int i = 0; i < array.Length; i++)
						{
							string b = array[i];
							SilverBlock silverBlock = this.vm.Blocks.FirstOrDefault((SilverBlock bl) => Stacker.<AddBlock_Click>g__IsValid|22_0(bl, b.ToLower()));
							if (silverBlock == null)
							{
								Alert.Error("'" + b + "' Block not found!!", "Error", false);
								return;
							}
							this.AddBlock(Activator.CreateInstance(silverBlock.Block) as BlockBase);
						}
						this.selectBlockComboBox.SelectedIndex = -1;
						this.selectBlockComboBox.Text = "";
					}
					else
					{
						new MainDialog(new MainDialog.InputDialog
						{
							Dialog = new DialogAddBlock(this),
							Title = "Add Block"
						}).ShowDialog();
					}
				}
				else if (string.IsNullOrWhiteSpace(this.selectBlockComboBox.Text))
				{
					Alert.Warning("Block not found!", "Warning", false);
				}
				else
				{
					BlockBase block = Activator.CreateInstance(((SilverBlock)this.selectBlockComboBox.SelectedItem).Block) as BlockBase;
					this.AddBlock(block);
					this.selectBlockComboBox.SelectedIndex = -1;
				}
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x06000AE6 RID: 2790 RVA: 0x00037504 File Offset: 0x00035704
		public void AddBlock(BlockBase block)
		{
			int num;
			if (this.vm.CurrentBlockIndex == -1)
			{
				num = this.vm.Stack.Count;
			}
			else
			{
				num = ((this.vm.Stack.Count > 0) ? (this.vm.CurrentBlockIndex + 1) : 0);
			}
			LoggerViewModel logger = GlobalData.Logger;
			Components component = Components.Stacker;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(35, 2);
			defaultInterpolatedStringHandler.AppendLiteral("Added a block of type ");
			defaultInterpolatedStringHandler.AppendFormatted<Type>(block.GetType());
			defaultInterpolatedStringHandler.AppendLiteral(" in position ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(num);
			logger.LogInfo(component, defaultInterpolatedStringHandler.ToStringAndClear(), false, 0);
			this.vm.UndoBlocks.Push(new StackerViewModel.UndoRedoBlock(this.vm.AddBlock(block, num), num, StackerViewModel.UndoRedoState.Added));
		}

		// Token: 0x06000AE7 RID: 2791 RVA: 0x000375C5 File Offset: 0x000357C5
		private void ReloadBlocks_Click(object sender, RoutedEventArgs e)
		{
			this.SwitchView(true);
		}

		// Token: 0x06000AE8 RID: 2792 RVA: 0x000375CE File Offset: 0x000357CE
		private void SaveConfig_Click(object sender, RoutedEventArgs e)
		{
			this.OnSaveConfig();
		}

		// Token: 0x06000AE9 RID: 2793 RVA: 0x000375D8 File Offset: 0x000357D8
		private void Page_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keyboard.Modifiers == ModifierKeys.Control)
			{
				Key key = e.Key;
				if (key != Key.C)
				{
					switch (key)
					{
					case Key.R:
						if (this.vm.View == StackerView.Blocks)
						{
							this.SwitchView(true);
						}
						break;
					case Key.S:
						if (this.vm.View == StackerView.SvbScript)
						{
							this.vm.LS.Script = this.svbScriptEditor.Text;
						}
						this.SaveConfig_Click(null, null);
						return;
					case Key.T:
					case Key.U:
					case Key.W:
					case Key.X:
						break;
					case Key.V:
						if (!GlobalData.SBSettings.General.DisableCopyPasteBlocks && this.stackListView.Focusable)
						{
							this.vm.PasteBlocks("");
							return;
						}
						break;
					case Key.Y:
						if (this.stackListView.Focusable)
						{
							this.vm.RedoBlock();
							return;
						}
						break;
					case Key.Z:
						if (this.stackListView.Focusable)
						{
							this.vm.UndoBlock();
							return;
						}
						break;
					default:
						return;
					}
				}
				else if (!GlobalData.SBSettings.General.DisableCopyPasteBlocks && this.stackListView.Focusable)
				{
					this.vm.CopyBlocks();
					return;
				}
			}
		}

		// Token: 0x06000AEA RID: 2794 RVA: 0x00037707 File Offset: 0x00035907
		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			this.OcrTestModeClicked();
		}

		// Token: 0x06000AEB RID: 2795 RVA: 0x00037710 File Offset: 0x00035910
		public void AutoSaveCfgClicked(bool autoSave)
		{
			foreach (StackerBlockViewModel stackerBlockViewModel in this.vm.Stack)
			{
				if (!autoSave)
				{
					stackerBlockViewModel.Page.LostFocus -= delegate(object <p0>, RoutedEventArgs <p1>)
					{
						this.AutoSaveConfig();
					};
				}
				else
				{
					stackerBlockViewModel.Page.LostFocus += delegate(object <p0>, RoutedEventArgs <p1>)
					{
						this.AutoSaveConfig();
					};
				}
			}
		}

		// Token: 0x06000AEC RID: 2796 RVA: 0x00037790 File Offset: 0x00035990
		private void StartDebuggerButton_Click(object sender, RoutedEventArgs e)
		{
			switch (this.debugger.Status)
			{
			case 0:
				if (this.vm.View == StackerView.Blocks)
				{
					this.vm.LS.FromBlocks(this.vm.GetList());
				}
				else if (this.vm.View == StackerView.SvbScript)
				{
					this.vm.LS.Script = this.svbScriptEditor.Text;
				}
				if (this.debuggerTabControl.SelectedIndex == 1)
				{
					this.logs.Focus();
				}
				this.vm.ControlsEnabled = false;
				if (!GlobalData.SBSettings.General.PersistDebuggerLog)
				{
					this.logs.Clear();
					if (GlobalData.SBSettings.General.SendDebuggerLogToNotepadPlus)
					{
						try
						{
							NotepadPlusExtension.Clear();
						}
						catch
						{
						}
					}
					this.logs.Text = string.Empty;
				}
				this.dataLogs.Document.Blocks.Clear();
				try
				{
					this.origImage.Source = null;
				}
				catch
				{
				}
				try
				{
					this.procImage.Source = null;
				}
				catch
				{
				}
				try
				{
					this.ocrResultTextBox.Text = string.Empty;
				}
				catch
				{
				}
				if (!this.debugger.IsBusy)
				{
					this.debugger.RunWorkerAsync();
					GlobalData.Logger.LogInfo(Components.Stacker, "Started the debugger", false, 0);
				}
				else
				{
					GlobalData.Logger.LogError(Components.Stacker, "Cannot start the debugger (busy)", false, 0);
				}
				this.vm.SBSEnabled = false;
				this.startButton.SetResourceReference(ContentControl.ContentProperty, "Abort");
				this.DisposeWebView_Click(null, null);
				this.SetBrowserStatus("Initialized!");
				try
				{
					this.webView.Reload(true);
				}
				catch
				{
				}
				IconElement.SetGeometry(this.startButton, Geometry.Parse("M417 550q35 0 59 -24t24 -59v-334q0 -35 -24 -59t-59 -24h-334q-35 0 -59 24t-24 59v334q0 35 24 59t59 24h334z"));
				this.debugger.Status = 1;
				return;
			case 1:
				if (this.debugger.IsBusy)
				{
					this.debugger.CancelAsync();
					GlobalData.Logger.LogInfo(Components.Stacker, "Sent Cancellation Request to the debugger", false, 0);
				}
				this.startButton.SetResourceReference(ContentControl.ContentProperty, "Force");
				IconElement.SetGeometry(this.startButton, Geometry.Parse("M417 550q35 0 59 -24t24 -59v-334q0 -35 -24 -59t-59 -24h-334q-35 0 -59 24t-24 59v334q0 35 24 59t59 24h334z"));
				this.debugger.Status = 2;
				return;
			case 2:
				this.tempSrc = null;
				this.debugger.Abort();
				GlobalData.Logger.LogInfo(Components.Stacker, "Hard aborted the debugger", false, 0);
				this.startButton.SetResourceReference(ContentControl.ContentProperty, "Start");
				IconElement.SetGeometry(this.startButton, Geometry.Parse("M128 896v-896l768 448z"));
				this.SetStartDebug();
				this.debugger.Status = 0;
				this.vm.ControlsEnabled = true;
				return;
			default:
				return;
			}
		}

		// Token: 0x06000AED RID: 2797 RVA: 0x00037A84 File Offset: 0x00035C84
		private void StartDebugButton_Click(object sender, RoutedEventArgs e)
		{
			if (((TextBlock)this.panelStartDebug.Children[1]).Tag.ToString() == "Step")
			{
				this.vm.SBSClear = true;
				return;
			}
			this.vm.SBSEnabled = false;
			this.vm.SBS = true;
			this.SetDebugStepOver();
			this.StartDebuggerButton_Click(sender, e);
		}

		// Token: 0x06000AEE RID: 2798 RVA: 0x00037AF0 File Offset: 0x00035CF0
		private void SetDebugStepOver()
		{
			this.panelStartDebug.Children.RemoveAt(0);
			this.panelStartDebug.Children.Insert(0, new PackIconMaterial
			{
				Kind = 2096,
				Margin = new Thickness(-3.0, 0.0, 5.0, 0.0),
				Width = 19.0
			});
			TextBlock textBlock = (TextBlock)this.panelStartDebug.Children[1];
			textBlock.SetResourceReference(TextBlock.TextProperty, "Stacker_Step");
			textBlock.Tag = "Step";
		}

		// Token: 0x06000AEF RID: 2799 RVA: 0x00037BA0 File Offset: 0x00035DA0
		private void SetStartDebug()
		{
			TextBlock textBlock = (TextBlock)this.panelStartDebug.Children[1];
			if (textBlock.Tag.ToString() == "Start Debug")
			{
				return;
			}
			this.panelStartDebug.Children.RemoveAt(0);
			this.panelStartDebug.Children.Insert(0, new PackIconCodicons
			{
				Kind = 74,
				Margin = new Thickness(0.0, 0.0, 3.0, 0.0),
				Width = 20.0,
				Height = 17.5
			});
			textBlock.Tag = "Start Debug";
			textBlock.SetResourceReference(TextBlock.TextProperty, "Stacker_StartDebug");
			this.vm.SBSEnabled = true;
		}

		// Token: 0x06000AF0 RID: 2800 RVA: 0x00037C80 File Offset: 0x00035E80
		private void DebuggerCheck(object sender, DoWorkEventArgs e)
		{
			try
			{
				string moduleDir = IApplication.NodeJSModulePaths;
				if (!Directory.Exists(moduleDir))
				{
					Directory.CreateDirectory(moduleDir);
				}
				StaticNodeJSService.Configure<NodeJSProcessOptions>(delegate(NodeJSProcessOptions opt)
				{
					opt.ProjectPath = moduleDir;
				});
				this.tempSrc = null;
				if (this.vm.BotData != null)
				{
					if (this.vm.BotData.IsPuppeteerOpen)
					{
						GlobalData.Logger.LogInfo(Components.Stacker, "Quitting the previously opened Puppeteer browser", false, 0);
						this.vm.BotData.PuppeteerBrowser.CloseAsync().GetAwaiter().GetResult();
						this.vm.BotData.DisposeObjectsExcept(new string[]
						{
							"Puppeteer.CustomProxy"
						});
						GlobalData.Logger.LogInfo(Components.Stacker, "Quitted correctly", false, 0);
					}
					if (this.vm.BotData.IsSeleniumOpen)
					{
						GlobalData.Logger.LogInfo(Components.Stacker, "Quitting the previously opened Selenium browser", false, 0);
						try
						{
							this.vm.BotData.SeleniumBrowser.Close();
						}
						catch
						{
						}
						this.vm.BotData.SeleniumBrowser.Quit();
						GlobalData.Logger.LogInfo(Components.Stacker, "Quitted correctly", false, 0);
					}
				}
				GlobalData.Logger.LogInfo(Components.Stacker, "Converting Observables", false, 0);
				this.vm.ConvertKeychains();
				GlobalData.Logger.LogInfo(Components.Stacker, "Initializing the request data", false, 0);
				CProxy cproxy = null;
				if (this.vm.TestProxy.StartsWith("("))
				{
					try
					{
						cproxy = new CProxy().Parse(this.vm.TestProxy, 0, "", "");
						goto IL_1D6;
					}
					catch
					{
						GlobalData.Logger.LogError(Components.Stacker, "Invalid Proxy Syntax", true, 0);
						goto IL_1D6;
					}
				}
				cproxy = new CProxy(this.vm.TestProxy, this.vm.ProxyType);
				IL_1D6:
				CData cdata = new CData(this.vm.TestData, GlobalData.Settings.Environment.GetWordlistType(this.vm.TestDataType));
				BotData botData = this.vm.BotData;
				if (botData != null)
				{
					botData.Dispose();
				}
				this.vm.BotData = new BotData(GlobalData.Settings.CoreSettings, this.vm.ConfigViewModel.Config.Settings, cdata, cproxy, this.vm.UseProxy, new Random(), 0, true)
				{
					BotsAmount = 1,
					CsCodeExecutor = new CsCodeExecutor(),
					BotNumber = 1,
					Worker = this.debugger
				};
				this.vm.LS.Reset();
				using (IEnumerator<CustomInput> enumerator = this.vm.BotData.ConfigSettings.CustomInputs.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						CustomInput input = enumerator.Current;
						GlobalData.Logger.LogInfo(Components.Stacker, "Asking for user input: " + input.Description, false, 0);
						Application.Current.Dispatcher.Invoke(delegate()
						{
							new MainDialog(new MainDialog.InputDialog
							{
								Dialog = new DialogCustomInput(this.vm, input),
								Title = "Custom Input"
							}).ShowDialog();
						});
					}
				}
				GlobalData.Logger.LogInfo(Components.Stacker, "Setting the first block as the current block", false, 0);
				string value = this.vm.UseProxy ? "ENABLED" : "DISABLED";
				List<LogEntry> logBuffer = this.vm.BotData.LogBuffer;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(66, 6);
				defaultInterpolatedStringHandler.AppendLiteral("===== DEBUGGER STARTED FOR CONFIG ");
				defaultInterpolatedStringHandler.AppendFormatted(this.vm.ConfigViewModel.Name);
				defaultInterpolatedStringHandler.AppendLiteral(" WITH DATA ");
				defaultInterpolatedStringHandler.AppendFormatted(this.vm.TestData);
				defaultInterpolatedStringHandler.AppendLiteral(" AND PROXY ");
				defaultInterpolatedStringHandler.AppendFormatted(this.vm.TestProxy);
				defaultInterpolatedStringHandler.AppendLiteral(" (");
				defaultInterpolatedStringHandler.AppendFormatted<ProxyType>(this.vm.ProxyType);
				defaultInterpolatedStringHandler.AppendLiteral(") ");
				defaultInterpolatedStringHandler.AppendFormatted(value);
				defaultInterpolatedStringHandler.AppendLiteral(" =====");
				defaultInterpolatedStringHandler.AppendFormatted(Environment.NewLine);
				logBuffer.Add(new LogEntry(defaultInterpolatedStringHandler.ToStringAndClear(), System.Drawing.Color.White));
				this.timer = new Stopwatch();
				int num = 1;
				this.timer.Start();
				if (this.vm.ConfigViewModel.Config.Settings.SeleniumAlwaysOpen)
				{
					new BlockSeleniumOpenBrowser().Process(this.vm.BotData);
				}
				if (this.vm.ConfigViewModel.Config.Settings.PuppeteerAlwaysOpen)
				{
					new BlockPuppeteerOpenBrowser().Process(this.vm.BotData);
				}
				if (!this.vm.SBS)
				{
					while (!this.debugger.CancellationPending)
					{
						this.CheckBreakpoint(num);
						this.Process();
						num++;
						if (!this.vm.LS.CanProceed)
						{
							goto IL_5CC;
						}
					}
					GlobalData.Logger.LogInfo(Components.Stacker, "Found cancellation pending, aborting debugger", false, 0);
					return;
				}
				this.vm.SBS = false;
				this.vm.SBSClear = true;
				for (;;)
				{
					Thread.Sleep(100);
					if (this.debugger.CancellationPending)
					{
						break;
					}
					if (this.vm.SBSClear)
					{
						this.vm.SBSEnabled = false;
						this.Process();
						LoggerViewModel logger = GlobalData.Logger;
						Components component = Components.Stacker;
						defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(42, 1);
						defaultInterpolatedStringHandler.AppendLiteral("Block processed in SBS mode, can proceed: ");
						defaultInterpolatedStringHandler.AppendFormatted<bool>(this.vm.LS.CanProceed);
						logger.LogInfo(component, defaultInterpolatedStringHandler.ToStringAndClear(), false, 0);
						this.vm.SBSEnabled = true;
						this.vm.SBSClear = false;
					}
					if (!this.vm.LS.CanProceed)
					{
						goto Block_16;
					}
				}
				GlobalData.Logger.LogInfo(Components.Stacker, "Found cancellation pending, aborting debugger", false, 0);
				return;
				Block_16:
				IL_5CC:
				this.vm.SBS = false;
				this.vm.SBSEnabled = true;
				if (this.vm.ConfigViewModel.Config.Settings.PuppeteerAlwaysQuit || this.vm.ConfigViewModel.Config.Settings.PuppeteerQuitBrowserStatuses.Any((string s) => s == this.vm.BotData.StatusString))
				{
					try
					{
						this.vm.BotData.PuppeteerBrowser.CloseAsync().GetAwaiter().GetResult();
						GlobalData.Logger.LogInfo(Components.Stacker, "Successfully quit the puppeteer browser", false, 0);
					}
					catch (Exception ex)
					{
						GlobalData.Logger.LogError(Components.Stacker, "Cannot quit the puppeteer browser - " + ex.Message, false, 0);
					}
				}
				if (this.vm.ConfigViewModel.Config.Settings.SeleniumAlwaysQuit || this.vm.ConfigViewModel.Config.Settings.SeleniumQuitBrowserStatuses.Any((string s) => s == this.vm.BotData.StatusString))
				{
					try
					{
						this.vm.BotData.SeleniumBrowser.Quit();
						GlobalData.Logger.LogInfo(Components.Stacker, "Successfully quit the selenium browser", false, 0);
					}
					catch (Exception ex2)
					{
						GlobalData.Logger.LogError(Components.Stacker, "Cannot quit the selenium browser - " + ex2.Message, false, 0);
					}
				}
				Application.Current.Dispatcher.Invoke(new Action(this.SetStartDebug));
			}
			finally
			{
				base.Dispatcher.Invoke(delegate()
				{
					this.SetStartDebug();
				});
				this.vm.ControlsEnabled = true;
			}
		}

		// Token: 0x06000AF1 RID: 2801 RVA: 0x00038480 File Offset: 0x00036680
		private void CheckBreakpoint(int blockIndex)
		{
			if (!this.vm.Breakpoint)
			{
				return;
			}
			if (blockIndex == 1)
			{
				base.Dispatcher.Invoke(delegate()
				{
					this.SetDebugStepOver();
				});
			}
			SvbScript.Breakpoint breakpoint;
			if ((breakpoint = this.vm.Breakpoints.FirstOrDefault((SvbScript.Breakpoint br) => !br.Block.Disabled && br.Index == blockIndex - 1)) != null)
			{
				base.Dispatcher.Invoke<int>(() => this.breakpointComboBox.SelectedIndex = this.vm.Breakpoints.IndexOf(breakpoint));
				this.vm.SBSClear = false;
				this.vm.SBSEnabled = true;
				while (!this.vm.SBSClear)
				{
					Thread.Sleep(100);
					if (this.debugger.CancellationPending)
					{
						GlobalData.Logger.LogInfo(Components.Stacker, "Found cancellation pending, aborting debugger", false, 0);
						return;
					}
				}
				this.vm.SBSEnabled = false;
				base.Dispatcher.Invoke<int>(() => this.breakpointComboBox.SelectedIndex = -1);
			}
		}

		// Token: 0x06000AF2 RID: 2802 RVA: 0x00038584 File Offset: 0x00036784
		private void Process()
		{
			try
			{
				if (this.vm.BotData.Return)
				{
					if (this.debugger.Status == 1)
					{
						base.Dispatcher.Invoke(delegate()
						{
							this.StartDebuggerButton_Click(null, null);
						});
					}
					return;
				}
				this.vm.LS.TakeStep(this.vm.BotData);
				GlobalData.Logger.LogInfo(Components.Stacker, "Processed " + BlockBase.TruncatePretty(this.vm.LS.CurrentLine, 20), false, 0);
			}
			catch (Exception ex)
			{
				GlobalData.Logger.LogError(Components.Stacker, "Processing of line " + BlockBase.TruncatePretty(this.vm.LS.CurrentLine, 20) + " failed, exception: " + ex.Message, false, 0);
			}
			try
			{
				this.PrintBotData();
			}
			catch
			{
			}
			try
			{
				this.PrintLogBuffer();
			}
			catch
			{
			}
			try
			{
				this.DisplayHTML();
			}
			catch
			{
			}
			try
			{
				this.DisplayCaptcha();
			}
			catch
			{
			}
		}

		// Token: 0x06000AF3 RID: 2803 RVA: 0x000386C4 File Offset: 0x000368C4
		private void PrintLogBuffer()
		{
			if (this.vm.BotData.LogBuffer.Count == 0)
			{
				return;
			}
			base.Dispatcher.Invoke(delegate()
			{
				for (int i = 0; i < this.vm.BotData.LogBuffer.Count; i++)
				{
					LogEntry logEntry = this.vm.BotData.LogBuffer[i];
					if (!GlobalData.SBSettings.General.DisableDebuggerLog)
					{
						this.logs.AppendLine(logEntry.LogString, logEntry.LogColor);
						this.logs.TextArea.Caret.BringCaretToView();
						this.logs.ScrollToLine(this.logs.LineCount);
						BinaryReader reader = this.vm.Reader;
						if (reader != null)
						{
							reader.Dispose();
						}
						if (this.vm.BotData.Source != null)
						{
							this.vm.Reader = new BinaryReader(new MemoryStream(ArrayExtension.ToByteArray(StringExtension.ToHex(this.vm.BotData.Source))));
						}
					}
					if (GlobalData.SBSettings.General.SendDebuggerLogToNotepadPlus)
					{
						NotepadPlusExtension.ShowText(logEntry.LogString + Environment.NewLine);
					}
				}
				this.vm.BotData.LogBuffer.Add(new LogEntry(Environment.NewLine, System.Drawing.Color.White));
			});
		}

		// Token: 0x06000AF4 RID: 2804 RVA: 0x000386F5 File Offset: 0x000368F5
		private void PrintBotData()
		{
			base.Dispatcher.Invoke(delegate()
			{
				this.dataLogs.Document.Blocks.Clear();
				this.dataLogs.AppendText(Environment.NewLine);
				this.dataLogs.AppendText("BOT STATUS: " + this.vm.BotData.StatusString + Environment.NewLine, Colors.White);
				switch (this.logFilterComboBox.SelectedIndex)
				{
				case 0:
					this.dataLogs.AppendLine("VARIABLES:", Colors.Yellow);
					if (GlobalData.SBSettings.General.DisplayCapturesLast)
					{
						foreach (CVar cvar in from v in this.vm.BotData.Variables.All
						where !v.Hidden && !v.IsCapture
						select v)
						{
							RichTextBox box = this.dataLogs;
							string name = cvar.Name;
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 1);
							defaultInterpolatedStringHandler.AppendLiteral(" (");
							defaultInterpolatedStringHandler.AppendFormatted<CVar.VarType>(cvar.Type);
							defaultInterpolatedStringHandler.AppendLiteral(") = ");
							box.AppendLine(name + defaultInterpolatedStringHandler.ToStringAndClear() + cvar.ToString(), Colors.Yellow);
						}
						using (IEnumerator<CVar> enumerator = (from v in this.vm.BotData.Variables.All
						where !v.Hidden && v.IsCapture
						select v).GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								CVar cvar2 = enumerator.Current;
								RichTextBox box2 = this.dataLogs;
								string name2 = cvar2.Name;
								DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 1);
								defaultInterpolatedStringHandler.AppendLiteral(" (");
								defaultInterpolatedStringHandler.AppendFormatted<CVar.VarType>(cvar2.Type);
								defaultInterpolatedStringHandler.AppendLiteral(") = ");
								box2.AppendLine(name2 + defaultInterpolatedStringHandler.ToStringAndClear() + cvar2.ToString(), Colors.Tomato);
							}
							return;
						}
					}
					using (IEnumerator<CVar> enumerator = (from v in this.vm.BotData.Variables.All
					where !v.Hidden
					select v).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							CVar cvar3 = enumerator.Current;
							RichTextBox box3 = this.dataLogs;
							string name3 = cvar3.Name;
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 1);
							defaultInterpolatedStringHandler.AppendLiteral(" (");
							defaultInterpolatedStringHandler.AppendFormatted<CVar.VarType>(cvar3.Type);
							defaultInterpolatedStringHandler.AppendLiteral(") = ");
							box3.AppendLine(name3 + defaultInterpolatedStringHandler.ToStringAndClear() + cvar3.ToString(), cvar3.IsCapture ? Colors.Tomato : Colors.Yellow);
						}
						return;
					}
					break;
				case 1:
					break;
				case 2:
					goto IL_39A;
				default:
					return;
				}
				this.dataLogs.AppendLine("VARIABLES:", Colors.Yellow);
				using (IEnumerator<CVar> enumerator = (from v in this.vm.BotData.Variables.All
				where !v.Hidden && !v.IsCapture
				select v).GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						CVar cvar4 = enumerator.Current;
						RichTextBox box4 = this.dataLogs;
						string name4 = cvar4.Name;
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 1);
						defaultInterpolatedStringHandler.AppendLiteral(" (");
						defaultInterpolatedStringHandler.AppendFormatted<CVar.VarType>(cvar4.Type);
						defaultInterpolatedStringHandler.AppendLiteral(") = ");
						box4.AppendLine(name4 + defaultInterpolatedStringHandler.ToStringAndClear() + cvar4.ToString(), Colors.Yellow);
					}
					return;
				}
				IL_39A:
				this.dataLogs.AppendLine("CAPTURES:", Colors.Tomato);
				foreach (CVar cvar5 in from v in this.vm.BotData.Variables.All
				where !v.Hidden && v.IsCapture
				select v)
				{
					RichTextBox box5 = this.dataLogs;
					string name5 = cvar5.Name;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 1);
					defaultInterpolatedStringHandler.AppendLiteral(" (");
					defaultInterpolatedStringHandler.AppendFormatted<CVar.VarType>(cvar5.Type);
					defaultInterpolatedStringHandler.AppendLiteral(") = ");
					box5.AppendLine(name5 + defaultInterpolatedStringHandler.ToStringAndClear() + cvar5.ToString(), Colors.Tomato);
				}
			});
		}

		// Token: 0x06000AF5 RID: 2805 RVA: 0x0003870E File Offset: 0x0003690E
		private void DisplayHTML()
		{
			if (GlobalData.SBSettings.General.DisableHTMLView)
			{
				return;
			}
			base.Dispatcher.Invoke(delegate()
			{
				if (this.vm.BotData.Source != string.Empty)
				{
					int? num = this.tempSrc;
					int hashCode = this.vm.BotData.Source.GetHashCode();
					if (!(num.GetValueOrDefault() == hashCode & num != null))
					{
						if (GlobalData.SBSettings.General.LocalHTMLViewer)
						{
							WebView webView = this.webView;
							if (webView != null)
							{
								webView.LoadHtml(this.vm.BotData.Source);
							}
							this.tempSrc = new int?(this.vm.BotData.Source.GetHashCode());
							return;
						}
						if (GlobalData.SBSettings.General.EnableCookiesInBrowser)
						{
							string host = new Uri(this.vm.BotData.Address).Host;
							foreach (KeyValuePair<string, string> keyValuePair in this.vm.BotData.Cookies)
							{
								try
								{
									this.webView.Engine.CookieManager.SetCookie(this.vm.BotData.Address, new Cookie(keyValuePair.Key, keyValuePair.Value)
									{
										Domain = host,
										Path = "/"
									});
								}
								catch
								{
								}
							}
							foreach (KeyValuePair<string, string> keyValuePair2 in this.vm.BotData.GlobalCookies)
							{
								try
								{
									this.webView.Engine.CookieManager.SetCookie(this.vm.BotData.Address, new Cookie(keyValuePair2.Key, keyValuePair2.Value)
									{
										Domain = host,
										Path = "/"
									});
								}
								catch
								{
								}
							}
						}
						if (!this.vm.BotData.HasImage)
						{
							WebView webView2 = this.webView;
							if (webView2 != null)
							{
								webView2.LoadHtml(this.vm.BotData.Source, this.vm.BotData.Address);
							}
						}
						else
						{
							WebView webView3 = this.webView;
							if (webView3 != null)
							{
								webView3.LoadUrl(this.vm.BotData.Address);
							}
						}
						this.tempSrc = new int?(this.vm.BotData.Source.GetHashCode());
					}
				}
			});
		}

		// Token: 0x06000AF6 RID: 2806 RVA: 0x0003873C File Offset: 0x0003693C
		private void DisplayCaptcha()
		{
			if (this.vm.BotData.ConfigSettings.EnableTestMode)
			{
				int? num = this.tempOrigCaptcha;
				if (num != null)
				{
					num = this.tempOrigCaptcha;
					int hashCode = this.vm.BotData.OriginalCaptcha.GetHashCode();
					if (num.GetValueOrDefault() == hashCode & num != null)
					{
						num = this.tempProcCaptcha;
						if (num != null)
						{
							num = this.tempProcCaptcha;
							hashCode = this.vm.BotData.OriginalCaptcha.GetHashCode();
							if (num.GetValueOrDefault() == hashCode & num != null)
							{
								return;
							}
						}
					}
				}
				this.tempOrigCaptcha = new int?(this.vm.BotData.OriginalCaptcha.GetHashCode());
				this.tempProcCaptcha = new int?(this.vm.BotData.OriginalCaptcha.GetHashCode());
				base.Dispatcher.Invoke(delegate()
				{
					try
					{
						this.origImage.Source = this.vm.BotData.OriginalCaptcha.ToImageSource();
					}
					catch
					{
					}
					try
					{
						this.procImage.Source = this.vm.BotData.ProcessedCaptcha.ToImageSource();
					}
					catch
					{
					}
					this.ocrResultTextBox.Text = (string.IsNullOrWhiteSpace(this.vm.BotData.OcrResult) ? "-" : this.vm.BotData.OcrResult) + " (" + this.vm.BotData.OcrRate.ToString().Substring(this.vm.BotData.OcrRate.ToString().IndexOf(".") + 1) + "%)";
				});
				return;
			}
		}

		// Token: 0x06000AF7 RID: 2807 RVA: 0x00038840 File Offset: 0x00036A40
		private void DebuggerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.tempSrc = null;
			this.timer.Stop();
			this.debugger.Status = 0;
			this.startButton.SetResourceReference(ContentControl.ContentProperty, "Start");
			IconElement.SetGeometry(this.startButton, Geometry.Parse("M128 896v-896l768 448z"));
			this.vm.SBSEnabled = true;
			this.vm.ControlsEnabled = true;
			this.vm.BotData.LogBuffer.Clear();
			if (!this.vm.BotData.Data.IsValid)
			{
				this.vm.BotData.LogBuffer.Add(new LogEntry("WARNING: The test input data did not respect the validity regex for the selected wordlist type!", System.Drawing.Color.Tomato));
			}
			if (!this.vm.BotData.Data.RespectsRules(this.vm.ConfigViewModel.Config.Settings.DataRules.ToList<DataRule>()))
			{
				this.vm.BotData.LogBuffer.Add(new LogEntry("WARNING: The test input data did not respect the data rules of this config!", System.Drawing.Color.Tomato));
			}
			List<LogEntry> logBuffer = this.vm.BotData.LogBuffer;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(57, 2);
			defaultInterpolatedStringHandler.AppendLiteral("===== DEBUGGER ENDED AFTER ");
			defaultInterpolatedStringHandler.AppendFormatted<double>((double)this.timer.ElapsedMilliseconds / 1000.0);
			defaultInterpolatedStringHandler.AppendLiteral(" SECOND(S) WITH STATUS: ");
			defaultInterpolatedStringHandler.AppendFormatted(this.vm.BotData.StatusString);
			defaultInterpolatedStringHandler.AppendLiteral(" =====");
			logBuffer.Add(new LogEntry(defaultInterpolatedStringHandler.ToStringAndClear(), System.Drawing.Color.White));
			this.vm.BotData.LogBuffer.Add(new LogEntry("==== [" + DateTime.Now.ToString("MM\\/dd\\/yyyy HH:mm:ss tt") + "] ====", System.Drawing.Color.LightSkyBlue));
			this.PrintLogBuffer();
			GlobalData.Logger.LogInfo(Components.Stacker, "Debugger completed", false, 0);
		}

		// Token: 0x06000AF8 RID: 2808 RVA: 0x00038A3C File Offset: 0x00036C3C
		private void ProxyTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			this.vm.ProxyType = this.proxyTypeCombobox.SelectedIndex;
		}

		// Token: 0x06000AF9 RID: 2809 RVA: 0x00038A54 File Offset: 0x00036C54
		private void TestDataTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			this.vm.TestDataType = (string)this.testDataTypeComboBox.SelectedItem;
		}

		// Token: 0x06000AFA RID: 2810 RVA: 0x00038A74 File Offset: 0x00036C74
		private void BlockClicked(object sender, RoutedEventArgs e)
		{
			ToggleButton toggleButton = sender as ToggleButton;
			StackerBlockViewModel blockById = this.vm.GetBlockById((int)toggleButton.Tag);
			if (!this.vm.Stack.Contains(this.vm.CurrentBlock))
			{
				this.vm.CurrentBlock = null;
			}
			bool flag = Keyboard.Modifiers == ModifierKeys.Shift;
			if (Keyboard.Modifiers == ModifierKeys.Control)
			{
				blockById.Selected = !blockById.Selected;
			}
			else if (flag)
			{
				if (this.vm.CurrentBlock == null || this.vm.CurrentBlock == blockById)
				{
					blockById.Selected = true;
				}
				else
				{
					this.vm.DeselectAll();
					int val = this.vm.Stack.IndexOf(this.vm.CurrentBlock);
					int val2 = this.vm.Stack.IndexOf(blockById);
					int num = Math.Min(val, val2);
					int num2 = Math.Max(val, val2);
					for (int i = num; i <= num2; i++)
					{
						this.vm.Stack[i].Selected = true;
					}
				}
			}
			else
			{
				this.vm.DeselectAll();
				blockById.Selected = true;
			}
			this.vm.CurrentBlock = this.vm.SelectedBlocks.LastOrDefault<StackerBlockViewModel>();
			if (this.vm.CurrentBlock == null)
			{
				this.stackListView.SelectedIndex = -1;
				this.BlockInfo.Content = null;
				this.vm.BlockLabel = string.Empty;
				return;
			}
			if (this.vm.CurrentBlock.Page != null)
			{
				this.BlockInfo.Content = this.vm.CurrentBlock.Page;
			}
			this.vm.BlockLabel = this.vm.CurrentBlock.Block.Label;
		}

		// Token: 0x06000AFB RID: 2811 RVA: 0x00038C44 File Offset: 0x00036E44
		private void BlockDoubleClicked(object sender, MouseButtonEventArgs e)
		{
			try
			{
				StackerBlockViewModel blockById = this.vm.GetBlockById((int)(sender as ToggleButton).Tag);
				if (blockById.Block.GetType() == typeof(BlockParse) || blockById.Block.GetType() == typeof(BlockKeycheck))
				{
					MethodInfo method = blockById.Page.GetType().GetMethod("Page_Loaded", BindingFlags.Instance | BindingFlags.NonPublic);
					if (method != null)
					{
						object page = blockById.Page;
						object[] array = new object[2];
						array[0] = sender;
						method.Invoke(page, array);
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000AFC RID: 2812 RVA: 0x00038CF0 File Offset: 0x00036EF0
		private void StackListView_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.A)
				{
					this.vm.SelectAll();
				}
				else if (e.Key == Key.Delete)
				{
					if (this.vm.Stack.Count == this.vm.SelectedBlocks.Count)
					{
						this.vm.ClearBlocks(true);
					}
					else
					{
						this.vm.RemoveBlock();
					}
				}
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x06000AFD RID: 2813 RVA: 0x00038D88 File Offset: 0x00036F88
		public void SetScript()
		{
			if (this.vm.View == StackerView.Blocks)
			{
				this.vm.LS.FromBlocks(this.vm.GetList());
			}
			else if (this.vm.View == StackerView.SvbScript)
			{
				this.vm.LS.Script = this.svbScriptEditor.Text;
			}
			this.vm.ConfigViewModel.Config.Script = this.vm.LS.Script;
		}

		// Token: 0x06000AFE RID: 2814 RVA: 0x00038E0D File Offset: 0x0003700D
		private void StackButton_Click(object sender, RoutedEventArgs e)
		{
			this.SwitchView(false);
		}

		// Token: 0x06000AFF RID: 2815 RVA: 0x00038E18 File Offset: 0x00037018
		private void SwitchView(bool reloadBlocks = false)
		{
			List<BlockBase> list;
			try
			{
				list = this.vm.LS.ToBlocks();
			}
			catch (Exception ex)
			{
				Alert.Error("Error while converting to blocks, please check the syntax!\n" + ex.Message, "Error", false);
				this.SwitchToSvbScriptEditor();
				return;
			}
			this.vm.ClearBlocks(false);
			for (int i = 0; i < list.Count; i++)
			{
				this.vm.AddBlock(list[i], -1);
			}
			this.vm.CurrentBlock = null;
			this.BlockInfo.Content = null;
			this.vm.BlockLabel = string.Empty;
			if (!reloadBlocks)
			{
				this.SwitchToStackerView();
			}
		}

		// Token: 0x06000B00 RID: 2816 RVA: 0x00038ED0 File Offset: 0x000370D0
		private void SvbScriptEditor_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (Keyboard.Modifiers == ModifierKeys.Control)
				{
					Key key = e.Key;
					if (key != Key.F)
					{
						if (key != Key.H)
						{
							if (key == Key.S)
							{
								if (this.vm.View == StackerView.SvbScript)
								{
									this.vm.LS.Script = this.svbScriptEditor.Text;
								}
								this.OnSaveConfig();
							}
						}
						else
						{
							this.ShowFindReplace(new TextEditorAdapter(this.svbScriptEditor), true);
						}
					}
					else
					{
						this.ButtonFindAndReplace_Click(this, null);
					}
				}
				bool disableSyntaxHelper = GlobalData.SBSettings.General.DisableSyntaxHelper;
			}
			catch
			{
			}
		}

		// Token: 0x06000B01 RID: 2817 RVA: 0x00038F6C File Offset: 0x0003716C
		private void TextBoxData_MouseEnter(object sender, MouseEventArgs e)
		{
			if (this.testDataTypeComboBox.BorderBrush == ResourceExtension.Get<LinearGradientBrush>("PrimaryBrush", ""))
			{
				return;
			}
			this.testDataTypeComboBox.SetResourceReference(Control.BorderBrushProperty, "SecondaryBorderBrush");
		}

		// Token: 0x06000B02 RID: 2818 RVA: 0x00038FA0 File Offset: 0x000371A0
		private void TextBoxData_MouseLeave(object sender, MouseEventArgs e)
		{
			if (this.testDataTypeComboBox.BorderBrush == ResourceExtension.Get<LinearGradientBrush>("PrimaryBrush", ""))
			{
				return;
			}
			this.testDataTypeComboBox.SetResourceReference(Control.BorderBrushProperty, "BorderBrush");
		}

		// Token: 0x06000B03 RID: 2819 RVA: 0x00038FD4 File Offset: 0x000371D4
		private void TextBoxData_GotFocus(object sender, RoutedEventArgs e)
		{
			this.testDataTypeComboBox.SetResourceReference(Control.BorderBrushProperty, "PrimaryBrush");
		}

		// Token: 0x06000B04 RID: 2820 RVA: 0x00038FEB File Offset: 0x000371EB
		private void TextBoxData_LostFocus(object sender, RoutedEventArgs e)
		{
			this.testDataTypeComboBox.SetResourceReference(Control.BorderBrushProperty, "BorderBrush");
		}

		// Token: 0x06000B05 RID: 2821 RVA: 0x00039002 File Offset: 0x00037202
		private void ComboBoxDataType_MouseEnter(object sender, MouseEventArgs e)
		{
			if (this.textBoxTestData.BorderBrush == ResourceExtension.Get<LinearGradientBrush>("PrimaryBrush", ""))
			{
				return;
			}
			this.textBoxTestData.SetResourceReference(Control.BorderBrushProperty, "SecondaryBorderBrush");
			this.TextBoxData_MouseEnter(sender, e);
		}

		// Token: 0x06000B06 RID: 2822 RVA: 0x0003903E File Offset: 0x0003723E
		private void ComboBoxDataType_MouseLeave(object sender, MouseEventArgs e)
		{
			if (this.textBoxTestData.BorderBrush == ResourceExtension.Get<LinearGradientBrush>("PrimaryBrush", ""))
			{
				return;
			}
			this.textBoxTestData.SetResourceReference(Control.BorderBrushProperty, "BorderBrush");
			this.TextBoxData_MouseLeave(sender, e);
		}

		// Token: 0x06000B07 RID: 2823 RVA: 0x0003907A File Offset: 0x0003727A
		private void ComboBoxDataType_GotFocus(object sender, RoutedEventArgs e)
		{
			this.textBoxTestData.SetResourceReference(Control.BorderBrushProperty, "PrimaryBrush");
			this.TextBoxData_GotFocus(sender, e);
		}

		// Token: 0x06000B08 RID: 2824 RVA: 0x00039099 File Offset: 0x00037299
		private void ComboBoxDataType_LostFocus(object sender, RoutedEventArgs e)
		{
			this.textBoxTestData.SetResourceReference(Control.BorderBrushProperty, "BorderBrush");
			this.TextBoxData_LostFocus(sender, e);
		}

		// Token: 0x06000B09 RID: 2825 RVA: 0x000390B8 File Offset: 0x000372B8
		private void TextBoxTestProxy_MouseEnter(object sender, MouseEventArgs e)
		{
			if (this.proxyTypeCombobox.BorderBrush == ResourceExtension.Get<LinearGradientBrush>("PrimaryBrush", ""))
			{
				return;
			}
			this.proxyTypeCombobox.SetResourceReference(Control.BorderBrushProperty, "SecondaryBorderBrush");
		}

		// Token: 0x06000B0A RID: 2826 RVA: 0x000390EC File Offset: 0x000372EC
		private void TextBoxTestProxy_MouseLeave(object sender, MouseEventArgs e)
		{
			if (this.proxyTypeCombobox.BorderBrush == ResourceExtension.Get<LinearGradientBrush>("PrimaryBrush", ""))
			{
				return;
			}
			this.proxyTypeCombobox.SetResourceReference(Control.BorderBrushProperty, "BorderBrush");
		}

		// Token: 0x06000B0B RID: 2827 RVA: 0x00039120 File Offset: 0x00037320
		private void TextBoxTestProxy_GotFocus(object sender, RoutedEventArgs e)
		{
			this.proxyTypeCombobox.SetResourceReference(Control.BorderBrushProperty, "PrimaryBrush");
		}

		// Token: 0x06000B0C RID: 2828 RVA: 0x00039137 File Offset: 0x00037337
		private void TextBoxTestProxy_LostFocus(object sender, RoutedEventArgs e)
		{
			this.proxyTypeCombobox.SetResourceReference(Control.BorderBrushProperty, "BorderBrush");
		}

		// Token: 0x06000B0D RID: 2829 RVA: 0x0003914E File Offset: 0x0003734E
		private void ComboBoxTestProxyType_MouseEnter(object sender, MouseEventArgs e)
		{
			if (this.textBoxTestProxy.BorderBrush == ResourceExtension.Get<LinearGradientBrush>("PrimaryBrush", ""))
			{
				return;
			}
			this.textBoxTestProxy.SetResourceReference(Control.BorderBrushProperty, "SecondaryBorderBrush");
			this.TextBoxTestProxy_MouseEnter(sender, e);
		}

		// Token: 0x06000B0E RID: 2830 RVA: 0x0003918A File Offset: 0x0003738A
		private void ComboBoxTestProxyType_MouseLeave(object sender, MouseEventArgs e)
		{
			if (this.textBoxTestProxy.BorderBrush == ResourceExtension.Get<LinearGradientBrush>("PrimaryBrush", ""))
			{
				return;
			}
			this.textBoxTestProxy.SetResourceReference(Control.BorderBrushProperty, "BorderBrush");
			this.TextBoxTestProxy_MouseLeave(sender, e);
		}

		// Token: 0x06000B0F RID: 2831 RVA: 0x000391C6 File Offset: 0x000373C6
		private void ComboBoxTestProxyType_GotFocus(object sender, RoutedEventArgs e)
		{
			this.textBoxTestProxy.SetResourceReference(Control.BorderBrushProperty, "PrimaryBrush");
			this.TextBoxTestProxy_GotFocus(sender, e);
		}

		// Token: 0x06000B10 RID: 2832 RVA: 0x000391E5 File Offset: 0x000373E5
		private void ComboBoxTestProxyType_LostFocus(object sender, RoutedEventArgs e)
		{
			this.textBoxTestProxy.SetResourceReference(Control.BorderBrushProperty, "BorderBrush");
			this.TextBoxTestProxy_LostFocus(sender, e);
		}

		// Token: 0x06000B11 RID: 2833 RVA: 0x00039204 File Offset: 0x00037404
		private void DataLogs_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.F)
				{
					this.ShowFind(new RichTextBoxAdapter(this.dataLogs));
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000B12 RID: 2834 RVA: 0x0003924C File Offset: 0x0003744C
		private void Logs_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.F)
				{
					this.ShowFind(new TextEditorAdapter(this.logs));
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000B13 RID: 2835 RVA: 0x00039294 File Offset: 0x00037494
		private void ButtonShowVariables_Click(object sender, RoutedEventArgs e)
		{
			this.ClickedCustomTabItem(sender, 0);
		}

		// Token: 0x06000B14 RID: 2836 RVA: 0x0003929E File Offset: 0x0003749E
		private void ButtonShowLog_Click(object sender, RoutedEventArgs e)
		{
			this.ClickedCustomTabItem(sender, 1);
		}

		// Token: 0x06000B15 RID: 2837 RVA: 0x000392A8 File Offset: 0x000374A8
		private void ButtonShowHtml_Click(object sender, RoutedEventArgs e)
		{
			this.ClickedCustomTabItem(sender, 2);
		}

		// Token: 0x06000B16 RID: 2838 RVA: 0x000392B2 File Offset: 0x000374B2
		private void ButtonShowRaw_Click(object sender, RoutedEventArgs e)
		{
			this.ClickedCustomTabItem(sender, 3);
		}

		// Token: 0x06000B17 RID: 2839 RVA: 0x000392BC File Offset: 0x000374BC
		private void ButtonShowCaptcha_Click(object sender, RoutedEventArgs e)
		{
			this.ClickedCustomTabItem(sender, (int)this.captchaIndexTabItem);
		}

		// Token: 0x06000B18 RID: 2840 RVA: 0x000392CC File Offset: 0x000374CC
		private void ClickedCustomTabItem(object sender, int index)
		{
			Button button = sender as Button;
			this.UnSelectItems(button);
			ForegroundColorAnimation.BeginAnimation(button, ResourceExtension.GetBrush("ForegroundOcrRate", ""), 300);
			button.SetResourceReference(Control.ForegroundProperty, "ForegroundOcrRate");
			BackgroundColorAnimation.BeginAnimation(button, ResourceExtension.GetBrush("BackgroundSecondary", ""), 300);
			button.SetResourceReference(Control.BackgroundProperty, "BackgroundSecondary");
			this.debuggerTabControl.SelectedIndex = index;
		}

		// Token: 0x06000B19 RID: 2841 RVA: 0x00039348 File Offset: 0x00037548
		private void UnSelectItems(Button currentTabItem)
		{
			List<Button> list = this.gridTabCtrlItems.FindVisualChildren<Button>().ToList<Button>();
			for (int i = 0; i < list.Count; i++)
			{
				Button button = list[i];
				if (button == currentTabItem)
				{
					button.Cursor = Cursors.Arrow;
				}
				else
				{
					button.SetResourceReference(Control.BackgroundProperty, "MainTabCtrlUnSelectedItemBackground");
					button.SetResourceReference(Control.ForegroundProperty, "ForegroundMainTabCtrlUnSelectedItem");
					button.Cursor = Cursors.Hand;
				}
			}
		}

		// Token: 0x06000B1A RID: 2842 RVA: 0x000393BB File Offset: 0x000375BB
		private void VarLogsInitSettings()
		{
			this.AddContextMenuLogControl(this.dataLogs, false, false);
		}

		// Token: 0x06000B1B RID: 2843 RVA: 0x000393CB File Offset: 0x000375CB
		private void LogsInitSettings()
		{
			this.AddContextMenuLogControl(this.logs, true, true);
		}

		// Token: 0x06000B1C RID: 2844 RVA: 0x000393DC File Offset: 0x000375DC
		private void SvbScriptEditorInitSettings()
		{
			ContextMenu contextMenu = new ContextMenu();
			contextMenu.Items.Add(ContextMenuItemExtension.CreateMenuItem<TextEditor>(ContextMenuItemType.Start, "Start", new RelayCommand<TextEditor>(delegate(TextEditor e)
			{
				this.StartDebuggerButton_Click(e, null);
			}, (TextEditor e) => !string.IsNullOrEmpty(e.Text) && e.Text.Length > 0), this.svbScriptEditor));
			contextMenu.Items.Add(new Separator
			{
				Margin = new Thickness(0.0, 2.0, 0.0, 2.0)
			});
			contextMenu.Items.Add(ContextMenuItemExtension.CreateMenuItem(ContextMenuItemType.Cut, "Cut", new RelayCommand(new Action(this.svbScriptEditor.Cut), () => this.svbScriptEditor.SelectionLength > 0), null));
			contextMenu.Items.Add(ContextMenuItemExtension.CreateMenuItem(ContextMenuItemType.Copy, "Copy", new RelayCommand(new Action(this.svbScriptEditor.Copy), () => this.svbScriptEditor.SelectionLength > 0), null));
			contextMenu.Items.Add(ContextMenuItemExtension.CreateMenuItem(ContextMenuItemType.Paste, "Paste", ApplicationCommands.Paste, null));
			contextMenu.Items.Add(ContextMenuItemExtension.CreateMenuItem(ContextMenuItemType.Delete, "Delete", ApplicationCommands.Delete, null));
			contextMenu.Items.Add(ContextMenuItemExtension.CreateMenuItem(ContextMenuItemType.SelectAll, "Select All", new RelayCommand(new Action(this.svbScriptEditor.SelectAll), () => !string.IsNullOrEmpty(this.svbScriptEditor.Text)), null));
			contextMenu.Items.Add(new Separator
			{
				Margin = new Thickness(0.0, 2.0, 0.0, 2.0)
			});
			contextMenu.Items.Add(ContextMenuItemExtension.CreateMenuItem<TextEditor>(ContextMenuItemType.Find, "Find", new RelayCommand<TextEditor>(delegate(TextEditor e)
			{
				this.ShowFindReplace(new TextEditorAdapter(e), false);
			}, (TextEditor e) => !string.IsNullOrEmpty(e.Text)), this.svbScriptEditor));
			contextMenu.Items.Add(ContextMenuItemExtension.CreateMenuItem<TextEditor>(ContextMenuItemType.Replace, "Replace", new RelayCommand<TextEditor>(delegate(TextEditor e)
			{
				this.ShowFindReplace(new TextEditorAdapter(e), true);
			}, (TextEditor e) => !string.IsNullOrEmpty(e.Text)), this.svbScriptEditor));
			this.svbScriptEditor.ContextMenu = contextMenu;
		}

		// Token: 0x06000B1D RID: 2845 RVA: 0x0003964B File Offset: 0x0003784B
		private void ButtonFindAndReplace_Click(object sender, RoutedEventArgs e)
		{
			this.ShowFindReplace(new TextEditorAdapter(this.svbScriptEditor), false);
		}

		// Token: 0x06000B1E RID: 2846 RVA: 0x00039660 File Offset: 0x00037860
		private void RawLogInitSettings()
		{
			ContextMenu contextMenu = new ContextMenu();
			contextMenu.Items.Add(ContextMenuItemExtension.CreateMenuItem(ContextMenuItemType.Copy, "Copy", ApplicationCommands.Copy, null));
			contextMenu.Items.Add(ContextMenuItemExtension.CreateMenuItem(ContextMenuItemType.SelectAll, "Select All", ApplicationCommands.SelectAll, null));
			this.rawLog.ContextMenu = contextMenu;
		}

		// Token: 0x06000B1F RID: 2847 RVA: 0x000396BC File Offset: 0x000378BC
		private void AddContextMenuLogControl(Control control, bool addOpeninNotepadItem = false, bool addJsonView = false)
		{
			ContextMenu contextMenu = new ContextMenu();
			TextEditor textEditor = null;
			try
			{
				textEditor = (TextEditor)control;
			}
			catch
			{
			}
			if (textEditor != null)
			{
				contextMenu.Items.Add(ContextMenuItemExtension.CreateMenuItem<TextEditor>(ContextMenuItemType.Copy, "Copy", new RelayCommand<TextEditor>(delegate(TextEditor e)
				{
					e.Copy();
				}, (TextEditor e) => e.SelectionStart > 0), textEditor));
				contextMenu.Items.Add(ContextMenuItemExtension.CreateMenuItem<TextEditor>(ContextMenuItemType.SelectAll, "Select All", new RelayCommand<TextEditor>(delegate(TextEditor e)
				{
					e.SelectAll();
				}, (TextEditor e) => !string.IsNullOrEmpty(e.Text)), textEditor));
				ItemCollection items = contextMenu.Items;
				MenuItem menuItem = new MenuItem();
				menuItem.Icon = new PackIconBoxIcons
				{
					Kind = 1471
				};
				menuItem.Header = "Clear";
				menuItem.CommandParameter = textEditor;
				menuItem.Command = new RelayCommand<TextEditor>(delegate(TextEditor e)
				{
					e.Clear();
				}, (TextEditor e) => e.LineCount > 0 && !string.IsNullOrEmpty(e.Text));
				items.Add(menuItem);
				contextMenu.Items.Add(new Separator
				{
					Margin = new Thickness(0.0, 2.0, 0.0, 2.0)
				});
				contextMenu.Items.Add(ContextMenuItemExtension.CreateMenuItem<TextEditor>(ContextMenuItemType.Find, "Find", new RelayCommand<TextEditor>(delegate(TextEditor e)
				{
					this.ShowFind(new TextEditorAdapter(e));
				}, (TextEditor e) => !string.IsNullOrEmpty(e.Text)), textEditor));
				if (addOpeninNotepadItem)
				{
					contextMenu.Items.Add(ContextMenuItemExtension.CreateMenuItem<TextEditor>(ContextMenuItemType.Notepad, "Open in Notepad", new RelayCommand<TextEditor>(delegate(TextEditor e)
					{
						if (e.SelectionLength > 0)
						{
							NotepadExtension.ShowText(e.SelectedText, "Log");
							return;
						}
						NotepadExtension.ShowText(e.Text, "Log");
					}, (TextEditor e) => !string.IsNullOrEmpty(e.Text) && e.Text.Length > 0), textEditor));
				}
				if (addJsonView)
				{
					contextMenu.Items.Add(ContextMenuItemExtension.CreateMenuItem<TextEditor>(ContextMenuItemType.Json, "Open in Json Viewer", new RelayCommand<TextEditor>(delegate(TextEditor e)
					{
						if (e.SelectionLength > 0)
						{
							JsonViewer jsonViewer = new JsonViewer();
							if (jsonViewer.Load(e.SelectedText))
							{
								new MainDialog(new MainDialog.InputDialog
								{
									Dialog = new Page
									{
										Content = jsonViewer
									},
									Title = "Json Viewer",
									ResizeMode = ResizeMode.CanResizeWithGrip,
									SizeToContent = SizeToContent.Manual,
									InitialWidth = new int?(550),
									InitialHeight = new int?(425)
								}).Show();
							}
						}
					}, (TextEditor e) => !string.IsNullOrEmpty(e.Text) && e.Text.Length > 0), textEditor));
				}
				textEditor.ContextMenu = contextMenu;
				return;
			}
			RichTextBox richTextBox = (RichTextBox)control;
			contextMenu.Items.Add(ContextMenuItemExtension.CreateMenuItem<RichTextBox>(ContextMenuItemType.Copy, "Copy", new RelayCommand<RichTextBox>(delegate(RichTextBox e)
			{
				e.Copy();
			}, (RichTextBox e) => e.Selection.Text.Length > 0), richTextBox));
			contextMenu.Items.Add(ContextMenuItemExtension.CreateMenuItem<RichTextBox>(ContextMenuItemType.SelectAll, "Select All", new RelayCommand<RichTextBox>(delegate(RichTextBox e)
			{
				e.SelectAll();
			}, (RichTextBox e) => !string.IsNullOrEmpty(e.GetText())), richTextBox));
			ItemCollection items2 = contextMenu.Items;
			MenuItem menuItem2 = new MenuItem();
			menuItem2.Icon = new PackIconBoxIcons
			{
				Kind = 1471
			};
			menuItem2.Header = "Clear";
			menuItem2.CommandParameter = richTextBox;
			menuItem2.Command = new RelayCommand<RichTextBox>(delegate(RichTextBox e)
			{
				e.Document.Blocks.Clear();
			}, (RichTextBox e) => e.Document.Blocks.Count > 0 && !string.IsNullOrEmpty(e.GetText()));
			items2.Add(menuItem2);
			contextMenu.Items.Add(new Separator
			{
				Margin = new Thickness(0.0, 2.0, 0.0, 2.0)
			});
			contextMenu.Items.Add(ContextMenuItemExtension.CreateMenuItem<RichTextBox>(ContextMenuItemType.Find, "Find", new RelayCommand<RichTextBox>(delegate(RichTextBox e)
			{
				this.ShowFind(new RichTextBoxAdapter(e));
			}, (RichTextBox e) => !string.IsNullOrEmpty(e.GetText())), richTextBox));
			if (addOpeninNotepadItem)
			{
				contextMenu.Items.Add(ContextMenuItemExtension.CreateMenuItem<TextEditor>(ContextMenuItemType.Notepad, "Open in Notepad", new RelayCommand<TextEditor>(delegate(TextEditor e)
				{
					NotepadExtension.ShowText(e.Text, "Log");
				}, (TextEditor e) => !string.IsNullOrEmpty(e.Text) && e.Text.Length > 0), richTextBox));
			}
			richTextBox.ContextMenu = contextMenu;
		}

		// Token: 0x06000B20 RID: 2848 RVA: 0x00039BA4 File Offset: 0x00037DA4
		private void SetBrowserStatus(string status)
		{
			base.Dispatcher.Invoke<string>(() => this.browserStatus.Text = status);
		}

		// Token: 0x06000B21 RID: 2849 RVA: 0x00039BE0 File Offset: 0x00037DE0
		private void SwitchSvbScript_Click(object sender, RoutedEventArgs e)
		{
			if (this.vm.View != StackerView.Blocks)
			{
				this.StackButton_Click(this, e);
				return;
			}
			this.vm.LS.FromBlocks(this.vm.GetList());
			this.svbScriptEditor.Text = this.vm.LS.Script;
			this.SwitchToSvbScriptEditor();
			using (XmlReader xmlReader = XmlReader.Create(Constants.HighlightingFolder + "\\ScriptHighlighting.xshd"))
			{
				this.svbScriptEditor.SyntaxHighlighting = HighlightingLoader.Load(xmlReader, HighlightingManager.Instance);
			}
		}

		// Token: 0x06000B22 RID: 2850 RVA: 0x00039C88 File Offset: 0x00037E88
		private void SwitchToSvbScriptEditor()
		{
			this.svbScriptEditor.LostFocus -= this.SvbScriptEditor_LostFocus;
			this.PanelSwitchSvbIcon.Children.RemoveAt(0);
			this.PanelSwitchSvbIcon.Children.Insert(0, new PackIconFontAwesome
			{
				Kind = 866,
				Width = 18.0,
				Height = 18.0,
				Foreground = ResourceExtension.GetBrush("ForegroundMain", "")
			});
			this.gridScriptAndSaveButtons.Margin = new Thickness(0.0, -1.0, 5.0, 0.0);
			this.gridScriptAndSaveButtons.ColumnDefinitions[0].Width = new GridLength(1.0, GridUnitType.Star);
			this.gridScriptAndSaveButtons.ColumnDefinitions[1].Width = new GridLength(1.0, GridUnitType.Star);
			Grid.SetRowSpan(this.stackerTabControl, 1);
			this.stackerTabControl.SelectedIndex = 1;
			this.scriptCodeTextBlock.Text = "SvbScript Code";
			this.svbScriptTextBlock.Text = "Stacker";
			this.vm.View = StackerView.SvbScript;
			this.BlockInfo.Content = null;
			this.svbScriptEditor.LostFocus += this.SvbScriptEditor_LostFocus;
		}

		// Token: 0x06000B23 RID: 2851 RVA: 0x00039DF8 File Offset: 0x00037FF8
		private void SwitchToCsharpScriptCode()
		{
			this.PanelSwitchCsharpIcon.Children.RemoveAt(0);
			this.PanelSwitchCsharpIcon.Children.Insert(0, new PackIconMaterial
			{
				Kind = 5040,
				Width = 18.0,
				Height = 18.0,
				Foreground = ResourceExtension.GetBrush("ForegroundMain", "")
			});
			this.gridScriptAndSaveButtons.Margin = new Thickness(0.0, -1.0, 5.0, 0.0);
			this.gridScriptAndSaveButtons.ColumnDefinitions[0].Width = new GridLength(1.0, GridUnitType.Star);
			this.gridScriptAndSaveButtons.ColumnDefinitions[1].Width = new GridLength(1.0, GridUnitType.Star);
			this.stackerTabControl.SelectedIndex = 1;
			this.scriptCodeTextBlock.Text = "C# Script Code";
			this.vm.View = StackerView.Csharp;
			this.BlockInfo.Content = null;
		}

		// Token: 0x06000B24 RID: 2852 RVA: 0x00039F1C File Offset: 0x0003811C
		private void SwitchToStackerView()
		{
			this.PanelSwitchSvbIcon.Children.RemoveAt(0);
			this.PanelSwitchSvbIcon.Children.Insert(0, new PackIconMaterial
			{
				Kind = 5040,
				Width = 18.0,
				Height = 18.0
			});
			Binding binding = new Binding("ActualWidth")
			{
				ElementName = "stackListView",
				Converter = new DivisionConverter(),
				ConverterParameter = 2
			};
			BindingOperations.SetBinding(this.gridScriptAndSaveButtons.ColumnDefinitions[0], ColumnDefinition.WidthProperty, binding);
			BindingOperations.SetBinding(this.gridScriptAndSaveButtons.ColumnDefinitions[1], ColumnDefinition.WidthProperty, binding);
			this.gridScriptAndSaveButtons.Margin = new Thickness(7.0, -1.0, 0.0, 0.0);
			Grid.SetRowSpan(this.stackerTabControl, 2);
			this.stackerTabControl.SelectedIndex = 0;
			this.scriptCodeTextBlock.Text = "Script Code";
			this.PanelSwitchCsharpIcon.Children.RemoveAt(0);
			this.PanelSwitchCsharpIcon.Children.Insert(0, new PackIconFileIcons
			{
				Kind = 200,
				Width = 18.0,
				Height = 19.0,
				Foreground = ResourceExtension.GetBrush("ForegroundMain", "")
			});
			this.svbScriptTextBlock.Text = "Script";
			this.vm.View = StackerView.Blocks;
			this.BlockInfo.Content = null;
		}

		// Token: 0x06000B25 RID: 2853 RVA: 0x0003A0CC File Offset: 0x000382CC
		private void SwitchCsharpScript_Click(object sender, RoutedEventArgs e)
		{
			this.svbScriptEditor.LostFocus -= this.SvbScriptEditor_LostFocus;
			if (this.vm.View == StackerView.Csharp)
			{
				this.SwitchToSvbScriptEditor();
				this.PanelSwitchCsharpIcon.Children.RemoveAt(0);
				this.PanelSwitchCsharpIcon.Children.Insert(0, new PackIconFileIcons
				{
					Kind = 200,
					Width = 18.0,
					Height = 19.0,
					Foreground = ResourceExtension.GetBrush("ForegroundMain", "")
				});
				this.BlockInfo.Content = null;
				this.vm.ConfigViewModel.Config.CsScript = this.svbScriptEditor.Text;
				this.svbScriptEditor.Text = this.vm.LS.Script;
				using (XmlReader xmlReader = XmlReader.Create(Constants.HighlightingFolder + "\\ScriptHighlighting.xshd"))
				{
					this.svbScriptEditor.SyntaxHighlighting = HighlightingLoader.Load(xmlReader, HighlightingManager.Instance);
					this.svbScriptEditor.LostFocus += this.SvbScriptEditor_LostFocus;
					return;
				}
			}
			this.<SwitchCsharpScript_Click>g__SwitchToCsharp|86_0();
		}

		// Token: 0x06000B26 RID: 2854 RVA: 0x0003A218 File Offset: 0x00038418
		private void Button_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			if ((sender as Button).ActualWidth >= 75.0)
			{
				this.svbScriptTextBlock.Visibility = Visibility.Visible;
				this.csharpScriptTextBlock.Visibility = Visibility.Visible;
				this.saveConfigTextBlock.Visibility = Visibility.Visible;
				return;
			}
			this.svbScriptTextBlock.Visibility = Visibility.Collapsed;
			this.csharpScriptTextBlock.Visibility = Visibility.Collapsed;
			this.saveConfigTextBlock.Visibility = Visibility.Collapsed;
		}

		// Token: 0x06000B27 RID: 2855 RVA: 0x0003A284 File Offset: 0x00038484
		private void BlockInfo_Navigated(object sender, NavigationEventArgs e)
		{
			try
			{
				this.BlockInfo.NavigationService.RemoveBackEntry();
			}
			catch
			{
			}
		}

		// Token: 0x06000B28 RID: 2856 RVA: 0x0003A2B8 File Offset: 0x000384B8
		private void Stack_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (e.NewItems != null)
			{
				foreach (object obj in e.NewItems)
				{
					StackerBlockViewModel stackerBlockViewModel = (StackerBlockViewModel)obj;
					try
					{
						stackerBlockViewModel.Page.LostFocus += delegate(object <p0>, RoutedEventArgs <p1>)
						{
							this.AutoSaveConfig();
						};
					}
					catch
					{
					}
				}
			}
			this.AutoSaveConfig();
		}

		// Token: 0x06000B29 RID: 2857 RVA: 0x0003A340 File Offset: 0x00038540
		public void AutoSaveConfig()
		{
			Task.Run(delegate()
			{
				base.Dispatcher.Invoke(delegate()
				{
					if (GlobalData.MainWindow.ConfigsSecionPage.ConfigManagerPage.CheckSaved() || !GlobalData.SBSettings.General.AutoSaveConfigOnStacker)
					{
						return;
					}
					this.OnSaveConfig();
				});
			}).ContinueWith(delegate(Task t)
			{
				try
				{
					t.Dispose();
				}
				catch
				{
				}
			});
		}

		// Token: 0x06000B2A RID: 2858 RVA: 0x0003A378 File Offset: 0x00038578
		private void SvbScriptEditor_TextChanged(object sender, EventArgs e)
		{
			try
			{
				this.AutoSaveConfig();
			}
			catch
			{
			}
		}

		// Token: 0x06000B2B RID: 2859 RVA: 0x0003A3A0 File Offset: 0x000385A0
		private void SvbScriptEditor_LostFocus(object sender, RoutedEventArgs e)
		{
			try
			{
				if (this.vm.View != StackerView.Csharp)
				{
					this.vm.LS.Script = this.svbScriptEditor.Text;
				}
				else
				{
					this.vm.ConfigViewModel.Config.CsScript = this.svbScriptEditor.Text;
				}
				if (e != null)
				{
					this.AutoSaveConfig();
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000B2C RID: 2860 RVA: 0x0003A418 File Offset: 0x00038618
		private void PersistLogCheckBox_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				GlobalData.SBSettings.General.PersistDebuggerLog = this.persistLogCheckBox.IsChecked.GetValueOrDefault();
				JToken jtoken = JToken.Parse(IOManager.ReadString(Constants.SBSettingsFile));
				jtoken["General"]["PersistDebuggerLog"] = GlobalData.SBSettings.General.PersistDebuggerLog;
				IOManager.SaveString(Constants.SBSettingsFile, jtoken.ToString());
			}
			catch
			{
			}
		}

		// Token: 0x06000B2D RID: 2861 RVA: 0x0003A4A8 File Offset: 0x000386A8
		private void LogFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				this.dataLogs.Document.Blocks.Clear();
				switch (this.logFilterComboBox.SelectedIndex)
				{
				case 0:
					this.dataLogs.AppendLine("BOT STATUS: " + this.vm.BotData.StatusString, Colors.White);
					this.dataLogs.AppendLine("VARIABLES:", Colors.Yellow);
					if (GlobalData.SBSettings.General.DisplayCapturesLast)
					{
						foreach (CVar cvar in from v in this.vm.BotData.Variables.All
						where !v.Hidden && !v.IsCapture
						select v)
						{
							RichTextBox box = this.dataLogs;
							string name = cvar.Name;
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 1);
							defaultInterpolatedStringHandler.AppendLiteral(" (");
							defaultInterpolatedStringHandler.AppendFormatted<CVar.VarType>(cvar.Type);
							defaultInterpolatedStringHandler.AppendLiteral(") = ");
							box.AppendLine(name + defaultInterpolatedStringHandler.ToStringAndClear() + cvar.ToString(), Colors.Yellow);
						}
						using (IEnumerator<CVar> enumerator = (from v in this.vm.BotData.Variables.All
						where !v.Hidden && v.IsCapture
						select v).GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								CVar cvar2 = enumerator.Current;
								RichTextBox box2 = this.dataLogs;
								string name2 = cvar2.Name;
								DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 1);
								defaultInterpolatedStringHandler.AppendLiteral(" (");
								defaultInterpolatedStringHandler.AppendFormatted<CVar.VarType>(cvar2.Type);
								defaultInterpolatedStringHandler.AppendLiteral(") = ");
								box2.AppendLine(name2 + defaultInterpolatedStringHandler.ToStringAndClear() + cvar2.ToString(), Colors.Tomato);
							}
							goto IL_4A7;
						}
					}
					using (IEnumerator<CVar> enumerator = (from v in this.vm.BotData.Variables.All
					where !v.Hidden
					select v).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							CVar cvar3 = enumerator.Current;
							RichTextBox box3 = this.dataLogs;
							string name3 = cvar3.Name;
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 1);
							defaultInterpolatedStringHandler.AppendLiteral(" (");
							defaultInterpolatedStringHandler.AppendFormatted<CVar.VarType>(cvar3.Type);
							defaultInterpolatedStringHandler.AppendLiteral(") = ");
							box3.AppendLine(name3 + defaultInterpolatedStringHandler.ToStringAndClear() + cvar3.ToString(), cvar3.IsCapture ? Colors.Tomato : Colors.Yellow);
						}
						goto IL_4A7;
					}
					break;
				case 1:
					break;
				case 2:
					goto IL_3B3;
				default:
					goto IL_4A7;
				}
				this.dataLogs.AppendLine("BOT STATUS: " + this.vm.BotData.StatusString, Colors.White);
				this.dataLogs.AppendLine("VARIABLES:", Colors.Yellow);
				using (IEnumerator<CVar> enumerator = (from v in this.vm.BotData.Variables.All
				where !v.Hidden && !v.IsCapture
				select v).GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						CVar cvar4 = enumerator.Current;
						RichTextBox box4 = this.dataLogs;
						string name4 = cvar4.Name;
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 1);
						defaultInterpolatedStringHandler.AppendLiteral(" (");
						defaultInterpolatedStringHandler.AppendFormatted<CVar.VarType>(cvar4.Type);
						defaultInterpolatedStringHandler.AppendLiteral(") = ");
						box4.AppendLine(name4 + defaultInterpolatedStringHandler.ToStringAndClear() + cvar4.ToString(), Colors.Yellow);
					}
					goto IL_4A7;
				}
				IL_3B3:
				this.dataLogs.AppendLine("BOT STATUS: " + this.vm.BotData.StatusString, Colors.White);
				this.dataLogs.AppendLine("CAPTURES:", Colors.Tomato);
				foreach (CVar cvar5 in from v in this.vm.BotData.Variables.All
				where !v.Hidden && v.IsCapture
				select v)
				{
					RichTextBox box5 = this.dataLogs;
					string name5 = cvar5.Name;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 1);
					defaultInterpolatedStringHandler.AppendLiteral(" (");
					defaultInterpolatedStringHandler.AppendFormatted<CVar.VarType>(cvar5.Type);
					defaultInterpolatedStringHandler.AppendLiteral(") = ");
					box5.AppendLine(name5 + defaultInterpolatedStringHandler.ToStringAndClear() + cvar5.ToString(), Colors.Tomato);
				}
				IL_4A7:;
			}
			catch
			{
			}
		}

		// Token: 0x06000B2E RID: 2862 RVA: 0x0003A9F8 File Offset: 0x00038BF8
		private void BlockLabel_TextChanged(object sender, TextChangedEventArgs e)
		{
			try
			{
				if (this.vm.CurrentBlock != null)
				{
					this.vm.CurrentBlock.Block.Label = this.vm.BlockLabel;
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000B2F RID: 2863 RVA: 0x0003AA48 File Offset: 0x00038C48
		private void ShowBlockDescription_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				Growl.Info(this.vm.CurrentBlock.Block.Info.ToString(), "");
			}
			catch
			{
			}
		}

		// Token: 0x06000B30 RID: 2864 RVA: 0x0003AA90 File Offset: 0x00038C90
		private void ShowFindReplace(object editor, bool selectReplaceTab = false)
		{
			this.findReplaceMgr.CurrentEditor = editor;
			DialogFindReplace.ShowFindReplace(this.findReplaceMgr, selectReplaceTab);
		}

		// Token: 0x06000B31 RID: 2865 RVA: 0x0003AAAA File Offset: 0x00038CAA
		private void ShowFind(object editor)
		{
			this.findReplaceMgr.CurrentEditor = editor;
			DialogFindReplace.ShowFind(this.findReplaceMgr);
		}

		// Token: 0x06000B32 RID: 2866 RVA: 0x0003AAC3 File Offset: 0x00038CC3
		private void ShowReplace(object editor)
		{
			this.findReplaceMgr.CurrentEditor = editor;
			DialogFindReplace.ShowReplace(this.findReplaceMgr);
		}

		// Token: 0x06000B33 RID: 2867 RVA: 0x0003AADC File Offset: 0x00038CDC
		public void Compile_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				ConfigViewModel config = GlobalData.ConfigManager.CurrentConfig;
				if (this.ProcessComp != null)
				{
					try
					{
						this.ProcessComp.Dispose();
					}
					catch
					{
					}
				}
				UIElement control = null;
				bool compAndRun = false;
				if (sender is Button)
				{
					control = this.stackerTabControl;
				}
				else
				{
					object[] array = sender as object[];
					if (array != null)
					{
						control = (array[0] as UIElement);
						compAndRun = (bool)array[1];
					}
				}
				control.BlurApply(0.0, 5.0, TimeSpan.FromSeconds(0.1), false);
				control.IsEnabled = false;
				Action <>9__2;
				Action <>9__3;
				Task.Run(delegate()
				{
					try
					{
						string text = Path.Combine(Constants.CompiledFolder, Path.GetFileNameWithoutExtension(config.FileName));
						if (!Directory.Exists(text))
						{
							Directory.CreateDirectory(text);
						}
						using (ScriptCompiler scriptCompiler = new ScriptCompiler(config.Config.Settings.CsScriptComp.Replace("<SVBCONFIG>", ScriptCompiler.ToLiteral(this.SerializeConfig(config.Config), null)), config.Config.Settings)
						{
							AssemblyName = config.Config.Settings.AssemblyName,
							DotNetFrameworkPath = GlobalData.Settings.CoreSettings.Compiler.DotNetFrameworkPath
						})
						{
							ScriptCompiler.TargetFramework targetFrameworkComp = config.Config.Settings.TargetFrameworkComp;
							using (MemoryStream memoryStream = scriptCompiler.Compile(null, targetFrameworkComp))
							{
								string text2 = Path.Combine(text, scriptCompiler.Settings.AssemblyName) + ".exe";
								if (targetFrameworkComp == null)
								{
									text2 = Path.Combine(text, "bin", scriptCompiler.Settings.AssemblyName) + ".exe";
									Directory.GetParent(text2).Create();
								}
								File.WriteAllBytes(text2, memoryStream.ToArray());
								if (targetFrameworkComp == null)
								{
									scriptCompiler.WriteRuntimeConfig(text2);
								}
								scriptCompiler.CopyReferences(Path.GetDirectoryName(text2));
								if (compAndRun)
								{
									if (targetFrameworkComp == null)
									{
										this.ProcessComp = System.Diagnostics.Process.Start("dotnet", text2);
									}
									else
									{
										this.ProcessComp = System.Diagnostics.Process.Start(text2);
									}
								}
								else
								{
									Alert.Success("Compiled Successfully On Path: " + text2, "DONE!", false);
								}
							}
						}
					}
					catch (Exception ex2)
					{
						Alert.Exception(ex2, "");
					}
					finally
					{
						Dispatcher dispatcher = this.Dispatcher;
						Action callback;
						if ((callback = <>9__2) == null)
						{
							callback = (<>9__2 = delegate()
							{
								if (!control.IsEnabled)
								{
									control.BlurDisable(TimeSpan.FromSeconds(0.1));
									control.IsEnabled = true;
								}
							});
						}
						dispatcher.Invoke(callback);
					}
				}).ContinueWith(delegate(Task t)
				{
					Dispatcher dispatcher = this.Dispatcher;
					Action callback;
					if ((callback = <>9__3) == null)
					{
						callback = (<>9__3 = delegate()
						{
							control.BlurDisable(TimeSpan.FromSeconds(0.1));
							control.IsEnabled = true;
						});
					}
					dispatcher.Invoke(callback);
					try
					{
						t.Dispose();
					}
					catch
					{
					}
				});
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x06000B34 RID: 2868 RVA: 0x0003ABF0 File Offset: 0x00038DF0
		private string SerializeConfig(Config config)
		{
			string result;
			using (StringWriter stringWriter = new StringWriter())
			{
				stringWriter.WriteLine("[SETTINGS]");
				stringWriter.WriteLine(JsonConvert.SerializeObject(config.Settings, 1).Remove(0, 1).Insert(0, "{\r\n  \"Name\": \"" + config.Settings.Name + "\","));
				stringWriter.WriteLine("");
				stringWriter.WriteLine("[SCRIPT]");
				stringWriter.Write(config.Script);
				result = stringWriter.ToString();
			}
			return result;
		}

		// Token: 0x06000B35 RID: 2869 RVA: 0x0003AC90 File Offset: 0x00038E90
		private void SelectBlockComboBox_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.Key == Key.Return)
				{
					this.AddBlock_Click(this, e);
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000B36 RID: 2870 RVA: 0x0003ACC4 File Offset: 0x00038EC4
		private void DisposeWebView_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				this.webView.Dispose();
				this.webView.Destroy();
				this.webControl.WebView.Dispose();
				this.webControl.WebView.Destroy();
				this.webView = null;
				if (sender != null)
				{
					Runtime.Restart();
				}
				this.webView = new WebView();
				this.webView.BeforeNavigate += new BeforeNavigateHandler(this.WebView_BeforeNavigate);
				this.webView.LoadCompleted += new LoadCompletedEventHandler(this.WebView_LoadCompleted);
				this.webView.AllowDropLoad = false;
				this.webControl.WebView = this.webView;
				this.SetBrowserStatus("Successfully closed!");
			}
			catch (Exception ex)
			{
				this.SetBrowserStatus("Error: " + ex.Message);
			}
		}

		// Token: 0x06000B37 RID: 2871 RVA: 0x0003ADA4 File Offset: 0x00038FA4
		private void WebView_BeforeNavigate(object sender, BeforeNavigateEventArgs e)
		{
			this.SetBrowserStatus("Navigating...");
			if (e.Cancel)
			{
				this.SetBrowserStatus("Navigation cancelled");
			}
		}

		// Token: 0x06000B38 RID: 2872 RVA: 0x0003ADC4 File Offset: 0x00038FC4
		private void WebView_LoadCompleted(object sender, LoadCompletedEventArgs e)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 1);
			defaultInterpolatedStringHandler.AppendLiteral("Navigation completed (");
			defaultInterpolatedStringHandler.AppendFormatted<int>(e.HttpStatusCode);
			defaultInterpolatedStringHandler.AppendLiteral(")");
			this.SetBrowserStatus(defaultInterpolatedStringHandler.ToStringAndClear());
		}

		// Token: 0x06000B39 RID: 2873 RVA: 0x0003AE10 File Offset: 0x00039010
		private void ShowDebugUI_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				WebView.ShowDebugUI();
			}
			catch
			{
			}
		}

		// Token: 0x06000B3A RID: 2874 RVA: 0x0003AE38 File Offset: 0x00039038
		private void OrigImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			try
			{
				if (e != null)
				{
					if (e.ClickCount < 2)
					{
						goto IL_DA;
					}
					BotData botData = this.vm.BotData;
					if (((botData != null) ? botData.OriginalCaptcha : null) == null)
					{
						goto IL_DA;
					}
				}
				SaveFileDialog saveFileDialog = new SaveFileDialog();
				saveFileDialog.Title = "Original";
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 2);
				defaultInterpolatedStringHandler.AppendLiteral("Orig Captcha (");
				defaultInterpolatedStringHandler.AppendFormatted<ImageFormat>(this.vm.BotData.OriginalCaptcha.RawFormat);
				defaultInterpolatedStringHandler.AppendLiteral(")|*.");
				defaultInterpolatedStringHandler.AppendFormatted<ImageFormat>(this.vm.BotData.OriginalCaptcha.RawFormat);
				saveFileDialog.Filter = defaultInterpolatedStringHandler.ToStringAndClear();
				SaveFileDialog saveFileDialog2 = saveFileDialog;
				bool? flag = saveFileDialog2.ShowDialog();
				bool flag2 = true;
				if (flag.GetValueOrDefault() == flag2 & flag != null)
				{
					this.vm.BotData.OriginalCaptcha.Save(saveFileDialog2.FileName);
				}
				IL_DA:;
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x06000B3B RID: 2875 RVA: 0x0003AF40 File Offset: 0x00039140
		private void ProcImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			try
			{
				if (e != null)
				{
					if (e.ClickCount < 2)
					{
						goto IL_DA;
					}
					BotData botData = this.vm.BotData;
					if (((botData != null) ? botData.ProcessedCaptcha : null) == null)
					{
						goto IL_DA;
					}
				}
				SaveFileDialog saveFileDialog = new SaveFileDialog();
				saveFileDialog.Title = "Processed";
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 2);
				defaultInterpolatedStringHandler.AppendLiteral("Captcha (");
				defaultInterpolatedStringHandler.AppendFormatted<ImageFormat>(this.vm.BotData.ProcessedCaptcha.RawFormat);
				defaultInterpolatedStringHandler.AppendLiteral(")|*.");
				defaultInterpolatedStringHandler.AppendFormatted<ImageFormat>(this.vm.BotData.ProcessedCaptcha.RawFormat);
				saveFileDialog.Filter = defaultInterpolatedStringHandler.ToStringAndClear();
				SaveFileDialog saveFileDialog2 = saveFileDialog;
				bool? flag = saveFileDialog2.ShowDialog();
				bool flag2 = true;
				if (flag.GetValueOrDefault() == flag2 & flag != null)
				{
					this.vm.BotData.ProcessedCaptcha.Save(saveFileDialog2.FileName);
				}
				IL_DA:;
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x06000B3C RID: 2876 RVA: 0x0003B048 File Offset: 0x00039248
		private void SendToSelectedOcrBlock_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (this.vm.SelectedBlocks.Count > 0)
				{
					BotData botData = this.vm.BotData;
					if (((botData != null) ? botData.OriginalCaptcha : null) != null)
					{
						BotData botData2 = this.vm.BotData;
						if (((botData2 != null) ? botData2.ProcessedCaptcha : null) != null)
						{
							string a = (sender as FrameworkElement).Tag.ToString();
							for (int i = 0; i < this.vm.SelectedBlocks.Count; i++)
							{
								BlockOcr blockOcr = this.vm.SelectedBlocks[i].Block as BlockOcr;
								if (blockOcr != null)
								{
									blockOcr.CaptchaInputMode = 4;
									if (a == "Orig")
									{
										blockOcr.Captcha = ImageExtension.ToBase64(this.vm.BotData.OriginalCaptcha);
									}
									else
									{
										blockOcr.Captcha = ImageExtension.ToBase64(this.vm.BotData.ProcessedCaptcha);
									}
								}
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x06000B3D RID: 2877 RVA: 0x0003B15C File Offset: 0x0003935C
		private void SaveProcCaptcha_Click(object sender, RoutedEventArgs e)
		{
			this.ProcImage_MouseLeftButtonDown(sender, null);
		}

		// Token: 0x06000B3E RID: 2878 RVA: 0x0003B166 File Offset: 0x00039366
		private void SaveOrigCaptcha_Click(object sender, RoutedEventArgs e)
		{
			this.OrigImage_MouseLeftButtonDown(sender, null);
		}

		// Token: 0x06000B3F RID: 2879 RVA: 0x0003B170 File Offset: 0x00039370
		private void AddBreakpoint_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				int num = int.Parse(this.breakpointComboBox.Text) - 1;
				BlockBase block = this.vm.Stack[num].Block;
				this.vm.Breakpoints.Add(new SvbScript.Breakpoint(block, num));
				this.breakpointComboBox.SelectedIndex = this.breakpointComboBox.Items.Count - 1;
			}
			catch
			{
			}
		}

		// Token: 0x06000B40 RID: 2880 RVA: 0x0003B1F0 File Offset: 0x000393F0
		private void RemoveBreakpoint_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				this.vm.Breakpoints.RemoveAt(this.breakpointComboBox.SelectedIndex);
			}
			catch
			{
			}
		}

		// Token: 0x06000B41 RID: 2881 RVA: 0x0003B230 File Offset: 0x00039430
		private void ClearBreakpoints_Click(object sender, MouseButtonEventArgs e)
		{
			if (e.LeftButton == MouseButtonState.Pressed && Alert.Choice("Do you want to delete all Breakpoint?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
			{
				try
				{
					this.vm.Breakpoints.Clear();
				}
				catch
				{
				}
			}
		}

		// Token: 0x06000B42 RID: 2882 RVA: 0x0003B280 File Offset: 0x00039480
		private void InsertBreakpoint_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (this.vm.Breakpoint)
				{
					foreach (StackerBlockViewModel stackerBlockViewModel in this.vm.SelectedBlocks)
					{
						this.vm.Breakpoints.Add(new SvbScript.Breakpoint(stackerBlockViewModel.Block, this.vm.Stack.IndexOf(stackerBlockViewModel)));
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000B43 RID: 2883 RVA: 0x0003B320 File Offset: 0x00039520
		private void DeleteBreakpoint_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (this.vm.Breakpoint)
				{
					using (List<StackerBlockViewModel>.Enumerator enumerator = this.vm.SelectedBlocks.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							StackerBlockViewModel b = enumerator.Current;
							try
							{
								this.vm.Breakpoints.Remove(this.vm.Breakpoints.FirstOrDefault((SvbScript.Breakpoint br) => br.Index == this.vm.Stack.IndexOf(b)));
							}
							catch
							{
							}
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000B44 RID: 2884 RVA: 0x0003B3E4 File Offset: 0x000395E4
		public void OcrTestModeClicked()
		{
			try
			{
				if (GlobalData.ConfigManager.CurrentConfig.Config.Settings.EnableTestMode)
				{
					this.ButtonShowCaptcha.Visibility = Visibility.Visible;
					this.gridTabCtrlItems.ColumnDefinitions.First((ColumnDefinition c) => c.Name == "CaptchaCol").Width = new GridLength(1.0, GridUnitType.Star);
				}
				else
				{
					this.ButtonShowCaptcha.Visibility = Visibility.Collapsed;
					this.gridTabCtrlItems.ColumnDefinitions.First((ColumnDefinition c) => c.Name == "CaptchaCol").Width = new GridLength(0.0);
					if (this.debuggerTabControl.SelectedIndex == (int)this.captchaIndexTabItem)
					{
						this.debuggerTabControl.SelectedIndex = -1;
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000B45 RID: 2885 RVA: 0x0003B4E0 File Offset: 0x000396E0
		public void Destroy()
		{
			try
			{
				WebView webView = this.webView;
				if (webView != null)
				{
					webView.Dispose();
				}
				WebView webView2 = this.webView;
				if (webView2 != null)
				{
					webView2.Destroy();
				}
				WebControl webControl = this.webControl;
				if (webControl != null)
				{
					WebView webView3 = webControl.WebView;
					if (webView3 != null)
					{
						webView3.Dispose();
					}
				}
				WebControl webControl2 = this.webControl;
				if (webControl2 != null)
				{
					WebView webView4 = webControl2.WebView;
					if (webView4 != null)
					{
						webView4.Destroy();
					}
				}
				StackerViewModel stackerViewModel = this.vm;
				if (stackerViewModel != null)
				{
					BinaryReader reader = stackerViewModel.Reader;
					if (reader != null)
					{
						reader.Dispose();
					}
				}
				this.webView = null;
				this.webControl = null;
				Runtime.Restart();
			}
			catch
			{
			}
			try
			{
				BotData botData = this.vm.BotData;
				if (botData != null)
				{
					botData.Dispose();
				}
			}
			catch
			{
			}
			try
			{
				this.origImage.Source = null;
				this.procImage.Source = null;
			}
			catch
			{
			}
			try
			{
				GC.SuppressFinalize(this);
				GC.Collect();
			}
			catch
			{
			}
		}

		// Token: 0x06000B48 RID: 2888 RVA: 0x0003BF2C File Offset: 0x0003A12C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IStyleConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 7)
			{
				((ToggleButton)target).Click += this.BlockClicked;
				((ToggleButton)target).MouseDoubleClick += this.BlockDoubleClicked;
			}
		}

		// Token: 0x06000B49 RID: 2889 RVA: 0x0003BF60 File Offset: 0x0003A160
		[CompilerGenerated]
		private void <OnSaveConfig>g__RestoreForegroundIconSave|15_0()
		{
			try
			{
				Task.Run(delegate()
				{
					Task.Delay(1099).GetAwaiter().GetResult();
					base.Dispatcher.Invoke<System.Windows.Media.Brush>(() => this.iconSave.Foreground = System.Windows.Media.Brushes.White);
				}).ContinueWith(delegate(Task t)
				{
					try
					{
						t.Dispose();
					}
					catch
					{
					}
				});
			}
			catch
			{
			}
		}

		// Token: 0x06000B4C RID: 2892 RVA: 0x0003C014 File Offset: 0x0003A214
		[CompilerGenerated]
		private void <OnSaveConfig>g__CouldNotSave|15_1()
		{
			try
			{
				this.iconSave.Foreground = "#FFF5645D".ToBrush();
				this.<OnSaveConfig>g__RestoreForegroundIconSave|15_0();
			}
			catch
			{
				this.iconSave.Foreground = System.Windows.Media.Brushes.White;
			}
		}

		// Token: 0x06000B4D RID: 2893 RVA: 0x0003C064 File Offset: 0x0003A264
		[CompilerGenerated]
		private void <OnSaveConfig>g__Saved|15_2()
		{
			try
			{
				this.iconSave.Foreground = "#FF5DF5A7".ToBrush();
				this.<OnSaveConfig>g__RestoreForegroundIconSave|15_0();
			}
			catch
			{
				this.iconSave.Foreground = System.Windows.Media.Brushes.White;
			}
		}

		// Token: 0x06000B4F RID: 2895 RVA: 0x0003C0F0 File Offset: 0x0003A2F0
		[CompilerGenerated]
		internal static bool <AddBlock_Click>g__IsValid|22_0(SilverBlock block, string blockName)
		{
			return block.Name.ToLower() == blockName || block.Name.ToLower() == blockName.Replace(" ", string.Empty) || (block.Block.Name.ToLower() == blockName || block.Block.Name.ToLower() == blockName.Replace(" ", string.Empty) || StringExtensions.ReplaceFirst(block.Block.Name.ToLower(), "block", string.Empty) == blockName || StringExtensions.ReplaceFirst(block.Block.Name.ToLower(), "block", string.Empty) == blockName.Replace(" ", ""));
		}

		// Token: 0x06000B62 RID: 2914 RVA: 0x0003CC50 File Offset: 0x0003AE50
		[CompilerGenerated]
		private void <SwitchCsharpScript_Click>g__SwitchToCsharp|86_0()
		{
			if (this.vm.View == StackerView.Blocks)
			{
				this.vm.LS.Script = this.svbScriptEditor.Text;
			}
			this.SwitchToCsharpScriptCode();
			this.PanelSwitchSvbIcon.Children.RemoveAt(0);
			this.PanelSwitchSvbIcon.Children.Insert(0, new PackIconFontAwesome
			{
				Kind = 866,
				Width = 18.0,
				Height = 18.0
			});
			this.svbScriptTextBlock.Text = "Stacker";
			this.vm.View = StackerView.Csharp;
			this.vm.LS.Script = this.svbScriptEditor.Text;
			using (XmlReader xmlReader = XmlReader.Create(Constants.HighlightingFolder + "\\CSharp-Mode.xshd"))
			{
				this.svbScriptEditor.SyntaxHighlighting = HighlightingLoader.Load(xmlReader, HighlightingManager.Instance);
				this.BlockInfo.Content = null;
				this.svbScriptEditor.LostFocus += this.SvbScriptEditor_LostFocus;
			}
		}

		// Token: 0x0400056B RID: 1387
		private Stopwatch timer;

		// Token: 0x0400056C RID: 1388
		private StackerViewModel vm;

		// Token: 0x0400056D RID: 1389
		private AbortableBackgroundWorker debugger = new AbortableBackgroundWorker();

		// Token: 0x0400056F RID: 1391
		private FindReplaceMgr findReplaceMgr = new FindReplaceMgr();

		// Token: 0x04000570 RID: 1392
		public Process ProcessComp;

		// Token: 0x04000571 RID: 1393
		public Action EnableScrolling;

		// Token: 0x04000572 RID: 1394
		private CompletionWindow completionWindow;

		// Token: 0x04000573 RID: 1395
		private int? tempSrc;

		// Token: 0x04000574 RID: 1396
		private int? tempOrigCaptcha;

		// Token: 0x04000575 RID: 1397
		private int? tempProcCaptcha;

		// Token: 0x04000576 RID: 1398
		private readonly sbyte captchaIndexTabItem = 4;

		// Token: 0x02000281 RID: 641
		// (Invoke) Token: 0x060011BB RID: 4539
		public delegate void SaveConfigEventHandler(object sender, EventArgs e);
	}
}
