using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Newtonsoft.Json.Linq;
using SilverBulletPro.Core;
using SilverBulletPro.Core.Extensions;
using SilverBulletPro.Updater;
using SilverBulletPro.Views.Dialogs;

namespace SilverBulletPro.UserControls
{
	// Token: 0x02000032 RID: 50
	public class NonClientAreaContent : Grid, IComponentConnector
	{
		// Token: 0x060001C3 RID: 451 RVA: 0x0000D6DB File Offset: 0x0000B8DB
		public NonClientAreaContent()
		{
			this.InitializeComponent();
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x0000D6EC File Offset: 0x0000B8EC
		private void ButtonLangs_OnClick(object sender, RoutedEventArgs e)
		{
			Button button = e.OriginalSource as Button;
			if (button != null)
			{
				string text = button.Tag as string;
				if (text != null)
				{
					this.PopupLangs.IsOpen = false;
					if (text.Equals(GlobalData.SBSettings.Language.CultureName))
					{
						return;
					}
					App.SetLanguageDictionary(new CultureInfo(text));
					try
					{
						GlobalData.SBSettings.Language.CultureName = text;
						JToken jtoken = JToken.Parse(IOManager.ReadString(Constants.SBSettingsFile));
						jtoken["Language"]["CultureName"] = text;
						IOManager.SaveString(Constants.SBSettingsFile, jtoken.ToString());
					}
					catch
					{
					}
				}
			}
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x0000D7AC File Offset: 0x0000B9AC
		private void ButtonOpenLangs_OnClick(object sender, RoutedEventArgs e)
		{
			this.PopupLangs.IsOpen = true;
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x0000D7BC File Offset: 0x0000B9BC
		private void ButtonOpenTelegram_OnClick(object sender, RoutedEventArgs e)
		{
			try
			{
				string url = string.Empty;
				Task.Run(delegate()
				{
					using (HttpClient httpClient = new HttpClient())
					{
						httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd(Constants.UserAgent);
						url = httpClient.GetStringAsync("https://raw.githubusercontent.com/mohamm4dx/SilverBulletPro/main/Telegram.txt").ConfigureAwait(false).GetAwaiter().GetResult();
					}
				}).ContinueWith(delegate(Task t)
				{
					if (string.IsNullOrWhiteSpace(url))
					{
						Alert.Error("Not found!", "Error", false);
						return;
					}
					try
					{
						ProcessExtension.Start(url);
					}
					catch
					{
						if (!url.Contains("domain="))
						{
							throw;
						}
						Process.Start("https://t.me/" + url.Split("domain=", StringSplitOptions.RemoveEmptyEntries)[1]);
					}
					try
					{
						t.Dispose();
					}
					catch
					{
					}
				});
			}
			catch (InvalidOperationException)
			{
			}
			catch (NullReferenceException)
			{
			}
			catch (Exception)
			{
				Alert.Error("An error occurred", "Error", false);
			}
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x0000D840 File Offset: 0x0000BA40
		private void ButtonOpenDiscord_OnClick(object sender, RoutedEventArgs e)
		{
			try
			{
				string url = string.Empty;
				Task.Run(delegate()
				{
					using (HttpClient httpClient = new HttpClient())
					{
						httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd(Constants.UserAgent);
						url = httpClient.GetStringAsync("https://raw.githubusercontent.com/mohamm4dx/SilverBullet/master/OpenBullet/Discoard.txt").ConfigureAwait(false).GetAwaiter().GetResult();
					}
				}).ContinueWith(delegate(Task t)
				{
					if (string.IsNullOrWhiteSpace(url))
					{
						Alert.Error("Not found!", "Error", false);
						return;
					}
					Process.Start(url).Dispose();
					try
					{
						t.Dispose();
					}
					catch
					{
					}
				});
			}
			catch (InvalidOperationException)
			{
			}
			catch (NullReferenceException)
			{
			}
			catch (Exception)
			{
				Alert.Error("An error occurred", "Error", false);
			}
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x0000D8C4 File Offset: 0x0000BAC4
		private void ButtonCamera_OnClick(object sender, RoutedEventArgs e)
		{
			if (!Directory.Exists("Screenshots"))
			{
				Directory.CreateDirectory("Screenshots");
			}
			this.CaptureScreen(Application.Current.MainWindow, "Screenshots\\Screenshot-" + DateTime.Now.ToString("ddMMyyyy-hhmmss") + ".png");
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x0000D91C File Offset: 0x0000BB1C
		public void CaptureScreen(UIElement source, string path)
		{
			try
			{
				double height;
				double num = height = source.RenderSize.Height;
				double width;
				RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap((int)(width = source.RenderSize.Width), (int)num, 96.0, 96.0, PixelFormats.Pbgra32);
				VisualBrush brush = new VisualBrush(source);
				DrawingVisual drawingVisual = new DrawingVisual();
				using (DrawingContext drawingContext = drawingVisual.RenderOpen())
				{
					drawingContext.DrawRectangle(brush, null, new Rect(new Point(0.0, 0.0), new Point(width, height)));
				}
				renderTargetBitmap.Render(drawingVisual);
				PngBitmapEncoder pngBitmapEncoder = new PngBitmapEncoder();
				pngBitmapEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
				using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
				{
					pngBitmapEncoder.Save(fileStream);
				}
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x060001CA RID: 458 RVA: 0x0000DA38 File Offset: 0x0000BC38
		private void ButtonOpenLog_OnClick(object sender, RoutedEventArgs e)
		{
			if (GlobalData.LogWindow == null)
			{
				GlobalData.LogWindow = new LogWindow();
				GlobalData.LogWindow.Show();
				return;
			}
			GlobalData.LogWindow.Show();
		}

		// Token: 0x060001CB RID: 459 RVA: 0x0000DA60 File Offset: 0x0000BC60
		private void ButtonChangeLog_OnClick(object sender, RoutedEventArgs e)
		{
			try
			{
				using (HttpClient httpClient = new HttpClient())
				{
					httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd(Constants.UserAgent);
					string result = httpClient.GetStringAsync("https://raw.githubusercontent.com/mohamm4dx/SilverBulletPro/main/Changelog.md").ConfigureAwait(false).GetAwaiter().GetResult();
					new MainDialog(new MainDialog.InputDialog
					{
						Dialog = new DialogChangeLog
						{
							markDown = 
							{
								Markdown = result
							}
						},
						Title = "Changelog"
					}).ShowDialog();
				}
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x060001CC RID: 460 RVA: 0x0000DB14 File Offset: 0x0000BD14
		private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				this.CheckForUpdate(true);
			}
			catch
			{
			}
		}

		// Token: 0x060001CD RID: 461 RVA: 0x0000DB40 File Offset: 0x0000BD40
		public void CheckForUpdate(bool showPrompt = true)
		{
			Transform updateBtnRenderTransform = this.ButtonUpdate.RenderTransform;
			Storyboard stWait = (Storyboard)base.FindResource("StWait");
			try
			{
				stWait.Begin();
				Action <>9__4;
				Action <>9__2;
				Task.Run(delegate()
				{
					try
					{
						LatestRelease latestRelease = UpdateChecker.Run<LatestRelease>("https://api.github.com/repos/mohamm4dx/SilverBulletPro/releases/latest");
						Assets[] assets = latestRelease.Assets;
						if (assets != null && assets.Length != 0 && latestRelease.Available)
						{
							this.Dispatcher.Invoke(delegate()
							{
								stWait.Stop();
								this.ButtonUpdate.RenderTransform = updateBtnRenderTransform;
								if (showPrompt)
								{
									MainDialog.InputDialog inputDialog = new MainDialog.InputDialog();
									inputDialog.Dialog = new DialogUpdateDetails(latestRelease);
									DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(11, 1);
									defaultInterpolatedStringHandler.AppendLiteral("Details [v");
									defaultInterpolatedStringHandler.AppendFormatted<Version>(latestRelease.Ver);
									defaultInterpolatedStringHandler.AppendLiteral("]");
									inputDialog.Title = defaultInterpolatedStringHandler.ToStringAndClear();
									new MainDialog(inputDialog).ShowDialog();
								}
								this.ButtonUpdate.SetResourceReference(Control.ForegroundProperty, "ForegroundBad");
								this.ButtonUpdate.ToolTip = "Update is available";
								this.labelUpdate.Visibility = Visibility.Visible;
							});
						}
						else
						{
							Dispatcher dispatcher = this.Dispatcher;
							Action callback;
							if ((callback = <>9__4) == null)
							{
								callback = (<>9__4 = delegate()
								{
									this.ButtonUpdate.SetResourceReference(Control.ForegroundProperty, "ForegroundMain");
									this.ButtonUpdate.ToolTip = "Check For Updates...";
									this.labelUpdate.Visibility = Visibility.Collapsed;
									stWait.Stop();
									this.ButtonUpdate.RenderTransform = updateBtnRenderTransform;
								});
							}
							dispatcher.Invoke(callback);
							if (showPrompt)
							{
								this.Dispatcher.Invoke(delegate()
								{
									Alert.Info("There are currently no updates available", "Info", false);
								});
							}
						}
					}
					finally
					{
						Dispatcher dispatcher2 = this.Dispatcher;
						Action callback2;
						if ((callback2 = <>9__2) == null)
						{
							callback2 = (<>9__2 = delegate()
							{
								stWait.Stop();
								this.ButtonUpdate.RenderTransform = updateBtnRenderTransform;
							});
						}
						dispatcher2.Invoke(callback2);
					}
				}).ContinueWith(delegate(Task t)
				{
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
				base.Dispatcher.Invoke(delegate()
				{
					stWait.Stop();
					this.ButtonUpdate.RenderTransform = updateBtnRenderTransform;
				});
				if (showPrompt)
				{
					Alert.Exception(ex, "");
				}
			}
		}

		// Token: 0x060001CE RID: 462 RVA: 0x0000DC08 File Offset: 0x0000BE08
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/usercontrols/nonclientareacontent.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060001CF RID: 463 RVA: 0x0000DC38 File Offset: 0x0000BE38
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.ButtonOpenLog = (Button)target;
				this.ButtonOpenLog.Click += this.ButtonOpenLog_OnClick;
				return;
			case 2:
				this.ButtonCamera = (Button)target;
				this.ButtonCamera.Click += this.ButtonCamera_OnClick;
				return;
			case 3:
				this.ButtonOpenDiscord = (Button)target;
				this.ButtonOpenDiscord.Click += this.ButtonOpenDiscord_OnClick;
				return;
			case 4:
				this.ButtonOpenTelegram = (Button)target;
				this.ButtonOpenTelegram.Click += this.ButtonOpenTelegram_OnClick;
				return;
			case 5:
				this.ButtonChangeLog = (Button)target;
				this.ButtonChangeLog.Click += this.ButtonChangeLog_OnClick;
				return;
			case 6:
				this.ButtonOpenLangs = (Button)target;
				this.ButtonOpenLangs.Click += this.ButtonOpenLangs_OnClick;
				return;
			case 7:
				this.PopupLangs = (Popup)target;
				return;
			case 8:
				((StackPanel)target).AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(this.ButtonLangs_OnClick));
				return;
			case 9:
				this.ButtonUpdate = (Button)target;
				this.ButtonUpdate.Click += this.ButtonUpdate_Click;
				return;
			case 10:
				this.labelUpdate = (Label)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x040000E6 RID: 230
		internal Button ButtonOpenLog;

		// Token: 0x040000E7 RID: 231
		internal Button ButtonCamera;

		// Token: 0x040000E8 RID: 232
		internal Button ButtonOpenDiscord;

		// Token: 0x040000E9 RID: 233
		internal Button ButtonOpenTelegram;

		// Token: 0x040000EA RID: 234
		internal Button ButtonChangeLog;

		// Token: 0x040000EB RID: 235
		internal Button ButtonOpenLangs;

		// Token: 0x040000EC RID: 236
		internal Popup PopupLangs;

		// Token: 0x040000ED RID: 237
		internal Button ButtonUpdate;

		// Token: 0x040000EE RID: 238
		internal Label labelUpdate;

		// Token: 0x040000EF RID: 239
		private bool _contentLoaded;
	}
}
