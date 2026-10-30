using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using AngleSharp.Text;
using Microsoft.Win32;
using SilverBulletPro.Core.Extensions;
using SilverBulletPro.Core.Models;
using SilverBulletPro.Requests;
using SilverBulletPro.ViewModels;
using SilverBulletPro.Views.Main;

namespace SilverBulletPro
{
	// Token: 0x0200001F RID: 31
	public class DialogAddProxies : Page, IComponentConnector
	{
		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06000107 RID: 263 RVA: 0x000094C8 File Offset: 0x000076C8
		// (set) Token: 0x06000108 RID: 264 RVA: 0x000094D0 File Offset: 0x000076D0
		public object Caller { get; set; }

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x06000109 RID: 265 RVA: 0x000094D9 File Offset: 0x000076D9
		// (set) Token: 0x0600010A RID: 266 RVA: 0x000094E1 File Offset: 0x000076E1
		public Proxylist Proxylist { get; private set; }

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x0600010B RID: 267 RVA: 0x000094EA File Offset: 0x000076EA
		// (set) Token: 0x0600010C RID: 268 RVA: 0x000094F2 File Offset: 0x000076F2
		public DialogResult DialogResult { get; private set; }

		// Token: 0x0600010D RID: 269 RVA: 0x000094FC File Offset: 0x000076FC
		public DialogAddProxies(object caller, Proxylist proxylist = null)
		{
			this.Proxylist = proxylist;
			this.InitializeComponent();
			this.Caller = caller;
			foreach (object obj in Enum.GetValues(typeof(ProxyType)))
			{
				ProxyType proxyType = (ProxyType)obj;
				if (proxyType != 4)
				{
					this.proxyTypeCombobox.Items.Add(proxyType);
				}
			}
			if (proxylist == null)
			{
				this.proxyTypeCombobox.SelectedIndex = 0;
				return;
			}
			this.proxyTypeCombobox.SelectedItem = StringExtensions.ToEnum<ProxyType>(proxylist.Type, 0);
		}

		// Token: 0x0600010E RID: 270 RVA: 0x000095B8 File Offset: 0x000077B8
		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			try
			{
				if (this.Proxylist == null)
				{
					this.nameTextbox.Visibility = Visibility.Collapsed;
				}
				else
				{
					this.nameTextbox.Visibility = Visibility.Visible;
					this.locationTextbox.Text = this.Proxylist.Path;
					this.nameTextbox.Text = this.Proxylist.Name;
					IList<CProxy> proxies = this.Proxylist.Proxies;
					if (proxies != null && proxies.Count > 0)
					{
						this.proxiesBox.Text = string.Join<CProxy>('\n', this.Proxylist.Proxies);
					}
					this.proxyTypeCombobox.SelectedItem = this.Proxylist.Type;
					this.urlTextbox.Text = this.Proxylist.Url;
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00009690 File Offset: 0x00007890
		private void LoadProxiesButton_Click(object sender, RoutedEventArgs e)
		{
			Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
			openFileDialog.Filter = "Proxy files | *.txt";
			openFileDialog.FilterIndex = 1;
			bool? flag = openFileDialog.ShowDialog();
			bool flag2 = true;
			if (flag.GetValueOrDefault() == flag2 & flag != null)
			{
				this.locationTextbox.Text = openFileDialog.FileName;
				string text = Path.GetFileNameWithoutExtension(this.locationTextbox.Text).ToLower();
				if (text.Contains("http") || text.Contains("https"))
				{
					this.proxyTypeCombobox.SelectedIndex = 0;
					return;
				}
				if (text.Contains("socks4"))
				{
					this.proxyTypeCombobox.SelectedIndex = 1;
					return;
				}
				if (text.Contains("socks5"))
				{
					this.proxyTypeCombobox.SelectedIndex = 2;
					return;
				}
				if (text.Contains("Socks4a"))
				{
					this.proxyTypeCombobox.SelectedIndex = 3;
				}
			}
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00009770 File Offset: 0x00007970
		private void acceptButton_Click(object sender, RoutedEventArgs e)
		{
			if (this.Proxylist != null)
			{
				this.Proxylist.Path = this.locationTextbox.Text;
				this.Proxylist.Name = this.nameTextbox.Text;
				ProxyType type = (ProxyType)this.proxyTypeCombobox.SelectedItem;
				this.Proxylist.Proxies = this.proxiesBox.Text.Split(new string[]
				{
					"\r\n",
					"\n"
				}, StringSplitOptions.RemoveEmptyEntries).Select(delegate(string p)
				{
					CProxy result;
					try
					{
						result = new CProxy().Parse(p, type, "", "");
					}
					catch (Exception)
					{
						result = new CProxy(p, type);
					}
					return result;
				}).ToList<CProxy>();
				this.Proxylist.Type = type.ToString();
				this.Proxylist.Url = this.urlTextbox.Text;
				this.DialogResult = DialogResult.OK;
			}
			else
			{
				string text = this.locationTextbox.Text;
				List<string> list = new List<string>();
				ProxyType proxyType = (ProxyType)this.proxyTypeCombobox.SelectedItem;
				if (!Directory.Exists("Proxylists"))
				{
					Directory.CreateDirectory("Proxylists");
				}
				try
				{
					switch (this.modeTabControl.SelectedIndex)
					{
					case 0:
						if (!(text != string.Empty))
						{
							GlobalData.Logger.LogError(Components.ProxyManager, "No file specified!", true, 0);
							return;
						}
						GlobalData.Logger.LogInfo(Components.ProxyManager, "Trying to load from file " + text, false, 0);
						if (this.Caller.GetType() == typeof(ProxyManager))
						{
							((ProxyManager)this.Caller).vm.Add(ProxyManagerViewModel.FileToProxylist(text, (ProxyType)this.proxyTypeCombobox.SelectedItem));
						}
						break;
					case 1:
						if (!(this.proxiesBox.Text != string.Empty))
						{
							GlobalData.Logger.LogError(Components.ProxyManager, "The box is empty!", true, 0);
							return;
						}
						list.AddRange(this.proxiesBox.Text.Split(new string[]
						{
							"\r\n",
							"\n"
						}, StringSplitOptions.RemoveEmptyEntries));
						((ProxyManager)this.Caller).vm.Add(ProxyManagerViewModel.ArrayToProxylist(list.Select(delegate(string p)
						{
							CProxy result;
							try
							{
								result = new CProxy().Parse(p, proxyType, "", "");
							}
							catch (Exception)
							{
								result = new CProxy(p, proxyType);
							}
							return result;
						}).ToList<CProxy>(), "Proxylist-" + StringExtension.RandomString(2), proxyType));
						break;
					case 2:
						if (this.urlTextbox.Text != string.Empty)
						{
							using (HttpRequest httpRequest = new HttpRequest
							{
								EnableEncodingContent = false
							})
							{
								string text2 = httpRequest.Get(this.urlTextbox.Text, null).ToString();
								list.AddRange(text2.Split(new string[]
								{
									"\r\n",
									"\n"
								}, StringSplitOptions.None));
								Proxylist proxylist = ProxyManagerViewModel.ArrayToProxylist((from p in list
								select new CProxy(p, proxyType)).ToList<CProxy>(), "Proxylist-" + StringExtension.RandomString(2), proxyType);
								proxylist.Url = this.urlTextbox.Text;
								((ProxyManager)this.Caller).vm.Add(proxylist);
								break;
							}
						}
						GlobalData.Logger.LogError(Components.ProxyManager, "No URL specified!", true, 0);
						return;
					}
				}
				catch (Exception ex)
				{
					GlobalData.Logger.LogError(Components.ProxyManager, "There was an error: " + ex.Message, false, 0);
					return;
				}
			}
			((MainDialog)base.Parent).Close();
		}

		// Token: 0x06000111 RID: 273 RVA: 0x00009B40 File Offset: 0x00007D40
		private void FileMode_MouseDown(object sender, MouseButtonEventArgs e)
		{
			this.fileMode.Foreground = Utils.GetBrush("ForegroundMenuSelected");
			this.pasteMode.Foreground = Utils.GetBrush("ForegroundMain");
			this.apiMode.Foreground = Utils.GetBrush("ForegroundMain");
			this.modeTabControl.SelectedIndex = 0;
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00009B98 File Offset: 0x00007D98
		private void PasteMode_MouseDown(object sender, MouseButtonEventArgs e)
		{
			this.fileMode.Foreground = Utils.GetBrush("ForegroundMain");
			this.pasteMode.Foreground = Utils.GetBrush("ForegroundMenuSelected");
			this.apiMode.Foreground = Utils.GetBrush("ForegroundMain");
			this.modeTabControl.SelectedIndex = 1;
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00009BF0 File Offset: 0x00007DF0
		private void ApiMode_MouseDown(object sender, MouseButtonEventArgs e)
		{
			this.fileMode.Foreground = Utils.GetBrush("ForegroundMain");
			this.pasteMode.Foreground = Utils.GetBrush("ForegroundMain");
			this.apiMode.Foreground = Utils.GetBrush("ForegroundMenuSelected");
			this.modeTabControl.SelectedIndex = 2;
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00009C48 File Offset: 0x00007E48
		private void TextBox_Drop(object sender, System.Windows.DragEventArgs e)
		{
			try
			{
				if (e.Data.GetDataPresent(System.Windows.DataFormats.FileDrop))
				{
					string[] array = e.Data.GetData(System.Windows.DataFormats.FileDrop) as string[];
					if (array != null && array.Length != 0 && File.Exists(array[0]) && Path.GetExtension(array[0]).ToLower() == ".txt")
					{
						((System.Windows.Controls.TextBox)sender).Text = array[0];
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000115 RID: 277 RVA: 0x00009CCC File Offset: 0x00007ECC
		private void TextBox_PreviewDragOver(object sender, System.Windows.DragEventArgs e)
		{
			e.Handled = true;
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00009CD5 File Offset: 0x00007ED5
		private void Page_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				this.acceptButton_Click(this, e);
			}
		}

		// Token: 0x06000117 RID: 279 RVA: 0x00009CE8 File Offset: 0x00007EE8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/dialogs/dialogaddproxies.xaml", UriKind.Relative);
			System.Windows.Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00009D18 File Offset: 0x00007F18
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				((DialogAddProxies)target).KeyDown += this.Page_KeyDown;
				((DialogAddProxies)target).Loaded += this.Page_Loaded;
				return;
			case 2:
				this.fileMode = (System.Windows.Controls.Label)target;
				this.fileMode.MouseDown += this.FileMode_MouseDown;
				return;
			case 3:
				this.pasteMode = (System.Windows.Controls.Label)target;
				this.pasteMode.MouseDown += this.PasteMode_MouseDown;
				return;
			case 4:
				this.apiMode = (System.Windows.Controls.Label)target;
				this.apiMode.MouseDown += this.ApiMode_MouseDown;
				return;
			case 5:
				this.modeTabControl = (System.Windows.Controls.TabControl)target;
				return;
			case 6:
				this.fileTab = (TabItem)target;
				return;
			case 7:
				this.locationTextbox = (System.Windows.Controls.TextBox)target;
				this.locationTextbox.Drop += this.TextBox_Drop;
				this.locationTextbox.PreviewDragOver += this.TextBox_PreviewDragOver;
				return;
			case 8:
				this.loadProxiesButton = (System.Windows.Controls.Button)target;
				this.loadProxiesButton.Click += this.LoadProxiesButton_Click;
				return;
			case 9:
				this.pasteTab = (TabItem)target;
				return;
			case 10:
				this.proxiesBox = (System.Windows.Controls.TextBox)target;
				return;
			case 11:
				this.apiTab = (TabItem)target;
				return;
			case 12:
				this.urlTextbox = (System.Windows.Controls.TextBox)target;
				return;
			case 13:
				this.advancedWarning = (TextBlock)target;
				return;
			case 14:
				this.nameTextbox = (System.Windows.Controls.TextBox)target;
				return;
			case 15:
				this.proxyTypeCombobox = (System.Windows.Controls.ComboBox)target;
				return;
			case 16:
				this.usernameTextbox = (System.Windows.Controls.TextBox)target;
				return;
			case 17:
				this.passwordTextbox = (System.Windows.Controls.TextBox)target;
				return;
			case 18:
				this.acceptButton = (System.Windows.Controls.Button)target;
				this.acceptButton.Click += this.acceptButton_Click;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x04000076 RID: 118
		internal System.Windows.Controls.Label fileMode;

		// Token: 0x04000077 RID: 119
		internal System.Windows.Controls.Label pasteMode;

		// Token: 0x04000078 RID: 120
		internal System.Windows.Controls.Label apiMode;

		// Token: 0x04000079 RID: 121
		internal System.Windows.Controls.TabControl modeTabControl;

		// Token: 0x0400007A RID: 122
		internal TabItem fileTab;

		// Token: 0x0400007B RID: 123
		internal System.Windows.Controls.TextBox locationTextbox;

		// Token: 0x0400007C RID: 124
		internal System.Windows.Controls.Button loadProxiesButton;

		// Token: 0x0400007D RID: 125
		internal TabItem pasteTab;

		// Token: 0x0400007E RID: 126
		internal System.Windows.Controls.TextBox proxiesBox;

		// Token: 0x0400007F RID: 127
		internal TabItem apiTab;

		// Token: 0x04000080 RID: 128
		internal System.Windows.Controls.TextBox urlTextbox;

		// Token: 0x04000081 RID: 129
		internal TextBlock advancedWarning;

		// Token: 0x04000082 RID: 130
		internal System.Windows.Controls.TextBox nameTextbox;

		// Token: 0x04000083 RID: 131
		internal System.Windows.Controls.ComboBox proxyTypeCombobox;

		// Token: 0x04000084 RID: 132
		internal System.Windows.Controls.TextBox usernameTextbox;

		// Token: 0x04000085 RID: 133
		internal System.Windows.Controls.TextBox passwordTextbox;

		// Token: 0x04000086 RID: 134
		internal System.Windows.Controls.Button acceptButton;

		// Token: 0x04000087 RID: 135
		private bool _contentLoaded;
	}
}
