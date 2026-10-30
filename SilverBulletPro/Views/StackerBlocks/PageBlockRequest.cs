using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using AngleSharp.Text;
using SilverBulletPro.Core;
using SilverBulletPro.Core.Blocks;
using SilverBulletPro.Core.Extensions;
using SilverBulletPro.Core.Functions.Requests;
using SilverBulletPro.Requests;
using SilverBulletPro.Views.UserControls;

namespace SilverBulletPro.Views.StackerBlocks
{
	// Token: 0x020000EC RID: 236
	public class PageBlockRequest : Page, IComponentConnector
	{
		// Token: 0x06000630 RID: 1584 RVA: 0x0001D4A0 File Offset: 0x0001B6A0
		public PageBlockRequest(BlockRequest block)
		{
			this.InitializeComponent();
			this.vm = block;
			base.DataContext = this.vm;
			this.AddHttpVersions();
			this.httpVersionComboBox.SelectedItem = this.vm.HttpVersion.ToString();
			foreach (object obj in Enum.GetValues(typeof(HttpMethod)))
			{
				HttpMethod httpMethod = (HttpMethod)obj;
				this.methodCombobox.Items.Add(httpMethod);
			}
			foreach (object obj2 in Enum.GetValues(typeof(HttpRequestLibrary)))
			{
				HttpRequestLibrary httpRequestLibrary = (HttpRequestLibrary)obj2;
				this.httpLibComboBox.Items.Add(EnumExtension.GetDescription(httpRequestLibrary));
			}
			this.httpLibComboBox.SelectedIndex = this.vm.HttpLibrary;
			this.methodCombobox.SelectedIndex = this.vm.Method;
			foreach (string newItem in Enum.GetNames(typeof(RequestType)))
			{
				this.requestTypeCombobox.Items.Add(newItem);
			}
			this.requestTypeCombobox.SelectedIndex = this.vm.RequestType;
			foreach (string newItem2 in Enum.GetNames(typeof(ResponseType)))
			{
				this.responseTypeCombobox.Items.Add(newItem2);
			}
			this.responseTypeCombobox.SelectedIndex = this.vm.ResponseType;
			this.rtCustomCookies.AddItems(this.vm.CustomCookies);
			this.rtCustomHeaders.AddItems(this.vm.CustomHeaders);
			this.rtMultipartContents.AddItems(this.vm.MultipartContents);
			foreach (string newItem3 in new string[]
			{
				"application/x-www-form-urlencoded",
				"application/octet-stream",
				"application/xhtml+xml",
				"application/json",
				"text/plain"
			})
			{
				this.contentTypeCombobox.Items.Add(newItem3);
				this.rawContentTypeComboBox.Items.Add(newItem3);
			}
			foreach (object obj3 in Enum.GetValues(typeof(SecurityProtocol)))
			{
				SecurityProtocol securityProtocol = (SecurityProtocol)obj3;
				this.securityProtocolCombobox.Items.Add(securityProtocol);
			}
			if (block.SecurityProtocol.ToString().Contains(","))
			{
				this.securityProtocolCombobox.Text = block.SecurityProtocol.ToString().Replace(" ", string.Empty);
			}
			foreach (object obj4 in Enum.GetValues(typeof(ProxyUsage)))
			{
				ProxyUsage proxyUsage = (ProxyUsage)obj4;
				this.proxyUsageComboBox.Items.Add(proxyUsage);
			}
		}

		// Token: 0x06000631 RID: 1585 RVA: 0x0001D854 File Offset: 0x0001BA54
		private void AddHttpVersions()
		{
			try
			{
				FieldInfo[] fields = typeof(HttpVersion).GetFields();
				for (int i = 0; i < fields.Length; i++)
				{
					if (fields[i].Name.StartsWith("Version"))
					{
						this.httpVersionComboBox.Items.Add(((Version)fields[i].GetValue(null)).ToString());
					}
				}
			}
			catch
			{
				this.httpVersionComboBox.Items.Add("1.0");
				this.httpVersionComboBox.Items.Add("1.1");
				this.httpVersionComboBox.Items.Add("2.0");
				this.httpVersionComboBox.Items.Add("3.0");
			}
		}

		// Token: 0x06000632 RID: 1586 RVA: 0x0001D924 File Offset: 0x0001BB24
		private void methodCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			this.vm.Method = this.methodCombobox.SelectedIndex;
		}

		// Token: 0x06000633 RID: 1587 RVA: 0x0001D93C File Offset: 0x0001BB3C
		private void requestTypeCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			this.vm.RequestType = this.requestTypeCombobox.SelectedIndex;
			this.urlEncodeContentPanel.Visibility = ((this.vm.RequestType == null) ? Visibility.Visible : Visibility.Collapsed);
			switch (this.vm.RequestType)
			{
			case 0:
				this.requestTypeTabControl.SelectedIndex = 2;
				return;
			default:
				this.requestTypeTabControl.SelectedIndex = 1;
				return;
			case 2:
				this.requestTypeTabControl.SelectedIndex = 3;
				return;
			case 3:
				this.requestTypeTabControl.SelectedIndex = 4;
				return;
			}
		}

		// Token: 0x06000634 RID: 1588 RVA: 0x0001D9D0 File Offset: 0x0001BBD0
		private void responseTypeCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			this.vm.ResponseType = this.responseTypeCombobox.SelectedIndex;
			ResponseType responseType = this.vm.ResponseType;
			if (responseType == 1)
			{
				this.responseTypeTabControl.SelectedIndex = 1;
				return;
			}
			if (responseType - 2 > 1)
			{
				this.responseTypeTabControl.SelectedIndex = 0;
				return;
			}
			this.responseTypeTabControl.SelectedIndex = 2;
			this.outputVar.OutputMode = StringExtensions.ToEnum<OutputMode>(this.vm.ResponseType.ToString(), 16);
		}

		// Token: 0x06000635 RID: 1589 RVA: 0x0001DA5C File Offset: 0x0001BC5C
		private void SecurityProtocolCombobox_LostFocus(object sender, RoutedEventArgs e)
		{
			try
			{
				this.vm.SecurityProtocol = StringExtensions.ToEnum<SecurityProtocol>(this.securityProtocolCombobox.Text, 0);
			}
			catch
			{
			}
		}

		// Token: 0x06000636 RID: 1590 RVA: 0x0001DA9C File Offset: 0x0001BC9C
		private void HttpVersionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				this.vm.HttpVersion = Version.Parse(this.httpVersionComboBox.SelectedItem as string);
			}
			catch
			{
				this.vm.HttpVersion = Version.Parse("1.1");
			}
		}

		// Token: 0x06000637 RID: 1591 RVA: 0x0001DAF4 File Offset: 0x0001BCF4
		private void HttpLibComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				this.vm.HttpLibrary = this.httpLibComboBox.SelectedIndex;
			}
			catch
			{
			}
			try
			{
				int selectedIndex = this.httpVersionComboBox.SelectedIndex;
				HttpRequestLibrary httpLibrary = this.vm.HttpLibrary;
				if (httpLibrary != null)
				{
					if (httpLibrary != 1)
					{
						this.httpVersionComboBox.Items.Clear();
						this.AddHttpVersions();
					}
					else
					{
						this.httpVersionComboBox.Items.Clear();
						this.AddHttpVersions();
					}
				}
				else
				{
					this.httpVersionComboBox.Items.Clear();
					this.httpVersionComboBox.Items.Add("1.0");
					this.httpVersionComboBox.Items.Add("1.1");
				}
				this.httpVersionComboBox.SelectedIndex = selectedIndex;
				if (this.httpVersionComboBox.SelectedIndex == -1)
				{
					this.httpVersionComboBox.SelectedIndex = 1;
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000638 RID: 1592 RVA: 0x0001DBF4 File Offset: 0x0001BDF4
		private void proxyUsageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				this.proxyUsageComboBox.ToolTip = EnumExtension.GetDescription((ProxyUsage)this.proxyUsageComboBox.SelectedItem);
			}
			catch
			{
			}
		}

		// Token: 0x06000639 RID: 1593 RVA: 0x0001DC3C File Offset: 0x0001BE3C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/http/pageblockrequest.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600063A RID: 1594 RVA: 0x0001DC6C File Offset: 0x0001BE6C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600063B RID: 1595 RVA: 0x0001DC78 File Offset: 0x0001BE78
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.methodCombobox = (ComboBox)target;
				this.methodCombobox.SelectionChanged += this.methodCombobox_SelectionChanged;
				return;
			case 2:
				this.httpLibComboBox = (ComboBox)target;
				this.httpLibComboBox.SelectionChanged += this.HttpLibComboBox_SelectionChanged;
				return;
			case 3:
				this.httpVersionComboBox = (ComboBox)target;
				this.httpVersionComboBox.SelectionChanged += this.HttpVersionComboBox_SelectionChanged;
				return;
			case 4:
				this.securityProtocolCombobox = (ComboBox)target;
				this.securityProtocolCombobox.LostFocus += this.SecurityProtocolCombobox_LostFocus;
				return;
			case 5:
				this.proxyUsageComboBox = (ComboBox)target;
				this.proxyUsageComboBox.SelectionChanged += this.proxyUsageComboBox_SelectionChanged;
				return;
			case 6:
				this.requestTypeCombobox = (ComboBox)target;
				this.requestTypeCombobox.SelectionChanged += this.requestTypeCombobox_SelectionChanged;
				return;
			case 7:
				this.requestTypeTabControl = (TabControl)target;
				return;
			case 8:
				this.emptyTab = (TabItem)target;
				return;
			case 9:
				this.basicAuthTab = (TabItem)target;
				return;
			case 10:
				this.standardTab = (TabItem)target;
				return;
			case 11:
				this.contentTypeCombobox = (ComboBox)target;
				return;
			case 12:
				this.multipartTab = (TabItem)target;
				return;
			case 13:
				this.rtMultipartContents = (RichTextInputBox)target;
				return;
			case 14:
				this.rawTab = (TabItem)target;
				return;
			case 15:
				this.rawContentTypeComboBox = (ComboBox)target;
				return;
			case 16:
				this.urlEncodeContentPanel = (DockPanel)target;
				return;
			case 17:
				this.rtCustomCookies = (RichTextInputBox)target;
				return;
			case 18:
				this.rtCustomHeaders = (RichTextInputBox)target;
				return;
			case 19:
				this.responseTypeCombobox = (ComboBox)target;
				this.responseTypeCombobox.SelectionChanged += this.responseTypeCombobox_SelectionChanged;
				return;
			case 20:
				this.responseTypeTabControl = (TabControl)target;
				return;
			case 21:
				this.emptyTab2 = (TabItem)target;
				return;
			case 22:
				this.fileTab = (TabItem)target;
				return;
			case 23:
				this.base64Tab = (TabItem)target;
				return;
			case 24:
				this.outputVar = (VarCapOutputBox)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x040002E1 RID: 737
		private BlockRequest vm;

		// Token: 0x040002E2 RID: 738
		internal ComboBox methodCombobox;

		// Token: 0x040002E3 RID: 739
		internal ComboBox httpLibComboBox;

		// Token: 0x040002E4 RID: 740
		internal ComboBox httpVersionComboBox;

		// Token: 0x040002E5 RID: 741
		internal ComboBox securityProtocolCombobox;

		// Token: 0x040002E6 RID: 742
		internal ComboBox proxyUsageComboBox;

		// Token: 0x040002E7 RID: 743
		internal ComboBox requestTypeCombobox;

		// Token: 0x040002E8 RID: 744
		internal TabControl requestTypeTabControl;

		// Token: 0x040002E9 RID: 745
		internal TabItem emptyTab;

		// Token: 0x040002EA RID: 746
		internal TabItem basicAuthTab;

		// Token: 0x040002EB RID: 747
		internal TabItem standardTab;

		// Token: 0x040002EC RID: 748
		internal ComboBox contentTypeCombobox;

		// Token: 0x040002ED RID: 749
		internal TabItem multipartTab;

		// Token: 0x040002EE RID: 750
		internal RichTextInputBox rtMultipartContents;

		// Token: 0x040002EF RID: 751
		internal TabItem rawTab;

		// Token: 0x040002F0 RID: 752
		internal ComboBox rawContentTypeComboBox;

		// Token: 0x040002F1 RID: 753
		internal DockPanel urlEncodeContentPanel;

		// Token: 0x040002F2 RID: 754
		internal RichTextInputBox rtCustomCookies;

		// Token: 0x040002F3 RID: 755
		internal RichTextInputBox rtCustomHeaders;

		// Token: 0x040002F4 RID: 756
		internal ComboBox responseTypeCombobox;

		// Token: 0x040002F5 RID: 757
		internal TabControl responseTypeTabControl;

		// Token: 0x040002F6 RID: 758
		internal TabItem emptyTab2;

		// Token: 0x040002F7 RID: 759
		internal TabItem fileTab;

		// Token: 0x040002F8 RID: 760
		internal TabItem base64Tab;

		// Token: 0x040002F9 RID: 761
		internal VarCapOutputBox outputVar;

		// Token: 0x040002FA RID: 762
		private bool _contentLoaded;
	}
}
