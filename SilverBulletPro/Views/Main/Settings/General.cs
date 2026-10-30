using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using HandyControl.Controls;

namespace SilverBulletPro.Views.Main.Settings
{
	// Token: 0x0200018E RID: 398
	public class General : Page, IComponentConnector
	{
		// Token: 0x060009FC RID: 2556 RVA: 0x0002E7DA File Offset: 0x0002C9DA
		public General()
		{
			this.InitializeComponent();
			base.DataContext = GlobalData.SBSettings.General;
			this.comboBox.SelectedIndex = (GlobalData.SBSettings.General.DisplaySvbScriptOnLoad ? 0 : 1);
		}

		// Token: 0x060009FD RID: 2557 RVA: 0x0002E818 File Offset: 0x0002CA18
		private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				int selectedIndex = (sender as ComboBox).SelectedIndex;
				if (selectedIndex != 0)
				{
					if (selectedIndex == 1)
					{
						GlobalData.SBSettings.General.DisplaySvbScriptOnLoad = false;
					}
				}
				else
				{
					GlobalData.SBSettings.General.DisplaySvbScriptOnLoad = true;
				}
			}
			catch
			{
			}
		}

		// Token: 0x060009FE RID: 2558 RVA: 0x0002E874 File Offset: 0x0002CA74
		private void MinimizeToSysTray_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				GlobalData.MainWindow.MinimizeToSysTray();
			}
			catch
			{
			}
		}

		// Token: 0x060009FF RID: 2559 RVA: 0x0002E8A0 File Offset: 0x0002CAA0
		private void AlwaysOnTop_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				GlobalData.MainWindow.Topmost = GlobalData.SBSettings.General.AlwaysOnTop;
			}
			catch
			{
			}
		}

		// Token: 0x06000A00 RID: 2560 RVA: 0x0002E8DC File Offset: 0x0002CADC
		private void NumericUpDown_TextChanged(object sender, TextChangedEventArgs e)
		{
			try
			{
				if ((sender as NumericUpDown).Tag.ToString() == "Width")
				{
					if (GlobalData.SBSettings.General.StartingWidth >= 10)
					{
						Application.Current.MainWindow.MinWidth = (double)GlobalData.SBSettings.General.StartingWidth;
					}
				}
				else if (GlobalData.SBSettings.General.StartingHeight >= 10)
				{
					Application.Current.MainWindow.MinHeight = (double)GlobalData.SBSettings.General.StartingHeight;
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000A01 RID: 2561 RVA: 0x0002E984 File Offset: 0x0002CB84
		private void AutoSaveCfg_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				GlobalData.MainWindow.ConfigsSecionPage.StackerPage.AutoSaveCfgClicked((sender as CheckBox).IsChecked.GetValueOrDefault());
			}
			catch
			{
			}
		}

		// Token: 0x06000A02 RID: 2562 RVA: 0x0002E9D0 File Offset: 0x0002CBD0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/main/settings/silverbullet/general.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000A03 RID: 2563 RVA: 0x0002EA00 File Offset: 0x0002CC00
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.comboBox = (ComboBox)target;
				this.comboBox.SelectionChanged += this.ComboBox_SelectionChanged;
				return;
			case 2:
				((CheckBox)target).Click += this.AlwaysOnTop_Click;
				return;
			case 3:
				((CheckBox)target).Click += this.MinimizeToSysTray_Click;
				return;
			case 4:
				((CheckBox)target).Click += this.AutoSaveCfg_Click;
				return;
			case 5:
				((NumericUpDown)target).AddHandler(TextBoxBase.TextChangedEvent, new TextChangedEventHandler(this.NumericUpDown_TextChanged));
				return;
			case 6:
				((NumericUpDown)target).AddHandler(TextBoxBase.TextChangedEvent, new TextChangedEventHandler(this.NumericUpDown_TextChanged));
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x040004D4 RID: 1236
		internal ComboBox comboBox;

		// Token: 0x040004D5 RID: 1237
		private bool _contentLoaded;
	}
}
