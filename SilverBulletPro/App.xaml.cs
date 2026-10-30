using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using EO.Base;
using HandyControl.Properties.Langs;
using HandyControl.Tools;
using SilverBulletPro.Core;

namespace SilverBulletPro
{
	// Token: 0x0200000B RID: 11
	public partial class App : Application
	{
		// Token: 0x06000024 RID: 36 RVA: 0x00002618 File Offset: 0x00000818
		public App()
		{
			try
			{
				Lang.Culture = new CultureInfo("en-US");
			}
			catch
			{
			}
			try
			{
				ConfigHelper.Instance.Lang = XmlLanguage.GetLanguage("en-US");
			}
			catch
			{
			}
			Tester.Run();
			AppDomain.CurrentDomain.UnhandledException += delegate(object s, UnhandledExceptionEventArgs e)
			{
				App.ReportCrash((Exception)e.ExceptionObject, true);
			};
			Application.Current.Dispatcher.UnhandledException += this.Dispatcher_UnhandledException;
			base.Dispatcher.UnhandledException += this.OnDispatcherUnhandledException;
			TaskScheduler.UnobservedTaskException += this.OnTaskException;
			AppDomain.CurrentDomain.AssemblyResolve += this.OnAssemblyResolve;
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002708 File Offset: 0x00000908
		private void Dispatcher_UnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
		{
			e.Handled = true;
			this.OnDispatcherUnhandledException(sender, e);
		}

		// Token: 0x06000026 RID: 38 RVA: 0x0000271C File Offset: 0x0000091C
		private static void ReportCrash(Exception ex, bool showAlert = true)
		{
			RWLock handle = FileLocker.GetHandle("crash.log");
			lock (handle)
			{
				File.WriteAllText("crash.log", string.Format("Unhandled exception thrown on {0}\r\n{1}", DateTime.Now, ex));
			}
			if (showAlert)
			{
				Alert.Error("An unhandled exception was thrown, the application will try to continue running. Please open the crash.log file. A few details about the exception: " + ex.Message, "Unhandled Exception", false);
			}
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002798 File Offset: 0x00000998
		private void OnTaskException(object sender, UnobservedTaskExceptionEventArgs e)
		{
			e.SetObserved();
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000027A0 File Offset: 0x000009A0
		private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
		{
			bool showAlert = !e.Exception.Message.StartsWith("Could not find a part of the path") && !e.Exception.Message.Contains("empty.png'.") && e.Exception.TargetSite.DeclaringType != typeof(Storyboard) && e.Exception.GetType() != typeof(XamlParseException) && !e.Exception.Message.Contains("name cannot be found in the name scope of 'System.Windows.Controls.ControlTemplate'");
			App.ReportCrash(e.Exception, showAlert);
			e.Handled = true;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002847 File Offset: 0x00000A47
		public Assembly OnAssemblyResolve(object sender, ResolveEventArgs args)
		{
			return null;
		}

		// Token: 0x0600002A RID: 42 RVA: 0x0000284C File Offset: 0x00000A4C
		protected override void OnExit(ExitEventArgs e)
		{
			try
			{
				Runtime.Shutdown();
			}
			catch
			{
			}
			try
			{
				GlobalData.MainWindow.NotifyIcon.Visibility = Visibility.Collapsed;
			}
			catch
			{
			}
			try
			{
				GlobalData.MainWindow.NotifyIcon.Dispose();
				GlobalData.MainWindow.NotifyIcon.CloseContextControl();
				GlobalData.MainWindow.NotifyIcon = null;
			}
			catch
			{
			}
			base.OnExit(e);
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000028D8 File Offset: 0x00000AD8
		internal static void SetLanguageDictionary(CultureInfo culture)
		{
			ResourceDictionary resourceDictionary = new ResourceDictionary();
			string name = Assembly.GetExecutingAssembly().GetName().Name;
			try
			{
				ResourceDictionary resourceDictionary2 = resourceDictionary;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(61, 2);
				defaultInterpolatedStringHandler.AppendLiteral("pack://application:,,,/");
				defaultInterpolatedStringHandler.AppendFormatted(name);
				defaultInterpolatedStringHandler.AppendLiteral(";component/Langs/StringResources.");
				defaultInterpolatedStringHandler.AppendFormatted<CultureInfo>(culture);
				defaultInterpolatedStringHandler.AppendLiteral(".xaml");
				resourceDictionary2.Source = new Uri(defaultInterpolatedStringHandler.ToStringAndClear(), UriKind.Absolute);
			}
			catch
			{
				resourceDictionary.Source = new Uri("pack://application:,,,/" + name + ";component/Langs/StringResources.en-US.xaml", UriKind.Absolute);
			}
			try
			{
				Application.Current.Resources.MergedDictionaries.Remove(Application.Current.Resources.MergedDictionaries.First((ResourceDictionary r) => r.Source.OriginalString.StartsWith("Langs/StringResources.")));
			}
			catch
			{
			}
			Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
			Window mainWindow = Application.Current.MainWindow;
			if (mainWindow != null)
			{
				mainWindow.OnApplyTemplate();
			}
			Window mainWindow2 = Application.Current.MainWindow;
			if (mainWindow2 != null)
			{
				mainWindow2.UpdateLayout();
			}
			try
			{
				ConfigHelper.Instance.Lang = XmlLanguage.GetLanguage("en-US");
			}
			catch
			{
			}
		}
	}
}
