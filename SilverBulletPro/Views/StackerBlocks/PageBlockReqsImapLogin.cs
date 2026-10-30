using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Rebex.Net;
using SilverBulletPro.Core.Blocks;
using SilverBulletPro.Core.Enums;
using SilverBulletPro.Views.UserControls;

namespace SilverBulletPro.Views.StackerBlocks
{
	// Token: 0x020000F1 RID: 241
	public class PageBlockReqsImapLogin : Page, IComponentConnector
	{
		// Token: 0x0600064F RID: 1615 RVA: 0x0001E438 File Offset: 0x0001C638
		public PageBlockReqsImapLogin(BlockImapLogin block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			foreach (object newItem in Enum.GetValues(typeof(MailServiceLoginMethod)))
			{
				this.loginMethod.Items.Add(newItem);
			}
			foreach (object obj in Enum.GetValues(typeof(ImapAuthentication)))
			{
				ImapAuthentication imapAuthentication = (ImapAuthentication)obj;
				this.authMethod.Items.Add(imapAuthentication);
			}
			this.LoginMethod_SelectionChanged(null, null);
		}

		// Token: 0x06000650 RID: 1616 RVA: 0x0001E51C File Offset: 0x0001C71C
		private void LoginMethod_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				if (this.loginMethod.SelectedIndex == 0)
				{
					this.token.Visibility = Visibility.Collapsed;
					this.password.Visibility = (this.username.Visibility = Visibility.Visible);
				}
				else
				{
					this.token.Visibility = Visibility.Visible;
					this.password.Visibility = (this.username.Visibility = Visibility.Collapsed);
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000651 RID: 1617 RVA: 0x0001E59C File Offset: 0x0001C79C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/imap/pageblockreqsimaplogin.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000652 RID: 1618 RVA: 0x0001E5CC File Offset: 0x0001C7CC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000653 RID: 1619 RVA: 0x0001E5D8 File Offset: 0x0001C7D8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.loginMethod = (ComboBox)target;
				this.loginMethod.SelectionChanged += this.LoginMethod_SelectionChanged;
				return;
			case 2:
				this.token = (TextInputBox)target;
				return;
			case 3:
				this.username = (TextInputBox)target;
				return;
			case 4:
				this.password = (TextInputBox)target;
				return;
			case 5:
				this.authMethod = (ComboBox)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x04000304 RID: 772
		internal ComboBox loginMethod;

		// Token: 0x04000305 RID: 773
		internal TextInputBox token;

		// Token: 0x04000306 RID: 774
		internal TextInputBox username;

		// Token: 0x04000307 RID: 775
		internal TextInputBox password;

		// Token: 0x04000308 RID: 776
		internal ComboBox authMethod;

		// Token: 0x04000309 RID: 777
		private bool _contentLoaded;
	}
}
