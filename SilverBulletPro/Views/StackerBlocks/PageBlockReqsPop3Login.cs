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
	// Token: 0x020000FB RID: 251
	public class PageBlockReqsPop3Login : Page, IComponentConnector
	{
		// Token: 0x0600067B RID: 1659 RVA: 0x0001ED80 File Offset: 0x0001CF80
		public PageBlockReqsPop3Login(BlockPop3Login block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			foreach (object newItem in Enum.GetValues(typeof(MailServiceLoginMethod)))
			{
				this.loginMethod.Items.Add(newItem);
			}
			foreach (object obj in Enum.GetValues(typeof(Pop3Authentication)))
			{
				Pop3Authentication pop3Authentication = (Pop3Authentication)obj;
				this.authMethod.Items.Add(pop3Authentication);
			}
			this.LoginMethod_SelectionChanged(null, null);
		}

		// Token: 0x0600067C RID: 1660 RVA: 0x0001EE64 File Offset: 0x0001D064
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

		// Token: 0x0600067D RID: 1661 RVA: 0x0001EEE4 File Offset: 0x0001D0E4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/pop3/pageblockreqspop3login.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600067E RID: 1662 RVA: 0x0001EF14 File Offset: 0x0001D114
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600067F RID: 1663 RVA: 0x0001EF20 File Offset: 0x0001D120
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

		// Token: 0x04000318 RID: 792
		internal ComboBox loginMethod;

		// Token: 0x04000319 RID: 793
		internal TextInputBox token;

		// Token: 0x0400031A RID: 794
		internal TextInputBox username;

		// Token: 0x0400031B RID: 795
		internal TextInputBox password;

		// Token: 0x0400031C RID: 796
		internal ComboBox authMethod;

		// Token: 0x0400031D RID: 797
		private bool _contentLoaded;
	}
}
