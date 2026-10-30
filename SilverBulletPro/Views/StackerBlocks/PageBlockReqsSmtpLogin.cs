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
	// Token: 0x02000100 RID: 256
	public class PageBlockReqsSmtpLogin : Page, IComponentConnector
	{
		// Token: 0x06000693 RID: 1683 RVA: 0x0001F510 File Offset: 0x0001D710
		public PageBlockReqsSmtpLogin(BlockSmtpLogin block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			foreach (object newItem in Enum.GetValues(typeof(MailServiceLoginMethod)))
			{
				this.loginMethod.Items.Add(newItem);
			}
			foreach (object obj in Enum.GetValues(typeof(SmtpAuthentication)))
			{
				SmtpAuthentication smtpAuthentication = (SmtpAuthentication)obj;
				this.authMethod.Items.Add(smtpAuthentication);
			}
			this.LoginMethod_SelectionChanged(null, null);
		}

		// Token: 0x06000694 RID: 1684 RVA: 0x0001F5F4 File Offset: 0x0001D7F4
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

		// Token: 0x06000695 RID: 1685 RVA: 0x0001F674 File Offset: 0x0001D874
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/smtp/pageblockreqssmtplogin.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000696 RID: 1686 RVA: 0x0001F6A4 File Offset: 0x0001D8A4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000697 RID: 1687 RVA: 0x0001F6B0 File Offset: 0x0001D8B0
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

		// Token: 0x04000327 RID: 807
		internal ComboBox loginMethod;

		// Token: 0x04000328 RID: 808
		internal TextInputBox token;

		// Token: 0x04000329 RID: 809
		internal TextInputBox username;

		// Token: 0x0400032A RID: 810
		internal TextInputBox password;

		// Token: 0x0400032B RID: 811
		internal ComboBox authMethod;

		// Token: 0x0400032C RID: 812
		private bool _contentLoaded;
	}
}
