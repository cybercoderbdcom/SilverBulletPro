using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using AngleSharp.Text;
using Rebex.Net;
using SilverBulletPro.Core.Blocks;

namespace SilverBulletPro.Views.StackerBlocks
{
	// Token: 0x020000FD RID: 253
	public class PageBlockReqsSmtpConnect : Page, IComponentConnector
	{
		// Token: 0x06000684 RID: 1668 RVA: 0x0001F004 File Offset: 0x0001D204
		public PageBlockReqsSmtpConnect(BlockSmtpConnect block)
		{
			this.InitializeComponent();
			this.vm = block;
			base.DataContext = block;
			foreach (object obj in Enum.GetValues(typeof(SslMode)))
			{
				SslMode sslMode = (SslMode)obj;
				this.sslModeBox.Items.Add(sslMode);
			}
			foreach (object obj2 in Enum.GetValues(typeof(TlsEllipticCurve)))
			{
				TlsEllipticCurve tlsEllipticCurve = (TlsEllipticCurve)obj2;
				this.sslAllowedCurvesBox.Items.Add(tlsEllipticCurve);
			}
			foreach (object obj3 in Enum.GetValues(typeof(TlsCipherSuite)))
			{
				TlsCipherSuite tlsCipherSuite = (TlsCipherSuite)obj3;
				this.sslAllowedSuitesBox.Items.Add(tlsCipherSuite);
			}
			foreach (object obj4 in Enum.GetValues(typeof(TlsVersion)))
			{
				TlsVersion tlsVersion = (TlsVersion)obj4;
				this.sslAllowedVersionsBox.Items.Add(tlsVersion);
			}
			if (block.SslAllowedCurves.ToString().Contains(","))
			{
				this.sslAllowedCurvesBox.Text = block.SslAllowedCurves.ToString().Replace(" ", string.Empty);
			}
			if (block.SslAllowedSuites.ToString().Contains(","))
			{
				this.sslAllowedSuitesBox.Text = block.SslAllowedSuites.ToString().Replace(" ", string.Empty);
			}
			if (block.SslAllowedVersions.ToString().Contains(","))
			{
				this.sslAllowedVersionsBox.Text = block.SslAllowedVersions.ToString().Replace(" ", string.Empty);
			}
		}

		// Token: 0x06000685 RID: 1669 RVA: 0x0001F2AC File Offset: 0x0001D4AC
		private void SslAllowedCurvesBox_LostFocus(object sender, RoutedEventArgs e)
		{
			try
			{
				this.vm.SslAllowedCurves = StringExtensions.ToEnum<TlsEllipticCurve>(this.sslAllowedCurvesBox.Text, 549755813887L);
			}
			catch
			{
			}
		}

		// Token: 0x06000686 RID: 1670 RVA: 0x0001F2F4 File Offset: 0x0001D4F4
		private void SslAllowedSuitesBox_LostFocus(object sender, RoutedEventArgs e)
		{
			try
			{
				this.vm.SslAllowedSuites = StringExtensions.ToEnum<TlsCipherSuite>(this.sslAllowedSuitesBox.Text, 873698327709876223L);
			}
			catch
			{
			}
		}

		// Token: 0x06000687 RID: 1671 RVA: 0x0001F33C File Offset: 0x0001D53C
		private void SslAllowedVersionsBox_LostFocus(object sender, RoutedEventArgs e)
		{
			try
			{
				this.vm.SslAllowedVersions = StringExtensions.ToEnum<TlsVersion>(this.sslAllowedVersionsBox.Text, 14);
			}
			catch
			{
			}
		}

		// Token: 0x06000688 RID: 1672 RVA: 0x0001F37C File Offset: 0x0001D57C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/smtp/pageblockreqssmtpconnect.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000689 RID: 1673 RVA: 0x0001F3AC File Offset: 0x0001D5AC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600068A RID: 1674 RVA: 0x0001F3B8 File Offset: 0x0001D5B8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.sslModeBox = (ComboBox)target;
				return;
			case 2:
				this.sslAllowedCurvesBox = (ComboBox)target;
				this.sslAllowedCurvesBox.LostFocus += this.SslAllowedCurvesBox_LostFocus;
				return;
			case 3:
				this.sslAllowedSuitesBox = (ComboBox)target;
				this.sslAllowedSuitesBox.LostFocus += this.SslAllowedSuitesBox_LostFocus;
				return;
			case 4:
				this.sslAllowedVersionsBox = (ComboBox)target;
				this.sslAllowedVersionsBox.LostFocus += this.SslAllowedVersionsBox_LostFocus;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x0400031F RID: 799
		private BlockSmtpConnect vm;

		// Token: 0x04000320 RID: 800
		internal ComboBox sslModeBox;

		// Token: 0x04000321 RID: 801
		internal ComboBox sslAllowedCurvesBox;

		// Token: 0x04000322 RID: 802
		internal ComboBox sslAllowedSuitesBox;

		// Token: 0x04000323 RID: 803
		internal ComboBox sslAllowedVersionsBox;

		// Token: 0x04000324 RID: 804
		private bool _contentLoaded;
	}
}
