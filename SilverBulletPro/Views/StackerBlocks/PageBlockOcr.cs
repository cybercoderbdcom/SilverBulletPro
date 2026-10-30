using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using AngleSharp.Text;
using HandyControl.Controls;
using SilverBulletPro.Core;
using SilverBulletPro.Core.Blocks;
using SilverBulletPro.Core.Extensions;
using SilverBulletPro.Core.Functions.Requests;
using SilverBulletPro.Core.Models;
using SilverBulletPro.Extensions;
using SilverBulletPro.Views.UserControls;
using TesseractOCR.Enums;

namespace SilverBulletPro.Views.StackerBlocks
{
	// Token: 0x0200014A RID: 330
	public class PageBlockOcr : Page, IComponentConnector, IStyleConnector
	{
		// Token: 0x060007BE RID: 1982 RVA: 0x00022000 File Offset: 0x00020200
		public PageBlockOcr(BlockOcr block)
		{
			this.InitializeComponent();
			this.vm = block;
			base.DataContext = block;
			this.AddHttpVersions();
			this.httpVersionComboBox.SelectedItem = this.vm.HttpVersion.ToString();
			foreach (object obj in Enum.GetValues(typeof(HttpRequestLibrary)))
			{
				HttpRequestLibrary httpRequestLibrary = (HttpRequestLibrary)obj;
				this.httpLibComboBox.Items.Add(EnumExtension.GetDescription(httpRequestLibrary));
			}
			this.httpLibComboBox.SelectedIndex = this.vm.HttpLibrary;
			foreach (object obj2 in Enum.GetValues(typeof(OcrLibrary)))
			{
				OcrLibrary ocrLibrary = (OcrLibrary)obj2;
				this.ocrLibComboBox.Items.Add(ocrLibrary);
			}
			foreach (object obj3 in Enum.GetValues(typeof(EngineMode)))
			{
				EngineMode engineMode = (EngineMode)obj3;
				this.engineComboBox.Items.Add(engineMode);
			}
			foreach (object obj4 in Enum.GetValues(typeof(PageSegMode)))
			{
				PageSegMode pageSegMode = (PageSegMode)obj4;
				this.pageSegComboBox.Items.Add(pageSegMode);
			}
			this.vm.PixelFormats.Add("Default");
			this.vm.PixelFormats.AddRange(Enum.GetNames(typeof(PixelFormat)));
			foreach (object obj5 in Enum.GetValues(typeof(ProxyUsage)))
			{
				ProxyUsage proxyUsage = (ProxyUsage)obj5;
				this.proxyUsageComboBox.Items.Add(proxyUsage);
			}
			foreach (object obj6 in Enum.GetValues(typeof(SecurityProtocol)))
			{
				SecurityProtocol securityProtocol = (SecurityProtocol)obj6;
				this.securityProtocolComboBox.Items.Add(securityProtocol);
			}
			if (block.SecurityProtocol.ToString().Contains(","))
			{
				this.securityProtocolComboBox.Text = block.SecurityProtocol.ToString().Replace(" ", string.Empty);
			}
			foreach (KeyValuePair<string, object> keyValuePair in BlockOcr.ImageFilters)
			{
				this.filterComboBox.Items.Add(keyValuePair.Value);
			}
			this.rtCustomCookies.AddItems(block.CustomCookies);
			this.rtCustomHeaders.AddItems(block.CustomHeaders);
			this.rtTranslate.AddItems(block.Translations);
			this.regexReplaceComboBox.Items.Add("[^\\d]");
			this.regexReplaceComboBox.Items.Add("[0-9]");
			foreach (object obj7 in Enum.GetValues(typeof(RegexOptions)))
			{
				RegexOptions regexOptions = (RegexOptions)obj7;
				this.regexOptionComboBox.Items.Add(regexOptions);
			}
			if (block.RegexOptions.ToString().Contains(","))
			{
				this.regexOptionComboBox.Text = block.RegexOptions.ToString().Replace(" ", string.Empty);
			}
		}

		// Token: 0x060007BF RID: 1983 RVA: 0x000224A8 File Offset: 0x000206A8
		private void AddHttpVersions()
		{
			try
			{
				FieldInfo[] fields = typeof(HttpVersion).GetFields();
				for (int i = 0; i < fields.Length; i++)
				{
					if (fields[i].Name.StartsWith("Version"))
					{
						this.httpVersionComboBox.Items.Add(((Version)fields[i].GetValue(null)).ToString());
					}
				}
			}
			catch
			{
				this.httpVersionComboBox.Items.Add("1.0");
				this.httpVersionComboBox.Items.Add("1.1");
				this.httpVersionComboBox.Items.Add("2.0");
				this.httpVersionComboBox.Items.Add("3.0");
			}
		}

		// Token: 0x060007C0 RID: 1984 RVA: 0x00022578 File Offset: 0x00020778
		private void LoadTessdata()
		{
			try
			{
				if (!Directory.Exists(".\\" + Constants.TessdataFolder))
				{
					Directory.CreateDirectory(".\\" + Constants.TessdataFolder);
				}
				foreach (FileInfo fileInfo in new DirectoryInfo(".\\" + Constants.TessdataFolder).GetFiles("."))
				{
					if (fileInfo.Name.Contains(".") && !this.vm.Languages.Contains(fileInfo.Name.Split('.', StringSplitOptions.None)[0]))
					{
						this.vm.Languages.Add(fileInfo.Name.Split(new char[]
						{
							'.'
						})[0]);
					}
				}
				try
				{
					this.vm.Languages = new ObservableCollection<string>(this.vm.Languages.Distinct<string>());
				}
				catch
				{
				}
			}
			catch (Exception)
			{
				Alert.Error("Missing folder \"tessdata\"! Please go make one and put your language files in it!", "NOTICE", false);
			}
		}

		// Token: 0x060007C1 RID: 1985 RVA: 0x00022694 File Offset: 0x00020894
		private void PixelFormatComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				this.vm.PixelFormat = this.pixelFormatComboBox.SelectedItem.ToString();
			}
			catch
			{
			}
		}

		// Token: 0x060007C2 RID: 1986 RVA: 0x000226D4 File Offset: 0x000208D4
		private void SecurityProtocolCombobox_LostFocus(object sender, RoutedEventArgs e)
		{
			try
			{
				this.vm.SecurityProtocol = StringExtensions.ToEnum<SecurityProtocol>(this.securityProtocolComboBox.Text, 0);
			}
			catch
			{
			}
		}

		// Token: 0x060007C3 RID: 1987 RVA: 0x00022714 File Offset: 0x00020914
		private void ProxyUsageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				this.proxyUsageComboBox.ToolTip = EnumExtension.GetDescription((ProxyUsage)this.proxyUsageComboBox.SelectedItem);
			}
			catch
			{
			}
		}

		// Token: 0x060007C4 RID: 1988 RVA: 0x0002275C File Offset: 0x0002095C
		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			this.LoadTessdata();
		}

		// Token: 0x060007C5 RID: 1989 RVA: 0x00022764 File Offset: 0x00020964
		private void AddFilter_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (!string.IsNullOrWhiteSpace(this.filterComboBox.Text))
				{
					this.vm.Filters.Add(new ImageFilter(this.filterComboBox.Text, 2));
					this.filterLB.Items.Add(this.filterComboBox.Text);
				}
			}
			catch
			{
			}
		}

		// Token: 0x060007C6 RID: 1990 RVA: 0x000227D8 File Offset: 0x000209D8
		private void TextInputBox_InputModeChanged(object sender, RoutedEventArgs e)
		{
			try
			{
				this.gridHttp.IsEnabled = (this.secProtoPanel.IsEnabled = (this.proxyUsagePanel.IsEnabled = (this.requestTimeoutNumStr.IsEnabled = (this.rtCustomCookies.IsEnabled = (this.rtCustomHeaders.IsEnabled = (this.vm.CaptchaInputMode != 4))))));
				this.captchaTextInputBox.TextInputBoxAllowDrop = (this.vm.CaptchaInputMode == 4);
			}
			catch
			{
			}
		}

		// Token: 0x060007C7 RID: 1991 RVA: 0x00022878 File Offset: 0x00020A78
		private void Captcha_Drop(object sender, DragEventArgs e)
		{
			try
			{
				if (e.Data.GetDataPresent(DataFormats.FileDrop) && this.vm.CaptchaInputMode == 4)
				{
					string[] array = e.Data.GetData(DataFormats.FileDrop) as string[];
					if (array != null && array.Length != 0 && File.Exists(array[0]) && ImageExtension.AllowedExtensions.Contains(Path.GetExtension(array[0]).ToUpperInvariant()))
					{
						this.vm.Captcha = ImageExtension.ToBase64(array[0]);
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x060007C8 RID: 1992 RVA: 0x00022910 File Offset: 0x00020B10
		private void Captcha_PreviewDragOver(object sender, DragEventArgs e)
		{
			e.Handled = this.captchaTextInputBox.TextInputBoxAllowDrop;
		}

		// Token: 0x060007C9 RID: 1993 RVA: 0x00022924 File Offset: 0x00020B24
		private void HttpLibComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				this.vm.HttpLibrary = this.httpLibComboBox.SelectedIndex;
			}
			catch
			{
			}
			try
			{
				int selectedIndex = this.httpVersionComboBox.SelectedIndex;
				HttpRequestLibrary httpLibrary = this.vm.HttpLibrary;
				if (httpLibrary != null)
				{
					if (httpLibrary != 1)
					{
						this.httpVersionComboBox.Items.Clear();
						this.AddHttpVersions();
					}
					else
					{
						this.httpVersionComboBox.Items.Clear();
						this.AddHttpVersions();
					}
				}
				else
				{
					this.httpVersionComboBox.Items.Clear();
					this.httpVersionComboBox.Items.Add("1.0");
					this.httpVersionComboBox.Items.Add("1.1");
				}
				this.httpVersionComboBox.SelectedIndex = selectedIndex;
				if (this.httpVersionComboBox.SelectedIndex == -1)
				{
					this.httpVersionComboBox.SelectedIndex = 1;
				}
			}
			catch
			{
			}
		}

		// Token: 0x060007CA RID: 1994 RVA: 0x00022A24 File Offset: 0x00020C24
		private void HttpVersionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				this.vm.HttpVersion = Version.Parse(this.httpVersionComboBox.SelectedItem as string);
			}
			catch
			{
				this.vm.HttpVersion = Version.Parse("1.1");
			}
		}

		// Token: 0x060007CB RID: 1995 RVA: 0x00022A7C File Offset: 0x00020C7C
		private void RegexOptionComboBox_LostFocus(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(this.regexOptionComboBox.Text))
			{
				return;
			}
			try
			{
				this.vm.RegexOptions = StringExtensions.ToEnum<RegexOptions>(this.regexOptionComboBox.Text, RegexOptions.Singleline);
			}
			catch
			{
			}
		}

		// Token: 0x060007CC RID: 1996 RVA: 0x00022AD0 File Offset: 0x00020CD0
		private void FilterComboBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				this.AddFilter_Click(sender, e);
			}
		}

		// Token: 0x060007CD RID: 1997 RVA: 0x00022AE4 File Offset: 0x00020CE4
		private void ListBoxItem_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				this.ListBoxItem_LostFocus(sender, e);
				return;
			}
			if (e.KeyboardDevice.Modifiers == ModifierKeys.Control)
			{
				if (e.Key == Key.V)
				{
					this.PasteFilter_Click(sender, e);
					return;
				}
				if (e.Key == Key.C)
				{
					this.CopyFilter_Click(sender, e);
					return;
				}
			}
			else if (e.Key == Key.Delete)
			{
				this.RemoveFilter_Click(sender, e);
			}
		}

		// Token: 0x060007CE RID: 1998 RVA: 0x00022B4C File Offset: 0x00020D4C
		private void CopyFilter_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				foreach (object obj in this.filterLB.SelectedItems)
				{
					stringBuilder.AppendLine(obj.ToString());
				}
				Clipboard.SetText(stringBuilder.ToString());
			}
			catch
			{
			}
		}

		// Token: 0x060007CF RID: 1999 RVA: 0x00022BD0 File Offset: 0x00020DD0
		private void PasteFilter_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				string text = Clipboard.GetText();
				if (!string.IsNullOrWhiteSpace(text) && !(!text.Contains("(") | !text.Contains(")")))
				{
					this.vm.Filters.Add(new ImageFilter(text, 2));
				}
			}
			catch
			{
			}
		}

		// Token: 0x060007D0 RID: 2000 RVA: 0x00022C38 File Offset: 0x00020E38
		private void RemoveFilter_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				this.vm.Filters.RemoveAt(this.filterLB.SelectedIndex);
			}
			catch
			{
			}
		}

		// Token: 0x060007D1 RID: 2001 RVA: 0x00022C78 File Offset: 0x00020E78
		private void FilterLB_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.Key == Key.Delete)
				{
					this.RemoveFilter_Click(sender, e);
				}
			}
			catch
			{
			}
		}

		// Token: 0x060007D2 RID: 2002 RVA: 0x00022CAC File Offset: 0x00020EAC
		private void CloneFilter_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				string text = this.filterLB.SelectedItem.ToString();
				if (!string.IsNullOrWhiteSpace(text))
				{
					this.vm.Filters.Insert(this.filterLB.SelectedIndex + 1, new ImageFilter(text, 2));
				}
			}
			catch
			{
			}
		}

		// Token: 0x060007D3 RID: 2003 RVA: 0x00022D10 File Offset: 0x00020F10
		private void DisableFilter_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (!string.IsNullOrWhiteSpace(this.filterLB.SelectedItem.ToString()))
				{
					int selectedIndex = this.filterLB.SelectedIndex;
					this.vm.Filters[selectedIndex].Disable = !this.vm.Filters[selectedIndex].Disable;
					this.filterLB.SelectedIndex = selectedIndex;
					this.filterLB.Items.Refresh();
				}
			}
			catch
			{
			}
		}

		// Token: 0x060007D4 RID: 2004 RVA: 0x00022DA8 File Offset: 0x00020FA8
		private void FilterMoveUp_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (!string.IsNullOrWhiteSpace(this.filterLB.SelectedItem.ToString()) && this.filterLB.Items.Count != 1)
				{
					int selectedIndex = this.filterLB.SelectedIndex;
					this.vm.Filters.Move(selectedIndex, selectedIndex - 1);
					this.filterLB.SelectedIndex = selectedIndex - 1;
				}
			}
			catch
			{
			}
		}

		// Token: 0x060007D5 RID: 2005 RVA: 0x00022E24 File Offset: 0x00021024
		private void FilterMoveDown_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				string text = this.filterLB.SelectedItem.ToString();
				if (!string.IsNullOrWhiteSpace(text) && this.filterLB.Items.Count != 1)
				{
					int selectedIndex = this.filterLB.SelectedIndex;
					this.vm.Filters.RemoveAt(selectedIndex);
					this.vm.Filters.Insert(selectedIndex + 1, new ImageFilter(text, 2));
					this.filterLB.SelectedIndex = selectedIndex + 1;
				}
			}
			catch
			{
			}
		}

		// Token: 0x060007D6 RID: 2006 RVA: 0x00022EBC File Offset: 0x000210BC
		private void ClearFilters_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (Alert.Choice("Are you sure you want to delete all filters?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
				{
					this.vm.Filters.Clear();
				}
			}
			catch
			{
			}
		}

		// Token: 0x060007D7 RID: 2007 RVA: 0x00022F08 File Offset: 0x00021108
		private void ListBoxItem_LostFocus(object sender, RoutedEventArgs e)
		{
			try
			{
				int selectedIndex = this.filterLB.SelectedIndex;
				if (this.filterLB.SelectedIndex != -1)
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
							this.vm.Filters[selectedIndex] = new ImageFilter(textBox.Text, this.vm.Filters[selectedIndex].InputMode);
							this.filterLB.SelectedIndex = -1;
							this.filterLB.SelectedIndex = selectedIndex;
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x060007D8 RID: 2008 RVA: 0x00022FEC File Offset: 0x000211EC
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

		// Token: 0x060007D9 RID: 2009 RVA: 0x0002303B File Offset: 0x0002123B
		private void ChangeModeButton_MouseLeave(object sender, MouseEventArgs e)
		{
			this.canEdit = true;
		}

		// Token: 0x060007DA RID: 2010 RVA: 0x00023044 File Offset: 0x00021244
		private void ChangeModeButton_MouseEnter(object sender, MouseEventArgs e)
		{
			this.canEdit = false;
		}

		// Token: 0x060007DB RID: 2011 RVA: 0x00023050 File Offset: 0x00021250
		private void InputModeButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				InputMode inputMode = (((FrameworkElement)sender).Tag as ImageFilter).InputMode;
				List<string> list = 115.ToString("g").Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToList<string>();
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
				(((FrameworkElement)sender).Tag as ImageFilter).InputMode = inputMode;
			}
			catch
			{
			}
		}

		// Token: 0x060007DC RID: 2012 RVA: 0x00023128 File Offset: 0x00021328
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

		// Token: 0x060007DD RID: 2013 RVA: 0x000231DB File Offset: 0x000213DB
		private void Button_Initialized(object sender, EventArgs e)
		{
			this.ApplyInputMode(sender as Button, (((FrameworkElement)sender).Tag as ImageFilter).InputMode);
		}

		// Token: 0x060007DE RID: 2014 RVA: 0x00023200 File Offset: 0x00021400
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

		// Token: 0x060007DF RID: 2015 RVA: 0x000232A8 File Offset: 0x000214A8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/solvers/pageblockocr.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060007E0 RID: 2016 RVA: 0x000232D8 File Offset: 0x000214D8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060007E1 RID: 2017 RVA: 0x000232E4 File Offset: 0x000214E4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				((PageBlockOcr)target).Loaded += this.Page_Loaded;
				return;
			case 2:
				this.captchaTextInputBox = (TextInputBox)target;
				return;
			case 3:
				this.langComboBox = (ComboBox)target;
				return;
			case 4:
				this.gridHttp = (Grid)target;
				return;
			case 5:
				this.httpLibComboBox = (ComboBox)target;
				this.httpLibComboBox.SelectionChanged += this.HttpLibComboBox_SelectionChanged;
				return;
			case 6:
				this.httpVersionComboBox = (ComboBox)target;
				this.httpVersionComboBox.SelectionChanged += this.HttpVersionComboBox_SelectionChanged;
				return;
			case 7:
				this.ocrLibComboBox = (ComboBox)target;
				return;
			case 8:
				this.engineComboBox = (ComboBox)target;
				return;
			case 9:
				this.pageSegComboBox = (ComboBox)target;
				return;
			case 10:
				this.pixelFormatComboBox = (ComboBox)target;
				this.pixelFormatComboBox.SelectionChanged += this.PixelFormatComboBox_SelectionChanged;
				return;
			case 11:
				this.secProtoPanel = (DockPanel)target;
				return;
			case 12:
				this.securityProtocolComboBox = (ComboBox)target;
				this.securityProtocolComboBox.LostFocus += this.SecurityProtocolCombobox_LostFocus;
				return;
			case 13:
				this.proxyUsagePanel = (DockPanel)target;
				return;
			case 14:
				this.proxyUsageComboBox = (ComboBox)target;
				this.proxyUsageComboBox.SelectionChanged += this.ProxyUsageComboBox_SelectionChanged;
				return;
			case 15:
				this.requestTimeoutNumStr = (NumStrInputBox)target;
				return;
			case 16:
				this.filterComboBox = (ComboBox)target;
				this.filterComboBox.KeyDown += this.FilterComboBox_KeyDown;
				return;
			case 17:
				((Button)target).Click += this.AddFilter_Click;
				return;
			case 18:
				this.filterLB = (ListBox)target;
				this.filterLB.KeyDown += this.FilterLB_KeyDown;
				return;
			case 24:
				((MenuItem)target).Click += this.CopyFilter_Click;
				return;
			case 25:
				((MenuItem)target).Click += this.PasteFilter_Click;
				return;
			case 26:
				((MenuItem)target).Click += this.RemoveFilter_Click;
				return;
			case 27:
				((Button)target).Click += this.CloneFilter_Click;
				return;
			case 28:
				((Button)target).Click += this.DisableFilter_Click;
				return;
			case 29:
				((Button)target).Click += this.FilterMoveUp_Click;
				return;
			case 30:
				((Button)target).Click += this.FilterMoveDown_Click;
				return;
			case 31:
				((Button)target).Click += this.RemoveFilter_Click;
				return;
			case 32:
				((Button)target).Click += this.ClearFilters_Click;
				return;
			case 33:
				this.filterGroupBox = (GroupBox)target;
				return;
			case 34:
				this.rtCustomCookies = (RichTextInputBox)target;
				return;
			case 35:
				this.rtCustomHeaders = (RichTextInputBox)target;
				return;
			case 36:
				this.rtTranslate = (RichTextInputBox)target;
				return;
			case 37:
				this.regexReplaceComboBox = (ComboBox)target;
				return;
			case 38:
				this.regexOptionComboBox = (ComboBox)target;
				this.regexOptionComboBox.LostFocus += this.RegexOptionComboBox_LostFocus;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x060007E2 RID: 2018 RVA: 0x0002367C File Offset: 0x0002187C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IStyleConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 19:
			{
				EventSetter eventSetter = new EventSetter();
				eventSetter.Event = UIElement.LostFocusEvent;
				eventSetter.Handler = new RoutedEventHandler(this.ListBoxItem_LostFocus);
				((Style)target).Setters.Add(eventSetter);
				return;
			}
			case 20:
				((Grid)target).PreviewMouseLeftButtonDown += this.ListBoxItem_MouseDoubleClick;
				return;
			case 21:
				((TextBlock)target).PreviewMouseLeftButtonDown += this.ListBoxItem_MouseDoubleClick;
				return;
			case 22:
				((TextBox)target).KeyDown += this.ListBoxItem_KeyDown;
				((TextBox)target).LostFocus += this.ListBoxItem_LostFocus;
				return;
			case 23:
				((Button)target).Click += this.InputModeButton_Click;
				((Button)target).Initialized += this.Button_Initialized;
				((Button)target).MouseEnter += this.ChangeModeButton_MouseEnter;
				((Button)target).MouseLeave += this.ChangeModeButton_MouseLeave;
				return;
			default:
				return;
			}
		}

		// Token: 0x04000395 RID: 917
		private BlockOcr vm;

		// Token: 0x04000396 RID: 918
		private TextBox tmpEditBox;

		// Token: 0x04000397 RID: 919
		private bool canEdit = true;

		// Token: 0x04000398 RID: 920
		internal TextInputBox captchaTextInputBox;

		// Token: 0x04000399 RID: 921
		internal ComboBox langComboBox;

		// Token: 0x0400039A RID: 922
		internal Grid gridHttp;

		// Token: 0x0400039B RID: 923
		internal ComboBox httpLibComboBox;

		// Token: 0x0400039C RID: 924
		internal ComboBox httpVersionComboBox;

		// Token: 0x0400039D RID: 925
		internal ComboBox ocrLibComboBox;

		// Token: 0x0400039E RID: 926
		internal ComboBox engineComboBox;

		// Token: 0x0400039F RID: 927
		internal ComboBox pageSegComboBox;

		// Token: 0x040003A0 RID: 928
		internal ComboBox pixelFormatComboBox;

		// Token: 0x040003A1 RID: 929
		internal DockPanel secProtoPanel;

		// Token: 0x040003A2 RID: 930
		internal ComboBox securityProtocolComboBox;

		// Token: 0x040003A3 RID: 931
		internal DockPanel proxyUsagePanel;

		// Token: 0x040003A4 RID: 932
		internal ComboBox proxyUsageComboBox;

		// Token: 0x040003A5 RID: 933
		internal NumStrInputBox requestTimeoutNumStr;

		// Token: 0x040003A6 RID: 934
		internal ComboBox filterComboBox;

		// Token: 0x040003A7 RID: 935
		internal ListBox filterLB;

		// Token: 0x040003A8 RID: 936
		internal GroupBox filterGroupBox;

		// Token: 0x040003A9 RID: 937
		internal RichTextInputBox rtCustomCookies;

		// Token: 0x040003AA RID: 938
		internal RichTextInputBox rtCustomHeaders;

		// Token: 0x040003AB RID: 939
		internal RichTextInputBox rtTranslate;

		// Token: 0x040003AC RID: 940
		internal ComboBox regexReplaceComboBox;

		// Token: 0x040003AD RID: 941
		internal ComboBox regexOptionComboBox;

		// Token: 0x040003AE RID: 942
		private bool _contentLoaded;
	}
}
