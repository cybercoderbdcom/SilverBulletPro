using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using ICSharpCode.AvalonEdit;

namespace SilverBulletPro.FindReplace
{
	// Token: 0x020001DA RID: 474
	public class FindReplaceMgr : DependencyObject
	{
		// Token: 0x170001C8 RID: 456
		// (get) Token: 0x06000ED3 RID: 3795 RVA: 0x0004B458 File Offset: 0x00049658
		internal DialogFindReplace Dialog
		{
			get
			{
				if (this._dialog == null)
				{
					this._dialog = new DialogFindReplace(this);
					this._dialog.Closed += delegate([Nullable(2)] object <p0>, EventArgs <p1>)
					{
						this._dialog = null;
					};
					if (this.OwnerWindow != null)
					{
						this._dialog.Owner = this.OwnerWindow;
					}
				}
				return this._dialog;
			}
		}

		// Token: 0x06000ED4 RID: 3796 RVA: 0x0004B4AF File Offset: 0x000496AF
		public FindReplaceMgr()
		{
			this.ReplacementText = "";
			this.SearchIn = FindReplaceMgr.SearchScope.CurrentDocument;
			this.ShowSearchIn = true;
		}

		// Token: 0x170001C9 RID: 457
		// (get) Token: 0x06000ED5 RID: 3797 RVA: 0x0004B4D0 File Offset: 0x000496D0
		public CommandBinding FindBinding
		{
			get
			{
				return new CommandBinding(ApplicationCommands.Find, delegate(object s, ExecutedRoutedEventArgs e)
				{
					this.ShowAsFind("");
				});
			}
		}

		// Token: 0x170001CA RID: 458
		// (get) Token: 0x06000ED6 RID: 3798 RVA: 0x0004B4E8 File Offset: 0x000496E8
		public CommandBinding FindNextBinding
		{
			get
			{
				return new CommandBinding(NavigationCommands.Search, delegate(object s, ExecutedRoutedEventArgs e)
				{
					this.FindNext(e.Parameter != null);
				});
			}
		}

		// Token: 0x170001CB RID: 459
		// (get) Token: 0x06000ED7 RID: 3799 RVA: 0x0004B500 File Offset: 0x00049700
		public CommandBinding ReplaceBinding
		{
			get
			{
				return new CommandBinding(ApplicationCommands.Replace, delegate(object s, ExecutedRoutedEventArgs e)
				{
					if (this.AllowReplace)
					{
						this.ShowAsReplace("");
					}
				});
			}
		}

		// Token: 0x170001CC RID: 460
		// (get) Token: 0x06000ED8 RID: 3800 RVA: 0x0004B518 File Offset: 0x00049718
		// (set) Token: 0x06000ED9 RID: 3801 RVA: 0x0004B52A File Offset: 0x0004972A
		public IEnumerable Editors
		{
			get
			{
				return (IEnumerable)base.GetValue(FindReplaceMgr.EditorsProperty);
			}
			set
			{
				base.SetValue(FindReplaceMgr.EditorsProperty, value);
			}
		}

		// Token: 0x170001CD RID: 461
		// (get) Token: 0x06000EDA RID: 3802 RVA: 0x0004B538 File Offset: 0x00049738
		// (set) Token: 0x06000EDB RID: 3803 RVA: 0x0004B545 File Offset: 0x00049745
		public object CurrentEditor
		{
			get
			{
				return base.GetValue(FindReplaceMgr.CurrentEditorProperty);
			}
			set
			{
				base.SetValue(FindReplaceMgr.CurrentEditorProperty, value);
			}
		}

		// Token: 0x170001CE RID: 462
		// (get) Token: 0x06000EDC RID: 3804 RVA: 0x0004B553 File Offset: 0x00049753
		// (set) Token: 0x06000EDD RID: 3805 RVA: 0x0004B565 File Offset: 0x00049765
		public IValueConverter InterfaceConverter
		{
			get
			{
				return (IValueConverter)base.GetValue(FindReplaceMgr.InterfaceConverterProperty);
			}
			set
			{
				base.SetValue(FindReplaceMgr.InterfaceConverterProperty, value);
			}
		}

		// Token: 0x170001CF RID: 463
		// (get) Token: 0x06000EDE RID: 3806 RVA: 0x0004B573 File Offset: 0x00049773
		// (set) Token: 0x06000EDF RID: 3807 RVA: 0x0004B585 File Offset: 0x00049785
		public string TextToFind
		{
			get
			{
				return (string)base.GetValue(FindReplaceMgr.TextToFindProperty);
			}
			set
			{
				base.SetValue(FindReplaceMgr.TextToFindProperty, value);
			}
		}

		// Token: 0x170001D0 RID: 464
		// (get) Token: 0x06000EE0 RID: 3808 RVA: 0x0004B593 File Offset: 0x00049793
		// (set) Token: 0x06000EE1 RID: 3809 RVA: 0x0004B5A5 File Offset: 0x000497A5
		public string ReplacementText
		{
			get
			{
				return (string)base.GetValue(FindReplaceMgr.ReplacementTextProperty);
			}
			set
			{
				base.SetValue(FindReplaceMgr.ReplacementTextProperty, value);
			}
		}

		// Token: 0x170001D1 RID: 465
		// (get) Token: 0x06000EE2 RID: 3810 RVA: 0x0004B5B3 File Offset: 0x000497B3
		// (set) Token: 0x06000EE3 RID: 3811 RVA: 0x0004B5C5 File Offset: 0x000497C5
		public bool UseWildcards
		{
			get
			{
				return (bool)base.GetValue(FindReplaceMgr.UseWildcardsProperty);
			}
			set
			{
				base.SetValue(FindReplaceMgr.UseWildcardsProperty, value);
			}
		}

		// Token: 0x170001D2 RID: 466
		// (get) Token: 0x06000EE4 RID: 3812 RVA: 0x0004B5D8 File Offset: 0x000497D8
		// (set) Token: 0x06000EE5 RID: 3813 RVA: 0x0004B5EA File Offset: 0x000497EA
		public bool SearchUp
		{
			get
			{
				return (bool)base.GetValue(FindReplaceMgr.SearchUpProperty);
			}
			set
			{
				base.SetValue(FindReplaceMgr.SearchUpProperty, value);
			}
		}

		// Token: 0x170001D3 RID: 467
		// (get) Token: 0x06000EE6 RID: 3814 RVA: 0x0004B5FD File Offset: 0x000497FD
		// (set) Token: 0x06000EE7 RID: 3815 RVA: 0x0004B60F File Offset: 0x0004980F
		public bool CaseSensitive
		{
			get
			{
				return (bool)base.GetValue(FindReplaceMgr.CaseSensitiveProperty);
			}
			set
			{
				base.SetValue(FindReplaceMgr.CaseSensitiveProperty, value);
			}
		}

		// Token: 0x170001D4 RID: 468
		// (get) Token: 0x06000EE8 RID: 3816 RVA: 0x0004B622 File Offset: 0x00049822
		// (set) Token: 0x06000EE9 RID: 3817 RVA: 0x0004B634 File Offset: 0x00049834
		public bool UseRegEx
		{
			get
			{
				return (bool)base.GetValue(FindReplaceMgr.UseRegExProperty);
			}
			set
			{
				base.SetValue(FindReplaceMgr.UseRegExProperty, value);
			}
		}

		// Token: 0x170001D5 RID: 469
		// (get) Token: 0x06000EEA RID: 3818 RVA: 0x0004B647 File Offset: 0x00049847
		// (set) Token: 0x06000EEB RID: 3819 RVA: 0x0004B659 File Offset: 0x00049859
		public bool WholeWord
		{
			get
			{
				return (bool)base.GetValue(FindReplaceMgr.WholeWordProperty);
			}
			set
			{
				base.SetValue(FindReplaceMgr.WholeWordProperty, value);
			}
		}

		// Token: 0x170001D6 RID: 470
		// (get) Token: 0x06000EEC RID: 3820 RVA: 0x0004B66C File Offset: 0x0004986C
		// (set) Token: 0x06000EED RID: 3821 RVA: 0x0004B67E File Offset: 0x0004987E
		public bool AcceptsReturn
		{
			get
			{
				return (bool)base.GetValue(FindReplaceMgr.AcceptsReturnProperty);
			}
			set
			{
				base.SetValue(FindReplaceMgr.AcceptsReturnProperty, value);
			}
		}

		// Token: 0x170001D7 RID: 471
		// (get) Token: 0x06000EEE RID: 3822 RVA: 0x0004B691 File Offset: 0x00049891
		// (set) Token: 0x06000EEF RID: 3823 RVA: 0x0004B6A3 File Offset: 0x000498A3
		public FindReplaceMgr.SearchScope SearchIn
		{
			get
			{
				return (FindReplaceMgr.SearchScope)base.GetValue(FindReplaceMgr.SearchInProperty);
			}
			set
			{
				base.SetValue(FindReplaceMgr.SearchInProperty, value);
			}
		}

		// Token: 0x170001D8 RID: 472
		// (get) Token: 0x06000EF0 RID: 3824 RVA: 0x0004B6B6 File Offset: 0x000498B6
		// (set) Token: 0x06000EF1 RID: 3825 RVA: 0x0004B6C8 File Offset: 0x000498C8
		public double WindowLeft
		{
			get
			{
				return (double)base.GetValue(FindReplaceMgr.WindowLeftProperty);
			}
			set
			{
				base.SetValue(FindReplaceMgr.WindowLeftProperty, value);
			}
		}

		// Token: 0x170001D9 RID: 473
		// (get) Token: 0x06000EF2 RID: 3826 RVA: 0x0004B6DB File Offset: 0x000498DB
		// (set) Token: 0x06000EF3 RID: 3827 RVA: 0x0004B6ED File Offset: 0x000498ED
		public double WindowTop
		{
			get
			{
				return (double)base.GetValue(FindReplaceMgr.WindowTopProperty);
			}
			set
			{
				base.SetValue(FindReplaceMgr.WindowTopProperty, value);
			}
		}

		// Token: 0x170001DA RID: 474
		// (get) Token: 0x06000EF4 RID: 3828 RVA: 0x0004B700 File Offset: 0x00049900
		// (set) Token: 0x06000EF5 RID: 3829 RVA: 0x0004B712 File Offset: 0x00049912
		public bool ShowSearchIn
		{
			get
			{
				return (bool)base.GetValue(FindReplaceMgr.ShowSearchInProperty);
			}
			set
			{
				base.SetValue(FindReplaceMgr.ShowSearchInProperty, value);
			}
		}

		// Token: 0x170001DB RID: 475
		// (get) Token: 0x06000EF6 RID: 3830 RVA: 0x0004B725 File Offset: 0x00049925
		// (set) Token: 0x06000EF7 RID: 3831 RVA: 0x0004B737 File Offset: 0x00049937
		public bool AllowReplace
		{
			get
			{
				return (bool)base.GetValue(FindReplaceMgr.AllowReplaceProperty);
			}
			set
			{
				base.SetValue(FindReplaceMgr.AllowReplaceProperty, value);
			}
		}

		// Token: 0x170001DC RID: 476
		// (get) Token: 0x06000EF8 RID: 3832 RVA: 0x0004B74A File Offset: 0x0004994A
		// (set) Token: 0x06000EF9 RID: 3833 RVA: 0x0004B75C File Offset: 0x0004995C
		public Window OwnerWindow
		{
			get
			{
				return (Window)base.GetValue(FindReplaceMgr.OwnerWindowProperty);
			}
			set
			{
				base.SetValue(FindReplaceMgr.OwnerWindowProperty, value);
			}
		}

		// Token: 0x06000EFA RID: 3834 RVA: 0x0004B76C File Offset: 0x0004996C
		private IEditor GetCurrentEditor()
		{
			if (this.CurrentEditor == null)
			{
				return null;
			}
			if (this.CurrentEditor is IEditor)
			{
				return this.CurrentEditor as IEditor;
			}
			if (this.InterfaceConverter == null)
			{
				return null;
			}
			return this.InterfaceConverter.Convert(this.CurrentEditor, typeof(IEditor), null, CultureInfo.CurrentCulture) as IEditor;
		}

		// Token: 0x06000EFB RID: 3835 RVA: 0x0004B7CC File Offset: 0x000499CC
		private IEditor GetNextEditor(bool previous = false)
		{
			if (!this.ShowSearchIn || this.SearchIn == FindReplaceMgr.SearchScope.CurrentDocument || this.Editors == null)
			{
				return this.GetCurrentEditor();
			}
			List<object> list = new List<object>(this.Editors.Cast<object>());
			int num = list.IndexOf(this.CurrentEditor);
			if (num >= 0)
			{
				num = (num + (previous ? (list.Count - 1) : 1)) % list.Count;
				this.CurrentEditor = list[num];
			}
			return this.GetCurrentEditor();
		}

		// Token: 0x06000EFC RID: 3836 RVA: 0x0004B848 File Offset: 0x00049A48
		public Regex GetRegEx(bool ForceLeftToRight = false)
		{
			RegexOptions regexOptions = RegexOptions.None;
			if (this.SearchUp && !ForceLeftToRight)
			{
				regexOptions |= RegexOptions.RightToLeft;
			}
			if (!this.CaseSensitive)
			{
				regexOptions |= RegexOptions.IgnoreCase;
			}
			Regex result;
			if (this.UseRegEx)
			{
				result = new Regex(this.TextToFind, regexOptions);
			}
			else
			{
				string text = Regex.Escape(this.TextToFind);
				if (this.UseWildcards)
				{
					text = text.Replace("\\*", ".*").Replace("\\?", ".");
				}
				if (this.WholeWord)
				{
					text = "\\b" + text + "\\b";
				}
				result = new Regex(text, regexOptions);
			}
			return result;
		}

		// Token: 0x06000EFD RID: 3837 RVA: 0x0004B8E0 File Offset: 0x00049AE0
		public void ReplaceAll(bool AskBefore = true)
		{
			IEditor editor = this.GetCurrentEditor();
			if (editor == null)
			{
				return;
			}
			if (!AskBefore || Alert.Choice(string.Concat(new string[]
			{
				"Do you really want to replace all occurences of '",
				this.TextToFind,
				"' with '",
				this.ReplacementText,
				"'?"
			}), "Replace all", MessageBoxButton.YesNoCancel, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
			{
				object currentEditor = this.CurrentEditor;
				do
				{
					Regex regEx = this.GetRegEx(true);
					int num = 0;
					editor.BeginChange();
					foreach (object obj in regEx.Matches(editor.Text))
					{
						Match match = (Match)obj;
						editor.Replace(num + match.Index, match.Length, this.ReplacementText);
						num += this.ReplacementText.Length - match.Length;
					}
					editor.EndChange();
					editor = this.GetNextEditor(false);
				}
				while (this.CurrentEditor != currentEditor);
			}
		}

		// Token: 0x06000EFE RID: 3838 RVA: 0x0004B9F4 File Offset: 0x00049BF4
		public void ShowAsFind(string title = "")
		{
			this.Dialog.tabMain.SelectedIndex = 0;
			this.Dialog.Show();
			this.Dialog.Activate();
			this.Dialog.txtFind.Focus();
			this.Dialog.txtFind.SelectAll();
			if (!string.IsNullOrWhiteSpace(title))
			{
				this.Dialog.Title = title;
			}
		}

		// Token: 0x06000EFF RID: 3839 RVA: 0x0004BA5E File Offset: 0x00049C5E
		public void ShowAsFind(TextEditor target)
		{
			this.CurrentEditor = target;
			this.ShowAsFind("");
		}

		// Token: 0x06000F00 RID: 3840 RVA: 0x0004BA74 File Offset: 0x00049C74
		public void ShowAsReplace(string title = "")
		{
			this.Dialog.tabMain.SelectedIndex = 1;
			this.Dialog.Show();
			this.Dialog.Activate();
			this.Dialog.txtFind2.Focus();
			this.Dialog.txtFind2.SelectAll();
			if (!string.IsNullOrWhiteSpace(title))
			{
				this.Dialog.Title = title;
			}
		}

		// Token: 0x06000F01 RID: 3841 RVA: 0x0004BADE File Offset: 0x00049CDE
		public void ShowAsReplace(object target)
		{
			this.CurrentEditor = target;
			this.ShowAsReplace("");
		}

		// Token: 0x06000F02 RID: 3842 RVA: 0x0004BAF2 File Offset: 0x00049CF2
		public void FindNext(object target, bool InvertLeftRight = false)
		{
			this.CurrentEditor = target;
			this.FindNext(InvertLeftRight);
		}

		// Token: 0x06000F03 RID: 3843 RVA: 0x0004BB04 File Offset: 0x00049D04
		public void FindNext(bool InvertLeftRight = false)
		{
			IEditor editor = this.GetCurrentEditor();
			if (editor == null)
			{
				return;
			}
			Regex regEx;
			if (InvertLeftRight)
			{
				this.SearchUp = !this.SearchUp;
				regEx = this.GetRegEx(false);
				this.SearchUp = !this.SearchUp;
			}
			else
			{
				regEx = this.GetRegEx(false);
			}
			Match match = regEx.Match(editor.Text, regEx.Options.HasFlag(RegexOptions.RightToLeft) ? editor.SelectionStart : (editor.SelectionStart + editor.SelectionLength));
			if (match.Success)
			{
				editor.Select(match.Index, match.Length);
				return;
			}
			object currentEditor = this.CurrentEditor;
			for (;;)
			{
				if (this.ShowSearchIn)
				{
					editor = this.GetNextEditor(regEx.Options.HasFlag(RegexOptions.RightToLeft));
					if (editor == null)
					{
						break;
					}
				}
				if (regEx.Options.HasFlag(RegexOptions.RightToLeft))
				{
					match = regEx.Match(editor.Text, editor.Text.Length);
				}
				else
				{
					match = regEx.Match(editor.Text, 0);
				}
				if (match.Success)
				{
					goto Block_8;
				}
				if (this.CurrentEditor == currentEditor)
				{
					return;
				}
			}
			return;
			Block_8:
			editor.Select(match.Index, match.Length);
		}

		// Token: 0x06000F04 RID: 3844 RVA: 0x0004BC3E File Offset: 0x00049E3E
		public void FindPrevious()
		{
			this.FindNext(true);
		}

		// Token: 0x06000F05 RID: 3845 RVA: 0x0004BC48 File Offset: 0x00049E48
		public void Replace()
		{
			IEditor currentEditor = this.GetCurrentEditor();
			if (currentEditor == null)
			{
				return;
			}
			Regex regEx = this.GetRegEx(false);
			string text = currentEditor.Text.Substring(currentEditor.SelectionStart, currentEditor.SelectionLength);
			Match match = regEx.Match(text);
			if (match.Success && match.Index == 0 && match.Length == text.Length)
			{
				currentEditor.Replace(currentEditor.SelectionStart, currentEditor.SelectionLength, this.ReplacementText);
			}
			this.FindNext(false);
		}

		// Token: 0x06000F06 RID: 3846 RVA: 0x0004BCC3 File Offset: 0x00049EC3
		public void CloseWindow()
		{
			this.Dialog.Close();
		}

		// Token: 0x04000701 RID: 1793
		private DialogFindReplace _dialog;

		// Token: 0x04000702 RID: 1794
		public static readonly DependencyProperty EditorsProperty = DependencyProperty.Register("Editors", typeof(IEnumerable), typeof(FindReplaceMgr), new PropertyMetadata(null));

		// Token: 0x04000703 RID: 1795
		public static readonly DependencyProperty CurrentEditorProperty = DependencyProperty.Register("CurrentEditor", typeof(object), typeof(FindReplaceMgr), new PropertyMetadata(0));

		// Token: 0x04000704 RID: 1796
		public static readonly DependencyProperty InterfaceConverterProperty = DependencyProperty.Register("InterfaceConverter", typeof(IValueConverter), typeof(FindReplaceMgr), new PropertyMetadata(null));

		// Token: 0x04000705 RID: 1797
		public static readonly DependencyProperty TextToFindProperty = DependencyProperty.Register("TextToFind", typeof(string), typeof(FindReplaceMgr), new UIPropertyMetadata(""));

		// Token: 0x04000706 RID: 1798
		public static readonly DependencyProperty ReplacementTextProperty = DependencyProperty.Register("ReplacementText", typeof(string), typeof(FindReplaceMgr), new UIPropertyMetadata(""));

		// Token: 0x04000707 RID: 1799
		public static readonly DependencyProperty UseWildcardsProperty = DependencyProperty.Register("UseWildcards", typeof(bool), typeof(FindReplaceMgr), new UIPropertyMetadata(false));

		// Token: 0x04000708 RID: 1800
		public static readonly DependencyProperty SearchUpProperty = DependencyProperty.Register("SearchUp", typeof(bool), typeof(FindReplaceMgr), new UIPropertyMetadata(false));

		// Token: 0x04000709 RID: 1801
		public static readonly DependencyProperty CaseSensitiveProperty = DependencyProperty.Register("CaseSensitive", typeof(bool), typeof(FindReplaceMgr), new UIPropertyMetadata(false));

		// Token: 0x0400070A RID: 1802
		public static readonly DependencyProperty UseRegExProperty = DependencyProperty.Register("UseRegEx", typeof(bool), typeof(FindReplaceMgr), new UIPropertyMetadata(false));

		// Token: 0x0400070B RID: 1803
		public static readonly DependencyProperty WholeWordProperty = DependencyProperty.Register("WholeWord", typeof(bool), typeof(FindReplaceMgr), new UIPropertyMetadata(false));

		// Token: 0x0400070C RID: 1804
		public static readonly DependencyProperty AcceptsReturnProperty = DependencyProperty.Register("AcceptsReturn", typeof(bool), typeof(FindReplaceMgr), new UIPropertyMetadata(false));

		// Token: 0x0400070D RID: 1805
		public static readonly DependencyProperty SearchInProperty = DependencyProperty.Register("SearchIn", typeof(FindReplaceMgr.SearchScope), typeof(FindReplaceMgr), new UIPropertyMetadata(FindReplaceMgr.SearchScope.CurrentDocument));

		// Token: 0x0400070E RID: 1806
		public static readonly DependencyProperty WindowLeftProperty = DependencyProperty.Register("WindowLeft", typeof(double), typeof(FindReplaceMgr), new UIPropertyMetadata(100.0));

		// Token: 0x0400070F RID: 1807
		public static readonly DependencyProperty WindowTopProperty = DependencyProperty.Register("WindowTop", typeof(double), typeof(FindReplaceMgr), new UIPropertyMetadata(100.0));

		// Token: 0x04000710 RID: 1808
		public static readonly DependencyProperty ShowSearchInProperty = DependencyProperty.Register("ShowSearchIn", typeof(bool), typeof(FindReplaceMgr), new UIPropertyMetadata(true));

		// Token: 0x04000711 RID: 1809
		public static readonly DependencyProperty AllowReplaceProperty = DependencyProperty.Register("AllowReplace", typeof(bool), typeof(FindReplaceMgr), new UIPropertyMetadata(true));

		// Token: 0x04000712 RID: 1810
		public static readonly DependencyProperty OwnerWindowProperty = DependencyProperty.Register("OwnerWindow", typeof(Window), typeof(FindReplaceMgr), new UIPropertyMetadata(null));

		// Token: 0x020002DC RID: 732
		public enum SearchScope
		{
			// Token: 0x0400099F RID: 2463
			CurrentDocument,
			// Token: 0x040009A0 RID: 2464
			AllDocuments
		}
	}
}
