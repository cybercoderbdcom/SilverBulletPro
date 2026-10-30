using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace SilverBulletPro.Views.Main.Tools
{
	// Token: 0x02000187 RID: 391
	public partial class BrowserTools : Page
	{
		// Token: 0x060009AF RID: 2479 RVA: 0x0002C780 File Offset: 0x0002A980
		public BrowserTools()
		{
			this.InitializeComponent();
		}

		// Token: 0x060009B0 RID: 2480 RVA: 0x0002C790 File Offset: 0x0002A990
		private void killChromedriversButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				Process.Start("cmd.exe", "/C C:\\Windows\\System32\\taskkill.exe /F /IM chromedriver.exe /T");
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x060009B1 RID: 2481 RVA: 0x0002C7CC File Offset: 0x0002A9CC
		private void killGeckodriversButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				Process.Start("cmd.exe", "/C C:\\Windows\\System32\\taskkill.exe /F /IM geckodriver.exe /T");
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x060009B2 RID: 2482 RVA: 0x0002C808 File Offset: 0x0002AA08
		private void deleteChromeCacheFoldersButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				foreach (string text in Directory.GetDirectories(Environment.ExpandEnvironmentVariables("%userprofile%") + "\\AppData\\Local\\Temp"))
				{
					if (text.Contains("scopeddir") || text.Contains("chromeurlfetcher") || text.Contains("chromeBITS"))
					{
						try
						{
							Directory.Delete(text, true);
						}
						catch
						{
						}
					}
				}
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x060009B3 RID: 2483 RVA: 0x0002C8A0 File Offset: 0x0002AAA0
		private void deleteFirefoxCacheFoldersButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				foreach (string text in Directory.GetDirectories(Environment.ExpandEnvironmentVariables("%userprofile%") + "\\AppData\\Local\\Temp"))
				{
					if (text.Contains("rust_mozprofile"))
					{
						try
						{
							Directory.Delete(text, true);
						}
						catch
						{
						}
					}
				}
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x060009B4 RID: 2484 RVA: 0x0002C91C File Offset: 0x0002AB1C
		private void killChromesButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				Process.Start("cmd.exe", "/C C:\\Windows\\System32\\taskkill.exe /F /IM chrome.exe /T");
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x060009B5 RID: 2485 RVA: 0x0002C958 File Offset: 0x0002AB58
		private void killFirefoxesButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				Process.Start("cmd.exe", "/C C:\\Windows\\System32\\taskkill.exe /F /IM firefox.exe /T");
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
		}
	}
}
