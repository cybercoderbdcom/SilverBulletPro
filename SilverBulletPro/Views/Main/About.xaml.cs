using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media.Animation;
using HandyControl.Controls;
using Newtonsoft.Json;
using SilverBulletPro.Core;
using SilverBulletPro.Core.Extensions;
using SilverBulletPro.Views.Dialogs;

namespace SilverBulletPro.Views.Main
{
	// Token: 0x02000179 RID: 377
	public partial class About : Page
	{
		// Token: 0x060008AB RID: 2219 RVA: 0x00025865 File Offset: 0x00023A65
		public About()
		{
			this.InitializeComponent();
		}

		// Token: 0x060008AC RID: 2220 RVA: 0x00025873 File Offset: 0x00023A73
		private void repoButton_Click(object sender, RoutedEventArgs e)
		{
		}

		// Token: 0x060008AD RID: 2221 RVA: 0x00025875 File Offset: 0x00023A75
		private void docuButton_Click(object sender, RoutedEventArgs e)
		{
		}

		// Token: 0x060008AE RID: 2222 RVA: 0x00025878 File Offset: 0x00023A78
		private void Donate_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				using (HttpClient httpClient = new HttpClient())
				{
					httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd(Constants.UserAgent);
					Donate[] donate = JsonConvert.DeserializeObject<SBUpdate>(httpClient.GetStringAsync("https://raw.githubusercontent.com/mohamm4dx/SilverBullet/master/SilverBulletUpdater/SBUpdate.json").ConfigureAwait(false).GetAwaiter().GetResult()).Donate;
					StringBuilder stringBuilder = new StringBuilder();
					for (int i = 0; i < donate.Length; i++)
					{
						stringBuilder.AppendLine(donate[i].Address);
					}
					new MainDialog(new MainDialog.InputDialog
					{
						Dialog = new DialogDonate
						{
							textBox = 
							{
								Text = stringBuilder.ToString()
							}
						},
						Title = "Donate"
					}).ShowDialog();
				}
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x060008AF RID: 2223 RVA: 0x00025964 File Offset: 0x00023B64
		private void ReportIssue_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				ProcessExtension.Start("tg://resolve?domain=mohamm4dx");
			}
			catch
			{
				Process.Start("https://t.me/SilverBulletSoft");
			}
		}

		// Token: 0x060008B0 RID: 2224 RVA: 0x0002599C File Offset: 0x00023B9C
		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			try
			{
				if (GlobalData.SBSettings.General.DisableAnimationMode)
				{
					this.trans.TransitionStoryboard = new Storyboard();
				}
				else if (!GlobalData.SBSettings.General.DisableAnimationMode)
				{
					this.trans.TransitionStoryboard = null;
				}
			}
			catch
			{
			}
		}
	}
}
