using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using AngleSharp.Text;
using HandyControl.Controls;
using SilverBulletPro.Core;
using SilverBulletPro.Core.Extensions;
using SilverBulletPro.Extensions;
using SilverBulletPro.Models;

namespace SilverBulletPro.Views.UserControls
{
	// Token: 0x02000038 RID: 56
	public class VarCapOutputBox : UserControl, IComponentConnector
	{
		// Token: 0x06000263 RID: 611 RVA: 0x000107AD File Offset: 0x0000E9AD
		public VarCapOutputBox()
		{
			this.InitializeComponent();
		}

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x06000264 RID: 612 RVA: 0x000107BC File Offset: 0x0000E9BC
		// (remove) Token: 0x06000265 RID: 613 RVA: 0x000107F4 File Offset: 0x0000E9F4
		public event RoutedEventHandler ModeChanged;

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x06000266 RID: 614 RVA: 0x0001082C File Offset: 0x0000EA2C
		// (remove) Token: 0x06000267 RID: 615 RVA: 0x00010864 File Offset: 0x0000EA64
		public event RoutedEventHandler VarCapChanged;

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x06000268 RID: 616 RVA: 0x00010899 File Offset: 0x0000EA99
		// (set) Token: 0x06000269 RID: 617 RVA: 0x000108AB File Offset: 0x0000EAAB
		public OutputMode OutputMode
		{
			get
			{
				return (OutputMode)base.GetValue(VarCapOutputBox.OutputModeProperty);
			}
			set
			{
				base.SetValue(VarCapOutputBox.OutputModeProperty, value);
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x0600026A RID: 618 RVA: 0x000108BE File Offset: 0x0000EABE
		// (set) Token: 0x0600026B RID: 619 RVA: 0x000108D0 File Offset: 0x0000EAD0
		public OutputMode ModesOfOutput
		{
			get
			{
				return (OutputMode)base.GetValue(VarCapOutputBox.ModesOfOutputProperty);
			}
			set
			{
				base.SetValue(VarCapOutputBox.ModesOfOutputProperty, value);
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x0600026C RID: 620 RVA: 0x000108E3 File Offset: 0x0000EAE3
		// (set) Token: 0x0600026D RID: 621 RVA: 0x000108F5 File Offset: 0x0000EAF5
		public bool EnableCapture
		{
			get
			{
				return (bool)base.GetValue(VarCapOutputBox.EnableCaptureProperty);
			}
			set
			{
				base.SetValue(VarCapOutputBox.EnableCaptureProperty, value);
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x0600026E RID: 622 RVA: 0x00010908 File Offset: 0x0000EB08
		// (set) Token: 0x0600026F RID: 623 RVA: 0x0001091A File Offset: 0x0000EB1A
		public bool EnableEncoding
		{
			get
			{
				return (bool)base.GetValue(VarCapOutputBox.EnableEncodingProperty);
			}
			set
			{
				base.SetValue(VarCapOutputBox.EnableEncodingProperty, value);
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x06000270 RID: 624 RVA: 0x0001092D File Offset: 0x0000EB2D
		// (set) Token: 0x06000271 RID: 625 RVA: 0x0001093F File Offset: 0x0000EB3F
		public string Text
		{
			get
			{
				return (string)base.GetValue(VarCapOutputBox.TextProperty);
			}
			set
			{
				base.SetValue(VarCapOutputBox.TextProperty, value);
			}
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x06000272 RID: 626 RVA: 0x0001094D File Offset: 0x0000EB4D
		// (set) Token: 0x06000273 RID: 627 RVA: 0x0001095F File Offset: 0x0000EB5F
		public bool IsCapture
		{
			get
			{
				return (bool)base.GetValue(VarCapOutputBox.IsCaptureProperty);
			}
			set
			{
				base.SetValue(VarCapOutputBox.IsCaptureProperty, value);
			}
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x06000274 RID: 628 RVA: 0x00010972 File Offset: 0x0000EB72
		// (set) Token: 0x06000275 RID: 629 RVA: 0x00010984 File Offset: 0x0000EB84
		public bool EnableHiddenVar
		{
			get
			{
				return (bool)base.GetValue(VarCapOutputBox.EnableHiddenVarProperty);
			}
			set
			{
				base.SetValue(VarCapOutputBox.EnableHiddenVarProperty, value);
			}
		}

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x06000276 RID: 630 RVA: 0x00010997 File Offset: 0x0000EB97
		// (set) Token: 0x06000277 RID: 631 RVA: 0x000109A9 File Offset: 0x0000EBA9
		public bool IsReadOnly
		{
			get
			{
				return (bool)base.GetValue(VarCapOutputBox.IsReadOnlyProperty);
			}
			set
			{
				base.SetValue(VarCapOutputBox.IsReadOnlyProperty, value);
			}
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x06000278 RID: 632 RVA: 0x000109BC File Offset: 0x0000EBBC
		// (set) Token: 0x06000279 RID: 633 RVA: 0x000109CE File Offset: 0x0000EBCE
		public bool EnableOutputMode
		{
			get
			{
				return (bool)base.GetValue(VarCapOutputBox.EnableOutputTypeProperty);
			}
			set
			{
				base.SetValue(VarCapOutputBox.EnableOutputTypeProperty, value);
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x0600027A RID: 634 RVA: 0x000109E1 File Offset: 0x0000EBE1
		// (set) Token: 0x0600027B RID: 635 RVA: 0x000109F3 File Offset: 0x0000EBF3
		public Encoding Encoding
		{
			get
			{
				return (Encoding)base.GetValue(VarCapOutputBox.EncodingProperty);
			}
			set
			{
				base.SetValue(VarCapOutputBox.EncodingProperty, value);
			}
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x0600027C RID: 636 RVA: 0x00010A01 File Offset: 0x0000EC01
		// (set) Token: 0x0600027D RID: 637 RVA: 0x00010A13 File Offset: 0x0000EC13
		public bool HiddenVar
		{
			get
			{
				return (bool)base.GetValue(VarCapOutputBox.HiddenVarProperty);
			}
			set
			{
				base.SetValue(VarCapOutputBox.HiddenVarProperty, value);
			}
		}

		// Token: 0x0600027E RID: 638 RVA: 0x00010A28 File Offset: 0x0000EC28
		private static void OnEnableHiddenVarChangedCallBack(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			VarCapOutputBox varCapOutputBox = (VarCapOutputBox)sender;
			if (e.NewValue != null)
			{
				try
				{
					if (!varCapOutputBox.EnableHiddenVar)
					{
						varCapOutputBox.borderHiddenVar.Visibility = Visibility.Collapsed;
						varCapOutputBox.varCapNameTextBox.BorderThickness = new Thickness(1.0);
						BorderElement.SetCornerRadius(varCapOutputBox.varCapNameTextBox, new CornerRadius(4.0));
					}
					else
					{
						varCapOutputBox.borderHiddenVar.Visibility = Visibility.Visible;
						varCapOutputBox.varCapNameTextBox.BorderThickness = new Thickness(1.0, 1.0, 0.0, 1.0);
						BorderElement.SetCornerRadius(varCapOutputBox.varCapNameTextBox, new CornerRadius(4.0, 0.0, 0.0, 4.0));
					}
				}
				catch
				{
				}
			}
		}

		// Token: 0x0600027F RID: 639 RVA: 0x00010B1C File Offset: 0x0000ED1C
		private static void OnOutputModeChangedCallBack(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			VarCapOutputBox varCapOutputBox = (VarCapOutputBox)sender;
			if (e.NewValue != null)
			{
				try
				{
					varCapOutputBox.OutputModeChanged();
				}
				catch
				{
				}
			}
		}

		// Token: 0x06000280 RID: 640 RVA: 0x00010B54 File Offset: 0x0000ED54
		private void VarCapNameTextBox_MouseEnter(object sender, MouseEventArgs e)
		{
			if (this.borderHiddenVar.BorderBrush == ResourceExtension.Get<LinearGradientBrush>("PrimaryBrush", ""))
			{
				return;
			}
			this.borderHiddenVar.SetResourceReference(Control.BorderBrushProperty, "SecondaryBorderBrush");
		}

		// Token: 0x06000281 RID: 641 RVA: 0x00010B88 File Offset: 0x0000ED88
		private void VarCapNameTextBox_MouseLeave(object sender, MouseEventArgs e)
		{
			if (this.borderHiddenVar.BorderBrush == ResourceExtension.Get<LinearGradientBrush>("PrimaryBrush", ""))
			{
				return;
			}
			this.borderHiddenVar.SetResourceReference(Control.BorderBrushProperty, "BorderBrush");
		}

		// Token: 0x06000282 RID: 642 RVA: 0x00010BBC File Offset: 0x0000EDBC
		private void VarCapNameTextBox_GotFocus(object sender, RoutedEventArgs e)
		{
			this.borderHiddenVar.SetResourceReference(Control.BorderBrushProperty, "PrimaryBrush");
		}

		// Token: 0x06000283 RID: 643 RVA: 0x00010BD3 File Offset: 0x0000EDD3
		private void VarCapNameTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			this.borderHiddenVar.SetResourceReference(Control.BorderBrushProperty, "BorderBrush");
		}

		// Token: 0x06000284 RID: 644 RVA: 0x00010BEA File Offset: 0x0000EDEA
		private void ToggleButton_MouseEnter(object sender, MouseEventArgs e)
		{
			if (this.varCapNameTextBox.BorderBrush == ResourceExtension.Get<LinearGradientBrush>("PrimaryBrush", ""))
			{
				return;
			}
			this.varCapNameTextBox.SetResourceReference(Control.BorderBrushProperty, "SecondaryBorderBrush");
			this.VarCapNameTextBox_MouseEnter(sender, e);
		}

		// Token: 0x06000285 RID: 645 RVA: 0x00010C26 File Offset: 0x0000EE26
		private void ToggleButton_MouseLeave(object sender, MouseEventArgs e)
		{
			if (this.varCapNameTextBox.BorderBrush == ResourceExtension.Get<LinearGradientBrush>("PrimaryBrush", ""))
			{
				return;
			}
			this.varCapNameTextBox.SetResourceReference(Control.BorderBrushProperty, "BorderBrush");
			this.VarCapNameTextBox_MouseLeave(sender, e);
		}

		// Token: 0x06000286 RID: 646 RVA: 0x00010C62 File Offset: 0x0000EE62
		private void ToggleButton_GotFocus(object sender, RoutedEventArgs e)
		{
			this.varCapNameTextBox.SetResourceReference(Control.BorderBrushProperty, "PrimaryBrush");
			this.VarCapNameTextBox_GotFocus(sender, e);
		}

		// Token: 0x06000287 RID: 647 RVA: 0x00010C81 File Offset: 0x0000EE81
		private void ToggleButton_LostFocus(object sender, RoutedEventArgs e)
		{
			this.varCapNameTextBox.SetResourceReference(Control.BorderBrushProperty, "BorderBrush");
			this.VarCapNameTextBox_LostFocus(sender, e);
		}

		// Token: 0x06000288 RID: 648 RVA: 0x00010CA0 File Offset: 0x0000EEA0
		private void CaptureBox_Click(object sender, RoutedEventArgs e)
		{
			RoutedEventHandler varCapChanged = this.VarCapChanged;
			if (varCapChanged == null)
			{
				return;
			}
			varCapChanged(this, e);
		}

		// Token: 0x06000289 RID: 649 RVA: 0x00010CB4 File Offset: 0x0000EEB4
		public void UpdateElements()
		{
			if (this.toggleButton.Tag == null)
			{
				this.toggleButton.Tag = "Loaded";
				this.toggleButton.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
				this.OutputModeChanged();
				try
				{
					this.VisibleOrCollapseHiddenVarCtrl();
				}
				catch
				{
				}
				try
				{
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
					}
					this.VisibleOrCollapseEncCtrl();
				}
				catch
				{
				}
			}
		}

		// Token: 0x0600028A RID: 650 RVA: 0x00010DD8 File Offset: 0x0000EFD8
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

		// Token: 0x0600028B RID: 651 RVA: 0x00010E30 File Offset: 0x0000F030
		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			this.UpdateElements();
		}

		// Token: 0x0600028C RID: 652 RVA: 0x00010E38 File Offset: 0x0000F038
		private void OutputModeButton_Click(object sender, RoutedEventArgs e)
		{
			this.ChangeOutputMode(true);
			RoutedEventHandler modeChanged = this.ModeChanged;
			if (modeChanged != null)
			{
				modeChanged(this, e);
			}
			this.VisibleOrCollapseEncCtrl();
		}

		// Token: 0x0600028D RID: 653 RVA: 0x00010E5C File Offset: 0x0000F05C
		private void ChangeOutputMode(bool backModeSupport = false)
		{
			List<string> list = this.ModesOfOutput.ToString("g").Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToList<string>();
			int num = list.IndexOf(this.OutputMode.ToString());
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
			this.OutputMode = StringExtensions.ToEnum<OutputMode>(list[num], 8);
			this.OutputModeChanged();
		}

		// Token: 0x0600028E RID: 654 RVA: 0x00010EFC File Offset: 0x0000F0FC
		private void OutputModeChanged()
		{
			try
			{
				this.outputModeButton.Content = EnumExtension.GetDescription(this.OutputMode);
				if (this.EnableOutputMode)
				{
					OutputMode outputMode = this.OutputMode;
					if (outputMode <= 8)
					{
						switch (outputMode)
						{
						case 1:
							this.outputModeButton.Content = EnumExtension.GetDescription(1);
							this.OutputMode = 1;
							break;
						case 2:
							this.outputModeButton.Content = EnumExtension.GetDescription(2);
							this.OutputMode = 2;
							break;
						case 3:
							break;
						case 4:
							this.outputModeButton.Content = EnumExtension.GetDescription(4);
							this.OutputMode = 4;
							break;
						default:
							if (outputMode == 8)
							{
								this.outputModeButton.Content = EnumExtension.GetDescription(8);
								this.OutputMode = 8;
							}
							break;
						}
					}
					else if (outputMode != 16)
					{
						if (outputMode == 32)
						{
							this.outputModeButton.Content = EnumExtension.GetDescription(32);
							this.OutputMode = 32;
						}
					}
					else
					{
						this.outputModeButton.Content = EnumExtension.GetDescription(16);
						this.OutputMode = 16;
					}
					this.outputModeButton.IsHitTestVisible = true;
				}
				else
				{
					this.outputModeButton.SetResourceReference(Control.ForegroundProperty, "ForegroundMain");
					this.outputModeButton.IsHitTestVisible = false;
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600028F RID: 655 RVA: 0x00011080 File Offset: 0x0000F280
		private void VisibleOrCollapseEncCtrl()
		{
			try
			{
				if (this.EnableEncoding)
				{
					if (this.OutputMode == 1)
					{
						this.encodingBox.Visibility = Visibility.Visible;
						BorderElement.SetCornerRadius(this.varCapNameTextBox, new CornerRadius(4.0, 0.0, 0.0, 4.0));
						this.borderHiddenVar.CornerRadius = new CornerRadius(0.0);
					}
					else
					{
						this.encodingBox.Visibility = Visibility.Collapsed;
						this.borderHiddenVar.CornerRadius = new CornerRadius(0.0, 4.0, 4.0, 0.0);
					}
				}
			}
			catch
			{
				if (this.OutputMode == 1)
				{
					this.encodingBox.Visibility = Visibility.Visible;
					BorderElement.SetCornerRadius(this.varCapNameTextBox, new CornerRadius(4.0, 0.0, 0.0, 4.0));
					this.borderHiddenVar.CornerRadius = new CornerRadius(0.0);
				}
				else
				{
					this.encodingBox.Visibility = Visibility.Collapsed;
					this.borderHiddenVar.CornerRadius = new CornerRadius(0.0, 4.0, 4.0, 0.0);
				}
			}
		}

		// Token: 0x06000290 RID: 656 RVA: 0x000111FC File Offset: 0x0000F3FC
		private void VisibleOrCollapseHiddenVarCtrl()
		{
			if (!this.EnableHiddenVar)
			{
				this.borderHiddenVar.Visibility = Visibility.Collapsed;
				this.varCapNameTextBox.BorderThickness = new Thickness(1.0);
				BorderElement.SetCornerRadius(this.varCapNameTextBox, new CornerRadius(4.0));
				return;
			}
			this.borderHiddenVar.Visibility = Visibility.Visible;
			this.varCapNameTextBox.BorderThickness = new Thickness(1.0, 1.0, 0.0, 1.0);
			BorderElement.SetCornerRadius(this.varCapNameTextBox, new CornerRadius(4.0, 0.0, 0.0, 4.0));
		}

		// Token: 0x06000291 RID: 657 RVA: 0x000112C4 File Offset: 0x0000F4C4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/usercontrols/output/varcapoutputbox.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000292 RID: 658 RVA: 0x000112F4 File Offset: 0x0000F4F4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.parent = (VarCapOutputBox)target;
				this.parent.Loaded += this.UserControl_Loaded;
				return;
			case 2:
				this.toggleButton = (ToggleButton)target;
				this.toggleButton.Click += this.CaptureBox_Click;
				return;
			case 3:
				this.b1 = (Border)target;
				return;
			case 4:
				this.b2 = (Border)target;
				return;
			case 5:
				this.outputModeButton = (Button)target;
				this.outputModeButton.Click += this.OutputModeButton_Click;
				return;
			case 6:
				this.varCapNameTextBox = (TextBox)target;
				this.varCapNameTextBox.GotFocus += this.VarCapNameTextBox_GotFocus;
				this.varCapNameTextBox.LostFocus += this.VarCapNameTextBox_LostFocus;
				this.varCapNameTextBox.MouseEnter += this.VarCapNameTextBox_MouseEnter;
				this.varCapNameTextBox.MouseLeave += this.VarCapNameTextBox_MouseLeave;
				return;
			case 7:
				this.borderHiddenVar = (Border)target;
				return;
			case 8:
				this.hiddenVar = (ToggleButton)target;
				this.hiddenVar.GotFocus += this.ToggleButton_GotFocus;
				this.hiddenVar.LostFocus += this.ToggleButton_LostFocus;
				this.hiddenVar.MouseEnter += this.ToggleButton_MouseEnter;
				this.hiddenVar.MouseLeave += this.ToggleButton_MouseLeave;
				return;
			case 9:
				this.encodingBox = (ComboBox)target;
				this.encodingBox.SelectionChanged += this.EncodingBox_SelectionChanged;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x04000136 RID: 310
		public static readonly DependencyProperty OutputModeProperty = DependencyProperty.Register("OutputMode", typeof(OutputMode), typeof(VarCapOutputBox), new PropertyMetadata(1, new PropertyChangedCallback(VarCapOutputBox.OnOutputModeChangedCallBack)));

		// Token: 0x04000137 RID: 311
		public static readonly DependencyProperty ModesOfOutputProperty = DependencyProperty.Register("OutputMode", typeof(OutputMode), typeof(TextInputBox), new PropertyMetadata(56));

		// Token: 0x04000138 RID: 312
		public static readonly DependencyProperty EnableCaptureProperty = DependencyProperty.Register("EnableCapture", typeof(bool), typeof(TextInputBox), new PropertyMetadata(true));

		// Token: 0x04000139 RID: 313
		public static readonly DependencyProperty EnableEncodingProperty = DependencyProperty.Register("EnableEncoding", typeof(bool), typeof(VarCapOutputBox), new PropertyMetadata(false));

		// Token: 0x0400013A RID: 314
		public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(VarCapOutputBox), new PropertyMetadata(""));

		// Token: 0x0400013B RID: 315
		public static readonly DependencyProperty IsCaptureProperty = DependencyProperty.Register("IsCapture", typeof(bool), typeof(VarCapOutputBox), new PropertyMetadata(false));

		// Token: 0x0400013C RID: 316
		public static readonly DependencyProperty EnableHiddenVarProperty = DependencyProperty.Register("EnableHiddenVar", typeof(bool), typeof(VarCapOutputBox), new PropertyMetadata(false, new PropertyChangedCallback(VarCapOutputBox.OnEnableHiddenVarChangedCallBack)));

		// Token: 0x0400013D RID: 317
		public static readonly DependencyProperty IsReadOnlyProperty = DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(VarCapOutputBox), new PropertyMetadata(false));

		// Token: 0x0400013E RID: 318
		public static readonly DependencyProperty EnableOutputTypeProperty = DependencyProperty.Register("EnableOutputMode", typeof(bool), typeof(VarCapOutputBox), new PropertyMetadata(false, delegate(DependencyObject dp, DependencyPropertyChangedEventArgs e)
		{
			object newValue = e.NewValue;
		}));

		// Token: 0x0400013F RID: 319
		public static readonly DependencyProperty EncodingProperty = DependencyProperty.Register("Encoding", typeof(Encoding), typeof(VarCapOutputBox), new PropertyMetadata(Encoding.UTF8));

		// Token: 0x04000140 RID: 320
		public static readonly DependencyProperty HiddenVarProperty = DependencyProperty.Register("HiddenVar", typeof(bool), typeof(VarCapOutputBox), new PropertyMetadata(false));

		// Token: 0x04000141 RID: 321
		private VarCapOutputBox parent;

		// Token: 0x04000142 RID: 322
		private ToggleButton toggleButton;

		// Token: 0x04000143 RID: 323
		private Border b1;

		// Token: 0x04000144 RID: 324
		private Border b2;

		// Token: 0x04000145 RID: 325
		private Button outputModeButton;

		// Token: 0x04000146 RID: 326
		internal TextBox varCapNameTextBox;

		// Token: 0x04000147 RID: 327
		internal Border borderHiddenVar;

		// Token: 0x04000148 RID: 328
		private ToggleButton hiddenVar;

		// Token: 0x04000149 RID: 329
		internal ComboBox encodingBox;

		// Token: 0x0400014A RID: 330
		private bool _contentLoaded;
	}
}
