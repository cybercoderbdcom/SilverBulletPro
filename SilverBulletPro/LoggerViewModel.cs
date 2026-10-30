using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using HandyControl.Controls;
using SilverBulletPro.Core;
using SilverBulletPro.Core.ViewModels;

namespace SilverBulletPro
{
	// Token: 0x0200001E RID: 30
	public class LoggerViewModel : ViewModelBase, ILogger
	{
		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060000F4 RID: 244 RVA: 0x0000908E File Offset: 0x0000728E
		// (set) Token: 0x060000F5 RID: 245 RVA: 0x00009096 File Offset: 0x00007296
		public ObservableCollection<LogEntry> EntriesCollection { get; set; }

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060000F6 RID: 246 RVA: 0x0000909F File Offset: 0x0000729F
		public IEnumerable<LogEntry> Entries
		{
			get
			{
				return this.EntriesCollection;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060000F7 RID: 247 RVA: 0x000090A8 File Offset: 0x000072A8
		public bool Enabled
		{
			get
			{
				bool result;
				try
				{
					result = GlobalData.SBSettings.General.EnableLogging;
				}
				catch
				{
					result = false;
				}
				return result;
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060000F8 RID: 248 RVA: 0x000090E0 File Offset: 0x000072E0
		public int BufferSize
		{
			get
			{
				int result;
				try
				{
					result = GlobalData.SBSettings.General.LogBufferSize;
				}
				catch
				{
					result = 0;
				}
				return result;
			}
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00009118 File Offset: 0x00007318
		public LoggerViewModel()
		{
			this.EntriesCollection = new ObservableCollection<LogEntry>();
			((CollectionView)CollectionViewSource.GetDefaultView(this.EntriesCollection)).Filter = new Predicate<object>(this.ErrorFilter);
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00009158 File Offset: 0x00007358
		public void Refresh()
		{
			try
			{
				CollectionViewSource.GetDefaultView(this.EntriesCollection).Refresh();
			}
			catch
			{
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060000FB RID: 251 RVA: 0x0000918C File Offset: 0x0000738C
		// (set) Token: 0x060000FC RID: 252 RVA: 0x00009194 File Offset: 0x00007394
		public bool OnlyErrors
		{
			get
			{
				return this.onlyErrors;
			}
			set
			{
				this.onlyErrors = value;
				this.OnPropertyChanged("OnlyErrors");
				this.Refresh();
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060000FD RID: 253 RVA: 0x000091AE File Offset: 0x000073AE
		// (set) Token: 0x060000FE RID: 254 RVA: 0x000091B6 File Offset: 0x000073B6
		public string SearchString
		{
			get
			{
				return this.searchString;
			}
			set
			{
				this.searchString = value;
				this.OnPropertyChanged("SearchString");
			}
		}

		// Token: 0x060000FF RID: 255 RVA: 0x000091CC File Offset: 0x000073CC
		private bool ErrorFilter(object item)
		{
			return (string.IsNullOrEmpty(this.SearchString) || (item as LogEntry).LogString.Contains(this.SearchString, StringComparison.OrdinalIgnoreCase)) && (!GlobalData.Logger.OnlyErrors || (item as LogEntry).LogLevel == 2);
		}

		// Token: 0x06000100 RID: 256 RVA: 0x0000921D File Offset: 0x0000741D
		public void Log(string message, LogLevel level, bool prompt = false, int timeout = 0)
		{
			this.Log(Components.Unknown, level, message, prompt, timeout);
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00009230 File Offset: 0x00007430
		public MessageBoxResult Log(Components component, LogLevel level, string message, bool prompt = false, int timeout = 0)
		{
			MessageBoxResult result = MessageBoxResult.None;
			if (prompt)
			{
				if (timeout == 0)
				{
					switch (level)
					{
					case 0:
						Alert.Info(message, "Info", false);
						result = MessageBoxResult.OK;
						break;
					case 1:
						Alert.Warning(message, "Warning", false);
						result = MessageBoxResult.OK;
						break;
					case 2:
						Alert.Error(message, "Error", false);
						result = MessageBoxResult.OK;
						break;
					default:
						Alert.None(message, level.ToString());
						break;
					}
				}
				else
				{
					Window w = new Window
					{
						Width = 0.0,
						Height = 0.0
					};
					Task.Delay(TimeSpan.FromSeconds((double)timeout)).ContinueWith(delegate(Task t)
					{
						w.Close();
					}, TaskScheduler.FromCurrentSynchronizationContext());
					result = MessageBox.Show(w, message, level.ToString(), MessageBoxButton.OK, MessageBoxImage.None, MessageBoxResult.None);
				}
			}
			if (!this.Enabled)
			{
				return result;
			}
			Application.Current.Dispatcher.Invoke(delegate()
			{
				LogEntry entry = new LogEntry(component.ToString(), message, level);
				this.InsertEntry(entry);
				LoggerViewModel.LogToFile(entry);
			});
			return result;
		}

		// Token: 0x06000102 RID: 258 RVA: 0x0000938F File Offset: 0x0000758F
		public void LogInfo(Components component, string message, bool prompt = false, int timeout = 0)
		{
			this.Log(component, 0, message, prompt, timeout);
		}

		// Token: 0x06000103 RID: 259 RVA: 0x0000939E File Offset: 0x0000759E
		public void LogWarning(Components component, string message, bool prompt = false, int timeout = 0)
		{
			this.Log(component, 1, message, prompt, timeout);
		}

		// Token: 0x06000104 RID: 260 RVA: 0x000093AD File Offset: 0x000075AD
		public void LogError(Components component, string message, bool prompt = false, int timeout = 0)
		{
			this.Log(component, 2, message, prompt, timeout);
		}

		// Token: 0x06000105 RID: 261 RVA: 0x000093BC File Offset: 0x000075BC
		private void InsertEntry(LogEntry entry)
		{
			try
			{
				this.EntriesCollection.Insert(0, entry);
				int count = this.EntriesCollection.Count;
				if (count > this.BufferSize)
				{
					this.EntriesCollection.RemoveAt(count - 1);
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00009410 File Offset: 0x00007610
		private static void LogToFile(LogEntry entry)
		{
			try
			{
				if (GlobalData.SBSettings.General.LogToFile)
				{
					string logFile = Constants.LogFile;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 3);
					defaultInterpolatedStringHandler.AppendLiteral("[");
					defaultInterpolatedStringHandler.AppendFormatted<DateTime>(entry.LogTime);
					defaultInterpolatedStringHandler.AppendLiteral("] (");
					defaultInterpolatedStringHandler.AppendFormatted<LogLevel>(entry.LogLevel);
					defaultInterpolatedStringHandler.AppendLiteral(") ");
					defaultInterpolatedStringHandler.AppendFormatted(entry.LogComponent);
					defaultInterpolatedStringHandler.AppendLiteral(" - ");
					File.AppendAllText(logFile, defaultInterpolatedStringHandler.ToStringAndClear() + entry.LogString + Environment.NewLine);
				}
			}
			catch
			{
			}
		}

		// Token: 0x04000071 RID: 113
		private bool onlyErrors;

		// Token: 0x04000072 RID: 114
		private string searchString = "";
	}
}
