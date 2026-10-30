using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;
using SilverBulletPro.Core;
using SilverBulletPro.Core.Extensions;

namespace SilverBulletPro.Views.Main.Tools
{
	// Token: 0x0200018A RID: 394
	public partial class TessDataDownloader : Page
	{
		// Token: 0x060009CD RID: 2509 RVA: 0x0002D477 File Offset: 0x0002B677
		public TessDataDownloader()
		{
			this.InitializeComponent();
		}

		// Token: 0x060009CE RID: 2510 RVA: 0x0002D4AC File Offset: 0x0002B6AC
		private void LoadSite_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
		{
			try
			{
				this.DispatcherInvoke(delegate
				{
					this.progressBar.Value = (double)e.ProgressPercentage;
				});
			}
			catch
			{
			}
		}

		// Token: 0x060009CF RID: 2511 RVA: 0x0002D4F4 File Offset: 0x0002B6F4
		private void DownloadBtn_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				TessDataDownloader.<>c__DisplayClass8_0 CS$<>8__locals1 = new TessDataDownloader.<>c__DisplayClass8_0();
				CS$<>8__locals1.<>4__this = this;
				this.LogsText.Clear();
				this.progressBar.Value = 0.0;
				CS$<>8__locals1.i = 0;
				TextBox logsText = this.LogsText;
				logsText.Text = logsText.Text + "Downloading tessdata files..." + Environment.NewLine;
				CS$<>8__locals1.items = this.DownloadList.Items;
				try
				{
					Task task = this.taskDl;
					if (task != null)
					{
						task.Dispose();
					}
				}
				catch
				{
				}
				this.taskDl = Task.Run(delegate()
				{
					TessDataDownloader.<>c__DisplayClass8_0.<<DownloadBtn_Click>b__0>d <<DownloadBtn_Click>b__0>d;
					<<DownloadBtn_Click>b__0>d.<>t__builder = AsyncTaskMethodBuilder.Create();
					<<DownloadBtn_Click>b__0>d.<>4__this = CS$<>8__locals1;
					<<DownloadBtn_Click>b__0>d.<>1__state = -1;
					<<DownloadBtn_Click>b__0>d.<>t__builder.Start<TessDataDownloader.<>c__DisplayClass8_0.<<DownloadBtn_Click>b__0>d>(ref <<DownloadBtn_Click>b__0>d);
					return <<DownloadBtn_Click>b__0>d.<>t__builder.Task;
				}).ContinueWith(delegate(Task t)
				{
					this.DispatcherInvoke(delegate
					{
						TextBox logsText2 = this.LogsText;
						logsText2.Text += "Your chosen languages have been downloaded ";
					});
					try
					{
						t.Dispose();
					}
					catch
					{
					}
				});
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x060009D0 RID: 2512 RVA: 0x0002D5D0 File Offset: 0x0002B7D0
		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			try
			{
				this.LogsText.Clear();
				this.LanguageList.Items.Clear();
				this.LogsText.Text = "Downloading language list...\n";
				Task.Run<string>(() => this.siteResponse = this.loadSite.DownloadString(this.url)).ContinueWith(delegate([Nullable(new byte[]
				{
					1,
					0
				})] Task<string> c)
				{
					foreach (object obj in this.lang.Matches(this.siteResponse))
					{
						Match match = (Match)obj;
						string val = match.Groups[1].Value.Split('"', StringSplitOptions.None).First<string>();
						if (Path.GetExtension(val) == ".traineddata")
						{
							base.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new ThreadStart(delegate()
							{
								this.LanguageList.Items.Add(Path.GetFileNameWithoutExtension(val) + " (" + Path.GetExtension(val).ToLower().Split('.', StringSplitOptions.None)[1] + ")");
							}));
						}
					}
					this.DispatcherInvoke(delegate
					{
						TextBox logsText = this.LogsText;
						logsText.Text = logsText.Text + "Downloading language list Finished!" + Environment.NewLine;
					});
				});
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x060009D1 RID: 2513 RVA: 0x0002D64C File Offset: 0x0002B84C
		private void DispatcherInvoke(Action action)
		{
			base.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new ThreadStart(delegate()
			{
				Action action2 = action;
				if (action2 == null)
				{
					return;
				}
				action2();
			}));
		}

		// Token: 0x060009D2 RID: 2514 RVA: 0x0002D680 File Offset: 0x0002B880
		public Task DownloadLanguage(int i, string language)
		{
			TessDataDownloader.<DownloadLanguage>d__11 <DownloadLanguage>d__;
			<DownloadLanguage>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<DownloadLanguage>d__.<>4__this = this;
			<DownloadLanguage>d__.language = language;
			<DownloadLanguage>d__.<>1__state = -1;
			<DownloadLanguage>d__.<>t__builder.Start<TessDataDownloader.<DownloadLanguage>d__11>(ref <DownloadLanguage>d__);
			return <DownloadLanguage>d__.<>t__builder.Task;
		}

		// Token: 0x060009D3 RID: 2515 RVA: 0x0002D6CB File Offset: 0x0002B8CB
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			this.DownloadList.Items.Add(this.LanguageList.SelectedItem);
		}

		// Token: 0x060009D4 RID: 2516 RVA: 0x0002D6E9 File Offset: 0x0002B8E9
		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			this.DownloadList.Items.Remove(this.DownloadList.SelectedItem);
		}

		// Token: 0x060009D5 RID: 2517 RVA: 0x0002D708 File Offset: 0x0002B908
		private void Button_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (Alert.Choice("This button will add ALL languages to the download list", "ALERT", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				foreach (object obj in ((IEnumerable)this.LanguageList.Items))
				{
					string newItem = (string)obj;
					this.DownloadList.Items.Add(newItem);
				}
			}
		}

		// Token: 0x060009D6 RID: 2518 RVA: 0x0002D788 File Offset: 0x0002B988
		private void Button_MouseRightButtonDown_1(object sender, MouseButtonEventArgs e)
		{
			if (Alert.Choice("This button will remove ALL languages to the download list", "ALERT", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				this.DownloadList.Items.Clear();
			}
		}

		// Token: 0x060009D7 RID: 2519 RVA: 0x0002D7AF File Offset: 0x0002B9AF
		private void Button_Click_2(object sender, RoutedEventArgs e)
		{
		}

		// Token: 0x060009D8 RID: 2520 RVA: 0x0002D7B4 File Offset: 0x0002B9B4
		private void OpenFolderButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				ProcessExtension.Start(Path.Combine(Directory.GetCurrentDirectory(), Constants.TessdataFolder));
			}
			catch
			{
			}
		}

		// Token: 0x040004A6 RID: 1190
		private WebClient loadSite = new WebClient();

		// Token: 0x040004A7 RID: 1191
		public string url = "https://github.com/tesseract-ocr/tessdata";

		// Token: 0x040004A8 RID: 1192
		public string siteResponse;

		// Token: 0x040004A9 RID: 1193
		public string language;

		// Token: 0x040004AA RID: 1194
		private Regex lang = new Regex("href=\"/tesseract-ocr/tessdata/blob/main/(.*?)\"");

		// Token: 0x040004AB RID: 1195
		private Task taskDl;
	}
}
