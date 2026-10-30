using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using HandyControl.Controls;
using HandyControl.Data;
using SilverBulletPro.Core;
using SilverBulletPro.Core.Extensions;
using SilverBulletPro.Models;
using SilverBulletPro.ViewModels;

namespace SilverBulletPro.Views.Main
{
	// Token: 0x02000184 RID: 388
	public class VerifiedMarket : Page, IComponentConnector, IStyleConnector
	{
		// Token: 0x06000984 RID: 2436 RVA: 0x0002B5CC File Offset: 0x000297CC
		public VerifiedMarket()
		{
			this.InitializeComponent();
			base.DataContext = (this.vm = GlobalData.VerifiedMarket);
		}

		// Token: 0x06000985 RID: 2437 RVA: 0x0002B5FC File Offset: 0x000297FC
		private void MediaElemControl_Click(object sender, RoutedEventArgs e)
		{
			Button button = sender as Button;
			MediaElement mediaElement = button.Tag as MediaElement;
			if (button.CommandParameter.ToString() == "Play")
			{
				mediaElement.Position = TimeSpan.Zero;
				mediaElement.LoadedBehavior = MediaState.Close;
				mediaElement.LoadedBehavior = MediaState.Play;
				button.CommandParameter = "Stop";
				IconElement.SetGeometry(button, Geometry.Parse("M256 8C119 8 8 119 8 256s111 248 248 248 248-111 248-248S393 8 256 8zm96 328c0 8.8-7.2 16-16 16H176c-8.8 0-16-7.2-16-16V176c0-8.8 7.2-16 16-16h160c8.8 0 16 7.2 16 16v160z"));
				return;
			}
			mediaElement.LoadedBehavior = MediaState.Stop;
			button.CommandParameter = "Play";
			IconElement.SetGeometry(button, Geometry.Parse("M256 8C119 8 8 119 8 256s111 248 248 248 248-111 248-248S393 8 256 8zm115.7 272l-176 101c-15.8 8.8-35.7-2.5-35.7-21V152c0-18.4 19.8-29.8 35.7-21l176 107c16.4 9.2 16.4 32.9 0 42z"));
		}

		// Token: 0x06000986 RID: 2438 RVA: 0x0002B68C File Offset: 0x0002988C
		private void MediaElement_MediaOpened(object sender, RoutedEventArgs e)
		{
			if ((sender as MediaElement).LoadedBehavior == MediaState.Stop)
			{
				return;
			}
			Button button = (Button)((FrameworkElement)(sender as MediaElement).Parent).Tag;
			button.CommandParameter = "Stop";
			IconElement.SetGeometry(button, Geometry.Parse("M256 8C119 8 8 119 8 256s111 248 248 248 248-111 248-248S393 8 256 8zm96 328c0 8.8-7.2 16-16 16H176c-8.8 0-16-7.2-16-16V176c0-8.8 7.2-16 16-16h160c8.8 0 16 7.2 16 16v160z"));
		}

		// Token: 0x06000987 RID: 2439 RVA: 0x0002B6DC File Offset: 0x000298DC
		private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
		{
			Button button = (Button)((FrameworkElement)(sender as MediaElement).Parent).Tag;
			button.CommandParameter = "Play";
			IconElement.SetGeometry(button, Geometry.Parse("M256 8C119 8 8 119 8 256s111 248 248 248 248-111 248-248S393 8 256 8zm115.7 272l-176 101c-15.8 8.8-35.7-2.5-35.7-21V152c0-18.4 19.8-29.8 35.7-21l176 107c16.4 9.2 16.4 32.9 0 42z"));
		}

		// Token: 0x06000988 RID: 2440 RVA: 0x0002B712 File Offset: 0x00029912
		private void MediaElement_MediaFailed(object sender, ExceptionRoutedEventArgs e)
		{
			Button button = (Button)((FrameworkElement)(sender as MediaElement).Parent).Tag;
			button.CommandParameter = "Play";
			IconElement.SetGeometry(button, Geometry.Parse("M256 8C119 8 8 119 8 256s111 248 248 248 248-111 248-248S393 8 256 8zm115.7 272l-176 101c-15.8 8.8-35.7-2.5-35.7-21V152c0-18.4 19.8-29.8 35.7-21l176 107c16.4 9.2 16.4 32.9 0 42z"));
		}

		// Token: 0x06000989 RID: 2441 RVA: 0x0002B748 File Offset: 0x00029948
		private void ButtonBuy_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				ProcessExtension.Start((sender as Button).Tag.ToString());
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x0600098A RID: 2442 RVA: 0x0002B788 File Offset: 0x00029988
		private void ButtonReport_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				ProcessExtension.Start((sender as Button).Tag.ToString());
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x0600098B RID: 2443 RVA: 0x0002B7C8 File Offset: 0x000299C8
		private void ButtonTlg_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				ProcessExtension.Start((sender as Button).Tag.ToString());
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x0600098C RID: 2444 RVA: 0x0002B808 File Offset: 0x00029A08
		private void ButtonDiscord_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				ProcessExtension.Start((sender as Button).Tag.ToString());
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x0600098D RID: 2445 RVA: 0x0002B848 File Offset: 0x00029A48
		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			try
			{
				UIElement uielement = this.progressBar;
				ObservableCollection<MarketModel> marketDataList = this.vm.MarketDataList;
				uielement.Visibility = ((marketDataList != null && marketDataList.Count <= 0) ? (this.progressBar.Visibility = Visibility.Visible) : (this.progressBar.Visibility = Visibility.Collapsed));
				string data = string.Empty;
				Task.Run(delegate()
				{
					using (HttpClient httpClient = new HttpClient())
					{
						httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd(Constants.UserAgent);
						data = httpClient.GetStringAsync(GlobalData.VerifiedMarketAddr).GetAwaiter().GetResult();
					}
				}).ContinueWith(delegate(Task t)
				{
					this.ChangeProgressVisibility(Visibility.Collapsed);
					if (!data.Contains("{"))
					{
						this.Dispatcher.Invoke(delegate()
						{
							Growl.Info("There is no market", "");
						});
						this.vm.MarketDataList = new ObservableCollection<MarketModel>();
					}
					else
					{
						this.vm.MarketDataList = new ObservableCollection<MarketModel>(IOManager.DeserializeObject<MarketModel[]>(data));
					}
					this.Dispatcher.Invoke(new Action(GlobalData.MainWindow.SilverZonePage.UpdateBadge));
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
				this.progressBar.Visibility = Visibility.Collapsed;
				Growl.Error("An unknown error occurred!! (VerifiedMarket)", "");
			}
		}

		// Token: 0x0600098E RID: 2446 RVA: 0x0002B928 File Offset: 0x00029B28
		private void SearchBar_SearchStarted(object sender, FunctionEventArgs<string> e)
		{
			try
			{
				SearchBar searchBar = sender as SearchBar;
				if (string.IsNullOrEmpty(searchBar.Text) || this.vm.MarketDataList == null)
				{
					this.itemsControl.ItemsSource = this.vm.MarketDataList;
				}
				else
				{
					string text = searchBar.Text;
					Func<string, bool> <>9__1;
					this.itemsControl.ItemsSource = this.vm.MarketDataList.Where(delegate(MarketModel m)
					{
						if (m == null)
						{
							return false;
						}
						string tags = m.Tags;
						string[] array = (tags != null) ? tags.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries) : null;
						if (array != null)
						{
							if (array.Length > 1)
							{
								IEnumerable<string> source = array;
								Func<string, bool> predicate;
								if ((predicate = <>9__1) == null)
								{
									predicate = (<>9__1 = ((string t) => t.Contains(text, StringComparison.OrdinalIgnoreCase)));
								}
								if (source.Any(predicate))
								{
									return true;
								}
							}
							if (array.Length == 1 && array[0].Contains(text, StringComparison.OrdinalIgnoreCase))
							{
								return true;
							}
						}
						return m.Buy.Contains(text, StringComparison.OrdinalIgnoreCase) || m.Category.Contains(text, StringComparison.OrdinalIgnoreCase) || m.Text.Contains(text, StringComparison.OrdinalIgnoreCase) || m.CreationDate.Contains(text, StringComparison.OrdinalIgnoreCase) || m.Description.Contains(text, StringComparison.OrdinalIgnoreCase) || m.Price.Contains(text, StringComparison.OrdinalIgnoreCase) || m.Seller.Contains(text, StringComparison.OrdinalIgnoreCase) || m.SellerRank.Contains(text, StringComparison.OrdinalIgnoreCase) || m.Discount.Contains(text, StringComparison.OrdinalIgnoreCase) || m.Telegram.Contains(text, StringComparison.OrdinalIgnoreCase) || m.Discord.Contains(text, StringComparison.OrdinalIgnoreCase);
					});
				}
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x0600098F RID: 2447 RVA: 0x0002B9C8 File Offset: 0x00029BC8
		private void SearchBar_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				this.SearchBar_SearchStarted(sender, null);
			}
		}

		// Token: 0x06000990 RID: 2448 RVA: 0x0002B9DC File Offset: 0x00029BDC
		private void ChangeProgressVisibility(Visibility visibility)
		{
			base.Dispatcher.Invoke<Visibility>(() => this.progressBar.Visibility = visibility);
		}

		// Token: 0x06000991 RID: 2449 RVA: 0x0002BA18 File Offset: 0x00029C18
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/main/silverzone/verifiedmarket.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000992 RID: 2450 RVA: 0x0002BA48 File Offset: 0x00029C48
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				((VerifiedMarket)target).Loaded += this.Page_Loaded;
				return;
			case 2:
				((SearchBar)target).KeyDown += this.SearchBar_KeyDown;
				((SearchBar)target).SearchStarted += this.SearchBar_SearchStarted;
				return;
			case 3:
				this.itemsControl = (ItemsControl)target;
				return;
			default:
				if (connectionId != 10)
				{
					this._contentLoaded = true;
					return;
				}
				this.progressBar = (CircleProgressBar)target;
				return;
			}
		}

		// Token: 0x06000993 RID: 2451 RVA: 0x0002BAD8 File Offset: 0x00029CD8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IStyleConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 4:
				((Button)target).Click += this.MediaElemControl_Click;
				return;
			case 5:
				((MediaElement)target).MediaEnded += this.MediaElement_MediaEnded;
				((MediaElement)target).MediaFailed += this.MediaElement_MediaFailed;
				((MediaElement)target).MediaOpened += this.MediaElement_MediaOpened;
				return;
			case 6:
				((Button)target).Click += this.ButtonTlg_Click;
				return;
			case 7:
				((Button)target).Click += this.ButtonDiscord_Click;
				return;
			case 8:
				((Button)target).Click += this.ButtonBuy_Click;
				return;
			case 9:
				((Button)target).Click += this.ButtonReport_Click;
				return;
			default:
				return;
			}
		}

		// Token: 0x04000477 RID: 1143
		private VerifiedMarketViewModel vm;

		// Token: 0x04000478 RID: 1144
		internal ItemsControl itemsControl;

		// Token: 0x04000479 RID: 1145
		internal CircleProgressBar progressBar;

		// Token: 0x0400047A RID: 1146
		private bool _contentLoaded;
	}
}
