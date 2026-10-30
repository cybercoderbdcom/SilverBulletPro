using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using AngleSharp.Text;
using HandyControl.Controls;
using SilverBulletPro.Core;
using SilverBulletPro.Core.Extensions;
using SilverBulletPro.Models;

namespace SilverBulletPro.Views.UserControls
{
	// Token: 0x02000037 RID: 55
	public class TextInputBox : UserControl, IComponentConnector
	{
		// Token: 0x06000232 RID: 562 RVA: 0x0000F888 File Offset: 0x0000DA88
		public TextInputBox()
		{
			this.InitializeComponent();
			this.initialized = false;
			InfoElement.SetShowClearButton(this.inputTextBox, true);
		}

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000233 RID: 563 RVA: 0x0000F8AC File Offset: 0x0000DAAC
		// (remove) Token: 0x06000234 RID: 564 RVA: 0x0000F8E4 File Offset: 0x0000DAE4
		public event RoutedEventHandler ModeChanged;

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06000235 RID: 565 RVA: 0x0000F91C File Offset: 0x0000DB1C
		// (remove) Token: 0x06000236 RID: 566 RVA: 0x0000F954 File Offset: 0x0000DB54
		public event TextChangedEventHandler TextChanged;

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x06000237 RID: 567 RVA: 0x0000F98C File Offset: 0x0000DB8C
		// (remove) Token: 0x06000238 RID: 568 RVA: 0x0000F9C4 File Offset: 0x0000DBC4
		public event DragEventHandler TextInputBoxDrop;

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06000239 RID: 569 RVA: 0x0000F9FC File Offset: 0x0000DBFC
		// (remove) Token: 0x0600023A RID: 570 RVA: 0x0000FA34 File Offset: 0x0000DC34
		public event DragEventHandler TextInputBoxPreviewDragOver;

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x0600023B RID: 571 RVA: 0x0000FA69 File Offset: 0x0000DC69
		// (set) Token: 0x0600023C RID: 572 RVA: 0x0000FA7B File Offset: 0x0000DC7B
		public string Text
		{
			get
			{
				return (string)base.GetValue(TextInputBox.TextProperty);
			}
			set
			{
				base.SetValue(TextInputBox.TextProperty, value);
			}
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x0600023D RID: 573 RVA: 0x0000FA89 File Offset: 0x0000DC89
		// (set) Token: 0x0600023E RID: 574 RVA: 0x0000FA9B File Offset: 0x0000DC9B
		public double InputFontSize
		{
			get
			{
				return (double)base.GetValue(TextInputBox.InputFontSizeProperty);
			}
			set
			{
				base.SetValue(TextInputBox.InputFontSizeProperty, value);
			}
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x0600023F RID: 575 RVA: 0x0000FAAE File Offset: 0x0000DCAE
		// (set) Token: 0x06000240 RID: 576 RVA: 0x0000FAC0 File Offset: 0x0000DCC0
		public Encoding Encoding
		{
			get
			{
				return (Encoding)base.GetValue(TextInputBox.EncodingProperty);
			}
			set
			{
				base.SetValue(TextInputBox.EncodingProperty, value);
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x06000241 RID: 577 RVA: 0x0000FACE File Offset: 0x0000DCCE
		// (set) Token: 0x06000242 RID: 578 RVA: 0x0000FAE0 File Offset: 0x0000DCE0
		public bool EnableEncoding
		{
			get
			{
				return (bool)base.GetValue(TextInputBox.EnableEncodingProperty);
			}
			set
			{
				base.SetValue(TextInputBox.EnableEncodingProperty, value);
			}
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x06000243 RID: 579 RVA: 0x0000FAF3 File Offset: 0x0000DCF3
		// (set) Token: 0x06000244 RID: 580 RVA: 0x0000FB05 File Offset: 0x0000DD05
		public bool IsReadOnly
		{
			get
			{
				return (bool)base.GetValue(TextInputBox.IsReadOnlyProperty);
			}
			set
			{
				base.SetValue(TextInputBox.IsReadOnlyProperty, value);
			}
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x06000245 RID: 581 RVA: 0x0000FB18 File Offset: 0x0000DD18
		// (set) Token: 0x06000246 RID: 582 RVA: 0x0000FB2A File Offset: 0x0000DD2A
		public bool AcceptsReturn
		{
			get
			{
				return (bool)base.GetValue(TextInputBox.AcceptsReturnProperty);
			}
			set
			{
				base.SetValue(TextInputBox.AcceptsReturnProperty, value);
			}
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000247 RID: 583 RVA: 0x0000FB3D File Offset: 0x0000DD3D
		// (set) Token: 0x06000248 RID: 584 RVA: 0x0000FB4F File Offset: 0x0000DD4F
		public string Placeholder
		{
			get
			{
				return (string)base.GetValue(TextInputBox.PlaceholderProperty);
			}
			set
			{
				base.SetValue(TextInputBox.PlaceholderProperty, value);
			}
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000249 RID: 585 RVA: 0x0000FB5D File Offset: 0x0000DD5D
		// (set) Token: 0x0600024A RID: 586 RVA: 0x0000FB6F File Offset: 0x0000DD6F
		public Visibility LabelVisibility
		{
			get
			{
				return (Visibility)base.GetValue(TextInputBox.LabelVisibilityProperty);
			}
			set
			{
				base.SetValue(TextInputBox.LabelVisibilityProperty, value);
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x0600024B RID: 587 RVA: 0x0000FB82 File Offset: 0x0000DD82
		// (set) Token: 0x0600024C RID: 588 RVA: 0x0000FB94 File Offset: 0x0000DD94
		public bool TextInputBoxAllowDrop
		{
			get
			{
				return (bool)base.GetValue(TextInputBox.TextInputBoxAllowDropProperty);
			}
			set
			{
				base.SetValue(TextInputBox.TextInputBoxAllowDropProperty, value);
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x0600024D RID: 589 RVA: 0x0000FBA7 File Offset: 0x0000DDA7
		// (set) Token: 0x0600024E RID: 590 RVA: 0x0000FBB9 File Offset: 0x0000DDB9
		public InputMode? ModesOfInput
		{
			get
			{
				return (InputMode?)base.GetValue(TextInputBox.ModesOfInputProperty);
			}
			set
			{
				base.SetValue(TextInputBox.ModesOfInputProperty, value);
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x0600024F RID: 591 RVA: 0x0000FBCC File Offset: 0x0000DDCC
		// (set) Token: 0x06000250 RID: 592 RVA: 0x0000FBDE File Offset: 0x0000DDDE
		public InputMode InputMode
		{
			get
			{
				return (InputMode)base.GetValue(TextInputBox.InputModeProperty);
			}
			set
			{
				base.SetValue(TextInputBox.InputModeProperty, value);
			}
		}

		// Token: 0x06000251 RID: 593 RVA: 0x0000FBF4 File Offset: 0x0000DDF4
		private static void OnInputModesChangedCallBack(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			TextInputBox control = (TextInputBox)sender;
			try
			{
				if (e2.NewValue == null || control.ModesOfInput == null)
				{
					control.inputModeButton.IsHitTestVisible = false;
					control.inputModeButton.Visibility = Visibility.Collapsed;
					BorderElement.SetCornerRadius(control.inputTextBox, new CornerRadius(4.0));
				}
				else
				{
					control.inputModeButton.Visibility = Visibility.Visible;
					BorderElement.SetCornerRadius(control.inputTextBox, new CornerRadius(4.0, 0.0, 0.0, 4.0));
					control.ChangeInputMode(false);
					control.inputModeButton.IsHitTestVisible = control.ModesOfInput.GetValueOrDefault().ToString("g").Contains(",");
					if (control.EnableEncoding)
					{
						control.encodingBox.SelectedItem = control.encodingBox.Items.Cast<EncodeModel>().FirstOrDefault((EncodeModel e) => e.Name.ToUpper() == control.Encoding.BodyName.ToUpper());
						control.encodingBox.ToolTip = ((EncodeModel)control.encodingBox.SelectedItem).Info.DisplayName;
						control.encodingBox.Visibility = ((control.InputMode == 1 || control.InputMode == 2) ? (control.encodingBox.Visibility = Visibility.Visible) : (control.encodingBox.Visibility = Visibility.Collapsed));
					}
					else
					{
						control.encodingBox.Visibility = Visibility.Collapsed;
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000252 RID: 594 RVA: 0x0000FE08 File Offset: 0x0000E008
		private static void OnInputModeChangedCallBack(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			TextInputBox textInputBox = (TextInputBox)sender;
			if (e.NewValue != null)
			{
				try
				{
					if (textInputBox.ModesOfInput == null)
					{
						textInputBox.inputModeButton.IsHitTestVisible = false;
						textInputBox.inputModeButton.Visibility = Visibility.Collapsed;
						return;
					}
					textInputBox.inputModeButton.Visibility = Visibility.Visible;
					if (textInputBox.ModesOfInput.GetValueOrDefault().ToString("g").Contains(","))
					{
						textInputBox.ApplyInputMode(textInputBox.InputMode);
					}
					else
					{
						textInputBox.ApplyInputMode(2);
					}
				}
				catch
				{
				}
			}
			RoutedEventHandler modeChanged = textInputBox.ModeChanged;
			if (modeChanged == null)
			{
				return;
			}
			modeChanged(textInputBox, new RoutedEventArgs());
		}

		// Token: 0x06000253 RID: 595 RVA: 0x0000FEC4 File Offset: 0x0000E0C4
		private static void OnEnableEncodingChangedCallBack(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			TextInputBox textInputBox = (TextInputBox)sender;
			if (e.NewValue != null)
			{
				try
				{
					textInputBox.encodingBox.Visibility = (textInputBox.EnableEncoding ? Visibility.Visible : Visibility.Collapsed);
				}
				catch
				{
				}
			}
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000254 RID: 596 RVA: 0x0000FF10 File Offset: 0x0000E110
		// (set) Token: 0x06000255 RID: 597 RVA: 0x0000FF22 File Offset: 0x0000E122
		public string Label
		{
			get
			{
				return (string)base.GetValue(TextInputBox.InputTypeProperty);
			}
			set
			{
				base.SetValue(TextInputBox.InputTypeProperty, value);
			}
		}

		// Token: 0x06000256 RID: 598 RVA: 0x0000FF30 File Offset: 0x0000E130
		private void InputModeButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				this.ChangeInputMode(true);
			}
			catch
			{
			}
			if (!this.EnableEncoding)
			{
				return;
			}
			try
			{
				this.encodingBox.Visibility = ((this.InputMode == 1 || this.InputMode == 2) ? (this.encodingBox.Visibility = Visibility.Visible) : (this.encodingBox.Visibility = Visibility.Collapsed));
			}
			catch
			{
			}
		}

		// Token: 0x06000257 RID: 599 RVA: 0x0000FFB4 File Offset: 0x0000E1B4
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

		// Token: 0x06000258 RID: 600 RVA: 0x00010070 File Offset: 0x0000E270
		private void ApplyInputMode(InputMode inputMode)
		{
			if (inputMode == 1)
			{
				this.inputModeButton.Content = string.Empty;
				this.inputModeButton.Padding = new Thickness(10.0, 0.0, 5.0, 0.0);
				IconElement.SetWidth(this.inputModeButton, 8.5);
			}
			else
			{
				this.inputModeButton.Padding = new Thickness(0.0, 0.0, 5.0, 0.0);
				IconElement.SetWidth(this.inputModeButton, 0.0);
				this.inputModeButton.Content = EnumExtension.GetDescription(inputMode);
			}
			this.SetForeColorByInputMode(inputMode);
		}

		// Token: 0x06000259 RID: 601 RVA: 0x00010140 File Offset: 0x0000E340
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

		// Token: 0x0600025A RID: 602 RVA: 0x00010210 File Offset: 0x0000E410
		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			try
			{
				if (this.initialized)
				{
					return;
				}
				try
				{
					this.ApplyInputMode(this.InputMode);
				}
				catch
				{
				}
				if (this.EnableEncoding)
				{
					foreach (EncodingInfo encodingInfo in Encoding.GetEncodings())
					{
						this.encodingBox.Items.Add(new EncodeModel
						{
							Info = encodingInfo,
							Name = encodingInfo.Name,
							DisplayName = encodingInfo.DisplayName
						});
					}
					this.encodingBox.SelectedItem = this.encodingBox.Items.Cast<EncodeModel>().FirstOrDefault((EncodeModel e) => e.Name.ToUpper() == this.Encoding.BodyName.ToUpper());
					this.encodingBox.ToolTip = ((EncodeModel)this.encodingBox.SelectedItem).Info.DisplayName;
					InputMode inputMode = this.InputMode;
					this.encodingBox.Visibility = ((inputMode == 1 || inputMode == 2) ? (this.encodingBox.Visibility = Visibility.Visible) : (this.encodingBox.Visibility = Visibility.Collapsed));
				}
				else
				{
					this.encodingBox.Visibility = Visibility.Collapsed;
				}
			}
			catch
			{
			}
			this.initialized = true;
		}

		// Token: 0x0600025B RID: 603 RVA: 0x00010374 File Offset: 0x0000E574
		private void EncodingBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				EncodeModel encodeModel = (EncodeModel)this.encodingBox.SelectedItem;
				this.encodingBox.ToolTip = encodeModel.DisplayName;
				this.Encoding = encodeModel.Info.GetEncoding();
			}
			catch
			{
			}
		}

		// Token: 0x0600025C RID: 604 RVA: 0x000103CC File Offset: 0x0000E5CC
		private void TextInputBox_Drop(object sender, DragEventArgs e)
		{
			DragEventHandler textInputBoxDrop = this.TextInputBoxDrop;
			if (textInputBoxDrop == null)
			{
				return;
			}
			textInputBoxDrop(sender, e);
		}

		// Token: 0x0600025D RID: 605 RVA: 0x000103E0 File Offset: 0x0000E5E0
		private void TextInputBox_PreviewDragOver(object sender, DragEventArgs e)
		{
			DragEventHandler textInputBoxPreviewDragOver = this.TextInputBoxPreviewDragOver;
			if (textInputBoxPreviewDragOver == null)
			{
				return;
			}
			textInputBoxPreviewDragOver(sender, e);
		}

		// Token: 0x0600025E RID: 606 RVA: 0x000103F4 File Offset: 0x0000E5F4
		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			TextChangedEventHandler textChanged = this.TextChanged;
			if (textChanged == null)
			{
				return;
			}
			textChanged(sender, e);
		}

		// Token: 0x0600025F RID: 607 RVA: 0x00010408 File Offset: 0x0000E608
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/usercontrols/input/textinputbox.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000260 RID: 608 RVA: 0x00010438 File Offset: 0x0000E638
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.parent = (TextInputBox)target;
				this.parent.Loaded += this.UserControl_Loaded;
				return;
			case 2:
				this.textBlock = (TextBlock)target;
				return;
			case 3:
				this.inputModeButton = (Button)target;
				this.inputModeButton.Click += this.InputModeButton_Click;
				return;
			case 4:
				this.encodingBox = (ComboBox)target;
				this.encodingBox.SelectionChanged += this.EncodingBox_SelectionChanged;
				return;
			case 5:
				this.inputTextBox = (TextBox)target;
				this.inputTextBox.Drop += this.TextInputBox_Drop;
				this.inputTextBox.PreviewDragOver += this.TextInputBox_PreviewDragOver;
				this.inputTextBox.TextChanged += this.TextBox_TextChanged;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x0400011D RID: 285
		private bool initialized;

		// Token: 0x04000122 RID: 290
		public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(TextInputBox), new PropertyMetadata(""));

		// Token: 0x04000123 RID: 291
		public static readonly DependencyProperty InputFontSizeProperty = DependencyProperty.Register("InputFontSize", typeof(double), typeof(TextInputBox), new PropertyMetadata(12.0));

		// Token: 0x04000124 RID: 292
		public static readonly DependencyProperty EncodingProperty = DependencyProperty.Register("Encoding", typeof(Encoding), typeof(TextInputBox), new PropertyMetadata(Encoding.UTF8));

		// Token: 0x04000125 RID: 293
		public static readonly DependencyProperty EnableEncodingProperty = DependencyProperty.Register("EnableEncoding", typeof(bool), typeof(TextInputBox), new PropertyMetadata(false, new PropertyChangedCallback(TextInputBox.OnEnableEncodingChangedCallBack)));

		// Token: 0x04000126 RID: 294
		public static readonly DependencyProperty IsReadOnlyProperty = DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(TextInputBox), new PropertyMetadata(false));

		// Token: 0x04000127 RID: 295
		public static readonly DependencyProperty AcceptsReturnProperty = DependencyProperty.Register("AcceptsReturn", typeof(bool), typeof(TextInputBox));

		// Token: 0x04000128 RID: 296
		public static readonly DependencyProperty PlaceholderProperty = DependencyProperty.Register("Placeholder", typeof(string), typeof(TextInputBox), new PropertyMetadata(string.Empty));

		// Token: 0x04000129 RID: 297
		public static readonly DependencyProperty LabelVisibilityProperty = DependencyProperty.Register("LabelVisibility", typeof(Visibility), typeof(TextInputBox), new PropertyMetadata(Visibility.Visible));

		// Token: 0x0400012A RID: 298
		public static readonly DependencyProperty TextInputBoxAllowDropProperty = DependencyProperty.Register("TextInputBoxAllowDrop", typeof(bool), typeof(TextInputBox), new PropertyMetadata(false));

		// Token: 0x0400012B RID: 299
		public static readonly DependencyProperty ModesOfInputProperty = DependencyProperty.Register("ModesOfInput", typeof(InputMode?), typeof(TextInputBox), new PropertyMetadata(13, new PropertyChangedCallback(TextInputBox.OnInputModesChangedCallBack)));

		// Token: 0x0400012C RID: 300
		public static readonly DependencyProperty InputModeProperty = DependencyProperty.Register("InputMode", typeof(InputMode), typeof(TextInputBox), new PropertyMetadata(2, new PropertyChangedCallback(TextInputBox.OnInputModeChangedCallBack)));

		// Token: 0x0400012D RID: 301
		public static readonly DependencyProperty InputTypeProperty = DependencyProperty.Register("Label", typeof(string), typeof(TextInputBox), new PropertyMetadata("Label"));

		// Token: 0x0400012E RID: 302
		private TextInputBox parent;

		// Token: 0x0400012F RID: 303
		internal TextBlock textBlock;

		// Token: 0x04000130 RID: 304
		private Button inputModeButton;

		// Token: 0x04000131 RID: 305
		internal ComboBox encodingBox;

		// Token: 0x04000132 RID: 306
		internal TextBox inputTextBox;

		// Token: 0x04000133 RID: 307
		private bool _contentLoaded;
	}
}
