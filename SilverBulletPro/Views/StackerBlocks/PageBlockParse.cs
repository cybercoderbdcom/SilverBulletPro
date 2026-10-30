using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using AngleSharp.Text;
using HandyControl.Controls;
using SilverBulletPro.Core;
using SilverBulletPro.Core.Blocks;
using SilverBulletPro.Core.Extensions;
using SilverBulletPro.Extensions;

namespace SilverBulletPro.Views.StackerBlocks
{
	// Token: 0x020000A4 RID: 164
	public class PageBlockParse : Page, IComponentConnector
	{
		// Token: 0x060004FD RID: 1277 RVA: 0x00019B4C File Offset: 0x00017D4C
		public PageBlockParse(BlockParse block)
		{
			this.InitializeComponent();
			this.vm = block;
			base.DataContext = this.vm;
			foreach (string newItem in this.defaultFields)
			{
				this.parseTargetCombobox.Items.Add(newItem);
			}
			foreach (object newItem2 in Enum.GetValues(typeof(ParseType)))
			{
				this.parseTypeComboBox.Items.Add(newItem2);
			}
			this.ApplyInputMode(this.vm.ParseInputMode);
		}

		// Token: 0x060004FE RID: 1278 RVA: 0x00019C50 File Offset: 0x00017E50
		private void LRRTB_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.Key == Key.LeftShift)
				{
					int length = new TextRange(this.LRRTB.Document.ContentStart, this.LRRTB.Selection.Start).Text.Length;
					int length2 = this.LRRTB.Selection.Text.Length;
					int num = length + length2 - 1;
					string text = "";
					string text2 = "";
					int num2 = length;
					while (num2 != 0)
					{
						text = this.LRRTB.GetText()[num2 - 1].ToString() + text;
						num2--;
						if (StringExtension.CountOccurrences(this.LRRTB.GetText(), text) <= 1)
						{
							break;
						}
					}
					num2 = num;
					while (num2 != this.LRRTB.GetText().Length - 1)
					{
						text2 += this.LRRTB.GetText()[num2 + 1].ToString();
						num2++;
						if (StringExtension.CountOccurrences(this.LRRTB.GetText(), text2) <= 1)
						{
							break;
						}
					}
					this.vm.LeftString = text;
					this.vm.RightString = text2;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		// Token: 0x060004FF RID: 1279 RVA: 0x00019DA0 File Offset: 0x00017FA0
		private void ParseTargetInputModeButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				this.ChangeInputMode(true);
			}
			catch
			{
			}
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x00019DCC File Offset: 0x00017FCC
		private void ChangeInputMode(bool backModeSupport = false)
		{
			List<string> list = 115.ToString("g").Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToList<string>();
			int num = list.IndexOf(this.vm.ParseInputMode.ToString());
			if (backModeSupport && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
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
			this.ApplyInputMode(this.vm.ParseInputMode = StringExtensions.ToEnum<InputMode>(list[num], 1));
		}

		// Token: 0x06000501 RID: 1281 RVA: 0x00019E78 File Offset: 0x00018078
		private void ApplyInputMode(InputMode inputMode)
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
				this.parseTargetInputMode.Padding = new Thickness(0.0, 0.0, 5.0, 0.0);
				IconElement.SetWidth(this.parseTargetInputMode, 0.0);
				this.parseTargetInputMode.Content = EnumExtension.GetDescription(inputMode);
			}
			else
			{
				this.parseTargetInputMode.Content = string.Empty;
				this.parseTargetInputMode.Padding = new Thickness(10.0, 0.0, 5.0, 0.0);
				IconElement.SetWidth(this.parseTargetInputMode, 8.5);
			}
			this.SetForeColorByInputMode(inputMode);
		}

		// Token: 0x06000502 RID: 1282 RVA: 0x00019F84 File Offset: 0x00018184
		private void SetForeColorByInputMode(InputMode mode)
		{
			if (mode <= 8)
			{
				if (mode == 2)
				{
					this.parseTargetInputMode.SetResourceReference(Control.ForegroundProperty, "ForegroundRetry");
					return;
				}
				if (mode == 4)
				{
					this.parseTargetInputMode.SetResourceReference(Control.ForegroundProperty, "ForegroundOcrRate");
					return;
				}
				if (mode == 8)
				{
					this.parseTargetInputMode.SetResourceReference(Control.ForegroundProperty, "ForegroundOcrRate");
					return;
				}
			}
			else
			{
				if (mode == 16)
				{
					this.parseTargetInputMode.SetResourceReference(Control.ForegroundProperty, "ForegroundCustom");
					return;
				}
				if (mode == 32)
				{
					this.parseTargetInputMode.SetResourceReference(Control.ForegroundProperty, "ForegroundCustom");
					return;
				}
				if (mode == 64)
				{
					this.parseTargetInputMode.SetResourceReference(Control.ForegroundProperty, "ForegroundGood");
					return;
				}
			}
			this.parseTargetInputMode.SetResourceReference(Control.ForegroundProperty, "ForegroundMain");
		}

		// Token: 0x06000503 RID: 1283 RVA: 0x0001A053 File Offset: 0x00018253
		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			this.AddDefinedVariablesToParseTarget();
		}

		// Token: 0x06000504 RID: 1284 RVA: 0x0001A05C File Offset: 0x0001825C
		private void AddDefinedVariablesToParseTarget()
		{
			try
			{
				object selectedItem = this.parseTargetCombobox.SelectedItem;
				string[] listOfVariables = SvbScriptExtension.GetListOfVariables(this.vm);
				for (int i = this.parseTargetCombobox.Items.Count - 1; i >= this.defaultFields.Length; i--)
				{
					this.parseTargetCombobox.Items.RemoveAt(i);
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
						this.parseTargetCombobox.Items.Add("<" + listOfVariables[num] + ">");
					}
					num++;
				}
				this.parseTargetCombobox.SelectedItem = selectedItem;
			}
			catch
			{
			}
		}

		// Token: 0x06000505 RID: 1285 RVA: 0x0001A13C File Offset: 0x0001833C
		private void VarCapChanged(object sender, RoutedEventArgs e)
		{
			if (this.vm.IsCapture)
			{
				this.vm.CreateEmpty = true;
				return;
			}
			this.vm.CreateEmpty = false;
		}

		// Token: 0x06000506 RID: 1286 RVA: 0x0001A164 File Offset: 0x00018364
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/parsing/pageblockparse.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000507 RID: 1287 RVA: 0x0001A194 File Offset: 0x00018394
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000508 RID: 1288 RVA: 0x0001A1A0 File Offset: 0x000183A0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				((PageBlockParse)target).Loaded += this.Page_Loaded;
				return;
			case 2:
				this.parseTargetInputMode = (Button)target;
				this.parseTargetInputMode.Click += this.ParseTargetInputModeButton_Click;
				return;
			case 3:
				this.parseTargetCombobox = (ComboBox)target;
				return;
			case 4:
				this.parseTypeComboBox = (ComboBox)target;
				return;
			case 5:
				this.typeTabControl = (TabControl)target;
				return;
			case 6:
				this.LRRTB = (RichTextBox)target;
				this.LRRTB.KeyUp += this.LRRTB_KeyUp;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x04000264 RID: 612
		private BlockParse vm;

		// Token: 0x04000265 RID: 613
		private string[] defaultFields = new string[]
		{
			"<SOURCE>",
			"<HEADERS(*)>",
			"<HEADERS{*}>",
			"<COOKIES(*)>",
			"<COOKIES{*}>",
			"<ADDRESS>"
		};

		// Token: 0x04000266 RID: 614
		private Button parseTargetInputMode;

		// Token: 0x04000267 RID: 615
		internal ComboBox parseTargetCombobox;

		// Token: 0x04000268 RID: 616
		internal ComboBox parseTypeComboBox;

		// Token: 0x04000269 RID: 617
		internal TabControl typeTabControl;

		// Token: 0x0400026A RID: 618
		internal RichTextBox LRRTB;

		// Token: 0x0400026B RID: 619
		private bool _contentLoaded;
	}
}
