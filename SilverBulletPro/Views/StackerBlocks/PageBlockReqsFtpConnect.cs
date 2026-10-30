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
	// Token: 0x020000D9 RID: 217
	public class PageBlockReqsFtpConnect : Page, IComponentConnector
	{
		// Token: 0x060005DF RID: 1503 RVA: 0x0001C550 File Offset: 0x0001A750
		public PageBlockReqsFtpConnect(BlockFtpConnect block)
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

		// Token: 0x060005E0 RID: 1504 RVA: 0x0001C7F8 File Offset: 0x0001A9F8
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

		// Token: 0x060005E1 RID: 1505 RVA: 0x0001C840 File Offset: 0x0001AA40
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

		// Token: 0x060005E2 RID: 1506 RVA: 0x0001C888 File Offset: 0x0001AA88
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

		// Token: 0x060005E3 RID: 1507 RVA: 0x0001C8C8 File Offset: 0x0001AAC8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/ftp/pageblockreqsftpconnect.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060005E4 RID: 1508 RVA: 0x0001C8F8 File Offset: 0x0001AAF8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060005E5 RID: 1509 RVA: 0x0001C904 File Offset: 0x0001AB04
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

		// Token: 0x040002BE RID: 702
		private BlockFtpConnect vm;

		// Token: 0x040002BF RID: 703
		internal ComboBox sslModeBox;

		// Token: 0x040002C0 RID: 704
		internal ComboBox sslAllowedCurvesBox;

		// Token: 0x040002C1 RID: 705
		internal ComboBox sslAllowedSuitesBox;

		// Token: 0x040002C2 RID: 706
		internal ComboBox sslAllowedVersionsBox;

		// Token: 0x040002C3 RID: 707
		private bool _contentLoaded;
	}
}
