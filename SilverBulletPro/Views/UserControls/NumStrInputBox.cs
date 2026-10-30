using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using AngleSharp.Text;
using HandyControl.Controls;
using SilverBulletPro.Core;
using SilverBulletPro.Core.Extensions;

namespace SilverBulletPro.Views.UserControls
{
	// Token: 0x02000035 RID: 53
	public class NumStrInputBox : UserControl, IComponentConnector
	{
		// Token: 0x060001E3 RID: 483 RVA: 0x0000E069 File Offset: 0x0000C269
		public NumStrInputBox()
		{
			this.InitializeComponent();
			this.initialized = false;
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x060001E4 RID: 484 RVA: 0x0000E07E File Offset: 0x0000C27E
		// (set) Token: 0x060001E5 RID: 485 RVA: 0x0000E090 File Offset: 0x0000C290
		public int DecimalPlaces
		{
			get
			{
				return (int)base.GetValue(NumStrInputBox.DecimalPlacesProperty);
			}
			set
			{
				base.SetValue(NumStrInputBox.DecimalPlacesProperty, value);
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060001E6 RID: 486 RVA: 0x0000E0A3 File Offset: 0x0000C2A3
		// (set) Token: 0x060001E7 RID: 487 RVA: 0x0000E0B5 File Offset: 0x0000C2B5
		public double Minimum
		{
			get
			{
				return (double)base.GetValue(NumStrInputBox.MinimumProperty);
			}
			set
			{
				base.SetValue(NumStrInputBox.MinimumProperty, value);
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x060001E8 RID: 488 RVA: 0x0000E0C8 File Offset: 0x0000C2C8
		// (set) Token: 0x060001E9 RID: 489 RVA: 0x0000E0DA File Offset: 0x0000C2DA
		public double Maximum
		{
			get
			{
				return (double)base.GetValue(NumStrInputBox.MaximumProperty);
			}
			set
			{
				base.SetValue(NumStrInputBox.MaximumProperty, value);
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x060001EA RID: 490 RVA: 0x0000E0ED File Offset: 0x0000C2ED
		// (set) Token: 0x060001EB RID: 491 RVA: 0x0000E0FF File Offset: 0x0000C2FF
		public string ValueFormat
		{
			get
			{
				return (string)base.GetValue(NumStrInputBox.ValueFormatProperty);
			}
			set
			{
				base.SetValue(NumStrInputBox.ValueFormatProperty, value);
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x060001EC RID: 492 RVA: 0x0000E10D File Offset: 0x0000C30D
		// (set) Token: 0x060001ED RID: 493 RVA: 0x0000E11F File Offset: 0x0000C31F
		public double NumericValue
		{
			get
			{
				return (double)base.GetValue(NumStrInputBox.NumericValueProperty);
			}
			set
			{
				base.SetValue(NumStrInputBox.NumericValueProperty, value);
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x060001EE RID: 494 RVA: 0x0000E132 File Offset: 0x0000C332
		// (set) Token: 0x060001EF RID: 495 RVA: 0x0000E144 File Offset: 0x0000C344
		public InputMode? ModesOfInput
		{
			get
			{
				return (InputMode?)base.GetValue(NumStrInputBox.ModesOfInputProperty);
			}
			set
			{
				base.SetValue(NumStrInputBox.ModesOfInputProperty, value);
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060001F0 RID: 496 RVA: 0x0000E157 File Offset: 0x0000C357
		// (set) Token: 0x060001F1 RID: 497 RVA: 0x0000E169 File Offset: 0x0000C369
		public InputMode InputMode
		{
			get
			{
				return (InputMode)base.GetValue(NumStrInputBox.InputModeProperty);
			}
			set
			{
				base.SetValue(NumStrInputBox.InputModeProperty, value);
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060001F2 RID: 498 RVA: 0x0000E17C File Offset: 0x0000C37C
		// (set) Token: 0x060001F3 RID: 499 RVA: 0x0000E18E File Offset: 0x0000C38E
		public string StringValue
		{
			get
			{
				return (string)base.GetValue(NumStrInputBox.StringValueProperty);
			}
			set
			{
				base.SetValue(NumStrInputBox.StringValueProperty, value);
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060001F4 RID: 500 RVA: 0x0000E19C File Offset: 0x0000C39C
		// (set) Token: 0x060001F5 RID: 501 RVA: 0x0000E1AE File Offset: 0x0000C3AE
		public string Label
		{
			get
			{
				return (string)base.GetValue(NumStrInputBox.LabelProperty);
			}
			set
			{
				base.SetValue(NumStrInputBox.LabelProperty, value);
			}
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x060001F6 RID: 502 RVA: 0x0000E1BC File Offset: 0x0000C3BC
		// (set) Token: 0x060001F7 RID: 503 RVA: 0x0000E1CE File Offset: 0x0000C3CE
		public TextAlignment TextAlignment
		{
			get
			{
				return (TextAlignment)base.GetValue(NumStrInputBox.TextAlignmentProperty);
			}
			set
			{
				base.SetValue(NumStrInputBox.TextAlignmentProperty, value);
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060001F8 RID: 504 RVA: 0x0000E1E1 File Offset: 0x0000C3E1
		// (set) Token: 0x060001F9 RID: 505 RVA: 0x0000E1F3 File Offset: 0x0000C3F3
		public Thickness NumMargin
		{
			get
			{
				return (Thickness)base.GetValue(NumStrInputBox.NumMarginProperty);
			}
			set
			{
				base.SetValue(NumStrInputBox.NumMarginProperty, value);
			}
		}

		// Token: 0x060001FA RID: 506 RVA: 0x0000E208 File Offset: 0x0000C408
		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			try
			{
				if (!this.initialized)
				{
					this.VisibleOrCollapseControl();
				}
			}
			catch
			{
			}
		}

		// Token: 0x060001FB RID: 507 RVA: 0x0000E23C File Offset: 0x0000C43C
		private void VisibleOrCollapseControl()
		{
			try
			{
				if (string.IsNullOrWhiteSpace(this.StringValue))
				{
					this.InputMode = 1;
				}
				this.ApplyInputMode(this.InputMode);
			}
			catch
			{
			}
		}

		// Token: 0x060001FC RID: 508 RVA: 0x0000E280 File Offset: 0x0000C480
		private void InputModeButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				this.ChangeInputMode(true);
			}
			catch
			{
			}
		}

		// Token: 0x060001FD RID: 509 RVA: 0x0000E2AC File Offset: 0x0000C4AC
		private void ChangeInputMode(bool backModeSupport = false)
		{
			if (this.ModesOfInput == null)
			{
				return;
			}
			List<string> list = this.ModesOfInput.GetValueOrDefault().ToString("g").Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToList<string>();
			int num = list.IndexOf(this.InputMode.ToString());
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
			this.ApplyInputMode(this.InputMode = StringExtensions.ToEnum<InputMode>(list[num], 1));
		}

		// Token: 0x060001FE RID: 510 RVA: 0x0000E368 File Offset: 0x0000C568
		private void ApplyInputMode(InputMode inputMode)
		{
			if (inputMode == 1)
			{
				this.inputTextBox.Visibility = Visibility.Collapsed;
				BorderElement.SetCornerRadius(this.inputModeButton, new CornerRadius(4.0));
				this.inputModeButton.Margin = new Thickness(5.0, 0.0, 0.0, 0.0);
				this.inputModeButton.BorderThickness = new Thickness(1.0);
				this.numUpDown.Visibility = Visibility.Visible;
				this.inputModeButton.Content = EnumExtension.GetDescription(inputMode);
				this.inputModeButton.Padding = new Thickness(10.0, 0.0, 5.0, 0.0);
				IconElement.SetWidth(this.inputModeButton, 8.9);
			}
			else
			{
				this.inputTextBox.Visibility = Visibility.Visible;
				BorderElement.SetCornerRadius(this.inputModeButton, new CornerRadius(0.0, 4.0, 4.0, 0.0));
				this.inputModeButton.Margin = new Thickness(0.0);
				this.inputModeButton.BorderThickness = new Thickness(0.0, 1.0, 1.0, 1.0);
				this.numUpDown.Visibility = Visibility.Collapsed;
				this.inputModeButton.Padding = new Thickness(0.0, 0.0, 5.0, 0.0);
				IconElement.SetWidth(this.inputModeButton, 0.0);
				this.inputModeButton.Content = EnumExtension.GetDescription(inputMode);
			}
			this.SetForeColorByInputMode(inputMode);
		}

		// Token: 0x060001FF RID: 511 RVA: 0x0000E55C File Offset: 0x0000C75C
		private void SetForeColorByInputMode(InputMode mode)
		{
			if (mode <= 8)
			{
				if (mode == 2)
				{
					this.inputModeButton.SetResourceReference(Control.ForegroundProperty, "ForegroundRetry");
					return;
				}
				if (mode == 4)
				{
					this.inputModeButton.SetResourceReference(Control.ForegroundProperty, "ForegroundOcrRate");
					return;
				}
				if (mode == 8)
				{
					this.inputModeButton.SetResourceReference(Control.ForegroundProperty, "ForegroundOcrRate");
					return;
				}
			}
			else
			{
				if (mode == 16)
				{
					this.inputModeButton.SetResourceReference(Control.ForegroundProperty, "ForegroundCustom");
					return;
				}
				if (mode == 32)
				{
					this.inputModeButton.SetResourceReference(Control.ForegroundProperty, "ForegroundCustom");
					return;
				}
				if (mode == 64)
				{
					this.inputModeButton.SetResourceReference(Control.ForegroundProperty, "ForegroundGood");
					return;
				}
			}
			this.inputModeButton.SetResourceReference(Control.ForegroundProperty, "ForegroundMain");
		}

		// Token: 0x06000200 RID: 512 RVA: 0x0000E62C File Offset: 0x0000C82C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/usercontrols/input/numstrinputbox.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000201 RID: 513 RVA: 0x0000E65C File Offset: 0x0000C85C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.parent = (NumStrInputBox)target;
				this.parent.Loaded += this.UserControl_Loaded;
				return;
			case 2:
				this.numUpDown = (NumericUpDown)target;
				return;
			case 3:
				this.inputTextBox = (TextBox)target;
				return;
			case 4:
				this.inputModeButton = (Button)target;
				this.inputModeButton.Click += this.InputModeButton_Click;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x040000FB RID: 251
		private bool initialized;

		// Token: 0x040000FC RID: 252
		public static readonly DependencyProperty DecimalPlacesProperty = DependencyProperty.Register("DecimalPlaces", typeof(int), typeof(NumStrInputBox), new PropertyMetadata(0));

		// Token: 0x040000FD RID: 253
		public static readonly DependencyProperty MinimumProperty = DependencyProperty.Register("Minimum", typeof(double), typeof(NumStrInputBox), new PropertyMetadata(0.0));

		// Token: 0x040000FE RID: 254
		public static readonly DependencyProperty MaximumProperty = DependencyProperty.Register("Maximum", typeof(double), typeof(NumStrInputBox), new PropertyMetadata(100000000.0));

		// Token: 0x040000FF RID: 255
		public static readonly DependencyProperty ValueFormatProperty = DependencyProperty.Register("ValueFormat", typeof(string), typeof(NumStrInputBox), new PropertyMetadata());

		// Token: 0x04000100 RID: 256
		public static readonly DependencyProperty NumericValueProperty = DependencyProperty.Register("NumericValue", typeof(double), typeof(NumStrInputBox), new PropertyMetadata(0.0));

		// Token: 0x04000101 RID: 257
		public static readonly DependencyProperty ModesOfInputProperty = DependencyProperty.Register("ModesOfInput", typeof(InputMode?), typeof(NumStrInputBox), new PropertyMetadata(3));

		// Token: 0x04000102 RID: 258
		public static readonly DependencyProperty InputModeProperty = DependencyProperty.Register("InputMode", typeof(InputMode), typeof(NumStrInputBox), new PropertyMetadata(1));

		// Token: 0x04000103 RID: 259
		public static readonly DependencyProperty StringValueProperty = DependencyProperty.Register("StringValue", typeof(string), typeof(NumStrInputBox), new PropertyMetadata(""));

		// Token: 0x04000104 RID: 260
		public static readonly DependencyProperty LabelProperty = DependencyProperty.Register("Label", typeof(string), typeof(NumStrInputBox), new PropertyMetadata("Label"));

		// Token: 0x04000105 RID: 261
		public static readonly DependencyProperty TextAlignmentProperty = DependencyProperty.Register("TextAlignment", typeof(TextAlignment), typeof(NumStrInputBox), new PropertyMetadata(TextAlignment.Left));

		// Token: 0x04000106 RID: 262
		public static readonly DependencyProperty NumMarginProperty = DependencyProperty.Register("NumMargin", typeof(Thickness), typeof(NumStrInputBox), new PropertyMetadata(new Thickness(0.0, 0.0, 0.0, -1.0)));

		// Token: 0x04000107 RID: 263
		private NumStrInputBox parent;

		// Token: 0x04000108 RID: 264
		private NumericUpDown numUpDown;

		// Token: 0x04000109 RID: 265
		private TextBox inputTextBox;

		// Token: 0x0400010A RID: 266
		private Button inputModeButton;

		// Token: 0x0400010B RID: 267
		private bool _contentLoaded;
	}
}
