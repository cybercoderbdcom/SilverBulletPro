using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using SilverBulletPro.Extensions;

namespace SilverBulletPro.Views.UserControls
{
	// Token: 0x0200003A RID: 58
	public partial class ProgressDialog : UserControl
	{
		// Token: 0x060002A0 RID: 672 RVA: 0x00011AFF File Offset: 0x0000FCFF
		public ProgressDialog()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x060002A1 RID: 673 RVA: 0x00011B18 File Offset: 0x0000FD18
		// (set) Token: 0x060002A2 RID: 674 RVA: 0x00011B2A File Offset: 0x0000FD2A
		public string Description
		{
			get
			{
				return (string)base.GetValue(ProgressDialog.DescriptionProperty);
			}
			set
			{
				base.SetValue(ProgressDialog.DescriptionProperty, value);
			}
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x060002A3 RID: 675 RVA: 0x00011B38 File Offset: 0x0000FD38
		// (set) Token: 0x060002A4 RID: 676 RVA: 0x00011B4A File Offset: 0x0000FD4A
		public double Value
		{
			get
			{
				return (double)base.GetValue(ProgressDialog.ValueProperty);
			}
			set
			{
				base.SetValue(ProgressDialog.ValueProperty, value);
			}
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x060002A5 RID: 677 RVA: 0x00011B5D File Offset: 0x0000FD5D
		// (set) Token: 0x060002A6 RID: 678 RVA: 0x00011B6F File Offset: 0x0000FD6F
		public bool IsIndeterminate
		{
			get
			{
				return (bool)base.GetValue(ProgressDialog.IsIndeterminateProperty);
			}
			set
			{
				base.SetValue(ProgressDialog.IsIndeterminateProperty, value);
			}
		}

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x060002A7 RID: 679 RVA: 0x00011B82 File Offset: 0x0000FD82
		// (remove) Token: 0x060002A8 RID: 680 RVA: 0x00011B9C File Offset: 0x0000FD9C
		public event RoutedEventHandler Dismiss
		{
			add
			{
				base.AddHandler(ProgressDialog.ClickEvent, value);
				this.Delegates.Add(value);
			}
			remove
			{
				base.RemoveHandler(ProgressDialog.ClickEvent, value);
				this.Delegates.Remove(value);
			}
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x00011BB7 File Offset: 0x0000FDB7
		private void RaiseClickEvent()
		{
			base.RaiseEvent(new RoutedEventArgs(ProgressDialog.ClickEvent));
		}

		// Token: 0x060002AA RID: 682 RVA: 0x00011BC9 File Offset: 0x0000FDC9
		private void OnClick()
		{
			this.RaiseClickEvent();
		}

		// Token: 0x060002AB RID: 683 RVA: 0x00011BD1 File Offset: 0x0000FDD1
		private void Dismiss_Click(object sender, RoutedEventArgs e)
		{
			this.OnClick();
		}

		// Token: 0x060002AC RID: 684 RVA: 0x00011BDC File Offset: 0x0000FDDC
		public void ClearDismissEvents(int? skip = null)
		{
			for (int i = this.Delegates.Count - 1; i >= skip.GetValueOrDefault(0); i--)
			{
				this.Dismiss -= this.Delegates[i];
			}
		}

		// Token: 0x060002AD RID: 685 RVA: 0x00011C1C File Offset: 0x0000FE1C
		public bool Enable(UIElement element, TimeSpan duration = default(TimeSpan))
		{
			if (duration == default(TimeSpan))
			{
				duration = TimeSpan.FromMilliseconds(500.0);
			}
			element.IsHitTestVisible = false;
			base.Visibility = Visibility.Visible;
			try
			{
				element.BlurApply(0.0, 1.0, duration, false);
			}
			catch
			{
				return false;
			}
			return true;
		}

		// Token: 0x060002AE RID: 686 RVA: 0x00011C8C File Offset: 0x0000FE8C
		public bool Disable(UIElement element, TimeSpan duration = default(TimeSpan))
		{
			if (duration == default(TimeSpan))
			{
				duration = TimeSpan.FromSeconds(0.1);
			}
			element.IsHitTestVisible = true;
			base.Visibility = Visibility.Collapsed;
			try
			{
				element.BlurDisable(duration);
			}
			catch
			{
				return false;
			}
			return true;
		}

		// Token: 0x0400014F RID: 335
		private List<RoutedEventHandler> Delegates = new List<RoutedEventHandler>();

		// Token: 0x04000150 RID: 336
		public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register("Description", typeof(string), typeof(ProgressDialog), new PropertyMetadata("Please wait..."));

		// Token: 0x04000151 RID: 337
		public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(double), typeof(ProgressDialog), new PropertyMetadata(0.0));

		// Token: 0x04000152 RID: 338
		public static readonly DependencyProperty IsIndeterminateProperty = DependencyProperty.Register("IsIndeterminate", typeof(bool), typeof(ProgressDialog), new PropertyMetadata(false));

		// Token: 0x04000153 RID: 339
		public static readonly RoutedEvent ClickEvent = EventManager.RegisterRoutedEvent("Dismiss", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ProgressDialog));
	}
}
