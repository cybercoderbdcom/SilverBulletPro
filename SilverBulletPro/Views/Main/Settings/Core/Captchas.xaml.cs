using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using SilverBulletPro.Core.Enums;

namespace SilverBulletPro.Views.Main.Settings.Core
{
	// Token: 0x02000192 RID: 402
	public partial class Captchas : Page
	{
		// Token: 0x06000A28 RID: 2600 RVA: 0x0002FAA8 File Offset: 0x0002DCA8
		public Captchas()
		{
			this.InitializeComponent();
			base.DataContext = GlobalData.Settings.CoreSettings.Captchas;
			foreach (string newItem in Enum.GetNames(typeof(CaptchaServiceType)))
			{
				this.currentServiceCombobox.Items.Add(newItem);
			}
			this.currentServiceCombobox.SelectedIndex = GlobalData.Settings.CoreSettings.Captchas.CurrentService;
		}

		// Token: 0x06000A29 RID: 2601 RVA: 0x0002FB2C File Offset: 0x0002DD2C
		private void currentServiceCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			GlobalData.Settings.CoreSettings.Captchas.CurrentService = this.currentServiceCombobox.SelectedIndex;
			Dictionary<CaptchaServiceType, int> dictionary = new Dictionary<CaptchaServiceType, int>
			{
				{
					0,
					0
				},
				{
					1,
					1
				},
				{
					2,
					2
				},
				{
					6,
					2
				},
				{
					3,
					3
				},
				{
					4,
					4
				},
				{
					5,
					5
				},
				{
					7,
					6
				},
				{
					8,
					7
				},
				{
					9,
					8
				},
				{
					10,
					9
				},
				{
					11,
					10
				},
				{
					12,
					11
				},
				{
					13,
					12
				},
				{
					14,
					13
				},
				{
					15,
					14
				}
			};
			this.captchaServiceTabControl.SelectedIndex = dictionary[GlobalData.Settings.CoreSettings.Captchas.CurrentService];
		}

		// Token: 0x06000A2A RID: 2602 RVA: 0x0002FC10 File Offset: 0x0002DE10
		private void checkBalanceButton_Click(object sender, RoutedEventArgs e)
		{
			Captchas.<checkBalanceButton_Click>d__2 <checkBalanceButton_Click>d__;
			<checkBalanceButton_Click>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<checkBalanceButton_Click>d__.<>4__this = this;
			<checkBalanceButton_Click>d__.<>1__state = -1;
			<checkBalanceButton_Click>d__.<>t__builder.Start<Captchas.<checkBalanceButton_Click>d__2>(ref <checkBalanceButton_Click>d__);
		}
	}
}
