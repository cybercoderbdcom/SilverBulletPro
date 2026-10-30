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
using SilverBulletPro.Models;
using SilverBulletPro.ViewModels;

namespace SilverBulletPro.Views.Main
{
	// Token: 0x02000183 RID: 387
	public class Notif : Page, IComponentConnector
	{
		// Token: 0x0600097D RID: 2429 RVA: 0x0002B310 File Offset: 0x00029510
		public Notif()
		{
			this.InitializeComponent();
			base.DataContext = (this.vm = GlobalData.Notif);
		}

		// Token: 0x0600097E RID: 2430 RVA: 0x0002B340 File Offset: 0x00029540
		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			try
			{
				UIElement uielement = this.progressBar;
				ObservableCollection<NotifModel> notifDataList = this.vm.NotifDataList;
				uielement.Visibility = ((notifDataList != null && notifDataList.Count <= 0) ? (this.progressBar.Visibility = Visibility.Visible) : (this.progressBar.Visibility = Visibility.Collapsed));
				string data = string.Empty;
				Task.Run(delegate()
				{
					using (HttpClient httpClient = new HttpClient())
					{
						httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd(Constants.UserAgent);
						data = httpClient.GetStringAsync(GlobalData.NotifAddr).GetAwaiter().GetResult();
					}
				}).ContinueWith(delegate(Task t)
				{
					this.ChangeProgressVisibility(Visibility.Collapsed);
					if (!data.Contains("{"))
					{
						this.Dispatcher.Invoke(delegate()
						{
							Growl.Info("There are no notif", "");
						});
						this.vm.NotifDataList = new ObservableCollection<NotifModel>();
					}
					else
					{
						this.vm.NotifDataList = new ObservableCollection<NotifModel>(IOManager.DeserializeObject<NotifModel[]>(data));
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
				Growl.Error("An unknown error occurred!! (Notif)", "");
			}
		}

		// Token: 0x0600097F RID: 2431 RVA: 0x0002B420 File Offset: 0x00029620
		private void ChangeProgressVisibility(Visibility visibility)
		{
			base.Dispatcher.Invoke<Visibility>(() => this.progressBar.Visibility = visibility);
		}

		// Token: 0x06000980 RID: 2432 RVA: 0x0002B459 File Offset: 0x00029659
		private void SearchBar_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				this.SearchBar_SearchStarted(sender, null);
			}
		}

		// Token: 0x06000981 RID: 2433 RVA: 0x0002B46C File Offset: 0x0002966C
		private void SearchBar_SearchStarted(object sender, FunctionEventArgs<string> e)
		{
			try
			{
				SearchBar searchBar = sender as SearchBar;
				if (string.IsNullOrEmpty(searchBar.Text) || this.vm.NotifDataList == null)
				{
					this.itemsControl.ItemsSource = this.vm.NotifDataList;
				}
				else
				{
					string text = searchBar.Text;
					Func<string, bool> <>9__1;
					this.itemsControl.ItemsSource = this.vm.NotifDataList.Where(delegate(NotifModel m)
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
						return m.Message.Contains(text, StringComparison.OrdinalIgnoreCase) || m.Sender.Contains(text, StringComparison.OrdinalIgnoreCase);
					});
				}
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x06000982 RID: 2434 RVA: 0x0002B50C File Offset: 0x0002970C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/main/silverzone/notif.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000983 RID: 2435 RVA: 0x0002B53C File Offset: 0x0002973C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				((Notif)target).Loaded += this.Page_Loaded;
				return;
			case 2:
				((SearchBar)target).KeyDown += this.SearchBar_KeyDown;
				((SearchBar)target).SearchStarted += this.SearchBar_SearchStarted;
				return;
			case 3:
				this.itemsControl = (ItemsControl)target;
				return;
			case 4:
				this.progressBar = (CircleProgressBar)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x04000473 RID: 1139
		private NotifViewModel vm;

		// Token: 0x04000474 RID: 1140
		internal ItemsControl itemsControl;

		// Token: 0x04000475 RID: 1141
		internal CircleProgressBar progressBar;

		// Token: 0x04000476 RID: 1142
		private bool _contentLoaded;
	}
}
