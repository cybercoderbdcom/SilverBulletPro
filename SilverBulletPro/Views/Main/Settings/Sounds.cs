using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace SilverBulletPro.Views.Main.Settings
{
	// Token: 0x0200018F RID: 399
	public class Sounds : Page, IComponentConnector
	{
		// Token: 0x06000A04 RID: 2564 RVA: 0x0002EADF File Offset: 0x0002CCDF
		public Sounds()
		{
			this.InitializeComponent();
			base.DataContext = GlobalData.SBSettings.Sounds;
		}

		// Token: 0x06000A05 RID: 2565 RVA: 0x0002EB00 File Offset: 0x0002CD00
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/main/settings/silverbullet/sounds.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000A06 RID: 2566 RVA: 0x0002EB30 File Offset: 0x0002CD30
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040004D6 RID: 1238
		private bool _contentLoaded;
	}
}
