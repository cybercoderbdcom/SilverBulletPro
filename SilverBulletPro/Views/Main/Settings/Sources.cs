using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using SilverBulletPro.Models;
using SilverBulletPro.ViewModels;

namespace SilverBulletPro.Views.Main.Settings
{
	// Token: 0x02000190 RID: 400
	public class Sources : Page, IComponentConnector, IStyleConnector
	{
		// Token: 0x06000A07 RID: 2567 RVA: 0x0002EB39 File Offset: 0x0002CD39
		public Sources()
		{
			this.vm = GlobalData.SBSettings.Sources;
			base.DataContext = this.vm;
			this.InitializeComponent();
		}

		// Token: 0x06000A08 RID: 2568 RVA: 0x0002EB70 File Offset: 0x0002CD70
		private void authTypeCombobox_Loaded(object sender, RoutedEventArgs e)
		{
			Source sourceById = this.vm.GetSourceById((int)(sender as ComboBox).Tag);
			if (sourceById.AuthInitialized)
			{
				return;
			}
			sourceById.AuthInitialized = true;
			foreach (string newItem in Enum.GetNames(typeof(Source.AuthMode)))
			{
				(sender as ComboBox).Items.Add(newItem);
			}
			(sender as ComboBox).SelectedIndex = (int)sourceById.Auth;
		}

		// Token: 0x06000A09 RID: 2569 RVA: 0x0002EBF0 File Offset: 0x0002CDF0
		private void authTypeCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			ComboBox comboBox = sender as ComboBox;
			Source sourceById = this.vm.GetSourceById((int)comboBox.Tag);
			sourceById.Auth = (Source.AuthMode)comboBox.SelectedIndex;
			if (sourceById.Auth != Source.AuthMode.UserPass)
			{
				(comboBox.ToolTip as ColumnDefinition).Width = new GridLength(0.0);
				return;
			}
			((ColumnDefinition)comboBox.ToolTip).Width = new GridLength(1.0, GridUnitType.Star);
		}

		// Token: 0x06000A0A RID: 2570 RVA: 0x0002EC6C File Offset: 0x0002CE6C
		private void removeSourceButton_Click(object sender, RoutedEventArgs e)
		{
			this.vm.RemoveSourceById((int)(sender as Button).Tag);
		}

		// Token: 0x06000A0B RID: 2571 RVA: 0x0002EC89 File Offset: 0x0002CE89
		private void clearSourcesButton_Click(object sender, RoutedEventArgs e)
		{
			this.vm.Sources.Clear();
		}

		// Token: 0x06000A0C RID: 2572 RVA: 0x0002EC9B File Offset: 0x0002CE9B
		private void addSourceButton_Click(object sender, RoutedEventArgs e)
		{
			this.vm.Sources.Add(new Source(this.rand.Next()));
		}

		// Token: 0x06000A0D RID: 2573 RVA: 0x0002ECC0 File Offset: 0x0002CEC0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/main/settings/silverbullet/sources.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000A0E RID: 2574 RVA: 0x0002ECF0 File Offset: 0x0002CEF0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				((Button)target).Click += this.addSourceButton_Click;
				return;
			}
			if (connectionId != 2)
			{
				this._contentLoaded = true;
				return;
			}
			((Button)target).Click += this.clearSourcesButton_Click;
		}

		// Token: 0x06000A0F RID: 2575 RVA: 0x0002ED40 File Offset: 0x0002CF40
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IStyleConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 3)
			{
				((ComboBox)target).Loaded += this.authTypeCombobox_Loaded;
				((ComboBox)target).SelectionChanged += this.authTypeCombobox_SelectionChanged;
				return;
			}
			if (connectionId != 4)
			{
				return;
			}
			((Button)target).Click += this.removeSourceButton_Click;
		}

		// Token: 0x040004D7 RID: 1239
		private SBSettingsSources vm;

		// Token: 0x040004D8 RID: 1240
		private Random rand = new Random();

		// Token: 0x040004D9 RID: 1241
		private bool _contentLoaded;
	}
}
