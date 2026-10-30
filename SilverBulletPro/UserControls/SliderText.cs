using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace SilverBulletPro.UserControls
{
	// Token: 0x02000033 RID: 51
	public class SliderText : UserControl, IComponentConnector
	{
		// Token: 0x060001D0 RID: 464 RVA: 0x0000DDB4 File Offset: 0x0000BFB4
		public SliderText()
		{
			this.InitializeComponent();
			base.DataContext = this;
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060001D1 RID: 465 RVA: 0x0000DDC9 File Offset: 0x0000BFC9
		// (set) Token: 0x060001D2 RID: 466 RVA: 0x0000DDDB File Offset: 0x0000BFDB
		public string Text
		{
			get
			{
				return (string)base.GetValue(SliderText.TextProperty);
			}
			set
			{
				base.SetValue(SliderText.TextProperty, value);
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x060001D3 RID: 467 RVA: 0x0000DDE9 File Offset: 0x0000BFE9
		// (set) Token: 0x060001D4 RID: 468 RVA: 0x0000DDFB File Offset: 0x0000BFFB
		public Duration Duration
		{
			get
			{
				return (Duration)base.GetValue(SliderText.DurationProperty);
			}
			set
			{
				base.SetValue(SliderText.DurationProperty, value);
			}
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x0000DE10 File Offset: 0x0000C010
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/usercontrols/slidertext.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x0000DE40 File Offset: 0x0000C040
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.stack = (StackPanel)target;
				return;
			case 2:
				this.txtKron = (Label)target;
				return;
			case 3:
				this.transferCurreny2 = (TranslateTransform)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x040000F0 RID: 240
		public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(SliderText));

		// Token: 0x040000F1 RID: 241
		public static readonly DependencyProperty DurationProperty = DependencyProperty.Register("Duration", typeof(Duration), typeof(SliderText), new PropertyMetadata(new Duration(TimeSpan.FromMilliseconds(999.0))));

		// Token: 0x040000F2 RID: 242
		internal StackPanel stack;

		// Token: 0x040000F3 RID: 243
		internal Label txtKron;

		// Token: 0x040000F4 RID: 244
		internal TranslateTransform transferCurreny2;

		// Token: 0x040000F5 RID: 245
		private bool _contentLoaded;
	}
}
