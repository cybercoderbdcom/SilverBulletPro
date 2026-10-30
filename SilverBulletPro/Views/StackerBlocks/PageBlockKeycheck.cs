using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using AngleSharp.Text;
using HandyControl.Controls;
using SilverBulletPro.Core;
using SilverBulletPro.Core.Blocks;
using SilverBulletPro.Core.Extensions;
using SilverBulletPro.Core.Functions.Conditions;
using SilverBulletPro.Core.Models;
using SilverBulletPro.Extensions;
using SilverBulletPro.ViewModels;

namespace SilverBulletPro.Views.StackerBlocks
{
	// Token: 0x02000048 RID: 72
	public class PageBlockKeycheck : Page, IComponentConnector, IStyleConnector
	{
		// Token: 0x0600034A RID: 842 RVA: 0x000141C0 File Offset: 0x000123C0
		public PageBlockKeycheck(BlockKeycheck block)
		{
			this.InitializeComponent();
			this.vm = new BlockKeycheckViewModel(block);
			base.DataContext = this.vm;
		}

		// Token: 0x0600034B RID: 843 RVA: 0x00014235 File Offset: 0x00012435
		private void AddKeychainButton_Click(object sender, RoutedEventArgs e)
		{
			this.vm.AddKeychain();
		}

		// Token: 0x0600034C RID: 844 RVA: 0x00014242 File Offset: 0x00012442
		private void ClearKeychainsButton_Click(object sender, RoutedEventArgs e)
		{
			if (Alert.Choice("Do you want to delete all keychains?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
			{
				ObservableCollection<KeychainViewModel> keychainList = this.vm.KeychainList;
				if (keychainList == null)
				{
					return;
				}
				keychainList.Clear();
			}
		}

		// Token: 0x0600034D RID: 845 RVA: 0x00014270 File Offset: 0x00012470
		private void keychainTypeCombobox_Loaded(object sender, RoutedEventArgs e)
		{
			KeychainViewModel keychainById = this.vm.GetKeychainById((int)((ComboBox)e.OriginalSource).Tag);
			if (keychainById.TypeInitialized)
			{
				return;
			}
			keychainById.TypeInitialized = true;
			foreach (string newItem in Enum.GetNames(typeof(KeyChain.KeychainType)))
			{
				((ComboBox)e.OriginalSource).Items.Add(newItem);
			}
			((ComboBox)e.OriginalSource).SelectedIndex = keychainById.Type;
		}

		// Token: 0x0600034E RID: 846 RVA: 0x00014300 File Offset: 0x00012500
		private void keychainModeCombobox_Loaded(object sender, RoutedEventArgs e)
		{
			KeychainViewModel keychainById = this.vm.GetKeychainById((int)((ComboBox)e.OriginalSource).Tag);
			if (keychainById.ModeInitialized)
			{
				return;
			}
			keychainById.ModeInitialized = true;
			foreach (string newItem in Enum.GetNames(typeof(KeyChain.KeychainMode)))
			{
				((ComboBox)e.OriginalSource).Items.Add(newItem);
			}
			((ComboBox)e.OriginalSource).SelectedIndex = keychainById.Mode;
		}

		// Token: 0x0600034F RID: 847 RVA: 0x00014390 File Offset: 0x00012590
		private void execPriorityCombobox_Loaded(object sender, RoutedEventArgs e)
		{
			KeychainViewModel keychainById = this.vm.GetKeychainById((int)((ComboBox)e.OriginalSource).Tag);
			if (keychainById.ExecPriorityInitialized)
			{
				return;
			}
			keychainById.ExecPriorityInitialized = true;
			foreach (string newItem in Enum.GetNames(typeof(KeyChain.ExecPriority)))
			{
				((ComboBox)e.OriginalSource).Items.Add(newItem);
			}
			((ComboBox)e.OriginalSource).SelectedIndex = keychainById.ExecPriority;
		}

		// Token: 0x06000350 RID: 848 RVA: 0x0001441D File Offset: 0x0001261D
		private void execPriorityCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			this.vm.GetKeychainById((int)((ComboBox)e.OriginalSource).Tag).ExecPriority = ((ComboBox)e.OriginalSource).SelectedIndex;
		}

		// Token: 0x06000351 RID: 849 RVA: 0x00014454 File Offset: 0x00012654
		private void customTypeCombobox_Loaded(object sender, RoutedEventArgs e)
		{
			KeychainViewModel keychainById = this.vm.GetKeychainById((int)((ComboBox)e.OriginalSource).Tag);
			if (keychainById.CustomTypeInitialized)
			{
				return;
			}
			keychainById.CustomTypeInitialized = true;
			foreach (string newItem in GlobalData.Settings.Environment.GetCustomKeychainNames())
			{
				((ComboBox)e.OriginalSource).Items.Add(newItem);
			}
			if (((ComboBox)e.OriginalSource).Items.IndexOf(keychainById.CustomType) > 0)
			{
				((ComboBox)e.OriginalSource).SelectedValue = keychainById.CustomType;
				return;
			}
			((ComboBox)e.OriginalSource).Text = keychainById.CustomType;
		}

		// Token: 0x06000352 RID: 850 RVA: 0x0001453C File Offset: 0x0001273C
		private void keychainTypeCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			this.vm.GetKeychainById((int)((ComboBox)e.OriginalSource).Tag).Type = ((ComboBox)e.OriginalSource).SelectedIndex;
		}

		// Token: 0x06000353 RID: 851 RVA: 0x00014573 File Offset: 0x00012773
		private void keychainModeCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			this.vm.GetKeychainById((int)((ComboBox)e.OriginalSource).Tag).Mode = ((ComboBox)e.OriginalSource).SelectedIndex;
		}

		// Token: 0x06000354 RID: 852 RVA: 0x000145AA File Offset: 0x000127AA
		private void customTypeCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			this.vm.GetKeychainById((int)((ComboBox)e.OriginalSource).Tag).CustomType = (string)(sender as ComboBox).SelectedItem;
		}

		// Token: 0x06000355 RID: 853 RVA: 0x000145E1 File Offset: 0x000127E1
		private void RemoveKeychainButton_Click(object sender, RoutedEventArgs e)
		{
			this.vm.RemoveKeychainById((int)((Button)e.OriginalSource).Tag);
		}

		// Token: 0x06000356 RID: 854 RVA: 0x00014604 File Offset: 0x00012804
		private void conditionCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			KeyFullId keyFullId = (KeyFullId)((ComboBox)e.OriginalSource).Tag;
			this.vm.GetKeychainById(keyFullId.ParentId).GetKeyById(keyFullId.KeyId).Comparer = ((ComboBox)e.OriginalSource).SelectedIndex;
		}

		// Token: 0x06000357 RID: 855 RVA: 0x00014658 File Offset: 0x00012858
		private void conditionCombobox_Loaded(object sender, RoutedEventArgs e)
		{
			KeyFullId keyFullId = (KeyFullId)((ComboBox)e.OriginalSource).Tag;
			if (keyFullId.ConditionInitialized)
			{
				return;
			}
			keyFullId.ConditionInitialized = true;
			foreach (string newItem in Enum.GetNames(typeof(Comparer)))
			{
				((ComboBox)e.OriginalSource).Items.Add(newItem);
			}
			((ComboBox)e.OriginalSource).SelectedIndex = this.vm.GetKeychainById(keyFullId.ParentId).GetKeyById(keyFullId.KeyId).Comparer;
		}

		// Token: 0x06000358 RID: 856 RVA: 0x000146F8 File Offset: 0x000128F8
		private void leftTermCombobox_Loaded(object sender, RoutedEventArgs e)
		{
			KeyFullId keyFullId = (KeyFullId)((ComboBox)e.OriginalSource).Tag;
			if (keyFullId.LeftTermInitialized)
			{
				this.AddDefinedVariablesToBox((ComboBox)e.OriginalSource);
				return;
			}
			keyFullId.LeftTermInitialized = true;
			foreach (string newItem in this.defaultFields)
			{
				((ComboBox)e.OriginalSource).Items.Add(newItem);
			}
			try
			{
				((ComboBox)e.OriginalSource).SelectedValue = this.vm.GetKeychainById(keyFullId.ParentId).GetKeyById(keyFullId.KeyId).LeftTerm;
			}
			catch
			{
				((ComboBox)e.OriginalSource).SelectedIndex = 0;
			}
			this.AddDefinedVariablesToBox((ComboBox)e.OriginalSource);
		}

		// Token: 0x06000359 RID: 857 RVA: 0x000147D8 File Offset: 0x000129D8
		private void AddKeyButton_Click(object sender, RoutedEventArgs e)
		{
			this.vm.GetKeychainById((int)((Button)e.OriginalSource).Tag).AddKey();
		}

		// Token: 0x0600035A RID: 858 RVA: 0x00014800 File Offset: 0x00012A00
		private void RemoveKeyButton_Click(object sender, RoutedEventArgs e)
		{
			KeyFullId keyFullId = (KeyFullId)((Button)e.OriginalSource).Tag;
			this.vm.GetKeychainById(keyFullId.ParentId).RemoveKeyById(keyFullId.KeyId);
		}

		// Token: 0x0600035B RID: 859 RVA: 0x00014840 File Offset: 0x00012A40
		private void customTypeCombobox_TextChanged(object sender, TextChangedEventArgs e)
		{
			ComboBox comboBox = sender as ComboBox;
			if (comboBox.Items.Count == 0)
			{
				return;
			}
			int id = (int)comboBox.Tag;
			this.vm.GetKeychainById(id).CustomType = comboBox.Text;
		}

		// Token: 0x0600035C RID: 860 RVA: 0x00014888 File Offset: 0x00012A88
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

		// Token: 0x0600035D RID: 861 RVA: 0x000148E0 File Offset: 0x00012AE0
		private void AddDefinedVariablesToBox(ComboBox comboBox)
		{
			try
			{
				object selectedItem = comboBox.SelectedItem;
				string[] listOfVariables = SvbScriptExtension.GetListOfVariables(this.vm.Block);
				for (int i = comboBox.Items.Count - 1; i >= this.defaultFields.Length; i--)
				{
					comboBox.Items.RemoveAt(i);
				}
				int num = 0;
				for (;;)
				{
					int num2 = num;
					int? num3 = (listOfVariables != null) ? new int?(listOfVariables.Length) : null;
					if (!(num2 < num3.GetValueOrDefault() & num3 != null))
					{
						break;
					}
					if (!string.IsNullOrWhiteSpace(listOfVariables[num]))
					{
						comboBox.Items.Add("<" + listOfVariables[num] + ">");
					}
					num++;
				}
				comboBox.SelectedItem = selectedItem;
			}
			catch
			{
			}
		}

		// Token: 0x0600035E RID: 862 RVA: 0x000149AC File Offset: 0x00012BAC
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

		// Token: 0x0600035F RID: 863 RVA: 0x000149F0 File Offset: 0x00012BF0
		private void InputModeButton_Click(object sender, RoutedEventArgs e)
		{
			KeyFullId keyFullId = (KeyFullId)((Button)e.OriginalSource).Tag;
			KeychainViewModel keychainById = this.vm.GetKeychainById(keyFullId.ParentId);
			InputMode inputMode = 115;
			List<string> list = inputMode.ToString("g").Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToList<string>();
			int num = list.IndexOf(keychainById.GetKeyById(keyFullId.KeyId).RightTermInputMode.ToString());
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
			this.ApplyInputMode(sender as Button, keychainById.GetKeyById(keyFullId.KeyId).RightTermInputMode = StringExtensions.ToEnum<InputMode>(list[num], 1));
		}

		// Token: 0x06000360 RID: 864 RVA: 0x00014AE0 File Offset: 0x00012CE0
		private void Button_Loaded(object sender, RoutedEventArgs e)
		{
			Button inputModeButton = sender as Button;
			KeyFullId keyFullId = (KeyFullId)((Button)e.OriginalSource).Tag;
			KeychainViewModel keychainById = this.vm.GetKeychainById(keyFullId.ParentId);
			this.ApplyInputMode(inputModeButton, keychainById.GetKeyById(keyFullId.KeyId).RightTermInputMode);
		}

		// Token: 0x06000361 RID: 865 RVA: 0x00014B34 File Offset: 0x00012D34
		private void ApplyInputMode(Button inputModeButton, InputMode inputMode)
		{
			if (inputMode != 1)
			{
				if (inputMode == 4 || inputMode == 8)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(17, 1);
					defaultInterpolatedStringHandler.AppendFormatted<InputMode>(inputMode);
					defaultInterpolatedStringHandler.AppendLiteral(" is not supported");
					throw new NotSupportedException(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				inputModeButton.Padding = new Thickness(0.0, 0.0, 5.0, 0.0);
				IconElement.SetWidth(inputModeButton, 0.0);
				inputModeButton.Content = EnumExtension.GetDescription(inputMode);
			}
			else
			{
				inputModeButton.Content = string.Empty;
				inputModeButton.Padding = new Thickness(10.0, 0.0, 5.0, 0.0);
				IconElement.SetWidth(inputModeButton, 8.5);
			}
			this.SetForeColorByInputMode(inputModeButton, inputMode);
		}

		// Token: 0x06000362 RID: 866 RVA: 0x00014C1C File Offset: 0x00012E1C
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

		// Token: 0x06000363 RID: 867 RVA: 0x00014CC4 File Offset: 0x00012EC4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/conditions/pageblockkeycheck.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000364 RID: 868 RVA: 0x00014CF4 File Offset: 0x00012EF4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				((PageBlockKeycheck)target).Loaded += this.Page_Loaded;
				((PageBlockKeycheck)target).Unloaded += this.Page_Unloaded;
				return;
			case 2:
				((Button)target).Click += this.AddKeychainButton_Click;
				return;
			case 3:
				((Button)target).Click += this.ClearKeychainsButton_Click;
				return;
			case 4:
				this.keychainsControl = (ItemsControl)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x06000365 RID: 869 RVA: 0x00014D90 File Offset: 0x00012F90
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IStyleConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 5:
				((Button)target).Click += this.RemoveKeychainButton_Click;
				return;
			case 6:
				((ComboBox)target).Loaded += this.keychainTypeCombobox_Loaded;
				((ComboBox)target).SelectionChanged += this.keychainTypeCombobox_SelectionChanged;
				return;
			case 7:
				((ComboBox)target).Loaded += this.keychainModeCombobox_Loaded;
				((ComboBox)target).SelectionChanged += this.keychainModeCombobox_SelectionChanged;
				return;
			case 8:
				((ComboBox)target).Loaded += this.execPriorityCombobox_Loaded;
				((ComboBox)target).SelectionChanged += this.execPriorityCombobox_SelectionChanged;
				return;
			case 9:
				((ComboBox)target).Loaded += this.customTypeCombobox_Loaded;
				((ComboBox)target).SelectionChanged += this.customTypeCombobox_SelectionChanged;
				((ComboBox)target).AddHandler(TextBoxBase.TextChangedEvent, new TextChangedEventHandler(this.customTypeCombobox_TextChanged));
				return;
			case 10:
				((Button)target).Click += this.AddKeyButton_Click;
				return;
			case 11:
				((Button)target).Click += this.RemoveKeyButton_Click;
				return;
			case 12:
				((ComboBox)target).Loaded += this.leftTermCombobox_Loaded;
				return;
			case 13:
				((ComboBox)target).Loaded += this.conditionCombobox_Loaded;
				((ComboBox)target).SelectionChanged += this.conditionCombobox_SelectionChanged;
				return;
			case 14:
				((Button)target).Click += this.InputModeButton_Click;
				((Button)target).Loaded += this.Button_Loaded;
				return;
			default:
				return;
			}
		}

		// Token: 0x0400019E RID: 414
		public BlockKeycheckViewModel vm;

		// Token: 0x0400019F RID: 415
		private string[] defaultFields = new string[]
		{
			"<SOURCE>",
			"<HEADERS(*)>",
			"<HEADERS{*}>",
			"<COOKIES(*)>",
			"<COOKIES{*}>",
			"<RESPONSECODE>",
			"<ADDRESS>"
		};

		// Token: 0x040001A0 RID: 416
		internal ItemsControl keychainsControl;

		// Token: 0x040001A1 RID: 417
		private bool _contentLoaded;
	}
}
