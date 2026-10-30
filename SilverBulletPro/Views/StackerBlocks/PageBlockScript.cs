using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Threading;
using System.Xml;
using AngleSharp.Text;
using GalaSoft.MvvmLight.Command;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Folding;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using ICSharpCode.AvalonEdit.Indentation.CSharp;
using Microsoft.CSharp.RuntimeBinder;
using SilverBulletPro.Core;
using SilverBulletPro.Core.Blocks;
using SilverBulletPro.Core.LS;
using SilverBulletPro.Extensions;
using SilverBulletPro.FindReplace;

namespace SilverBulletPro.Views.StackerBlocks
{
	// Token: 0x020000A1 RID: 161
	public class PageBlockScript : Page, IComponentConnector
	{
		// Token: 0x060004DD RID: 1245 RVA: 0x00018A90 File Offset: 0x00016C90
		public PageBlockScript(BlockScriptCode block)
		{
			this.InitializeComponent();
			this.block = block;
			base.DataContext = this.block;
			this.interpreterBox.Items.Add("Default");
			foreach (object obj in Enum.GetValues(typeof(Interpreter)))
			{
				this.interpreterBox.Items.Add(obj.ToString());
			}
			Interpreter? interpreter = this.UpdateInterpreter();
			this.SetOutputs();
			this.ScriptEditorInitSettings();
			this.scriptEditor.Text = block.Script;
			if (string.IsNullOrWhiteSpace(this.scriptEditor.Text))
			{
				this.scriptEditor.Text = "BEGIN " + Environment.NewLine + "END ";
			}
			this.scriptEditor.ShowLineNumbers = true;
			this.scriptEditor.TextArea.Foreground = new SolidColorBrush(Colors.Gainsboro);
			this.scriptEditor.TextArea.TextView.LinkTextForegroundBrush = new SolidColorBrush(Colors.DodgerBlue);
			Interpreter? interpreter2 = interpreter;
			Interpreter interpreter3 = 3;
			using (XmlReader xmlReader = XmlReader.Create((interpreter2.GetValueOrDefault() == interpreter3 & interpreter2 != null) ? (Constants.HighlightingFolder + "\\CSharp-Mode.xshd") : (Constants.HighlightingFolder + "\\ScriptHighlighting.xshd")))
			{
				this.scriptEditor.SyntaxHighlighting = HighlightingLoader.Load(xmlReader, HighlightingManager.Instance);
			}
			interpreter2 = interpreter;
			interpreter3 = 3;
			if (interpreter2.GetValueOrDefault() == interpreter3 & interpreter2 != null)
			{
				this.interpreterBox.SelectedItem = 3.ToString();
				this.HighlightingComboBox_SelectionChanged(null, null);
				this.foldingUpdateTimer = new DispatcherTimer();
				this.foldingUpdateTimer.Interval = TimeSpan.FromSeconds(2.0);
				this.foldingUpdateTimer.Tick += this.FoldingUpdateTimer_Tick;
				this.foldingUpdateTimer.Start();
			}
		}

		// Token: 0x060004DE RID: 1246 RVA: 0x00018CC4 File Offset: 0x00016EC4
		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			try
			{
				GlobalData.MainWindow.ConfigsSecionPage.StackerPage.BlockInfoScrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
				GlobalData.MainWindow.ConfigsSecionPage.StackerPage.BlockInfoScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
			}
			catch
			{
			}
		}

		// Token: 0x060004DF RID: 1247 RVA: 0x00018D1C File Offset: 0x00016F1C
		private void ScriptEditor_LostFocus(object sender, RoutedEventArgs e)
		{
			try
			{
				if (this.interpreterBox.SelectedItem.ToString() == 3.ToString())
				{
					this.scriptEditor.Text = string.Join(Environment.NewLine, from line in this.scriptEditor.Text.Split(Environment.NewLine, StringSplitOptions.None)
					select line.TrimStart('\t'));
				}
			}
			catch
			{
			}
			this.block.Script = this.scriptEditor.Text;
			this.SetOutputs();
			this.UpdateInterpreter();
		}

		// Token: 0x060004E0 RID: 1248 RVA: 0x00018DD8 File Offset: 0x00016FD8
		private void TextEditor_TextArea_TextEntered(object sender, TextCompositionEventArgs e)
		{
			if (e.Text == ".")
			{
				this.completionWindow = new CompletionWindow(this.scriptEditor.TextArea);
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

		// Token: 0x060004E1 RID: 1249 RVA: 0x00018E81 File Offset: 0x00017081
		private void TextEditor_TextArea_TextEntering(object sender, TextCompositionEventArgs e)
		{
			if (e.Text.Length > 0 && this.completionWindow != null && !char.IsLetterOrDigit(e.Text[0]))
			{
				this.completionWindow.CompletionList.RequestInsertion(e);
			}
		}

		// Token: 0x060004E2 RID: 1250 RVA: 0x00018EC0 File Offset: 0x000170C0
		private void HighlightingComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			this.scriptEditor.TextArea.IndentationStrategy = new CSharpIndentationStrategy(this.scriptEditor.Options);
			this.braceFoldingStrategy = new BraceFoldingStrategy();
			if (this.braceFoldingStrategy != null)
			{
				if (this.foldingManager == null)
				{
					this.foldingManager = FoldingManager.Install(this.scriptEditor.TextArea);
				}
				this.braceFoldingStrategy.UpdateFoldings(this.foldingManager, this.scriptEditor.Document);
				return;
			}
			if (this.foldingManager != null)
			{
				FoldingManager.Uninstall(this.foldingManager);
				this.foldingManager = null;
			}
		}

		// Token: 0x060004E3 RID: 1251 RVA: 0x00018F58 File Offset: 0x00017158
		private void FoldingUpdateTimer_Tick(object sender, EventArgs e)
		{
			try
			{
				if (this.braceFoldingStrategy != null)
				{
					this.braceFoldingStrategy.UpdateFoldings(this.foldingManager, this.scriptEditor.Document);
				}
			}
			catch
			{
			}
		}

		// Token: 0x060004E4 RID: 1252 RVA: 0x00018FA0 File Offset: 0x000171A0
		private void SetOutputs()
		{
			try
			{
				string text = StringExtensions.ReplaceFirst(this.block.Script.Split(Environment.NewLine, StringSplitOptions.None).Last<string>(), "END SCRIPT", "").Trim();
				LineParser.EnsureIdentifier(ref text, "->");
				LineParser.EnsureIdentifier(ref text, "VARS");
				string text2 = LineParser.ParseLiteral(ref text, "OUTPUTS", false, null);
				this.outputVariable.Text = text2;
			}
			catch
			{
			}
		}

		// Token: 0x060004E5 RID: 1253 RVA: 0x00019028 File Offset: 0x00017228
		private Interpreter? GetInterpreter()
		{
			Interpreter? result = null;
			try
			{
				result = new Interpreter?(Enum.Parse<Interpreter>(this.interpreterBox.SelectedItem.ToString(), true));
			}
			catch
			{
			}
			if (!string.IsNullOrWhiteSpace(this.block.Script))
			{
				try
				{
					string text = this.block.Script.Split(Environment.NewLine, StringSplitOptions.None)[0].Replace("BEGIN SCRIPT ", string.Empty);
					if (PageBlockScript.<>o__13.<>p__0 == null)
					{
						PageBlockScript.<>o__13.<>p__0 = CallSite<Func<CallSite, object, Interpreter>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Interpreter), typeof(PageBlockScript)));
					}
					result = new Interpreter?(PageBlockScript.<>o__13.<>p__0.Target(PageBlockScript.<>o__13.<>p__0, LineParser.ParseEnum(ref text, "Interpreter", typeof(Interpreter))));
				}
				catch
				{
					try
					{
						string text2 = StringExtensions.ReplaceFirst(this.block.Script, "BEGIN SCRIPT ", string.Empty);
						if (PageBlockScript.<>o__13.<>p__1 == null)
						{
							PageBlockScript.<>o__13.<>p__1 = CallSite<Func<CallSite, object, Interpreter>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Interpreter), typeof(PageBlockScript)));
						}
						result = new Interpreter?(PageBlockScript.<>o__13.<>p__1.Target(PageBlockScript.<>o__13.<>p__1, LineParser.ParseEnum(ref text2, "Interpreter", typeof(Interpreter))));
					}
					catch
					{
					}
				}
			}
			return result;
		}

		// Token: 0x060004E6 RID: 1254 RVA: 0x000191A4 File Offset: 0x000173A4
		private Interpreter? UpdateInterpreter()
		{
			Interpreter? interpreter = this.GetInterpreter();
			if (interpreter != null)
			{
				this.interpreterBox.SelectedItem = interpreter.GetValueOrDefault().ToString();
			}
			else
			{
				this.interpreterBox.SelectedItem = "Default";
			}
			return interpreter;
		}

		// Token: 0x060004E7 RID: 1255 RVA: 0x000191F4 File Offset: 0x000173F4
		private void InterpreterBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				if (this.interpreterBox.SelectedIndex == 4)
				{
					using (XmlReader xmlReader = XmlReader.Create(Constants.HighlightingFolder + "\\CSharp-Mode.xshd"))
					{
						this.scriptEditor.SyntaxHighlighting = HighlightingLoader.Load(xmlReader, HighlightingManager.Instance);
						this.HighlightingComboBox_SelectionChanged(null, null);
						try
						{
							DispatcherTimer dispatcherTimer = this.foldingUpdateTimer;
							if (dispatcherTimer != null)
							{
								dispatcherTimer.Stop();
							}
							this.foldingUpdateTimer.IsEnabled = false;
						}
						catch
						{
						}
						this.foldingUpdateTimer = new DispatcherTimer();
						this.foldingUpdateTimer.Interval = TimeSpan.FromSeconds(2.0);
						this.foldingUpdateTimer.Tick += this.FoldingUpdateTimer_Tick;
						this.foldingUpdateTimer.Start();
						goto IL_13D;
					}
				}
				try
				{
					DispatcherTimer dispatcherTimer2 = this.foldingUpdateTimer;
					if (dispatcherTimer2 != null)
					{
						dispatcherTimer2.Stop();
					}
					this.foldingUpdateTimer.IsEnabled = false;
				}
				catch
				{
				}
				using (XmlReader xmlReader2 = XmlReader.Create(Constants.HighlightingFolder + "\\ScriptHighlighting.xshd"))
				{
					this.scriptEditor.SyntaxHighlighting = HighlightingLoader.Load(xmlReader2, HighlightingManager.Instance);
					try
					{
						this.scriptEditor.TextArea.IndentationStrategy = null;
						FoldingManager.Uninstall(this.foldingManager);
						this.foldingManager = null;
					}
					catch
					{
					}
				}
				IL_13D:;
			}
			catch
			{
			}
		}

		// Token: 0x060004E8 RID: 1256 RVA: 0x000193D8 File Offset: 0x000175D8
		private void ChangeOutVar_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				List<string> list = new List<string>(this.block.Script.Split(Environment.NewLine, StringSplitOptions.None));
				if (list.Count != 0)
				{
					string text;
					if (string.IsNullOrWhiteSpace(text = list.Last<string>()) || !text.StartsWith("END SCRIPT -> VARS \"") || text.StartsWith("END SCRIPT -> VARS "))
					{
						list.RemoveAt(list.Count - 1);
					}
					list.Add("END SCRIPT -> VARS \"" + this.outputVariable.Text + "\"");
					this.block.Script = string.Join(Environment.NewLine, list);
					this.scriptEditor.Text = this.block.Script;
				}
			}
			catch
			{
			}
		}

		// Token: 0x060004E9 RID: 1257 RVA: 0x000194AC File Offset: 0x000176AC
		private void OutputVariable_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.Key == Key.Return)
				{
					this.SetOutputs();
				}
			}
			catch
			{
			}
		}

		// Token: 0x060004EA RID: 1258 RVA: 0x000194E0 File Offset: 0x000176E0
		private void ScriptEditorInitSettings()
		{
			ContextMenu contextMenu = new ContextMenu();
			contextMenu.Items.Add(ContextMenuItemExtension.CreateMenuItem(ContextMenuItemType.Cut, "Cut", new RelayCommand(new Action(this.scriptEditor.Cut), () => this.scriptEditor.SelectionLength > 0), null));
			contextMenu.Items.Add(ContextMenuItemExtension.CreateMenuItem(ContextMenuItemType.Copy, "Copy", new RelayCommand(new Action(this.scriptEditor.Copy), () => this.scriptEditor.SelectionLength > 0), null));
			contextMenu.Items.Add(ContextMenuItemExtension.CreateMenuItem(ContextMenuItemType.Paste, "Paste", ApplicationCommands.Paste, null));
			contextMenu.Items.Add(ContextMenuItemExtension.CreateMenuItem(ContextMenuItemType.Delete, "Delete", ApplicationCommands.Delete, null));
			contextMenu.Items.Add(ContextMenuItemExtension.CreateMenuItem(ContextMenuItemType.SelectAll, "Select All", new RelayCommand(new Action(this.scriptEditor.SelectAll), () => !string.IsNullOrEmpty(this.scriptEditor.Text)), null));
			contextMenu.Items.Add(new Separator
			{
				Margin = new Thickness(0.0, 2.0, 0.0, 2.0)
			});
			contextMenu.Items.Add(ContextMenuItemExtension.CreateMenuItem<TextEditor>(ContextMenuItemType.Find, "Find", new RelayCommand<TextEditor>(delegate(TextEditor e)
			{
				DialogFindReplace.ShowFindReplace(new FindReplaceMgr
				{
					CurrentEditor = new TextEditorAdapter(e)
				}, false);
			}, (TextEditor e) => !string.IsNullOrEmpty(e.Text)), this.scriptEditor));
			contextMenu.Items.Add(ContextMenuItemExtension.CreateMenuItem<TextEditor>(ContextMenuItemType.Replace, "Replace", new RelayCommand<TextEditor>(delegate(TextEditor e)
			{
				DialogFindReplace.ShowFindReplace(new FindReplaceMgr
				{
					CurrentEditor = new TextEditorAdapter(e)
				}, true);
			}, (TextEditor e) => !string.IsNullOrEmpty(e.Text)), this.scriptEditor));
			this.scriptEditor.ContextMenu = contextMenu;
		}

		// Token: 0x060004EB RID: 1259 RVA: 0x000196E8 File Offset: 0x000178E8
		private void Page_Unloaded(object sender, RoutedEventArgs e)
		{
			try
			{
				Action enableScrolling = GlobalData.MainWindow.ConfigsSecionPage.StackerPage.EnableScrolling;
				if (enableScrolling != null)
				{
					enableScrolling();
				}
			}
			catch
			{
			}
		}

		// Token: 0x060004EC RID: 1260 RVA: 0x0001972C File Offset: 0x0001792C
		private void Page_LostFocus(object sender, RoutedEventArgs e)
		{
			try
			{
				if (this.interpreterBox.SelectedItem.ToString() == 3.ToString())
				{
					this.scriptEditor.Text = string.Join(Environment.NewLine, from line in this.scriptEditor.Text.Split(Environment.NewLine, StringSplitOptions.None)
					select line.TrimStart('\t'));
				}
			}
			catch
			{
			}
			try
			{
				this.block.Script = this.scriptEditor.Text;
				this.SetOutputs();
				this.interpreterBox.SelectedItem = this.GetInterpreter().ToString();
			}
			catch
			{
			}
		}

		// Token: 0x060004ED RID: 1261 RVA: 0x00019810 File Offset: 0x00017A10
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/interop/pageblockscriptcode.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060004EE RID: 1262 RVA: 0x00019840 File Offset: 0x00017A40
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				((PageBlockScript)target).Loaded += this.Page_Loaded;
				((PageBlockScript)target).LostFocus += this.Page_LostFocus;
				((PageBlockScript)target).Unloaded += this.Page_Unloaded;
				return;
			case 2:
				((Button)target).Click += this.ChangeOutVar_Click;
				return;
			case 3:
				this.outputVariable = (TextBox)target;
				this.outputVariable.KeyDown += this.OutputVariable_KeyDown;
				return;
			case 4:
				this.interpreterBox = (ComboBox)target;
				this.interpreterBox.SelectionChanged += this.InterpreterBox_SelectionChanged;
				return;
			case 5:
				this.scriptEditor = (TextEditor)target;
				this.scriptEditor.LostFocus += this.ScriptEditor_LostFocus;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x04000257 RID: 599
		private BlockScriptCode block;

		// Token: 0x04000258 RID: 600
		private FoldingManager foldingManager;

		// Token: 0x04000259 RID: 601
		private BraceFoldingStrategy braceFoldingStrategy;

		// Token: 0x0400025A RID: 602
		private CompletionWindow completionWindow;

		// Token: 0x0400025B RID: 603
		private DispatcherTimer foldingUpdateTimer;

		// Token: 0x0400025C RID: 604
		internal TextBox outputVariable;

		// Token: 0x0400025D RID: 605
		internal ComboBox interpreterBox;

		// Token: 0x0400025E RID: 606
		internal TextEditor scriptEditor;

		// Token: 0x0400025F RID: 607
		private bool _contentLoaded;
	}
}
