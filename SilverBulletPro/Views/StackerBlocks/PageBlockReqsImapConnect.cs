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
	// Token: 0x020000ED RID: 237
	public class PageBlockReqsImapConnect : Page, IComponentConnector
	{
		// Token: 0x0600063C RID: 1596 RVA: 0x0001DED4 File Offset: 0x0001C0D4
		public PageBlockReqsImapConnect(BlockImapConnect block)
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

		// Token: 0x0600063D RID: 1597 RVA: 0x0001E17C File Offset: 0x0001C37C
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

		// Token: 0x0600063E RID: 1598 RVA: 0x0001E1C4 File Offset: 0x0001C3C4
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

		// Token: 0x0600063F RID: 1599 RVA: 0x0001E20C File Offset: 0x0001C40C
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

		// Token: 0x06000640 RID: 1600 RVA: 0x0001E24C File Offset: 0x0001C44C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/imap/pageblockreqsimapconnect.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000641 RID: 1601 RVA: 0x0001E27C File Offset: 0x0001C47C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000642 RID: 1602 RVA: 0x0001E288 File Offset: 0x0001C488
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

		// Token: 0x040002FB RID: 763
		private BlockImapConnect vm;

		// Token: 0x040002FC RID: 764
		internal ComboBox sslModeBox;

		// Token: 0x040002FD RID: 765
		internal ComboBox sslAllowedCurvesBox;

		// Token: 0x040002FE RID: 766
		internal ComboBox sslAllowedSuitesBox;

		// Token: 0x040002FF RID: 767
		internal ComboBox sslAllowedVersionsBox;

		// Token: 0x04000300 RID: 768
		private bool _contentLoaded;
	}
}
