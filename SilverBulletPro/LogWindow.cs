using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using HandyControl.Controls;
using HandyControl.Data;
using HandyControl.Tools;
using SilverBulletPro.Core;

namespace SilverBulletPro
{
	// Token: 0x0200002F RID: 47
	public class LogWindow : Window, IComponentConnector, IStyleConnector
	{
		// Token: 0x060001A2 RID: 418 RVA: 0x0000D062 File Offset: 0x0000B262
		public LogWindow()
		{
			this.InitializeComponent();
			base.DataContext = GlobalData.Logger;
			base.Closing += this.LogWindowClosing;
			base.Owner = WindowHelper.GetActiveWindow();
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x0000D098 File Offset: 0x0000B298
		private void LogWindowClosing(object sender, CancelEventArgs e)
		{
			GlobalData.LogWindow = null;
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x0000D0A0 File Offset: 0x0000B2A0
		private void copyClick(object sender, RoutedEventArgs e)
		{
			string text = "";
			foreach (object obj in this.logListView.SelectedItems)
			{
				LogEntry logEntry = (LogEntry)obj;
				string str = text;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 3);
				defaultInterpolatedStringHandler.AppendLiteral("[");
				defaultInterpolatedStringHandler.AppendFormatted<DateTime>(logEntry.LogTime);
				defaultInterpolatedStringHandler.AppendLiteral("] (");
				defaultInterpolatedStringHandler.AppendFormatted<LogLevel>(logEntry.LogLevel);
				defaultInterpolatedStringHandler.AppendLiteral(") ");
				defaultInterpolatedStringHandler.AppendFormatted(logEntry.LogComponent);
				defaultInterpolatedStringHandler.AppendLiteral(" - ");
				text = str + defaultInterpolatedStringHandler.ToStringAndClear() + logEntry.LogString + Environment.NewLine;
			}
			Clipboard.SetText(text);
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x0000D188 File Offset: 0x0000B388
		private void copyAllButton_Click(object sender, RoutedEventArgs e)
		{
			string text = "";
			foreach (object obj in ((IEnumerable)this.logListView.Items))
			{
				LogEntry logEntry = (LogEntry)obj;
				string str = text;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 3);
				defaultInterpolatedStringHandler.AppendLiteral("[");
				defaultInterpolatedStringHandler.AppendFormatted<DateTime>(logEntry.LogTime);
				defaultInterpolatedStringHandler.AppendLiteral("] (");
				defaultInterpolatedStringHandler.AppendFormatted<LogLevel>(logEntry.LogLevel);
				defaultInterpolatedStringHandler.AppendLiteral(") ");
				defaultInterpolatedStringHandler.AppendFormatted(logEntry.LogComponent);
				defaultInterpolatedStringHandler.AppendLiteral(" - ");
				text = str + defaultInterpolatedStringHandler.ToStringAndClear() + logEntry.LogString + Environment.NewLine;
			}
			Clipboard.SetText(text);
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x0000D270 File Offset: 0x0000B470
		private void ListViewItem_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
		{
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x0000D274 File Offset: 0x0000B474
		private void clearButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				GlobalData.Logger.EntriesCollection.Clear();
			}
			catch
			{
			}
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x0000D2A8 File Offset: 0x0000B4A8
		private void SearchBar_SearchStarted(object sender, FunctionEventArgs<string> e)
		{
			GlobalData.Logger.SearchString = this.searchBar.Text;
			GlobalData.Logger.Refresh();
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x0000D2C9 File Offset: 0x0000B4C9
		private void SearchBar_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				this.SearchBar_SearchStarted(sender, null);
			}
		}

		// Token: 0x060001AA RID: 426 RVA: 0x0000D2DC File Offset: 0x0000B4DC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/logging/logwindow.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060001AB RID: 427 RVA: 0x0000D30C File Offset: 0x0000B50C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				((MenuItem)target).Click += this.copyClick;
				return;
			case 2:
				this.logListView = (ListView)target;
				return;
			case 4:
				this.copyAllButton = (Button)target;
				this.copyAllButton.Click += this.copyAllButton_Click;
				return;
			case 5:
				this.clearButton = (Button)target;
				this.clearButton.Click += this.clearButton_Click;
				return;
			case 6:
				this.searchBar = (SearchBar)target;
				this.searchBar.KeyDown += this.SearchBar_KeyDown;
				this.searchBar.SearchStarted += this.SearchBar_SearchStarted;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x060001AC RID: 428 RVA: 0x0000D3F0 File Offset: 0x0000B5F0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IStyleConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 3)
			{
				EventSetter eventSetter = new EventSetter();
				eventSetter.Event = UIElement.MouseRightButtonDownEvent;
				eventSetter.Handler = new MouseButtonEventHandler(this.ListViewItem_MouseRightButtonDown);
				((Style)target).Setters.Add(eventSetter);
			}
		}

		// Token: 0x040000D9 RID: 217
		internal ListView logListView;

		// Token: 0x040000DA RID: 218
		internal Button copyAllButton;

		// Token: 0x040000DB RID: 219
		internal Button clearButton;

		// Token: 0x040000DC RID: 220
		internal SearchBar searchBar;

		// Token: 0x040000DD RID: 221
		private bool _contentLoaded;
	}
}
