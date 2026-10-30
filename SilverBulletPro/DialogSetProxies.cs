using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using SilverBulletPro.Core.Runners;

namespace SilverBulletPro
{
	// Token: 0x02000029 RID: 41
	public class DialogSetProxies : Page, IComponentConnector
	{
		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000180 RID: 384 RVA: 0x0000C601 File Offset: 0x0000A801
		// (set) Token: 0x06000181 RID: 385 RVA: 0x0000C609 File Offset: 0x0000A809
		public object Caller { get; set; }

		// Token: 0x06000182 RID: 386 RVA: 0x0000C614 File Offset: 0x0000A814
		public DialogSetProxies(object caller)
		{
			this.InitializeComponent();
			this.Caller = caller;
			RunnerViewModel runnerViewModel = this.Caller as RunnerViewModel;
			ProxyMode? proxyMode = (runnerViewModel != null) ? new ProxyMode?(runnerViewModel.Options.ProxyMode) : null;
			if (proxyMode != null)
			{
				switch (proxyMode.GetValueOrDefault())
				{
				case 0:
					this.proxiesDefaultRadio.IsChecked = new bool?(true);
					return;
				case 1:
					this.proxiesOnRadio.IsChecked = new bool?(true);
					return;
				case 2:
					this.proxiesOffRadio.IsChecked = new bool?(true);
					return;
				}
			}
			this.proxiesDefaultRadio.IsChecked = new bool?(true);
		}

		// Token: 0x06000183 RID: 387 RVA: 0x0000C6CC File Offset: 0x0000A8CC
		private void selectButton_Click(object sender, RoutedEventArgs e)
		{
			ProxyMode proxyMode = 0;
			if (this.proxiesDefaultRadio.IsChecked.Value)
			{
				proxyMode = 0;
			}
			else if (this.proxiesOnRadio.IsChecked.Value)
			{
				proxyMode = 1;
			}
			else if (this.proxiesOffRadio.IsChecked.Value)
			{
				proxyMode = 2;
			}
			if (this.Caller.GetType() == typeof(RunnerViewModel))
			{
				(this.Caller as RunnerViewModel).Options.ProxyMode = proxyMode;
			}
			((MainDialog)base.Parent).Close();
		}

		// Token: 0x06000184 RID: 388 RVA: 0x0000C768 File Offset: 0x0000A968
		private void Page_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.Key == Key.Return)
				{
					this.selectButton_Click(sender, e);
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000185 RID: 389 RVA: 0x0000C79C File Offset: 0x0000A99C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/dialogs/dialogsetproxies.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000186 RID: 390 RVA: 0x0000C7CC File Offset: 0x0000A9CC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				((DialogSetProxies)target).KeyDown += this.Page_KeyDown;
				return;
			case 2:
				this.proxiesDefaultRadio = (RadioButton)target;
				return;
			case 3:
				this.proxiesOnRadio = (RadioButton)target;
				return;
			case 4:
				this.proxiesOffRadio = (RadioButton)target;
				return;
			case 5:
				this.selectButton = (Button)target;
				this.selectButton.Click += this.selectButton_Click;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x040000C8 RID: 200
		internal RadioButton proxiesDefaultRadio;

		// Token: 0x040000C9 RID: 201
		internal RadioButton proxiesOnRadio;

		// Token: 0x040000CA RID: 202
		internal RadioButton proxiesOffRadio;

		// Token: 0x040000CB RID: 203
		internal Button selectButton;

		// Token: 0x040000CC RID: 204
		private bool _contentLoaded;
	}
}
