using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace SilverBulletPro.UserControls
{
	// Token: 0x02000031 RID: 49
	public class CustomTabItem : UserControl, IComponentConnector
	{
		// Token: 0x060001B0 RID: 432 RVA: 0x0000D47D File Offset: 0x0000B67D
		public CustomTabItem()
		{
			this.InitializeComponent();
			base.DataContext = this;
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060001B1 RID: 433 RVA: 0x0000D492 File Offset: 0x0000B692
		// (set) Token: 0x060001B2 RID: 434 RVA: 0x0000D4A4 File Offset: 0x0000B6A4
		public UIElement Icon
		{
			get
			{
				return (UIElement)base.GetValue(CustomTabItem.IconProperty);
			}
			set
			{
				base.SetValue(CustomTabItem.IconProperty, value);
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060001B3 RID: 435 RVA: 0x0000D4B2 File Offset: 0x0000B6B2
		// (set) Token: 0x060001B4 RID: 436 RVA: 0x0000D4C4 File Offset: 0x0000B6C4
		public Thickness MarginIcon
		{
			get
			{
				return (Thickness)base.GetValue(CustomTabItem.MarginIconProperty);
			}
			set
			{
				base.SetValue(CustomTabItem.MarginIconProperty, value);
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060001B5 RID: 437 RVA: 0x0000D4D7 File Offset: 0x0000B6D7
		// (set) Token: 0x060001B6 RID: 438 RVA: 0x0000D4E9 File Offset: 0x0000B6E9
		public double TextWidth
		{
			get
			{
				return (double)base.GetValue(CustomTabItem.TextWidthProperty);
			}
			set
			{
				base.SetValue(CustomTabItem.TextWidthProperty, value);
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060001B7 RID: 439 RVA: 0x0000D4FC File Offset: 0x0000B6FC
		// (set) Token: 0x060001B8 RID: 440 RVA: 0x0000D50E File Offset: 0x0000B70E
		public Thickness MarginText
		{
			get
			{
				return (Thickness)base.GetValue(CustomTabItem.MarginTextProperty);
			}
			set
			{
				base.SetValue(CustomTabItem.MarginTextProperty, value);
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060001B9 RID: 441 RVA: 0x0000D521 File Offset: 0x0000B721
		// (set) Token: 0x060001BA RID: 442 RVA: 0x0000D533 File Offset: 0x0000B733
		public string Text
		{
			get
			{
				return (string)base.GetValue(CustomTabItem.TextProperty);
			}
			set
			{
				base.SetValue(CustomTabItem.TextProperty, value);
			}
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x060001BB RID: 443 RVA: 0x0000D541 File Offset: 0x0000B741
		// (remove) Token: 0x060001BC RID: 444 RVA: 0x0000D54F File Offset: 0x0000B74F
		public event RoutedEventHandler Click
		{
			add
			{
				base.AddHandler(CustomTabItem.ClickEvent, value);
			}
			remove
			{
				base.RemoveHandler(CustomTabItem.ClickEvent, value);
			}
		}

		// Token: 0x060001BD RID: 445 RVA: 0x0000D560 File Offset: 0x0000B760
		private void RaiseClickEvent()
		{
			RoutedEventArgs e = new RoutedEventArgs(CustomTabItem.ClickEvent);
			base.RaiseEvent(e);
		}

		// Token: 0x060001BE RID: 446 RVA: 0x0000D57F File Offset: 0x0000B77F
		private void OnClick()
		{
			this.RaiseClickEvent();
		}

		// Token: 0x060001BF RID: 447 RVA: 0x0000D587 File Offset: 0x0000B787
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			this.OnClick();
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x0000D590 File Offset: 0x0000B790
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/usercontrols/customtabitem.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x0000D5C0 File Offset: 0x0000B7C0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				((Button)target).Click += this.Button_Click;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x0000D5E8 File Offset: 0x0000B7E8
		// Note: this type is marked as 'beforefieldinit'.
		static CustomTabItem()
		{
			CustomTabItem.ClickEvent = EventManager.RegisterRoutedEvent("Click", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(CustomTabItem));
		}

		// Token: 0x040000DF RID: 223
		public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(UIElement), typeof(CustomTabItem));

		// Token: 0x040000E0 RID: 224
		public static readonly DependencyProperty MarginIconProperty = DependencyProperty.Register("MarginIcon", typeof(Thickness), typeof(CustomTabItem));

		// Token: 0x040000E1 RID: 225
		public static readonly DependencyProperty TextWidthProperty = DependencyProperty.Register("TextWidth", typeof(double), typeof(CustomTabItem), new PropertyMetadata(60.0));

		// Token: 0x040000E2 RID: 226
		public static readonly DependencyProperty MarginTextProperty = DependencyProperty.Register("MarginText", typeof(Thickness), typeof(CustomTabItem));

		// Token: 0x040000E3 RID: 227
		public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(CustomTabItem));

		// Token: 0x040000E5 RID: 229
		private bool _contentLoaded;
	}
}
