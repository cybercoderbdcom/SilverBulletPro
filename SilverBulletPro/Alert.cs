using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Windows;
using HandyControl.Controls;
using HandyControl.Data;
using SilverBulletPro.Views.Dialogs;

namespace SilverBulletPro
{
	// Token: 0x02000014 RID: 20
	internal static class Alert
	{
		// Token: 0x060000B6 RID: 182 RVA: 0x00008605 File Offset: 0x00006805
		public static void None(string message, string title = "")
		{
			Alert.Show(AlertType.None, message, title);
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x0000860F File Offset: 0x0000680F
		public static void Info(string message, string title = "Info", bool notification = false)
		{
			if (notification)
			{
				Alert.ShowNotif(AlertType.Info, message);
				return;
			}
			Alert.Show(AlertType.Info, message, title);
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00008624 File Offset: 0x00006824
		public static void Success(string message, string title = "Success", bool notification = false)
		{
			if (notification)
			{
				Alert.ShowNotif(AlertType.Success, message);
				return;
			}
			Alert.Show(AlertType.Success, message, title);
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00008639 File Offset: 0x00006839
		public static void Warning(string message, string title = "Warning", bool notification = false)
		{
			if (notification)
			{
				Alert.ShowNotif(AlertType.Warning, message);
				return;
			}
			Alert.Show(AlertType.Warning, message, title);
		}

		// Token: 0x060000BA RID: 186 RVA: 0x0000864E File Offset: 0x0000684E
		public static void Error(string message, string title = "Error", bool notification = false)
		{
			if (notification)
			{
				Alert.ShowNotif(AlertType.Error, message);
				return;
			}
			Alert.Show(AlertType.Error, message, title);
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00008663 File Offset: 0x00006863
		public static void Fatal(string message, string title = "Fatal", bool notification = false)
		{
			if (notification)
			{
				Alert.ShowNotif(AlertType.Fatal, message);
				return;
			}
			Alert.Show(AlertType.Fatal, message, title);
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00008678 File Offset: 0x00006878
		public static MessageBoxResult Choice(string message, string title, MessageBoxButton button = MessageBoxButton.YesNo, MessageBoxImage icon = MessageBoxImage.Question)
		{
			return MessageBox.Show(message, title, button, icon, MessageBoxResult.None);
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00008684 File Offset: 0x00006884
		public static string CustomInput(string question, string title = "Custom Title", IEnumerable defaultAnswer = null)
		{
			string answer = string.Empty;
			Action<string> <>9__1;
			Application.Current.Dispatcher.Invoke(delegate()
			{
				Action<string> action;
				if ((action = <>9__1) == null)
				{
					action = (<>9__1 = delegate(string a)
					{
						answer = a;
					});
				}
				Action<string> onAnswer = action;
				new MainDialog(new MainDialog.InputDialog
				{
					Dialog = new CustomInputDialog(question, defaultAnswer, onAnswer),
					Title = title,
					ResizeMode = ResizeMode.NoResize
				}).ShowDialog();
			});
			return answer;
		}

		// Token: 0x060000BE RID: 190 RVA: 0x000086D8 File Offset: 0x000068D8
		public static void Show(AlertType type, string message, string title)
		{
			MessageBoxInfo messageBoxInfo = new MessageBoxInfo
			{
				Message = message,
				Caption = title,
				Button = MessageBoxButton.OK
			};
			switch (type)
			{
			case AlertType.None:
				messageBoxInfo.IconKey = "";
				break;
			case AlertType.Success:
				messageBoxInfo.IconKey = "SuccessGeometry";
				messageBoxInfo.IconBrushKey = "SuccessBrush";
				break;
			case AlertType.Warning:
				messageBoxInfo.IconKey = "WarningGeometry";
				messageBoxInfo.IconBrushKey = "WarningBrush";
				break;
			case AlertType.Error:
				messageBoxInfo.IconKey = "ErrorGeometry";
				messageBoxInfo.IconBrushKey = "DangerBrush";
				break;
			case AlertType.Info:
				messageBoxInfo.IconKey = "InfoGeometry";
				messageBoxInfo.IconBrushKey = "InfoBrush";
				break;
			case AlertType.Fatal:
				messageBoxInfo.IconKey = "FatalGeometry";
				messageBoxInfo.IconBrushKey = "PrimaryTextBrush";
				break;
			}
			MessageBox.Show(messageBoxInfo);
		}

		// Token: 0x060000BF RID: 191 RVA: 0x000087B0 File Offset: 0x000069B0
		public static void ShowNotif(AlertType type, string message)
		{
			switch (type)
			{
			case AlertType.Success:
				Growl.Success(message, "");
				return;
			case AlertType.Warning:
				Growl.Warning(message, "");
				return;
			case AlertType.Error:
				Growl.Error(message, "");
				return;
			case AlertType.Info:
				Growl.Info(message, "");
				return;
			case AlertType.Fatal:
				Growl.Fatal(message, "");
				return;
			default:
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(22, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Type ");
				defaultInterpolatedStringHandler.AppendFormatted<AlertType>(type);
				defaultInterpolatedStringHandler.AppendLiteral(" is not supported");
				throw new NotSupportedException(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			}
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x0000884D File Offset: 0x00006A4D
		public static void Exception(Exception ex, string title = "")
		{
			Alert.Error(ex.Message, string.IsNullOrEmpty(title) ? ex.GetType().Name : title, false);
		}
	}
}
