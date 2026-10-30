using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using AngleSharp.Text;
using HandyControl.Controls;
using SilverBulletPro.Core;
using SilverBulletPro.Core.Extensions;
using SilverBulletPro.Core.Models;
using SilverBulletPro.Extensions;

namespace SilverBulletPro.Views.UserControls
{
	// Token: 0x02000036 RID: 54
	public class RichTextInputBox : UserControl, IComponentConnector, IStyleConnector
	{
		// Token: 0x06000203 RID: 515 RVA: 0x0000E92B File Offset: 0x0000CB2B
		public RichTextInputBox()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x06000204 RID: 516 RVA: 0x0000E940 File Offset: 0x0000CB40
		// (set) Token: 0x06000205 RID: 517 RVA: 0x0000E952 File Offset: 0x0000CB52
		public InputMode? ModesOfInput
		{
			get
			{
				return (InputMode?)base.GetValue(RichTextInputBox.ModesOfInputProperty);
			}
			set
			{
				base.SetValue(RichTextInputBox.ModesOfInputProperty, value);
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x06000206 RID: 518 RVA: 0x0000E965 File Offset: 0x0000CB65
		// (set) Token: 0x06000207 RID: 519 RVA: 0x0000E977 File Offset: 0x0000CB77
		public Visibility LabelVisibility
		{
			get
			{
				return (Visibility)base.GetValue(RichTextInputBox.LabelVisibilityProperty);
			}
			set
			{
				base.SetValue(RichTextInputBox.LabelVisibilityProperty, value);
			}
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x06000208 RID: 520 RVA: 0x0000E98A File Offset: 0x0000CB8A
		// (set) Token: 0x06000209 RID: 521 RVA: 0x0000E99C File Offset: 0x0000CB9C
		public string Label
		{
			get
			{
				return (string)base.GetValue(RichTextInputBox.LabelProperty);
			}
			set
			{
				base.SetValue(RichTextInputBox.LabelProperty, value);
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x0600020A RID: 522 RVA: 0x0000E9AA File Offset: 0x0000CBAA
		// (set) Token: 0x0600020B RID: 523 RVA: 0x0000E9B7 File Offset: 0x0000CBB7
		public object RichTextBoxToolTip
		{
			get
			{
				return base.GetValue(RichTextInputBox.RichTextBoxToolTipProperty);
			}
			set
			{
				base.SetValue(RichTextInputBox.RichTextBoxToolTipProperty, value);
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x0600020C RID: 524 RVA: 0x0000E9C5 File Offset: 0x0000CBC5
		// (set) Token: 0x0600020D RID: 525 RVA: 0x0000E9D2 File Offset: 0x0000CBD2
		public object ListBoxToolTip
		{
			get
			{
				return base.GetValue(RichTextInputBox.ListBoxToolTipProperty);
			}
			set
			{
				base.SetValue(RichTextInputBox.ListBoxToolTipProperty, value);
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x0600020E RID: 526 RVA: 0x0000E9E0 File Offset: 0x0000CBE0
		// (set) Token: 0x0600020F RID: 527 RVA: 0x0000E9F2 File Offset: 0x0000CBF2
		public bool IsEditable
		{
			get
			{
				return (bool)base.GetValue(RichTextInputBox.IsEditableProperty);
			}
			set
			{
				base.SetValue(RichTextInputBox.IsEditableProperty, value);
			}
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06000210 RID: 528 RVA: 0x0000EA05 File Offset: 0x0000CC05
		// (set) Token: 0x06000211 RID: 529 RVA: 0x0000EA17 File Offset: 0x0000CC17
		public char SplitChar
		{
			get
			{
				return (char)base.GetValue(RichTextInputBox.SplitCharProperty);
			}
			set
			{
				base.SetValue(RichTextInputBox.SplitCharProperty, value);
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x06000212 RID: 530 RVA: 0x0000EA2A File Offset: 0x0000CC2A
		// (set) Token: 0x06000213 RID: 531 RVA: 0x0000EA3C File Offset: 0x0000CC3C
		public int? SplitCount
		{
			get
			{
				return (int?)base.GetValue(RichTextInputBox.SplitCountProperty);
			}
			set
			{
				base.SetValue(RichTextInputBox.SplitCountProperty, value);
			}
		}

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000214 RID: 532 RVA: 0x0000EA50 File Offset: 0x0000CC50
		// (remove) Token: 0x06000215 RID: 533 RVA: 0x0000EA88 File Offset: 0x0000CC88
		public event RoutedEventHandler RichTextBoxLostFocus;

		// Token: 0x06000216 RID: 534 RVA: 0x0000EABD File Offset: 0x0000CCBD
		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
		}

		// Token: 0x06000217 RID: 535 RVA: 0x0000EAC0 File Offset: 0x0000CCC0
		private void RichTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			ObservableCollection<ListItem> observableCollection = (ObservableCollection<ListItem>)this.listBox.ItemsSource;
			if (observableCollection == null)
			{
				observableCollection = new ObservableCollection<ListItem>();
				this.listBox.ItemsSource = observableCollection;
			}
			else
			{
				observableCollection.Clear();
			}
			if (this.richTextBox.Lines(StringSplitOptions.RemoveEmptyEntries).Length == 0)
			{
				return;
			}
			string[] array = this.richTextBox.Lines(StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < array.Length; i++)
			{
				observableCollection.Add(this.CreateListItem(array[i]));
			}
			RoutedEventHandler richTextBoxLostFocus = this.RichTextBoxLostFocus;
			if (richTextBoxLostFocus == null)
			{
				return;
			}
			richTextBoxLostFocus(sender, e);
		}

		// Token: 0x06000218 RID: 536 RVA: 0x0000EB48 File Offset: 0x0000CD48
		private void ToggleButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if ((sender as ToggleButton).IsChecked.GetValueOrDefault())
				{
					this.VisibleRichTextBox();
				}
				else
				{
					this.VisibleListBox();
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000219 RID: 537 RVA: 0x0000EB90 File Offset: 0x0000CD90
		public void AddItems(IEnumerable<ListItem> itemsSource)
		{
			this.listBox.ItemsSource = itemsSource;
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < this.listBox.Items.Count; i++)
			{
				if (i < this.listBox.Items.Count - 1)
				{
					stringBuilder.AppendLine(this.listBox.Items[i].ToString());
				}
				else
				{
					stringBuilder.Append(this.listBox.Items[i].ToString());
				}
			}
			this.richTextBox.SetText(stringBuilder.ToString());
		}

		// Token: 0x0600021A RID: 538 RVA: 0x0000EC2C File Offset: 0x0000CE2C
		public void AddItem(ListItem item)
		{
			this.richTextBox.AppendLine(item.ToString());
		}

		// Token: 0x0600021B RID: 539 RVA: 0x0000EC40 File Offset: 0x0000CE40
		private void VisibleRichTextBox()
		{
			this.richTextBox.SetText(string.Empty);
			for (int i = 0; i < this.listBox.Items.Count; i++)
			{
				ListItem listItem = this.listBox.Items[i] as ListItem;
				if (i < this.listBox.Items.Count - 1)
				{
					if (listItem.InputMode != 2 || this.<VisibleRichTextBox>g__CanAppendInputMode|43_0(listItem.Value))
					{
						this.richTextBox.AppendLine(listItem.Value + this.SplitChar.ToString() + listItem.InputMode.ToString());
					}
					else
					{
						this.richTextBox.AppendLine(listItem.Value);
					}
				}
				else if (listItem.InputMode != 2 || this.<VisibleRichTextBox>g__CanAppendInputMode|43_0(listItem.Value))
				{
					this.richTextBox.AppendText(listItem.Value + this.SplitChar.ToString() + listItem.InputMode.ToString());
				}
				else
				{
					this.richTextBox.AppendText(listItem.Value);
				}
			}
		}

		// Token: 0x0600021C RID: 540 RVA: 0x0000ED70 File Offset: 0x0000CF70
		private void VisibleListBox()
		{
		}

		// Token: 0x0600021D RID: 541 RVA: 0x0000ED74 File Offset: 0x0000CF74
		private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			if (e.ClickCount >= 2 && this.canEdit)
			{
				TextBox textBox = ((FrameworkElement)sender).FindVisualChildren<TextBox>().FirstOrDefault<TextBox>();
				if (textBox != null && textBox.Visibility != Visibility.Visible)
				{
					textBox.IsReadOnly = false;
					textBox.Visibility = Visibility.Visible;
					this.tmpEditBox = textBox;
				}
			}
		}

		// Token: 0x0600021E RID: 542 RVA: 0x0000EDC4 File Offset: 0x0000CFC4
		private void ListBoxItem_LostFocus(object sender, RoutedEventArgs e)
		{
			try
			{
				int selectedIndex = this.listBox.SelectedIndex;
				if (this.listBox.SelectedIndex != -1)
				{
					TextBox textBox;
					if (sender is ListBoxItem && this.tmpEditBox != null)
					{
						textBox = this.tmpEditBox;
						if (!textBox.IsFocused && textBox.IsMouseOver)
						{
							return;
						}
						this.tmpEditBox = null;
					}
					else
					{
						textBox = (sender as TextBox);
					}
					if (textBox != null)
					{
						if (textBox.Visibility != Visibility.Collapsed)
						{
							textBox.IsReadOnly = true;
							textBox.Visibility = Visibility.Collapsed;
							this.listBox.SelectedIndex = -1;
							this.listBox.SelectedIndex = selectedIndex;
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600021F RID: 543 RVA: 0x0000EE74 File Offset: 0x0000D074
		private void ListBoxItem_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				this.ListBoxItem_LostFocus(sender, e);
			}
		}

		// Token: 0x06000220 RID: 544 RVA: 0x0000EE87 File Offset: 0x0000D087
		private void ChangeModeButton_MouseLeave(object sender, MouseEventArgs e)
		{
			this.canEdit = true;
		}

		// Token: 0x06000221 RID: 545 RVA: 0x0000EE90 File Offset: 0x0000D090
		private void ChangeModeButton_MouseEnter(object sender, MouseEventArgs e)
		{
			this.canEdit = false;
		}

		// Token: 0x06000222 RID: 546 RVA: 0x0000EE9C File Offset: 0x0000D09C
		private void InputModeButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (this.ModesOfInput != null)
				{
					InputMode inputMode = (((FrameworkElement)sender).Tag as ListItem).InputMode;
					List<string> list = this.ModesOfInput.GetValueOrDefault().ToString("g").Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToList<string>();
					int num = list.IndexOf(inputMode.ToString());
					if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
					{
						num--;
						if (num <= -1)
						{
							num = list.Count - 1;
						}
					}
					else
					{
						num = ((list.Count - 1 == num) ? 0 : (num + 1));
					}
					this.ApplyInputMode(sender as Button, inputMode = StringExtensions.ToEnum<InputMode>(list[num], 1));
					(((FrameworkElement)sender).Tag as ListItem).InputMode = inputMode;
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000223 RID: 547 RVA: 0x0000EF94 File Offset: 0x0000D194
		private void ApplyInputMode(Button inputModeButton, InputMode inputMode)
		{
			if (inputMode == 1)
			{
				inputModeButton.Content = string.Empty;
				inputModeButton.Padding = new Thickness(10.0, 0.0, 5.0, 0.0);
				IconElement.SetWidth(inputModeButton, 8.5);
			}
			else
			{
				inputModeButton.Padding = new Thickness(0.0, 0.0, 5.0, 0.0);
				IconElement.SetWidth(inputModeButton, 0.0);
				inputModeButton.Content = EnumExtension.GetDescription(inputMode);
			}
			this.SetForeColorByInputMode(inputModeButton, inputMode);
		}

		// Token: 0x06000224 RID: 548 RVA: 0x0000F047 File Offset: 0x0000D247
		private void Button_Initialized(object sender, EventArgs e)
		{
			this.ApplyInputMode(sender as Button, (((FrameworkElement)sender).Tag as ListItem).InputMode);
		}

		// Token: 0x06000225 RID: 549 RVA: 0x0000F06C File Offset: 0x0000D26C
		private void SetForeColorByInputMode(Button inputModeButton, InputMode mode)
		{
			if (mode <= 8)
			{
				if (mode == 2)
				{
					inputModeButton.SetResourceReference(Control.ForegroundProperty, "ForegroundRetry");
					return;
				}
				if (mode == 4)
				{
					inputModeButton.SetResourceReference(Control.ForegroundProperty, "ForegroundOcrRate");
					return;
				}
				if (mode == 8)
				{
					inputModeButton.SetResourceReference(Control.ForegroundProperty, "ForegroundOcrRate");
					return;
				}
			}
			else
			{
				if (mode == 16)
				{
					inputModeButton.SetResourceReference(Control.ForegroundProperty, "ForegroundCustom");
					return;
				}
				if (mode == 32)
				{
					inputModeButton.SetResourceReference(Control.ForegroundProperty, "ForegroundCustom");
					return;
				}
				if (mode == 64)
				{
					inputModeButton.SetResourceReference(Control.ForegroundProperty, "ForegroundGood");
					return;
				}
			}
			inputModeButton.SetResourceReference(Control.ForegroundProperty, "ForegroundMain");
		}

		// Token: 0x06000226 RID: 550 RVA: 0x0000F114 File Offset: 0x0000D314
		private void AddItem_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				((ObservableCollection<ListItem>)this.listBox.ItemsSource).Add(new ListItem());
			}
			catch
			{
			}
		}

		// Token: 0x06000227 RID: 551 RVA: 0x0000F150 File Offset: 0x0000D350
		private void CopySelected_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				ListItem listItem = this.listBox.SelectedItem as ListItem;
				Clipboard.SetText((listItem.InputMode == 2) ? listItem.Value : (listItem.Value + this.SplitChar.ToString() + listItem.InputMode.ToString()));
			}
			catch
			{
			}
		}

		// Token: 0x06000228 RID: 552 RVA: 0x0000F1C8 File Offset: 0x0000D3C8
		private ListItem CreateListItem(string text)
		{
			if (!text.Contains(this.SplitChar))
			{
				return new ListItem(text, 2);
			}
			List<string> list;
			if (this.SplitCount == null)
			{
				list = text.Split(this.SplitChar, StringSplitOptions.None).ToList<string>();
			}
			else
			{
				list = text.Split(this.SplitChar, this.SplitCount.GetValueOrDefault(3), StringSplitOptions.None).ToList<string>();
			}
			if (list.Count == 0)
			{
				return new ListItem(list[0], 2);
			}
			string text2 = list.Last<string>().Trim();
			object obj;
			if (text2.Length > 0 && !char.IsNumber(text2[0]) && Enum.TryParse(typeof(InputMode), text2, true, out obj))
			{
				list.RemoveAt(list.Count - 1);
				return new ListItem(string.Join<string>(this.SplitChar, list), (InputMode)obj);
			}
			return new ListItem(text, 2);
		}

		// Token: 0x06000229 RID: 553 RVA: 0x0000F2B0 File Offset: 0x0000D4B0
		private void Paste_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				string[] array = Clipboard.GetText().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
				for (int i = 0; i < array.Length; i++)
				{
					((ObservableCollection<ListItem>)this.listBox.ItemsSource).Add(this.CreateListItem(array[i]));
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600022A RID: 554 RVA: 0x0000F310 File Offset: 0x0000D510
		private void RemoveSelected_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				((ObservableCollection<ListItem>)this.listBox.ItemsSource).RemoveAt(this.listBox.SelectedIndex);
			}
			catch
			{
			}
		}

		// Token: 0x0600022B RID: 555 RVA: 0x0000F354 File Offset: 0x0000D554
		private void Clear_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (Alert.Choice("Do you want to delete all items?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
				{
					((ObservableCollection<ListItem>)this.listBox.ItemsSource).Clear();
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600022C RID: 556 RVA: 0x0000F3A4 File Offset: 0x0000D5A4
		private void ListBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyboardDevice.Modifiers == ModifierKeys.Control)
			{
				if (e.Key == Key.V)
				{
					this.Paste_Click(sender, e);
					return;
				}
				if (e.Key == Key.C)
				{
					this.CopySelected_Click(sender, e);
					return;
				}
				if (e.Key == Key.N)
				{
					this.AddItem_Click(sender, e);
					return;
				}
			}
			else if (e.Key == Key.Delete)
			{
				this.RemoveSelected_Click(sender, e);
			}
		}

		// Token: 0x0600022D RID: 557 RVA: 0x0000F40C File Offset: 0x0000D60C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/usercontrols/input/richtextinputbox.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600022E RID: 558 RVA: 0x0000F43C File Offset: 0x0000D63C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.parent = (RichTextInputBox)target;
				this.parent.Loaded += this.Page_Loaded;
				return;
			case 2:
				this.textBlock = (TextBlock)target;
				return;
			case 3:
				this.toggleButton = (ToggleButton)target;
				this.toggleButton.Click += this.ToggleButton_Click;
				return;
			case 4:
				this.listBox = (ListBox)target;
				this.listBox.KeyDown += this.ListBox_KeyDown;
				return;
			case 10:
				((MenuItem)target).Click += this.AddItem_Click;
				return;
			case 11:
				((MenuItem)target).Click += this.CopySelected_Click;
				return;
			case 12:
				((MenuItem)target).Click += this.Paste_Click;
				return;
			case 13:
				((MenuItem)target).Click += this.RemoveSelected_Click;
				return;
			case 14:
				((MenuItem)target).Click += this.Clear_Click;
				return;
			case 15:
				this.richTextBox = (RichTextBox)target;
				this.richTextBox.LostFocus += this.RichTextBox_LostFocus;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x0600022F RID: 559 RVA: 0x0000F5B0 File Offset: 0x0000D7B0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IStyleConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 5:
			{
				EventSetter eventSetter = new EventSetter();
				eventSetter.Event = UIElement.LostFocusEvent;
				eventSetter.Handler = new RoutedEventHandler(this.ListBoxItem_LostFocus);
				((Style)target).Setters.Add(eventSetter);
				return;
			}
			case 6:
				((Grid)target).PreviewMouseLeftButtonDown += this.ListBoxItem_MouseDoubleClick;
				return;
			case 7:
				((TextBlock)target).PreviewMouseLeftButtonDown += this.ListBoxItem_MouseDoubleClick;
				return;
			case 8:
				((TextBox)target).KeyDown += this.ListBoxItem_KeyDown;
				((TextBox)target).LostFocus += this.ListBoxItem_LostFocus;
				return;
			case 9:
				((Button)target).Click += this.InputModeButton_Click;
				((Button)target).Initialized += this.Button_Initialized;
				((Button)target).MouseEnter += this.ChangeModeButton_MouseEnter;
				((Button)target).MouseLeave += this.ChangeModeButton_MouseLeave;
				return;
			default:
				return;
			}
		}

		// Token: 0x06000231 RID: 561 RVA: 0x0000F83C File Offset: 0x0000DA3C
		[CompilerGenerated]
		private bool <VisibleRichTextBox>g__CanAppendInputMode|43_0(string value)
		{
			string text = value.Split(this.SplitChar, StringSplitOptions.None).Last<string>();
			object obj;
			return text.Length > 0 && !char.IsNumber(text[0]) && Enum.TryParse(typeof(InputMode), text, true, out obj);
		}

		// Token: 0x0400010C RID: 268
		private bool canEdit = true;

		// Token: 0x0400010D RID: 269
		private TextBox tmpEditBox;

		// Token: 0x0400010E RID: 270
		public static readonly DependencyProperty ModesOfInputProperty = DependencyProperty.Register("ModesOfInput", typeof(InputMode?), typeof(RichTextInputBox), new PropertyMetadata(115));

		// Token: 0x0400010F RID: 271
		public static readonly DependencyProperty LabelVisibilityProperty = DependencyProperty.Register("LabelVisibility", typeof(Visibility), typeof(RichTextInputBox), new PropertyMetadata(Visibility.Visible));

		// Token: 0x04000110 RID: 272
		public static readonly DependencyProperty LabelProperty = DependencyProperty.Register("Label", typeof(string), typeof(RichTextInputBox), new PropertyMetadata("Label"));

		// Token: 0x04000111 RID: 273
		public static readonly DependencyProperty RichTextBoxToolTipProperty = DependencyProperty.Register("RichTextBoxToolTip", typeof(object), typeof(RichTextInputBox), new PropertyMetadata(null));

		// Token: 0x04000112 RID: 274
		public static readonly DependencyProperty ListBoxToolTipProperty = DependencyProperty.Register("ListBoxToolTip", typeof(object), typeof(RichTextInputBox), new PropertyMetadata(null));

		// Token: 0x04000113 RID: 275
		public static readonly DependencyProperty IsEditableProperty = DependencyProperty.Register("IsEditable", typeof(bool), typeof(RichTextInputBox), new PropertyMetadata(false));

		// Token: 0x04000114 RID: 276
		public static readonly DependencyProperty SplitCharProperty = DependencyProperty.Register("SplitChar", typeof(char), typeof(RichTextInputBox), new PropertyMetadata(':'));

		// Token: 0x04000115 RID: 277
		public static readonly DependencyProperty SplitCountProperty = DependencyProperty.Register("SplitCount", typeof(int?), typeof(RichTextInputBox), new PropertyMetadata(null));

		// Token: 0x04000117 RID: 279
		private RichTextInputBox parent;

		// Token: 0x04000118 RID: 280
		internal TextBlock textBlock;

		// Token: 0x04000119 RID: 281
		private ToggleButton toggleButton;

		// Token: 0x0400011A RID: 282
		private ListBox listBox;

		// Token: 0x0400011B RID: 283
		private RichTextBox richTextBox;

		// Token: 0x0400011C RID: 284
		private bool _contentLoaded;
	}
}
