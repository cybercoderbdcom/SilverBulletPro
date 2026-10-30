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
using HandyControl.Controls;
using HandyControl.Data;
using SilverBulletPro.Core;
using SilverBulletPro.Core.Extensions;
using SilverBulletPro.Models;
using SilverBulletPro.ViewModels;

namespace SilverBulletPro.Views.Main
{
	// Token: 0x02000182 RID: 386
	public class Ads : Page, IComponentConnector, IStyleConnector
	{
		// Token: 0x06000974 RID: 2420 RVA: 0x0002AFDC File Offset: 0x000291DC
		public Ads()
		{
			this.InitializeComponent();
			base.DataContext = (this.vm = GlobalData.Ads);
		}

		// Token: 0x06000975 RID: 2421 RVA: 0x0002B00C File Offset: 0x0002920C
		private void Button_Click(object sender, RoutedEventArgs e)
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

		// Token: 0x06000976 RID: 2422 RVA: 0x0002B04C File Offset: 0x0002924C
		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			try
			{
				UIElement uielement = this.progressBar;
				ObservableCollection<AdModel> adsDataList = this.vm.AdsDataList;
				uielement.Visibility = ((adsDataList != null && adsDataList.Count <= 0) ? (this.progressBar.Visibility = Visibility.Visible) : (this.progressBar.Visibility = Visibility.Collapsed));
				string data = string.Empty;
				Task.Run(delegate()
				{
					using (HttpClient httpClient = new HttpClient())
					{
						httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd(Constants.UserAgent);
						data = httpClient.GetStringAsync(GlobalData.AdsAddr).GetAwaiter().GetResult();
					}
				}).ContinueWith(delegate(Task t)
				{
					this.ChangeProgressVisibility(Visibility.Collapsed);
					if (!data.Contains("{"))
					{
						this.Dispatcher.Invoke(delegate()
						{
							Growl.Info("There are no ads", "");
						});
						this.vm.AdsDataList = new ObservableCollection<AdModel>();
					}
					else
					{
						this.vm.AdsDataList = new ObservableCollection<AdModel>(IOManager.DeserializeObject<AdModel[]>(data));
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
				Growl.Error("An unknown error occurred!! (Ads)", "");
			}
		}

		// Token: 0x06000977 RID: 2423 RVA: 0x0002B12C File Offset: 0x0002932C
		private void SearchBar_SearchStarted(object sender, FunctionEventArgs<string> e)
		{
			try
			{
				SearchBar searchBar = sender as SearchBar;
				if (string.IsNullOrEmpty(searchBar.Text) || this.vm.AdsDataList == null)
				{
					this.listBox.ItemsSource = this.vm.AdsDataList;
				}
				else
				{
					string text = searchBar.Text;
					this.listBox.ItemsSource = null;
					Func<string, bool> <>9__1;
					this.listBox.ItemsSource = this.vm.AdsDataList.Where(delegate(AdModel s)
					{
						if (s == null)
						{
							return false;
						}
						string tags = s.Tags;
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
						return s.Address.Contains(text, StringComparison.OrdinalIgnoreCase) || s.Text.Contains(text, StringComparison.OrdinalIgnoreCase) || s.Name.Contains(text, StringComparison.OrdinalIgnoreCase) || s.Description.Contains(text, StringComparison.OrdinalIgnoreCase);
					});
					this.listBox.UpdateLayout();
				}
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x06000978 RID: 2424 RVA: 0x0002B1E0 File Offset: 0x000293E0
		private void SearchBar_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				this.SearchBar_SearchStarted(sender, null);
			}
		}

		// Token: 0x06000979 RID: 2425 RVA: 0x0002B1F4 File Offset: 0x000293F4
		private void ChangeProgressVisibility(Visibility visibility)
		{
			base.Dispatcher.Invoke<Visibility>(() => this.progressBar.Visibility = visibility);
		}

		// Token: 0x0600097A RID: 2426 RVA: 0x0002B230 File Offset: 0x00029430
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/main/silverzone/ads.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600097B RID: 2427 RVA: 0x0002B260 File Offset: 0x00029460
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				((Ads)target).Loaded += this.Page_Loaded;
				return;
			case 2:
				((SearchBar)target).KeyDown += this.SearchBar_KeyDown;
				((SearchBar)target).SearchStarted += this.SearchBar_SearchStarted;
				return;
			case 3:
				this.listBox = (ListBox)target;
				return;
			case 5:
				this.progressBar = (CircleProgressBar)target;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x0600097C RID: 2428 RVA: 0x0002B2F3 File Offset: 0x000294F3
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IStyleConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 4)
			{
				((Button)target).Click += this.Button_Click;
			}
		}

		// Token: 0x0400046F RID: 1135
		private AdsViewModel vm;

		// Token: 0x04000470 RID: 1136
		internal ListBox listBox;

		// Token: 0x04000471 RID: 1137
		internal CircleProgressBar progressBar;

		// Token: 0x04000472 RID: 1138
		private bool _contentLoaded;
	}
}
