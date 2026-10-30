using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using SilverBulletPro.Core;

namespace SilverBulletPro
{
	// Token: 0x0200002A RID: 42
	public class DialogShowLog : Page, IComponentConnector
	{
		// Token: 0x06000187 RID: 391 RVA: 0x0000C864 File Offset: 0x0000AA64
		public DialogShowLog(List<LogEntry> log)
		{
			this.InitializeComponent();
			base.DataContext = this.vm;
			this.logRTB.Font = new Font("Consolas", 10f);
			this.logRTB.BackColor = Color.FromArgb(22, 22, 22);
			foreach (LogEntry logEntry in log)
			{
				this.logRTB.AppendText(logEntry.LogString, logEntry.LogColor);
			}
		}

		// Token: 0x06000188 RID: 392 RVA: 0x0000C918 File Offset: 0x0000AB18
		private void searchButton_Click(object sender, RoutedEventArgs e)
		{
			GlobalData.Logger.LogInfo(Components.Stacker, "Seaching for " + this.vm.SearchString, false, 0);
			this.logRTB.SelectAll();
			this.logRTB.SelectionBackColor = Color.FromArgb(22, 22, 22);
			this.logRTB.DeselectAll();
			if (this.vm.SearchString == string.Empty)
			{
				return;
			}
			int selectionStart = this.logRTB.SelectionStart;
			int num = 0;
			this.vm.Indexes.Clear();
			int num2;
			while ((num2 = this.logRTB.Text.IndexOf(this.vm.SearchString, num, StringComparison.InvariantCultureIgnoreCase)) != -1)
			{
				this.logRTB.Select(num2, this.vm.SearchString.Length);
				this.logRTB.SelectionColor = Color.White;
				this.logRTB.SelectionBackColor = Color.Navy;
				num = num2 + this.vm.SearchString.Length;
				this.vm.Indexes.Add(num);
				if (this.vm.Indexes.Count == 1)
				{
					this.logRTB.ScrollToCaret();
				}
			}
			this.vm.UpdateTotalSearchMatches();
			this.logRTB.SelectionStart = selectionStart;
			this.logRTB.SelectionLength = 0;
			this.logRTB.SelectionColor = Color.Black;
			LoggerViewModel logger = GlobalData.Logger;
			Components component = Components.Stacker;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 1);
			defaultInterpolatedStringHandler.AppendLiteral("Found ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.vm.Indexes.Count);
			defaultInterpolatedStringHandler.AppendLiteral(" matches");
			logger.LogInfo(component, defaultInterpolatedStringHandler.ToStringAndClear(), true, 0);
			if (this.vm.Indexes.Count > 0)
			{
				this.vm.CurrentSearchMatch = 1;
			}
		}

		// Token: 0x06000189 RID: 393 RVA: 0x0000CAF0 File Offset: 0x0000ACF0
		private void previousMatchButton_Click(object sender, RoutedEventArgs e)
		{
			if (this.vm.TotalSearchMatches == 0)
			{
				return;
			}
			if (this.vm.CurrentSearchMatch == 1)
			{
				this.vm.CurrentSearchMatch = this.vm.Indexes.Count;
			}
			else
			{
				FullLogViewModel fullLogViewModel = this.vm;
				int currentSearchMatch = fullLogViewModel.CurrentSearchMatch;
				fullLogViewModel.CurrentSearchMatch = currentSearchMatch - 1;
			}
			this.logRTB.DeselectAll();
			this.logRTB.Select(this.vm.Indexes[this.vm.CurrentSearchMatch - 1], 0);
			this.logRTB.ScrollToCaret();
		}

		// Token: 0x0600018A RID: 394 RVA: 0x0000CB8C File Offset: 0x0000AD8C
		private void nextMatchButton_Click(object sender, RoutedEventArgs e)
		{
			if (this.vm.TotalSearchMatches == 0)
			{
				return;
			}
			if (this.vm.CurrentSearchMatch == this.vm.Indexes.Count)
			{
				this.vm.CurrentSearchMatch = 1;
			}
			else
			{
				FullLogViewModel fullLogViewModel = this.vm;
				int currentSearchMatch = fullLogViewModel.CurrentSearchMatch;
				fullLogViewModel.CurrentSearchMatch = currentSearchMatch + 1;
			}
			this.logRTB.DeselectAll();
			this.logRTB.Select(this.vm.Indexes[this.vm.CurrentSearchMatch - 1], 0);
			this.logRTB.ScrollToCaret();
		}

		// Token: 0x0600018B RID: 395 RVA: 0x0000CC28 File Offset: 0x0000AE28
		private void TextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
		{
			try
			{
				if (e.Key == Key.Return)
				{
					this.searchButton_Click(sender, e);
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600018C RID: 396 RVA: 0x0000CC5C File Offset: 0x0000AE5C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/dialogs/dialogshowlog.xaml", UriKind.Relative);
			System.Windows.Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600018D RID: 397 RVA: 0x0000CC8C File Offset: 0x0000AE8C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.logRTB = (System.Windows.Forms.RichTextBox)target;
				return;
			case 2:
				((System.Windows.Controls.TextBox)target).KeyDown += this.TextBox_KeyDown;
				return;
			case 3:
				this.searchButton = (System.Windows.Controls.Button)target;
				this.searchButton.Click += this.searchButton_Click;
				return;
			case 4:
				((System.Windows.Controls.Button)target).Click += this.previousMatchButton_Click;
				return;
			case 5:
				((System.Windows.Controls.Button)target).Click += this.nextMatchButton_Click;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x040000CD RID: 205
		public FullLogViewModel vm = new FullLogViewModel();

		// Token: 0x040000CE RID: 206
		internal System.Windows.Forms.RichTextBox logRTB;

		// Token: 0x040000CF RID: 207
		internal System.Windows.Controls.Button searchButton;

		// Token: 0x040000D0 RID: 208
		private bool _contentLoaded;
	}
}
