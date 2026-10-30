using System;
using System.Collections;
using System.Windows;
using SilverBulletPro.Core;

namespace SilverBulletPro
{
	// Token: 0x02000015 RID: 21
	public class Alerter : IAlerter
	{
		// Token: 0x060000C1 RID: 193 RVA: 0x00008871 File Offset: 0x00006A71
		public bool YesOrNo(string message, string title = "")
		{
			return Alert.Choice(message, title, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes;
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00008880 File Offset: 0x00006A80
		public bool OkOrCancel(string message, string title = "")
		{
			return Alert.Choice(message, title, MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK;
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x0000888F File Offset: 0x00006A8F
		public string CustomInput(string question, string title = "Custom Title", IEnumerable defaultAnswer = null)
		{
			return Alert.CustomInput(question, title, defaultAnswer);
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00008899 File Offset: 0x00006A99
		public void None(string message, string title = "")
		{
			Alert.None(message, title);
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x000088A2 File Offset: 0x00006AA2
		public void Success(string message, string title = "", bool notification = false)
		{
			if (notification)
			{
				Alert.ShowNotif(AlertType.Success, message);
				return;
			}
			Alert.Success(message, title, false);
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x000088B7 File Offset: 0x00006AB7
		public void Info(string message, string title = "", bool notification = false)
		{
			if (notification)
			{
				Alert.ShowNotif(AlertType.Info, message);
				return;
			}
			Alert.Info(message, title, false);
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x000088CC File Offset: 0x00006ACC
		public void Warning(string message, string title = "", bool notification = false)
		{
			if (notification)
			{
				Alert.ShowNotif(AlertType.Warning, message);
				return;
			}
			Alert.Warning(message, title, false);
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x000088E1 File Offset: 0x00006AE1
		public void Error(string message, string title = "", bool notification = false)
		{
			if (notification)
			{
				Alert.ShowNotif(AlertType.Error, message);
				return;
			}
			Alert.Error(message, title, false);
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x000088F6 File Offset: 0x00006AF6
		public void Fatal(string message, string title = "", bool notification = false)
		{
			if (notification)
			{
				Alert.ShowNotif(AlertType.Fatal, message);
				return;
			}
			Alert.Fatal(message, title, false);
		}
	}
}
