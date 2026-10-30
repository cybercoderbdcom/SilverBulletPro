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
	// Token: 0x020000F6 RID: 246
	public class PageBlockReqsPop3Connect : Page, IComponentConnector
	{
		// Token: 0x06000664 RID: 1636 RVA: 0x0001E7C4 File Offset: 0x0001C9C4
		public PageBlockReqsPop3Connect(BlockPop3Connect block)
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

		// Token: 0x06000665 RID: 1637 RVA: 0x0001EA6C File Offset: 0x0001CC6C
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

		// Token: 0x06000666 RID: 1638 RVA: 0x0001EAB4 File Offset: 0x0001CCB4
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

		// Token: 0x06000667 RID: 1639 RVA: 0x0001EAFC File Offset: 0x0001CCFC
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

		// Token: 0x06000668 RID: 1640 RVA: 0x0001EB3C File Offset: 0x0001CD3C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/pop3/pageblockreqspop3connect.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000669 RID: 1641 RVA: 0x0001EB6C File Offset: 0x0001CD6C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600066A RID: 1642 RVA: 0x0001EB78 File Offset: 0x0001CD78
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

		// Token: 0x0400030E RID: 782
		private BlockPop3Connect vm;

		// Token: 0x0400030F RID: 783
		internal ComboBox sslModeBox;

		// Token: 0x04000310 RID: 784
		internal ComboBox sslAllowedCurvesBox;

		// Token: 0x04000311 RID: 785
		internal ComboBox sslAllowedSuitesBox;

		// Token: 0x04000312 RID: 786
		internal ComboBox sslAllowedVersionsBox;

		// Token: 0x04000313 RID: 787
		private bool _contentLoaded;
	}
}
